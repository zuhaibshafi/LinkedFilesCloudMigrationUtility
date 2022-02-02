var storageType;
var CloudConnectionData;
var CloudConnectionDataforHR;
var ACTION = { DOWNLOAD: 1, OPEN: 2, VIEW: 3, GETBLOB: 4 };
var ThirdPartySettings = { NONE: 0, AWSS3: 1, GoogleDrive: 2, Dropbox: 3, WebLink: 4, OneDrive: 5, QuickBooks: 6, Xero: 7, MYOB: 8, Yodlee: 9, Box: 10 };
var IMAGEEXTENTIONS = ['jpeg', 'jpg', 'gif', 'png', 'pdf'];
var RESTRICTEDEXTENTIONS = ['application/x-msdownload', 'application/octet-stream'];
var FileUpload = {};
var boxVersionDataFile;//, odfileUploadData;
var selFiles = [];
var outlookEventId = null;
$(document).ready(function () {


    if ($("#SkipAutoLoadingAccessToken").length === 0) {
        if ($('#ModuleID').val() === "243")
            getAccessTokenforhrForms(null, "True");
        getAccessToken();
    }

    $(document).off('click.newEventUpload', '#jsUploadFile').on('click.newEventUpload', '#jsUploadFile', function (event) {
        var continueWithUpload = true;
        var callbackAfterUploadComplete = ($(".jsAddAttachment").length > 0 && $(".jsAddAttachment").data('afterfileuploadcomplete').length > 0) ? $(".jsAddAttachment").data('afterfileuploadcomplete') : $("#add-attachment").data('afterfileuploadcomplete');
        someRequestsUnderProcess = false;
        //var current = $(this).closest('.dialog-box').find('.tab-header .active-tab').data('target');
        var current = $(this).closest('#add-attachment-modal').find('.jsTabHeader .active').data('target');
        selFiles = [];
        var createFileSharableLink = false;
        if ($('#CreateFileSharableLink ').length > 0 && $(this).closest("#add-attachment-modal").data("shareablelink") == true) {
            createFileSharableLink = true;
        }
        if ((current === "from-computer") && (typeof (draggedFiles) !== 'undefined' && draggedFiles.length > 0)) {
            selFiles = draggedFiles;
        }
        else if (current === "hyperlink") {
            var cloudfileurl = $("#cloudfileurl").val();
            var description = $("#cloudfiledescription").val();

            if (cloudfileurl != "" && (cloudfileurl.toUpperCase().indexOf('HTTP') === 0 || cloudfileurl.toUpperCase().indexOf('WWW') === 0)) {
                if (cloudfileurl.toUpperCase().indexOf('WWW') === 0) cloudfileurl = "http://" + cloudfileurl;//Anchor tag's href values need http:// preprended to the URL
                if (entityid === undefined && isAttachmentOnNewRecord) {
                    if ($.isFunction(window[myCallback]))
                        window[myCallback](cloudfileurl, getFileDescription(current), ThirdPartySettings.WebLink, true);
                } else {
                    //saveLinkedFiles(cloudfileurl, getFileDescription(current), "", 4, "");

                    var linkedFile = { FileURL: cloudfileurl, StorageType: ThirdPartySettings.WebLink, Description: getFileDescription(current), LinkedRecord_ID: entityid };
                    postLinkedFiles([linkedFile], callbackAfterUploadComplete);
                    closeDialog('#add-attachment-modal');

                }
            } else {
                showAlertDialog("Invalid URL. Should start with http or www.");
            }
            return true;
        }
        else if ((current === "dropbox") && (typeof (dbxSelectedFiles) !== 'undefined' && dbxSelectedFiles.length > 0)) {
            $(dbxSelectedFiles).each(function (index, file) {
                //var dbfile = new File([file.bytes], file.name, { type: file.bytes.type, lastModified: ShortDate(new Date()) });  // Edge Browser doesn't support File Object                
                var fl = new Blob([file.bytes], { type: file.bytes.type });
                fl.name = file.name;
                selFiles.push(fl);
            });
        }
        else if ((current === "google-drive")) {
            if (typeof (googleSelectedFiles) !== 'undefined' && googleSelectedFiles.length > 0) {
                $.each(googleSelectedFiles, function (index, file) {
                    //var fl = new File([file.bytes], file.name, { type: file.bytes.type, lastModified: ShortDate(new Date()) });  // Edge Browser doesn't support File Object
                    var fl = new Blob([file.bytes], { type: file.bytes.type });
                    fl.name = file.name;
                    selFiles.push(fl);
                });
            }

            var webLinks = $("#jsFilesAddedGD").data("weblinks");
            if (typeof webLinks !== typeof undefined && webLinks != null) {
                for (var i = 0; i < webLinks.length; i++) {
                    var filelink = webLinks[i];
                    var actionlink = "<br/><br/><span>Attached link: </span><a href='" + filelink.link + "'>" + filelink.name + "</a><br/><br/>";
                    $("#jsBody").val($("#jsBody").val() + actionlink).siblings(".htmlEditor").append(actionlink);
                }
                $("#jsFilesAddedGD").data("weblinks", null);
            }
        }

        else if ((current === "box") && (typeof (boxSelectedFiles) !== 'undefined' && boxSelectedFiles.length > 0)) {
            $.each(boxSelectedFiles, function (index, file) {
                //var fl = new File([file.bytes], file.name, { type: file.bytes.type, lastModified: ShortDate(new Date()) }); // Edge Browser doesn't support File Object
                var fl = new Blob([file.bytes], { type: file.bytes.type });
                fl.name = file.name;
                selFiles.push(fl);

            });
        }

        else if ((current === "one-drive") && (typeof (oneDriveSelectedFiles) !== 'undefined' && oneDriveSelectedFiles.length > 0)) {
            $.each(oneDriveSelectedFiles, function (index, file) {
                //var fl = new File([file.bytes], file.name, { type: file.bytes.type, lastModified: ShortDate(new Date()) }); // Edge Browser doesn't support File Object
                var fl = new Blob([file.bytes], { type: file.bytes.type });
                fl.name = file.name;
                selFiles.push(fl);
            });
        }

        else if (current === "resource-library") {
            var dlgBox = $(this).closest(".dialog-box");
            continueWithUpload = false;
            var selectedRsItems = dlgBox.find(".jsRowSelectedCheckbox:checked").closest('tr');
            var selectedRsIds = [];
            selectedRsItems.each(function () {
                selectedRsIds.push($(this).data("id"))
            });

            if (selectedRsIds.length > 0) {
                if (typeof dlgBox.data('nonassignmenttype') != typeof undefined && dlgBox.data('nonassignmenttype') == true) {
                    getResourceLibraryFiles(selectedRsIds).then(function (rsFiles) {
                        UploadFiles(rsFiles, current, callbackAfterUploadComplete, createFileSharableLink);
                    });
                } else if (typeof dlgBox.data('imagenonassignment') != typeof undefined && dlgBox.data('imagenonassignment') == true) {
                    GetLinkedFileObjects(selectedRsIds, callbackAfterUploadComplete);
                }
                else {
                    if (typeof entityid != typeof undefined) {
                        AssignResources(selectedRsIds, entityid, callbackAfterUploadComplete);
                    }
                    else {
                        if ($.isFunction(window[myCallback])) {
                            window[myCallback](selectedRsIds, $("#jsDroppable"), "", "", true);
                            closeDialog('#add-attachment-modal');
                        }
                    }
                }
            } else if ($(".jsCurrentModule").length > 0 && $(".jsCurrentModule").val() == "359") {
                CopyResourceStructure(dlgBox.find(".jsSelectedRsGroup").data("id"), entityid, "refreshResources")
            } else {
                showAlertDialog("Please select a resource to add.");
            }


            //getResourceLibraryFiles(selectedRsIds).then(function (rsFiles) {
            //    UploadFiles(rsFiles, current, callbackAfterUploadComplete);
            //});
        }

        //showNonModalWaiting("Uploading files", 500);        
        if (continueWithUpload) {
            UploadFiles(selFiles, current, callbackAfterUploadComplete, createFileSharableLink);
        }

    });

    $(document).off('click.newEventDownload', '.jsDownloadFile').on('click.newEventDownload', '.jsDownloadFile', function (e) {

        if (CloudConnectionData == null) {
            WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }
        showNonModalWaiting("", 500);
        var tr = $(".jsSelectedDropdown").closest('.js-linked-file-item');
        var linkedFile = getLinkedFileAttributes(tr);

        if (linkedFile.OutlookAttachmentId != null && linkedFile.OutlookAttachmentId != undefined && linkedFile.OutlookAttachmentId != '') {
            closeNonModalWaiting();
            urltoFile('data:' + linkedFile.MimeType + ';base64,' + linkedFile.OutlookFileData, linkedFile.FileName, linkedFile.MimeType).then(function (data) {
                downloadBlob(data, linkedFile.FileName, linkedFile.mimeType);
            });
            return;
        }

        if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == ThirdPartySettings.AWSS3) {
            getFileFromAWSS3(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == ThirdPartySettings.GoogleDrive) {
            getFileFromGoogleDrive(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == ThirdPartySettings.Dropbox) {
            getFileFromDropbox(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == ThirdPartySettings.Box) {
            getFileFromBox(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == ThirdPartySettings.OneDrive) {
            getFileFromOneDrive(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "WebLink" || linkedFile.StorageType == ThirdPartySettings.WebLink) {
            window.open(linkedFile.FileURL);
            closeWaiting();
        }
    });

    $(document).off('click.newEventOpenAttachment', '.jscloudOpenAttachment').on('click.newEventOpenAttachment', '.jscloudOpenAttachment', function (e) {
        if (CloudConnectionData == null) {
            WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }
        showNonModalWaiting("", 500);
        var tr = $(this).closest('.js-linked-file-item');
        var linkedFile = getLinkedFileAttributes(tr);
        if (linkedFile.OutlookAttachmentId != null && linkedFile.OutlookAttachmentId != undefined && linkedFile.OutlookAttachmentId != '') {
            urltoFile('data:' + linkedFile.MimeType + ';base64,' + linkedFile.OutlookFileData, linkedFile.FileName, linkedFile.MimeType).then(function (data) {

                openBlob(data, linkedFile.FileName, linkedFile.MimeType)
            });
            return;
        }


        if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == ThirdPartySettings.AWSS3) {
            getFileFromAWSS3(linkedFile, ACTION.OPEN);
        }
        else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == ThirdPartySettings.GoogleDrive) {
            getFileFromGoogleDrive(linkedFile, ACTION.OPEN);
        }
        else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == ThirdPartySettings.Dropbox) {
            getFileFromDropbox(linkedFile, ACTION.OPEN);
        }
        else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == ThirdPartySettings.Box) {
            getFileFromBox(linkedFile, ACTION.OPEN);
        }
        else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == ThirdPartySettings.OneDrive) {
            getFileFromOneDrive(linkedFile, ACTION.OPEN);
        }
        else if (linkedFile.StorageType == "WebLink" || linkedFile.StorageType == ThirdPartySettings.WebLink) {
            window.open(linkedFile.FileURL);
            closeWaiting();
        }

    });
    //Batch Dowanload Documents
    $(document).off('click.newEventBatchDownload', '.jsBatchDownload').on('click.newEventBatchDownload', '.jsBatchDownload', function (e) {
        if (CloudConnectionData == null) {
            WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }
        showNonModalWaiting("Downloading files", 500);
        let targetElement = $(this);
        let targetTable = $('div[name=' + $(targetElement).data("targettable") + ']');
        if ($("div.tr.selected", targetTable).length == 0) {
            showAlertDialog(RESOURCE_MSG.getMessage("NO_RECORD_SELECTED"));
            return false;
        }
        var selectedIds = new Array();
        GetSelectedIDs(targetTable).then(function (response) {
            if (response != null) {
                selectedIds = response;
            

        // var outlookCalId = localStorage.getItem('outlookCalId');
        var outlookEventid = $('#OutlookEventId').val();
        if (outlookEventid != null && outlookEventid != undefined && outlookEventid != '') {
            DownloadOutlookFiles($(this));
            closeNonModalWaiting();
            return;
        }
        $.each($("div.tr.selected", targetTable), function (index, id) {
            var linkedFile = getLinkedFileAttributes($(this));
            if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == ThirdPartySettings.AWSS3) {
                getFileFromAWSS3(linkedFile, ACTION.DOWNLOAD, null, null, index + 1);
            }
            else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == ThirdPartySettings.GoogleDrive) {
                getFileFromGoogleDrive(linkedFile, ACTION.DOWNLOAD);
            }
            else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == ThirdPartySettings.Dropbox) {
                getFileFromDropbox(linkedFile, ACTION.DOWNLOAD);
            }
            else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == ThirdPartySettings.Box) {
                getFileFromBox(linkedFile, ACTION.DOWNLOAD);
            }
            else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == ThirdPartySettings.OneDrive) {
                getFileFromOneDrive(linkedFile, ACTION.DOWNLOAD);
            }
            else if (linkedFile.StorageType == "WebLink")
                closeNonModalWaiting();
        });
            }
        });
        $('#documentlistTable input[type=checkbox]').attr("checked", false);
        $('#documentlistTable input[type=checkbox]').closest('tr').removeClass("selected-row")

    });
    $(document).off('click.newEventOpenAttachment', '.jsDetailViewOpenAttachment').on('click.newEventOpenAttachment', '.jsDetailViewOpenAttachment', function (e) {
        showNonModalWaiting("", 500);
        var dataSource = $(this).data("source");
        var currentView = $(this).closest('#documentsList');
        if (currentView.length <= 0) {
            currentView = $(this).children(".documentsList");

        }
        var isSystem = "False";
        if (dataSource === "HRForms") {
            $(this).addClass("active-tab").siblings().removeClass("active-tab");
            $(this).addClass("selected_item").siblings().removeClass("selected_item");
            if (currentView.find('[id$=IsSystem]').val() == "True") {
                isSystem = "True";
            }
        }
        if (CloudConnectionData == null) {
            if ($('#ModuleID').val() === "243" || CloudConnectionDataforHR == null) {


                // WarningNotification("Please wait ... getting cloud storage information.", "hrForms");
                showAlertDialog("Token expired! Please reload the page");
                return false;
            }
            else
                WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }
        var storageTypeName = currentView.find('[id$=documentStorageType]').val();
        var fileName = currentView.find('[id$=LinkedFileName]').val();
        var cloundStoage_id = currentView.find('[id$=documentCloudStorage_ID]').val();
        var fileURL = currentView.find('[id$=documentFileURL]').val();

        /*var fName = currentView.find('[id$=LinkedFileName]').val();
        var i = fName.lastIndexOf(".");
        var fileType = fName.substring(i + 1);*/
        var fileType = currentView.find('[id$=LinkedFileMIMETypes]').val();//currentView.find('#detailFileMimeType').val();

        var outlookAttachmentId = currentView.find("[id*=documentOutlookAttachmentId]").val();
        var outlookFileData = currentView.find("[id*=documentOutlookFileData]").val();

        var linkedFile = { FileURL: fileURL, FileName: fileName, CloudStorage_ID: cloundStoage_id, StorageType: storageTypeName, MimeType: fileType, OutlookAttachmentId: outlookAttachmentId, OutlookFileData: outlookFileData };

        if (linkedFile.OutlookAttachmentId != null && linkedFile.OutlookAttachmentId != undefined && linkedFile.OutlookAttachmentId != '') {
            urltoFile('data:' + linkedFile.MimeType + ';base64,' + linkedFile.OutlookFileData, linkedFile.FileName, linkedFile.MimeType).then(function (data) {

                openBlob(data, linkedFile.FileName, linkedFile.MimeType)
            });
            return;
        }

        if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == "1") {

            if (dataSource != undefined) {
                getFileFromAWSS3(linkedFile, ACTION.VIEW, dataSource, isSystem);
            }
            else {
                getFileFromAWSS3(linkedFile, ACTION.OPEN);

            }
        }
        else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == "2") {
            if (dataSource != undefined) {
                getFileFromGoogleDrive(linkedFile, ACTION.VIEW, dataSource);
            } else {

                getFileFromGoogleDrive(linkedFile, ACTION.OPEN);
            }

        }
        else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == "3") {
            if (dataSource != undefined) {

                getFileFromDropbox(linkedFile, ACTION.VIEW, dataSource);
            } else {

                getFileFromDropbox(linkedFile, ACTION.OPEN);
            }


        }
        else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == "10") {
            if (dataSource != undefined) {
                getFileFromBox(linkedFile, ACTION.VIEW, dataSource);
            } else {

                getFileFromBox(linkedFile, ACTION.OPEN);
            }

        }
        else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == "5") {


            if (dataSource != undefined) {
                getFileFromOneDrive(linkedFile, ACTION.VIEW, dataSource);
            }
            else {
                getFileFromOneDrive(linkedFile, ACTION.OPEN);


            }
        }
        else if (linkedFile.StorageType == "WebLink" || linkedFile.StorageType == ThirdPartySettings.WebLink) {
            window.open(linkedFile.FileURL);
            closeWaiting();
        }


        if (dataSource === "HRForms") {
            //LoadForms($('#ddlType').val());
        }


    });

    $(document).off('click.newEventOpenAttachment', '.jsDocumentViewer').on('click.newEventOpenAttachment', '.jsDocumentViewer', function (e) {
        if (CloudConnectionData == null) {
            WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }
        showNonModalWaiting("", 500);
        var currentRow = $(this).closest('.js-linked-file-item');
        currentRow.addClass('js-current-doc-view-row');

        setNofNFileViewer(currentRow);

        var linkedFile = getLinkedFileAttributes(currentRow);
        viewFileInDialog(linkedFile);
    });

    $(document).off('click.newNexEventt', '.jsNextLinkedFileRecord').on('click.newNexEventt', '.jsNextLinkedFileRecord', function () {

        var currentRow = $('.js-current-doc-view-row');

        var viewAbleFiles = getViewAbleFiles(currentRow);

        var nextTrIndex = viewAbleFiles.index(currentRow) + 1;
        if (nextTrIndex >= viewAbleFiles.length) return;


        var nextTr = $(viewAbleFiles[nextTrIndex]);
        if (nextTr.length == 0) return;

        showNonModalWaiting("", 500);
        currentRow.removeClass('js-current-doc-view-row');
        nextTr.addClass('js-current-doc-view-row');

        setNofNFileViewer(nextTr);

        var linkedFile = getLinkedFileAttributes(nextTr);
        viewFileInDialog(linkedFile);
    });

    $(document).off('click.newNexEventt', '.jsPreviousLinkedFileRecord').on('click.newNexEventt', '.jsPreviousLinkedFileRecord', function () {

        var currentRow = $('.js-current-doc-view-row');

        var viewAbleFiles = getViewAbleFiles(currentRow);

        var prevTrIndex = viewAbleFiles.index(currentRow) - 1;
        if (prevTrIndex <= -1) return;

        showNonModalWaiting("", 500);

        prevTr = $(viewAbleFiles[prevTrIndex]);

        currentRow.removeClass('js-current-doc-view-row');
        prevTr.addClass('js-current-doc-view-row');
        setNofNFileViewer(prevTr);

        var linkedFile = getLinkedFileAttributes($(prevTr));
        viewFileInDialog(linkedFile);
    });

    $(document).off('click.newEventOpenAttachment', '.jsDownloadBtnOnView').on('click.newEventOpenAttachment', '.jsDownloadBtnOnView', function (e) {
        if (CloudConnectionData == null) {
            WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }
        showNonModalWaiting("", 500);
        var linkedFile = $('.jsDownloadBtnOnView').attr('file') == "" ? "" : JSON.parse($('.jsDownloadBtnOnView').attr('file'));
        if (linkedFile.OutlookAttachmentId != null && linkedFile.OutlookAttachmentId != undefined && linkedFile.OutlookAttachmentId != '') {
            closeNonModalWaiting();
            urltoFile('data:' + linkedFile.MimeType + ';base64,' + linkedFile.OutlookFileData, linkedFile.FileName, linkedFile.MimeType).then(function (data) {
                downloadBlob(data, linkedFile.FileName, linkedFile.mimeType);
            });
            return;
        }



        if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == ThirdPartySettings.AWSS3) {
            getFileFromAWSS3(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == ThirdPartySettings.GoogleDrive) {
            getFileFromGoogleDrive(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == ThirdPartySettings.Dropbox) {
            getFileFromDropbox(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == ThirdPartySettings.Box) {
            getFileFromBox(linkedFile, ACTION.DOWNLOAD);
        }
        else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == ThirdPartySettings.OneDrive) {
            getFileFromOneDrive(linkedFile, ACTION.DOWNLOAD);
        }
        else {
            closeWaiting();
        }
    });

    //if ($('.avatar').length >0) {
    //    GetLinkedFile();
    //}

});


function GetLinkedFile(fileName, storageType) {

    return new Promise(function (resolve, reject) {


        if (CloudConnectionData == null) {
            WarningNotification("Please wait ... getting cloud storage information.");
            setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            return;
        }

        var dataSource = "avatar";

        var objParameter = new BQEParameter();

        objParameter.FilterList = [];


        objParameter.FilterList.push({ Field: "Entity_ID", Operator: "EqualTo", StartValue: $(".main_id").val() });
        objParameter.FilterList.push({ Field: "IsSystem", Operator: "EqualTo", StartValue: "true" });

        if (fileName != undefined) {
            objParameter.FilterList = [];
            objParameter.FilterList.push({ Field: "FileName", Operator: "EqualTo", StartValue: fileName, Conjunction: "AND" });

            if (storageType != undefined) objParameter.FilterList.push({ Field: "StorageType", Operator: "EqualTo", StartValue: storageType, Conjunction: "AND" });
        }


        var _url = GetBaseURL() + "Json/PostObjectGlobalization?url=api/LinkedFiles/LinkedFiles";

        ajaxCall({
            url: _url,
            data: JSON.stringify(objParameter),
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            dataType: 'json'



        }).done(function (data) {

            if (data.IsSuccessStatusCode) {


                if (storageType != undefined) {

                    if (data.Response != null) {
                        resolve(data.Response);
                    }
                    else resolve(null)

                    return false;
                }

                var linkedFile = new Object();

                linkedFile.FileName = data.Response[0].FileName;
                linkedFile.FileURL = data.Response[0].FileURL;
                linkedFile.CloudStorage_ID = data.Response[0].CloudStorage_ID;
                linkedFile.StorageType = data.Response[0].StorageType;


                if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == "1") {

                    if (dataSource != undefined) {
                        getFileFromAWSS3(linkedFile, ACTION.VIEW, dataSource);
                    }
                    else {
                        getFileFromAWSS3(linkedFile, ACTION.OPEN);

                    }
                }
                else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == "2") {
                    if (dataSource != undefined) {
                        getFileFromGoogleDrive(linkedFile, ACTION.VIEW, dataSource);
                    } else {

                        getFileFromGoogleDrive(linkedFile, ACTION.OPEN);
                    }

                }
                else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == "3") {
                    if (dataSource != undefined) {

                        getFileFromDropbox(linkedFile, ACTION.VIEW, dataSource);
                    } else {

                        getFileFromDropbox(linkedFile, ACTION.OPEN);
                    }


                }
                else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == "10") {
                    if (dataSource != undefined) {
                        getFileFromBox(linkedFile, ACTION.VIEW, dataSource);
                    } else {

                        getFileFromBox(linkedFile, ACTION.OPEN);
                    }

                }
                else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == "5") {
                    getFileFromOneDrive(linkedFile, ACTION.OPEN);
                }
                else if (linkedFile.StorageType == "WebLink" || linkedFile.StorageType == "4") {
                    window.open(linkedFile.FileURL);
                    closeWaiting();
                }
            }

        });


    });

}

function viewBlob(data, fileName, mimeType, dataSource) {
    var blob, url;
    var isEdge = false;

    blob = new Blob([data], {
        type: mimeType
    });


    var fileExt = blob.type.split('/').pop();
    if (fileExt == "jpeg" || fileExt == "jpg" || fileExt == "gif" || fileExt == "png" || fileExt == "pdf") {
        if (fileExt == "pdf")
            $('.attachment-image div').text("").remove('.fileViewer').append("<iframe class='fileViewer' src='' style='width: 100%; height: 100%; border: none'></iframe>");
        else
            $('.attachment-image div').text("").remove('.fileViewer').append("<img class='fileViewer' src='' />");
    } else {

        if (window.navigator && window.navigator.msSaveOrOpenBlob) {
            isEdge = true;

            $('.jsSetCustom').text("This browser doesn't support view.").addClass('inherit-font-size');
            $('.jsOptionfileDownload').attr('target', "");

        } else {
            $('.attachment-image div').text("No preview available.").addClass('inherit-font-size');
        }
    }
    if (!isEdge) {
        url = window.URL.createObjectURL(blob);
    }


    if (dataSource === undefined) {

        $(".fileViewer").attr('src', url);
        showDialog('#show-attachment-modal');
    }

    else if (dataSource === "avatar") {

        $('.jsavatar').attr('src', url);
    } else {
        if (dataSource != undefined &&
            dataSource === "HRForms")
            if (!isEdge) {// INTERNET EXPLORER ISSUE AS IT DOENST SUPPORT window.URL.createObjectURL METHOD 
                $('.fileImgObj').css('display', 'none');
                $('.fileObj').css('display', 'block');
                if (fileExt.search("jpeg") < 0 && fileExt.search("jpg") < 0 && fileExt.search("gif") < 0 && fileExt.search("png") < 0 && fileExt.search("pdf") < 0) {
                    $("#jsfileDownload").attr("href", url);
                    $("#jsfileDownload,.jsfileDownload").attr("download", fileName);
                    $('.jsobjectDiv').addClass('hidden');
                    $('.jsNoPreviewDiv').removeClass('hidden');
                } else {
                    $('.jsNoPreviewDiv').addClass('hidden');
                    $('.jsobjectDiv').removeClass('hidden');
                    $('.fileObj').attr('data', url);
                    $("#jsfileDownload").attr("href", url);
                    $("#jsfileDownload,.jsfileDownload").attr("download", fileName);
                }
                $("#jsOptionfileDownload").attr("href", url).attr("target", "_blank");

            } else {

                $(document).off('click', '#jsfileDownload').on('click', '#jsfileDownload', function (event) {
                    window.navigator.msSaveOrOpenBlob(blob, fileName);
                });
                $(document).off('click', '#jsOptionfileDownload').on('click', '#jsOptionfileDownload', function (event) {
                    window.navigator.msSaveOrOpenBlob(blob, fileName);
                });

            }

    }

}

function openBlob(data, fileName, mimeType) {
    //closeNonModalWaiting();

    var blob, url;
    blob = new Blob([data], {
        type: mimeType
    });
    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(blob, fileName);
    }
    else {
        /*url = window.URL.createObjectURL(blob);
        window.open(url, "_blank");*/

        var link = document.createElement('a');
        link.href = window.URL.createObjectURL(blob);
        link.setAttribute('download', fileName);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}

function downloadBlob(data, fileName, mimeType) {
    var blob, url;
    blob = new Blob([data], {
        type: mimeType
    });

    if (window.navigator && window.navigator.msSaveOrOpenBlob && window.navigator.userAgent.indexOf('Trident/') > -1) {
        // GAL-40843- Fixed, added window.navigator.userAgent.indexOf('Trident/') > -1) for IE browser.
        window.navigator.msSaveOrOpenBlob(blob);
    }
    else {
        url = window.URL.createObjectURL(blob);

        downloadURL(url, fileName, mimeType);
        setTimeout(function () {
            return window.URL.revokeObjectURL(url);
        }, 1000);
    }

};

function getBlob(data, fileName, mimeType) {
    var blob;
    blob = new Blob([data], {
        type: mimeType,
        name: fileName
    });
    return blob;
};

function downloadURL(data, fileName) {
    var a = document.createElement('a');
    a.href = data;
    a.download = fileName;
    $('body').append(a);
    a.style = 'display: none';
    a.click();
    a.remove();
};

function getAccessToken(callback, fromUpload) {
    var localStorageData = getObjectFromLocalStorage("CloudConnectionData");
    if (localStorageData != null) {
        ProcessCloudConnectionData(localStorageData, callback);
    } else {
        var CloudParameter = new Object();
        CloudParameter.SinglePane = new BQEParameter();
        CloudParameter.SinglePane.ModuleID = typeof fromUpload != typeof undefined ? $('#ModuleID').val() : "9";
        var _url = GetBaseURL() + "Json/PostObjectGlobalization?url=api/LinkedFiles/GetCloudConnection";
        ajaxCall({
            url: _url,
            data: JSON.stringify(CloudParameter.SinglePane),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            showWaiting: false,
            type: "POST",
            success: function (response) {
                if (response != null && response.Response) {
                    if (response.Response.DefaultStorage != null) {
                        response.Response.DefaultStorageType = response.Response.DefaultStorage.Type;
                        //delete response["DefaultStorage"];
                    }
                    /*if (response.Response.GoogleData != null && response.Response.GoogleData.authResult != null && response.GoogleData != null && response.Response.GoogleData.authResult.Credential != null && response.Response.GoogleData.authResult.Credential.Token != null) {
                        response.Response.GoogleData.access_token = response.Response.GoogleData.authResult.Credential.Token.access_token;
                        response.Response.GoogleData.refresh_token = response.Response.GoogleData.authResult.Credential.Token.refresh_token;
                        //delete response["GoogleData"]["authResult"];
                    }*/
                    if (response.Response.GoogleData != null && response.Response.GoogleData.TokenInfo != null) {
                        response.Response.GoogleData.access_token = response.Response.GoogleData.TokenInfo.access_token;
                        response.Response.GoogleData.refresh_token = response.Response.GoogleData.TokenInfo.refresh_token;
                        //delete response["GoogleData"]["authResult"];
                    }
                    setObjectInLocalStorage("CloudConnectionData", response.Response);
                    ProcessCloudConnectionData(response.Response, callback);
                }
                else {
                    WarningNotification("Couldn't fetch cloud storage information. " + response.Error.Message);
                }
            }
        });
    }
}
function getAccessTokenforhrForms(callback, fromUpload) {
    var localStorageData = getObjectFromLocalStorage("CloudConnectionDatafromhr");
    if (localStorageData != null) {
        ProcessCloudConnectionDataforHR(localStorageData, callback);
    } else {
        GENERALPARAMETERS = new Object();
        GENERALPARAMETERS.SinglePane = new BQEParameter();
        GENERALPARAMETERS.SinglePane.ModuleID = typeof fromUpload != typeof undefined ? $('#ModuleID').val() : "9";
        var _url = GetBaseURL() + "Json/PostObjectGlobalization?url=api/LinkedFiles/GetCloudConnection";
        ajaxCall({
            url: _url,
            data: JSON.stringify(GENERALPARAMETERS.SinglePane),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            showWaiting: false,
            type: "POST",
            success: function (response) {
                if (response != null && response.Response) {
                    if (response.Response.DefaultStorage != null) {
                        response.Response.DefaultStorageType = response.Response.DefaultStorage.Type;
                        //delete response["DefaultStorage"];
                    }
                    if (response.Response.GoogleData != null && response.Response.GoogleData.TokenInfo != null) {
                        response.Response.GoogleData.access_token = response.Response.GoogleData.TokenInfo.access_token;
                        response.Response.GoogleData.refresh_token = response.Response.GoogleData.TokenInfo.refresh_token;
                        //delete response["GoogleData"]["authResult"];
                    }
                    setObjectInLocalStorage("CloudConnectionDataforHR", response.Response);
                    ProcessCloudConnectionDataforHR(response.Response, callback);
                }
            }
        });
    }
}

function ProcessCloudConnectionData(data, callback) {
    CloudConnectionData = data;
    storageType = CloudConnectionData.DefaultStorageType;//CloudConnectionData.DefaultStorage.Type;
    checkStorage();
    amazonStorageUsed = CloudConnectionData != null && CloudConnectionData.AmazonData != null ? CloudConnectionData.AmazonData.StorageUsed || 0 : 0;
    if (typeof callback === "function")
        callback();
}
function ProcessCloudConnectionDataforHR(data, callback) {
    CloudConnectionDataforHR = data;
    storageType = CloudConnectionDataforHR.DefaultStorageType;//CloudConnectionData.DefaultStorage.Type;
    checkStorage();
    amazonStorageUsed = CloudConnectionDataforHR != null && CloudConnectionDataforHR.AmazonData != null ? CloudConnectionDataforHR.AmazonData.StorageUsed || 0 : 0;
    if (typeof callback === "function")
        callback();
}

var amazonStorageUsed = 0;
var someRequestsUnderProcess = false;

function generateFileSignedURL(linkedFile) {
    return new Promise(function (resolve, reject) {
        /*var fileKey = CloudConnectionData.AmazonData.CompanyFolder + "/" + linkedFile.FileName;
        var awsBucket = CloudConnectionData.AmazonData.AWSBucketName;
        var params = {
            Key: fileKey,
            Bucket: awsBucket,
            ContentType: linkedFile.FileMIMEType
        };
        AWS.config.accessKeyId = CloudConnectionData.AmazonData.AccessKeyId;
        AWS.config.secretAccessKey = CloudConnectionData.AmazonData.SecretAccessKey;
        //var s3obj = new AWS.S3();
        
        var s3obj = new AWS.S3({
            params: params
        });
        s3obj.getSignedUrl("putObject", params, function (err, link) {
            if (err == null) {
                resolve(link);
            }
        });
        return false;*/
        var _url = GetBaseURL() + "Json/PostObjectGlobalization?url=api/LinkedFiles/GenerateSignedURL";
        ajaxCall({
            url: _url,
            data: JSON.stringify(linkedFile),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            type: "POST",
            success: function (response) {
                if (response != null) {
                    resolve(response.Response);
                }
            }
        });
    });
}

function uploadWithSignedRequest(s3presignedUrl, file, createFileSharableLink) {
    return new Promise(function (resolve, reject) {
        var xhr = new XMLHttpRequest()
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    resolve(true);
                } else {
                    var errorMessage = 'Unable to upload file';
                    reject(errorMessage);
                }
            }
        }
        xhr.open('PUT', s3presignedUrl, true)
        if (createFileSharableLink) xhr.setRequestHeader('x-amz-acl', 'public-read');
        xhr.setRequestHeader('Content-Type', file.type)
        xhr.send(file);
        return false;
        ajaxCall({
            url: s3presignedUrl,
            type: "PUT",
            data: file,
            dataType: "text",
            cache: false,
            contentType: file.type,
            /*headers: {
                'x-amz-acl': 'public-read'                
            }, */
            beforeSend: function (xhr) { xhr.setRequestHeader('acl', 'public-read'); },
            //Expires: 300,
            //acl: 'public-read',
            //'x-amz-acl': 'public-read',
            processData: false,
            success: function (err, response, request) {
                //alert(request.getResponseHeader('etag'));//getAllResponseHeaders()
                if (err) {
                    var errorMessage = err.message || 'Unable to upload file';
                    reject(Error(errorMessage));
                }
                else {
                    resolve(true);
                }
            }
        });
    });
}

function encode(data) {
    var str = data.reduce(function (a, b) { return a + String.fromCharCode(b) }, '');
    return btoa(str).replace(/.{76}(?=.)/g, '$&\n');
}
function b64EncodeUnicode(str) {
    return btoa(encodeURIComponent(str).replace(/%([0-9A-F]{2})/g, function (match, p1) {
        return String.fromCharCode('0x' + p1);
    }));
}
function downloadWithSignedRequest(s3presignedUrl, fileMIMEType) {
    return new Promise(function (resolve, reject) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', s3presignedUrl, true);
        xhr.responseType = 'arraybuffer';
        xhr.onload = function (e) {
            if (this.status == 200) {
                var blob = this.response;
                resolve(blob);
                /*var str = btoa(String.fromCharCode.apply(null, new Uint8Array(blob)));
                //var b64Str = 'data:image/jpeg;base64,' + str;
                var b64Str = "data:" + fileMIMEType + ";base64," + str;
                //$('#imgtst')[0].src = b64Str;
                resolve(b64Str);*/
            }
        };
        xhr.send();
        return false;
        /*ajaxCall({
            url: s3presignedUrl,
            type: "GET",
            responseType: 'arraybuffer',
            success: function (data, response, request) {
                if (response == "success") {
                    
                    var encUni = b64EncodeUnicode(data);
                    //var resultDataString = btoa(unescape(encodeURIComponent(data))).replace(/.{76}(?=.)/g, '$&\n');
                    //var resultDataString = btoa(data).replace(/.{76}(?=.)/g, '$&\n');
                    var resultDataString = btoa(data.replace(/[\u00A0-\u2666]/g, function (c) {
                        return '&#' + c.charCodeAt(0) + ';';
                    }));

                    var b64Str = "data:" + fileMIMEType + ";base64," + encode(data);
                    var b64Str = 'data:image/jpeg;base64,' + resultDataString;

                    //var url = b64Str.replace(/^data:image\/[^;]+/, 'data:application/octet-stream');
                    //window.open(url);
                    //document.querySelector('img').src = b64Str;
                    $('#imgtst')[0].src = b64Str;
                    //downloadURL(b64Str, "a.jpg", fileMIMEType);

                    //resolve(b64Str);
                }
                else {
                    var errorMessage = err.message || 'Unable to download file';
                    reject(Error(errorMessage));
                }
            }
        });*/
    });
}

function startupload(file, current, createFileSharableLink) {
    return new Promise(function (resolve, reject) {

        //Commented this file validation code
        RESTRICTEDEXTENTIONS.forEach(function (item, index) {
            if (typeof file.type != typeof undefined && file.type === item) {
                reject("File type not allowed");
                return false;
            }
        });

        var fileNameUploaded = file.name;
        if (fileNameUploaded.indexOf('%') != -1) {
            fileNameUploaded = clearSpecialSymbolsInFileName(fileNameUploaded);
        }

        if (storageType == ThirdPartySettings.AWSS3) {
            if (checkStorage() == false) {
                if (!someRequestsUnderProcess) {
                    closeWaiting();
                }
                return null;
            }
            amazonStorageUsed += parseFloat((file.size / Math.pow(1024, 3)).toFixed(3));
            if (amazonStorageUsed >= CloudConnectionData.AmazonData.StorageContract) {
                storageExceed = true;
                if ($("#warnContainer").length == 0 || $("#warnContainer").css('display') == 'none') {
                    WarningNotification("File(s) uploaded exceeds the storage available.");
                    setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
                }
                if (!someRequestsUnderProcess) {
                    closeWaiting();
                }
                resolve(null);
                return null;
            }

            //////////name Check before upload
            var fileName = fileNameUploaded.split('.').slice(0, -1).join('.');
            var ext = fileNameUploaded.split('.').pop();

            /*getAWSObject(fileName, fileName, ext, "", 0).then(function (fileNameforUpload) {
                if (fileNameforUpload != undefined) {
                    var indexedFileName = fileNameforUpload + "." + ext;
                    someRequestsUnderProcess = true;
                    AWS.config.accessKeyId = CloudConnectionData.AmazonData.AccessKeyId;
                    AWS.config.secretAccessKey = CloudConnectionData.AmazonData.SecretAccessKey;
                    var bucket = CloudConnectionData.AmazonData.AWSBucketName;
                    var filekey = CloudConnectionData.AmazonData.CompanyFolder + "/" + indexedFileName;
                    var awsParams = {
                        Bucket: CloudConnectionData.AmazonData.AWSBucketName, Key: filekey, ContentType: file.type, filename: indexedFileName
                    }*/
            /*var s3obj = new AWS.S3({
                params: awsParams
            });
            s3obj.upload({
                Body: file,
                ACL: 'public-read'
            }).
                on("httpUploadProgress", function (evt) {
                        //showNonModalWaiting("Uploading files", 500);
                        }).
                    send(function (err, data) {
                        if (err) {
                            var errorMessage = err.message || 'Unable to upload file';
                            reject(Error(errorMessage));
                    }
                    else {
                            CloudConnectionData.AmazonData.StorageUsed += parseFloat((file.size / Math.pow(1024, 3)).toFixed(3));
                            amazonStorageUsed = CloudConnectionData.AmazonData.StorageUsed;
                            var linkedFile = {
                                FileURL: data.Location, FileName: indexedFileName, CloudStorage_ID: data.Key, StorageType: ThirdPartySettings.AWSS3, Length: file.size, Description: getFileDescription(current), ShareableLink: data.Location  };
                                setObjectInLocalStorage("CloudConnectionData", CloudConnectionData);
                                resolve(linkedFile);
                    }
                });*/

            //var awsAuthParams = { presignedURL: "", contentType: file.type };
            //var linkedFileObj = { FileName: CloudConnectionData.AmazonData.CompanyFolder + "/" + fileNameUploaded, StorageType: 1, Title: file.type };
            //generateFileSignedURL(linkedFileObj).then(function (urlGenerated) {
            getAWSObject(fileName, fileName, ext, "", 0, file.type, createFileSharableLink).then(function (fileNameforUpload) {
                if (fileNameforUpload != undefined) {
                    var indexedFileName = fileNameforUpload + "." + ext;
                    someRequestsUnderProcess = true;
                    var filekey = CloudConnectionData.AmazonData.CompanyFolder + "/" + indexedFileName;
                    var linkedFileObj = { FileName: filekey, StorageType: 1, MIMETypes: file.type, PreSignRequestVerb: 3, CreateSharableLink: createFileSharableLink };
                    generateFileSignedURL(linkedFileObj).then(function (urlGenerated) {
                        uploadWithSignedRequest(urlGenerated, file, createFileSharableLink).then(function (uploaded) {
                            if (uploaded) {
                                CloudConnectionData.AmazonData.StorageUsed += parseFloat((file.size / Math.pow(1024, 3)).toFixed(3));
                                amazonStorageUsed = CloudConnectionData.AmazonData.StorageUsed;
                                var linkedFile = {
                                    FileName: indexedFileName, FileURL: CloudConnectionData.AmazonData.AWSBucketName, CloudStorage_ID: filekey, StorageType: ThirdPartySettings.AWSS3, Length: file.size, Description: getFileDescription(current)
                                };
                                if (createFileSharableLink) {
                                    var AWSBucketName = CloudConnectionData.AmazonData.AWSPublicBucketName;
                                    var AWSHost = AWSBucketName + '.s3.amazonaws.com';
                                    var awsFileKey = linkedFile.CloudStorage_ID;//CloudConnectionData.AmazonData.CompanyFolder + "/" + linkedFile.FileName;
                                    linkedFile.FileURL = 'https://' + AWSHost + '/' + awsFileKey;
                                }
                                setObjectInLocalStorage("CloudConnectionData", CloudConnectionData);
                                resolve(linkedFile);
                            }
                            else {
                                reject("AWS Upload failed!")
                            }
                        });
                    });

                }

            });

            //});

            //////////////



        }
        else if (storageType == ThirdPartySettings.GoogleDrive) {

            ////////////// GOOGLE Rest API made functional /////////////////////////
            createUploadFolderOnGoogleDrive(file).then(function (folder) {
                var accessToken = CloudConnectionData.GoogleData.TokenInfo.access_token; //CloudConnectionData.GoogleData.access_token;
                //var refreshTokenCode = CloudConnectionData.GoogleData.refresh_token;
                if (folder != null) {
                    showNonModalWaiting("Uploading files", 500);
                    //ToDo: Move file upload logic inside promise here

                    var folderId = folder.id;//CloudConnectionData.GoogleData.rootFolderId;
                    gapi.auth.setToken({
                        access_token: accessToken
                    });

                    const boundary = '-------314159265358979323846';
                    const delimiter = "\r\n--" + boundary + "\r\n";
                    const close_delim = "\r\n--" + boundary + "--";

                    var reader = new FileReader();
                    reader.readAsBinaryString(file);
                    reader.onload = function (e) {
                        var contentType = file.type || 'application/octet-stream';
                        var metadata = {
                            'title': file.name,
                            'mimeType': contentType,
                            'parents': [{ "id": folderId }]
                        };
                        var base64Data = btoa(reader.result);
                        var multipartRequestBody =
                            delimiter +
                            'Content-Type: application/json\r\n\r\n' +
                            JSON.stringify(metadata) +
                            delimiter +
                            'Content-Type: ' + contentType + '\r\n' +
                            'Content-Transfer-Encoding: base64\r\n' +
                            '\r\n' +
                            base64Data +
                            close_delim;

                        var request = gapi.client.request({
                            'path': '/upload/drive/v2/files',
                            'method': 'POST',
                            'params': { 'uploadType': 'multipart' },
                            'headers': {
                                'Content-Type': 'multipart/mixed; boundary="' + boundary + '"'
                            },
                            'body': multipartRequestBody
                        });
                        request.execute(function (response) {
                            if (response.error) {
                                var errorMessage = response.error.message || 'Unable to upload file';
                                if (errorMessage.toLowerCase().indexOf('invalid credentials') > -1) {
                                    //renew access token using refresh token
                                    //refreshToken();

                                    //Will only fetch..
                                    //localStorage.removeItem("CloudConnectionData");
                                    //getAccessToken();

                                    //call and update thirdpartysettings
                                    RefreshTokenSettings();

                                    /*//ZS: To be considered rather for resfresh process
                                    googleRefreshToken().then(function (googleRefreshToken) {
                                        if (googleRefreshToken != null) {
                                            createUploadFolderOnGoogleDrive(file);
                                        }
                                    });*/

                                }
                                else reject(Error(errorMessage));
                            } else {

                                var linkedFile = { FileURL: response.embedLink, FileName: response.title, CloudStorage_ID: response.id, StorageType: ThirdPartySettings.GoogleDrive, Length: response.fileSize, Description: getFileDescription(current), ShareableLink: response.alternateLink };

                                resolve(linkedFile);
                            }
                        });
                    }





                }
            }, function (error) {

                ErrorNotification(error);
                //closeWaiting();
            });

            /////////////////////////////////////////////////


        }
        else if (storageType == ThirdPartySettings.Dropbox) {
            uploadToDropBoxStorage(file, file.name, current).then(function (linkedFile) {
                if (linkedFile != null) {
                    resolve(linkedFile);
                }
                else reject(linkedFile);
            });

        }
        else if (storageType == ThirdPartySettings.OneDrive) {
            var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
            var objOneDriveData = eval("(function(){return " + oneDriveTokenInfo + ";})()");
            var objJSON = eval("(function(){return " + objOneDriveData.AccessTokenInfo + ";})()");
            var accessToken = objJSON.access_token;
            var user_id = objJSON.user_id;
            var refresh_token = objJSON.refresh_token;
            var fileSharedLink = null;
            IstokenRefreshed = false;
            accessToken_afterRefresh = "";

            showNonModalWaiting("Uploading files");

            GetLinkedFile(fileNameUploaded, ThirdPartySettings.OneDrive).then(function (data) {

                var fileGeneratedName = fileNameUploaded;
                if (data != null) {
                    var index = Math.floor(Math.random() * (1000 - 1)) + 1;
                    var name = file.name.split('.').slice(0, -1).join('.');
                    var ext = file.name.substring(file.name.lastIndexOf('.') + 1, file.name.length)
                    fileGeneratedName = name + "-" + index + "." + ext;

                } else {



                }

                //odfileUploadData = null;
                getOneDriveFileUploadSession(file, accessToken, fileGeneratedName, current).then(function (data) {

                    if (data.status != 409) { // 409 FILE CONFLICT FOR FILE VERSIONING
                        var odFile = data.json;
                        if (odFile != undefined) {
                            //odfileUploadData = odFile;

                            var linkedFile = {
                                OneDriveFileId: odFile.id,
                                FileURL: odFile.webUrl, FileName: odFile.name,
                                CloudStorage_ID: odFile.id, StorageType: ThirdPartySettings.OneDrive, Length: odFile.size,
                                Description: getFileDescription(current)
                            };

                            createFileShareableLink(linkedFile, accessToken).then(function (fileData) {
                                /*if (fileLnk != undefined) {
                                    fileSharedLink = fileLnk.link.webUrl;

                                }*/
                                //else {
                                //var errorMessage = data.responseText || 'Unable to create link';
                                // reject(Error(errorMessage));
                                // }

                                resolve(fileData);
                            });

                        }
                        else {
                            var errorMessage = data.responseText || 'Unable to upload file';
                            reject(Error(errorMessage));
                        }
                    } else {
                        // HANDLE FILE VERSION HANDLING IF EXIST
                    }
                });


            });



        }

        else if (storageType == ThirdPartySettings.Box) {

            createUploadFolderOnBox(file).then(function (folder) {
                if (folder != null) {

                    var boxTokenInfo = CloudConnectionData.BoxData.accessToken; //"u4KkVCmzrouOCwkeeYHUy25H3gU56T8q";
                    var objJSON = eval("(function(){return " + boxTokenInfo + ";})()");
                    var accessToken = objJSON.AccessTokenInfo.access_token;

                    var form = new FormData();
                    //form.append('file', file);
                    // JS file-like object
                    form.append('file', file, file.name);
                    form.append('parent_id', folder.id);

                    //boxVersionDataFile = form;

                    uploadToBoxStorage(file, folder, form, accessToken, current).then(function (linkedFile) {
                        if (linkedFile != null) {
                            resolve(linkedFile);
                        }
                        else reject(linkedFile);
                    });

                }
            }, function (error) {

                ErrorNotification(error);
                var errorMessage = error || 'Unable to upload file';
                reject(Error(errorMessage));
                //closeWaiting();
            });

        }

    });
}

function uploadToDropBoxStorage(file, fileName, current) {
    return new Promise(function (resolve, reject) {
        var accessToken = CloudConnectionData.DropBoxData.accessToken; //CloudConnectionData.DefaultStorage.AccessToken;
        var xhr = new XMLHttpRequest();
        xhr.upload.onprogress = function (evt) {
            //var percentComplete = parseInt(100.0 * evt.loaded / evt.total);
            showNonModalWaiting("Uploading files", 500);
        };

        xhr.onload = function () {
            if (xhr.status === 200) {

                var fileSharedLink = null;
                var http = new XMLHttpRequest();
                var url = 'https://api.dropboxapi.com/2/sharing/create_shared_link_with_settings';
                var params = JSON.stringify({
                    path: CloudConnectionData.DropBoxData.cloudFileBasePath + fileName
                });
                http.open('POST', url, true);

                http.setRequestHeader('Authorization', 'Bearer ' + accessToken);
                http.setRequestHeader('Content-type', 'application/json');

                http.onreadystatechange = function () {
                    if (http.readyState == 4) {

                        if (http.status === 200 || http.status === 201) {

                            var fileInfo = JSON.parse(http.responseText);
                            fileSharedLink = fileInfo.url;

                            //if (fileInfo != undefined) {
                            var linkedFile = { FileURL: fileInfo.path_lower, FileName: fileInfo.name, CloudStorage_ID: fileInfo.id, StorageType: ThirdPartySettings.Dropbox, Length: fileInfo.size, Description: getFileDescription(current), ShareableLink: fileSharedLink };
                            resolve(linkedFile);
                            //}
                        }
                        else if (http.status === 409) {
                            var index = Math.floor(Math.random() * (1000 - 1)) + 1;
                            var name = file.name.split('.').slice(0, -1).join('.');
                            var ext = file.name.substring(file.name.lastIndexOf('.') + 1, file.name.length)

                            uploadToDropBoxStorage(file, name + "-" + index + "." + ext, current).then(function (linkedFile) {
                                if (linkedFile != null) {
                                    resolve(linkedFile);
                                }
                                else reject(linkedFile);
                            });
                        }


                    }
                }
                http.send(params);

            }
            else {
                var errorMessage = xhr.response || 'Unable to upload file';
                reject(Error(errorMessage));
            }
        };
        xhr.open('POST', 'https://content.dropboxapi.com/2/files/upload');
        xhr.setRequestHeader('Authorization', 'Bearer ' + accessToken);
        xhr.setRequestHeader('Content-Type', 'application/octet-stream');
        xhr.setRequestHeader('Dropbox-API-Arg', JSON.stringify({
            path: CloudConnectionData.DropBoxData.cloudFileBasePath + fileName,
            mode: 'add',
            autorename: true,
            mute: false
        }));
        xhr.send(file);

    });
}

function checkLinkedFileNameExisting() {

    return new Promise(function (resolve, reject) {

        //var access_token = CloudConnectionData.GoogleData.TokenInfo.access_token; //CloudConnectionData.GoogleData.access_token;
        var refreshToken = CloudConnectionData.GoogleData.TokenInfo.refresh_token;
        var clientId = CloudConnectionData.GoogleData.ConsumerInfo.Token;
        var clientSecretKey = CloudConnectionData.GoogleData.ConsumerInfo.Secret;

        var form = new FormData();
        form.append("grant_type", "refresh_token");
        form.append("refresh_token", refreshToken);
        form.append("client_id", clientId);
        form.append("client_secret", clientSecretKey);

        var settings = {
            "async": true,
            "crossDomain": true,
            "url": "https://www.googleapis.com/oauth2/v4/token",
            "method": "POST",
            "headers": {
                "Cache-Control": "no-cache",
            },
            "processData": false,
            "contentType": false,
            "mimeType": "multipart/form-data",
            "data": form
        }

        $.ajax(settings)
            .done(function (response) {
                if (response != "") {//refreshed successfully
                    updateGoogleToken(response).then(function (updateToken) {
                        if (updateToken != null && updateToken.IsSuccessStatusCode) {
                            var objJSON = eval("(function(){return " + updateToken.Response.AccessToken + ";})()");
                            resolve(objJSON.AccessTokenInfo.access_token);
                        }
                    });
                }
            })
            .fail(function (response) {
                var err = JSON.parse(response.responseText);
                var message = "Cannot refresh. " + err.error + ". " + err.error_description;
                closeWaiting();
                showAlertDialog(message);
                reject(message);
            });
    });
}

function uploadToBoxStorage(file, folder, formData, accessToken, current) {
    return new Promise(function (resolve, reject) {
        showNonModalWaiting("Uploading files", 500);
        var uploadUrl = 'https://upload.box.com/api/2.0/files/content';

        var xhr = new XMLHttpRequest()
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {

                var fileInfo = JSON.parse(xhr.responseText);

                if (xhr.status != 409) { // 409 FILE CONFLICT FOR FILE VERSIONING
                    if (fileInfo.total_count != undefined && fileInfo.total_count != 0) {
                        //boxVersionDataFile = null;
                        fileInfo.entries.forEach(function (boxFile) {

                            var fileSharedLink = null;
                            var http = new XMLHttpRequest();
                            var url = 'https://api.box.com/2.0/files/' + boxFile.id;
                            var params = JSON.stringify({
                                shared_link: { "access": "open" }
                            });
                            http.open('PUT', url, true);
                            http.setRequestHeader('Authorization', 'Bearer ' + accessToken);
                            http.setRequestHeader('Content-type', 'application/json');
                            http.onreadystatechange = function () {
                                if (http.readyState == 4) {
                                    if (http.status === 200) {
                                        var fileInfo = JSON.parse(http.responseText);
                                        fileSharedLink = fileInfo.shared_link.url;
                                    }
                                    else {
                                        //var errorMessage = req.response || 'Unable to get link';
                                        //reject(Error(errorMessage));
                                    }
                                    var linkedFile = { FileURL: boxFile.name, FileName: boxFile.name, CloudStorage_ID: boxFile.id, StorageType: ThirdPartySettings.Box, Length: boxFile.size, Description: getFileDescription(current), Parent_ID: boxFile.file_version.id, ShareableLink: fileSharedLink };
                                    resolve(linkedFile);

                                }
                            }
                            http.send(params);
                        });
                    }
                    else {
                        var errorMessage = xhr.responseText || 'Unable to upload file';
                        reject(Error(errorMessage));
                    }
                } else {
                    var index = Math.floor(Math.random() * (1000 - 1)) + 1;
                    var name = file.name.split('.').slice(0, -1).join('.');
                    var ext = file.name.substring(file.name.lastIndexOf('.') + 1, file.name.length)
                    var formDt = new FormData();
                    formDt.append('file', file, name + "-" + index + "." + ext);
                    formDt.append('parent_id', folder.id);

                    uploadToBoxStorage(file, folder, formDt, accessToken).then(function (linkedFile) {
                        if (linkedFile != null) {
                            resolve(linkedFile);
                        }
                        else reject(linkedFile);
                    });

                    //BOX FILE VERSION HANDLING
                    /*var versionFileId = data.responseJSON.context_info.conflicts.id;
                    boxVersionUpload(boxVersionDataFile, accessToken, versionFileId).then(function (boxFile) {
                        if (boxFile.total_count != undefined && boxFile.total_count != 0) {
                            var linkedFile = { FileURL: boxFile.entries[0].type, FileName: boxFile.entries[0].name, CloudStorage_ID: boxFile.entries[0].id, StorageType: "10", Length: boxFile.entries[0].size, Description: getFileDescription(current) };
                            resolve(linkedFile);
                        }
                        else {
                            var errorMessage = data.responseText || 'Unable to upload new version file';
                            reject("ERROR");
                        }
    
                    });*/
                }

            }
        }
        xhr.open('POST', uploadUrl, true)
        xhr.setRequestHeader('Authorization', 'Bearer ' + accessToken)
        //xhr.setRequestHeader('Content-Type', file.type)
        xhr.send(formData);

    });
}

function getAWSObject(givenName, indexedName, ext, msg, index, contentType, createFileSharableLink) {
    return new Promise(function (resolve, reject) {
        try {

            var objectName = CloudConnectionData.AmazonData.CompanyFolder + "/" + indexedName + "." + ext;
            var coreAWSBucket = CloudConnectionData.AmazonData.AWSBucketName;
            var publicUri;
            if (createFileSharableLink) {
                coreAWSBucket = CloudConnectionData.AmazonData.AWSPublicBucketName;
                var AWSHost = coreAWSBucket + '.s3.amazonaws.com';
                var awsFileKey = objectName;
                publicUri = 'https://' + AWSHost + '/' + awsFileKey;
            }
            var linkedFileObj = { CloudStorage_ID: objectName, FileName: objectName, FileURL: coreAWSBucket, StorageType: 1, MIMETypes: contentType, PreSignRequestVerb: 1, CreateSharableLink: createFileSharableLink };
            generateFileSignedURL(linkedFileObj).then(function (urlGenerated) {
                //awsAuthParams.presignedURL = urlGenerated;
                var xhr = new XMLHttpRequest();
                if (createFileSharableLink)
                    xhr.open('GET', publicUri, true);
                else
                    xhr.open('GET', urlGenerated, true);
                xhr.responseType = 'arraybuffer';
                //xhr.setRequestHeader('x-amz-acl', 'public-read');
                xhr.onload = function (dataResp, resp, req) {
                    if (this.status == 404) {
                        resolve(indexedName);
                    }
                    else if (this.status == 403 && linkedFileObj.CreateSharableLink && linkedFileObj.PreSignRequestVerb == 1) {
                        //404 Expected. AWS status code permission issue related to IAM user to perform the s3:ListBucket action
                        //https://forums.aws.amazon.com/thread.jspa?threadID=84468
                        resolve(indexedName);
                    }
                    else if (this.status == 200) {
                        indexedName = givenName + "_" + index++;// + "." + ext;
                        getAWSObject(givenName, indexedName, ext, "", index, contentType, createFileSharableLink).then(function (data) {
                            if (data != undefined) {
                                resolve(data);
                            } else {
                                reject(data);
                            }
                        });
                    }
                    else {
                        reject(dataResp);
                    }
                };
                xhr.send();
            });
            //return false;


            /*var bucket = CloudConnectionData.AmazonData.AWSBucketName;
            AWS.config.accessKeyId = CloudConnectionData.AmazonData.AccessKeyId;
            AWS.config.secretAccessKey = CloudConnectionData.AmazonData.SecretAccessKey;
            
            var s3 = new AWS.S3();
    
            var params = { Bucket: bucket, Key: objectName };

            s3.getObject(params,
                            function (error, data) {
                                if (error != null) {
                                    msg = error.code;
                                    if (msg == "NoSuchKey") {
                                        resolve(indexedName);
                                    }
                                    else {
                                        indexedName = null;
                                        reject(indexedName);
                                    }
                                } else {
                                    indexedName = givenName + "_" + index++;// + "." + ext;
                                    getAWSObject(givenName, indexedName, ext, "", index).then(function (data) {
                                        if (data != undefined) {
                                            resolve(data);
                                        } else {
                                            reject(data);
                                        }
                                    });
                                }                                
                            });*/
        }
        catch (e) {
            reject(e);
        }
    });
}

var SCOPES = ['https://www.googleapis.com/auth/drive'];

var gconfig = {
    'client_id': '744976136609-bfchdj3jb13en0nj1isrbm5lctg717e1.apps.googleusercontent.com',
    'scope': SCOPES.join(' '),
    'immediate': true,
    'access_type': 'offline',
    //'approval_prompt': 'force',
    'response_type': 'code'
};
//Function not used anywhere
function refreshToken() {
    gapi.auth.authorize(gconfig, tokenRefreshed);
}

function tokenRefreshed(result) {
    var thirdPartyStorageObject = {}
    thirdPartyStorageObject = CloudConnectionData.DefaultStorage;
    thirdPartyStorageObject.Type = 2;

    var googleTokenInfo = JSON.parse(thirdPartyStorageObject.AccessToken);
    googleTokenInfo.Token.access_token = result.code;
    thirdPartyStorageObject.AccessToken = JSON.stringify(googleTokenInfo);

    var _url = GetBaseURL() + "Json/PutObjectGlobalization?url=api/ThirdPartySetting/PutThirdPartySetting&module=ThirdPartySetting";
    ajaxCall({
        url: _url,
        data: JSON.stringify(thirdPartyStorageObject),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "PUT",
        success: function (response) {
            if (response != null) {
                if (response.IsSuccessStatusCode) {
                } else {
                    ErrorNotification(response.Error.Message);
                }
            }
        }
    });
}

function RefreshTokenSettings() {
    var _url = GetBaseURL() + "Json/PostObjectGlobalization?url=api/LinkedFiles/RefreshTokenSettings&module=ThirdPartySetting";
    ajaxCall({
        url: _url,
        data: JSON.stringify(CloudConnectionData.DefaultStorage),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "PUT",
        success: function (response) {
            if (response != null) {
                if (response.IsSuccessStatusCode) {
                    localStorage.removeItem("CloudConnectionData");
                    getAccessToken();
                    SuccessNotification("Token refreshed successfully. Please try adding now.");
                } else {
                    ErrorNotification(response.Error.Message);
                }
            }
        }
    });
}

// GOOGLE GET REFRESH TOKEN FROM ENDPOINT.
function googleRefreshToken() {

    return new Promise(function (resolve, reject) {

        //var access_token = CloudConnectionData.GoogleData.TokenInfo.access_token; //CloudConnectionData.GoogleData.access_token;
        var refreshToken = CloudConnectionData.GoogleData.TokenInfo.refresh_token;
        var clientId = CloudConnectionData.GoogleData.ConsumerInfo.Token;
        var clientSecretKey = CloudConnectionData.GoogleData.ConsumerInfo.Secret;

        var form = new FormData();
        form.append("grant_type", "refresh_token");
        form.append("refresh_token", refreshToken);
        form.append("client_id", clientId);
        form.append("client_secret", clientSecretKey);

        var settings = {
            "async": true,
            "crossDomain": true,
            "url": "https://www.googleapis.com/oauth2/v4/token",
            "method": "POST",
            "headers": {
                "Cache-Control": "no-cache",
            },
            "processData": false,
            "contentType": false,
            "mimeType": "multipart/form-data",
            "data": form
        }

        $.ajax(settings)
            .done(function (response) {
                if (response != "") {//refreshed successfully
                    updateGoogleToken(response).then(function (updateToken) {
                        if (updateToken != null && updateToken.IsSuccessStatusCode) {
                            var objJSON = eval("(function(){return " + updateToken.Response.AccessToken + ";})()");
                            resolve(objJSON.AccessTokenInfo.access_token);
                        }
                    });
                }
            })
            .fail(function (response) {
                var err = JSON.parse(response.responseText);
                var message = "Cannot refresh. " + err.error + ". " + err.error_description;

                closeWaiting();
                if (err.error.indexOf("invalid_grant") >= 0) {
                    showAlertDialog("Your Google Drive credentials have expired. Please connect to your Google Drive storage again in Global settings!");
                }
                // showAlertDialog(message);
                reject(message);
            });
    });
}

// GOOGLE UPDATE TOKEN  TO DATABASE
function updateGoogleToken(refreshResponse) {
    return new Promise(function (resolve, reject) {
        var type = 2, alias = "";
        var appendUrl = "api/ThirdPartySetting/GetStorage?type=" + type + "&alias=" + alias;
        var _url = GetBaseURL() + "Json/GetItem?url=" + encodeURIComponent(appendUrl);
        ajaxCall({
            url: _url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            showWaiting: false,
            type: "GET",
            success: function (response) {
                if (response != null) {
                    var refreshedResponse = JSON.parse(refreshResponse);
                    var thirdPartyStorageObject = response[0];
                    var googleTokenInfo = thirdPartyStorageObject.AccessToken;
                    var objJSON = eval("(function(){return " + googleTokenInfo + ";})()");
                    objJSON.AccessTokenInfo.access_token = refreshedResponse.access_token;
                    thirdPartyStorageObject.AccessToken = JSON.stringify(objJSON);
                    var data = JSON.stringify(thirdPartyStorageObject);
                    var _url = GetBaseURL() + "Json/PutObjectGlobalization?url=api/ThirdPartySetting/PutThirdPartySetting&module=ThirdPartySetting";
                    ajaxCall({
                        url: _url,
                        data: data,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        type: "PUT",
                        success: function (response) {
                            if (response != null) {
                                if (response.IsSuccessStatusCode) {
                                    var objJSON = eval("(function(){return " + response.Response.AccessToken + ";})()");
                                    CloudConnectionData.GoogleData.TokenInfo = objJSON.AccessTokenInfo;
                                    localStorage.removeItem("CloudConnectionData");
                                    setObjectInLocalStorage("CloudConnectionData", CloudConnectionData);
                                    resolve(response);
                                } else {
                                    resolve(response);
                                    ErrorNotification(response.Error.Message);
                                }
                            }
                        }
                    });
                }

            }
        });
    });
}
///////////////////// GOOGLE TOKEN HANDLING END
function isGuid(strGuid) {
    if (strGuid != null && strGuid[0] === "{") {
        strGuid = strGuid.substring(1, strGuid.length - 1);
    }
    var regexGuid = /^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$/gi;
    return regexGuid.test(strGuid);
}

function getFileFromAWSS3(linkedFile, action, dataSource, systemtype, fileCount) {
    return new Promise(function (resolve, reject) {

        var fileObjectName = linkedFile.FileName;
        if (isGuid(linkedFile.CloudStorage_ID))
            linkedFile.FileName = CloudConnectionData.AmazonData.CompanyFolder + "/" + linkedFile.FileName;
        else linkedFile.FileName = linkedFile.CloudStorage_ID;
        linkedFile.PreSignRequestVerb = 1;
        generateFileSignedURL(linkedFile).then(function (urlGenerated) {
            downloadWithSignedRequest(urlGenerated, linkedFile.MimeType).then(function (data) {
                //if (downloaded) {
                linkedFile.FileName = fileObjectName;//reset without company folder in file name
                if (action == ACTION.DOWNLOAD || linkedFile.MimeType == "application/octet-stream") {
                    setTimeout(function () {
                        downloadBlob(data, fileObjectName, linkedFile.MimeType);
                    }, (fileCount++ * 150))

                } else if (action == ACTION.OPEN) {
                    openBlob(data, fileObjectName, linkedFile.MimeType);
                } else if (action == ACTION.VIEW) {
                    viewBlob(data, fileObjectName, linkedFile.MimeType, dataSource);
                    setFileAttributes(linkedFile);
                } else if (action == ACTION.GETBLOB) {
                    var fileBlob = new Blob([data], {
                        type: linkedFile.MimeType
                    });
                    fileBlob.name = fileObjectName;
                    resolve(fileBlob);
                }
                    //}
                else {
                    reject("AWS Upload failed!")
                }
            });
        });
        return false;

    });
}

function getResourceLibraryFiles(selectedRsIds) {
    return new Promise(function (resolve, reject) {

        var params = {
            FilterList: [{ Field: "LinkedFile_ID", Operator: "In", DiscreteValues: selectedRsIds }]
        };

        showNonModalWaiting("Uploading files", 500);

        ajaxCall({
            url: GetBaseURL() + "Json/GetList?url=api/LinkedFiles/LinkedFileCompact",
            data: JSON.stringify(params),
            contentType: "application/json; charset=utf-8",
            showWaiting: false,
            dataType: "json",
            type: "POST",
            async: false,
            success: function (list) {
                if (list != null && list.length > 0) {
                    for (var i = 0; i < list.length; i++) {
                        var files = [];
                        var downloadCount = 0;
                        if (list[i].StorageType == "4") {
                            files.push(list[i]);
                            resolve(files);
                        }
                        else {
                            var idx = list[i].FileName.lastIndexOf(".");
                            var fileType = list[i].FileName.substring(idx + 1).toLowerCase();
                            list[i].MimeType = getMimeByExt(fileType);
                            getFileFromAWSS3(list[i], ACTION.GETBLOB).then(function (blob) {
                                downloadCount++;
                                if (blob != null) {
                                    files.push(blob);
                                    if (downloadCount == list.length) {
                                        resolve(files);
                                        closeNonModalWaiting();
                                    }
                                }

                            });
                        }

                    }
                } else {
                    ErrorNotification("No Such files found");
                }
            }
        });
    });
}

function getFileFromGoogleDrive(linkedFile, action, dataSource) {
    if (CloudConnectionData.GoogleData == null) {
        showAlertDialog("That didn't work. Please check if you have an active Google drive connection in Core Global settings.");
        closeWaiting();
        return false;
    }
    var accessToken = CloudConnectionData.GoogleData.TokenInfo.access_token; //CloudConnectionData.GoogleData.access_token;
    gapi.auth.setToken({
        access_token: accessToken
    });
    var downloadUrl;
    gapi.client.request({
        'path': '/drive/v2/files/' + linkedFile.CloudStorage_ID,
        'method': 'GET',
        callback: function (response, responsetxt) {
            if (response.error) {
                var errorMessage = response.error.message || 'Unable to get folder';
                if (errorMessage.toLowerCase().indexOf('invalid credentials') > -1) {
                    //considered rather for refresh process
                    googleRefreshToken().then(function (googleRefreshedAccessToken) {
                        if (googleRefreshedAccessToken != undefined) {
                            getFileFromGoogleDrive(linkedFile, action, dataSource);
                        }
                    });

                }
                else {
                    //reject(Error(errorMessage));
                    ErrorNotification(errorMessage);
                    closeWaiting();
                }
            } else {
                if (action == ACTION.DOWNLOAD) {
                    window.open(response.webContentLink, '_blank')
                } else if (action == ACTION.OPEN) {
                    window.open(response.alternateLink, '_blank')
                } else if (action == ACTION.VIEW) {

                    if (dataSource === undefined) {

                        $(".fileViewer").attr('src', response.webContentLink);
                        showDialog('#show-attachment-modal');
                        setFileAttributes(linkedFile);

                    }

                    else if (dataSource === "avatar") {
                        $('.jsavatar').attr('data', url);

                    }
                    else {
                        $('.fileObj').attr('data', url);
                        LoadForms($('#ddlType').val());
                    }

                }
            }





            closeWaiting();
        }
    });

}

function createUploadFolderOnGoogleDrive(file) {
    return new Promise(function (resolve, reject) {
        var accessToken = CloudConnectionData.GoogleData.TokenInfo.access_token;

        getUploadFolderOnGoogleDrive(accessToken, file).then(function (folder) {
            if (folder != null) {
                resolve(folder);
                return false;
            } else {
                /*gapi.auth.setToken({
                    access_token: accessToken
                });*/
                var request = gapi.client.request({
                    'path': '/drive/v2/files/',
                    'method': 'POST',
                    'headers': {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + accessToken,
                    },
                    'body': {
                        "title": "BQE Core Attachments",
                        "mimeType": "application/vnd.google-apps.folder",
                    }
                });

                request.execute(function (response) {
                    if (response.error) {
                        var errorMessage = response.error.message || 'Unable to create folder';
                        if (errorMessage.toLowerCase().indexOf('invalid credentials') > -1) {
                            //renew access token using refresh token
                            //refreshToken();

                            //Will only fetch..
                            //localStorage.removeItem("CloudConnectionData");
                            //getAccessToken();

                            //call and update thirdpartysettings
                            RefreshTokenSettings();

                            /*//ZS: To be considered rather for resfresh process
                            googleRefreshToken().then(function (googleRefreshToken) {
                                if (googleRefreshToken != null) {
                                    startupload(file, current);//getFileFromGoogleDrive
                                }
                            });*/

                        }
                        else reject(Error(errorMessage));
                    } else {
                        resolve(response);
                    }
                });

            }
        });

    });
}

function getUploadFolderOnGoogleDrive(accessToken, file) {
    var callbackAfterUploadComplete = ($(".jsAddAttachment").length > 0 && $(".jsAddAttachment").data('afterfileuploadcomplete').length > 0) ? $(".jsAddAttachment").data('afterfileuploadcomplete') : $("#add-attachment").data('afterfileuploadcomplete');
    return new Promise(function (resolve, reject) {

        gapi.auth.setToken({
            access_token: accessToken
        });
        gapi.client.load('drive', 'v2', function () {
            /*var folders = gapi.client.drive.files.list({ q: "mimeType = 'application/vnd.google-apps.folder' and title = 'BQE Core Attachments' and trashed = false" })
            .then(function (directories) {
                var directory = directories.result.items;

                if (!directory.length) {
                    createGoogleFolder().then(function (fol) {
                        insertPermission(fol.result).then(function (res) {
                            resolve(fol.result);
                        });
                    });
                } else {
                    resolve(directory[0]);
                }
            });*/
            var folders = gapi.client.drive.files.list({ q: "mimeType = 'application/vnd.google-apps.folder' and title = 'BQE Core Attachments' and trashed = false" });
            folders.execute(function (directories) {
                if (directories.error) {
                    var errorMessage = directories.error.message || 'Unable to get folder';
                    if (errorMessage.toLowerCase().indexOf('invalid credentials') > -1) {
                        //call and update thirdpartysettings
                        //RefreshTokenSettings();

                        //considered rather for refresh process
                        googleRefreshToken().then(function (googleRefreshedAccessToken) {
                            if (googleRefreshedAccessToken != undefined) {
                                resolve(getUploadFolderOnGoogleDrive(googleRefreshedAccessToken, file));
                            }
                        });

                    }
                    else reject(Error(errorMessage));
                } else {
                    var directory = directories.result.items;

                    if (!directory.length) {
                        createGoogleFolder().then(function (fol) {
                            insertPermission(fol.result).then(function (res) {
                                resolve(fol.result);
                            });
                        });
                    } else {
                        resolve(directory[0]);
                    }
                }



            });

        });

    });

}

function createGoogleFolder() {
    return new Promise(function (resolve, reject) {
        var folder = gapi.client.drive.files.insert({
            'resource': {
                "title": 'BQE Core Attachments',
                "mimeType": "application/vnd.google-apps.folder"
            }
        });
        folder.execute(function (response) {
            resolve(response);
        });
    });

}

function insertPermission(file) {
    return new Promise(function (resolve, reject) {
        var permission = gapi.client.drive.permissions.insert({
            'fileId': file.id,
            'resource': {
                "withLink": true,
                "role": "reader",
                "type": "anyone"
            }
        });
        permission.execute(function (response) {
            resolve(response);
        });
    });

}

function DeleteFromGoogleDriveCloudStorage(CloudStorage_ID, rowId) {

    return new Promise(function (resolve, reject) {

        var accessToken = CloudConnectionData.GoogleData.TokenInfo.access_token;

        gapi.auth.setToken({
            access_token: accessToken
        });
        gapi.client.load('drive', 'v2', function () {
            var request = gapi.client.drive.files.delete({
                'fileId': CloudStorage_ID
            });
            request.execute(function (resp) {
                resolve(xhr.status);
                // GET REFRESH TOKEN 
                if (xhr.status == 401) {
                    googleRefreshToken().then(function (gdRefreshToken) {
                        if (gdRefreshToken != null) {
                            DeleteFromGoogleDriveCloudStorage(CloudStorage_ID, rowId).then(function (cloudResponse) {
                                if (cloudResponse == 200) {
                                    DeleteFile(rowId);
                                }
                            });
                        }
                    })
                } else if (xhr.status == 404) {
                    reject(xhr.status);
                    closeWaiting();
                }
            });
        });

    });
}
/////GOOGLE OPS END


function downloadFileBytesFromAWSS3_1(linkedFile) {
    return new Promise(function (resolve, reject) {
        AWS.config.accessKeyId = CloudConnectionData.AmazonData.AccessKeyId;
        AWS.config.secretAccessKey = CloudConnectionData.AmazonData.SecretAccessKey;
        var bucket = CloudConnectionData.AmazonData.AWSBucketName;
        var s3 = new AWS.S3();
        var params = { Bucket: bucket, Key: linkedFile.CloudStorage_ID };
        s3.getObject(
            params,
            function (error, data) {
                if (error != null) {
                    reject(Error(error));
                    //ErrorNotification("Failed to retrieve an object: " + error);
                } else {
                    var objFile = new Object();

                    objFile.Name = linkedFile.FileName;
                    var blObj = uint8ToBase64(data.Body); //getBlob(data.Body, linkedFile.FileName, data.ContentType);
                    objFile.FileData = blObj;
                    objFile.ContentType = data.ContentType;
                    objFile.Size = data.Body.length;
                    //var blObj = Array.from(data.Body);
                    //  blObj.name = linkedFile.FileName;
                    resolve(objFile);
                    //return blObj;
                }
                //closeWaiting();
            }
        );
    });
}

function downloadFileBytesFromAWSS3(linkedFile) {
    return new Promise(function (resolve, reject) {
        linkedFile.FileName = CloudConnectionData.AmazonData.CompanyFolder + "/" + linkedFile.FileName;
        linkedFile.PreSignRequestVerb = 1;
        generateFileSignedURL(linkedFile).then(function (urlGenerated) {
            downloadWithSignedRequest(urlGenerated, linkedFile.MimeType).then(function (blobData) {
                if (blobData != null) {
                    var objFile = new Object();
                    objFile.Name = linkedFile.FileName;
                    var blObj = uint8ToBase64(blobData);
                    objFile.FileData = blObj;
                    resolve(objFile);
                }
                else {
                    reject("Download failed");
                }
            });
        });
    });
}

function downloadFileBytesFromDropbox(linkedFile) {
    return new Promise(function (resolve, reject) {
        var accToken = CloudConnectionData.DropBoxData.accessToken;
        var xhr = new XMLHttpRequest();
        xhr.responseType = 'arraybuffer';
        xhr.onload = function () {
            if (xhr.status === 200) {
                var Base64String = arrayBufferToBase64(xhr.response);
                var size = xhr.response.length;
                resolve({ b64Array: Base64String, Size: size });
            } else {
                var errorMessage = xhr.response || 'Unable to download file';
                ErrorNotification(errorMessage);
            }
        };
        xhr.open('POST', 'https://content.dropboxapi.com/2/files/download');
        xhr.setRequestHeader('Authorization', 'Bearer ' + accToken);
        xhr.setRequestHeader('Dropbox-API-Arg', JSON.stringify({
            path: linkedFile.FileURL
        }));
        xhr.send();
    });
}

function uint8ToBase64(buffer) {
    var binary = '';
    var len = buffer.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(buffer[i]);
    }
    return window.btoa(binary);
}

function arrayBufferToBase64(buffer) {
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}

function downloadFilesFromGoogleDrive(linkedFile) {
    return new Promise(function (resolve, reject) {
        var accessToken = CloudConnectionData.GoogleData.TokenInfo.access_token; //CloudConnectionData.GoogleData.access_token;//
        gapi.auth.setToken({
            access_token: accessToken
        });
        var downloadUrl;
        gapi.client.request({
            'path': '/drive/v2/files/' + linkedFile.CloudStorage_ID,
            'method': 'GET',
            callback: function (response, responsetxt) {
                downloadUrl = response.downloadUrl;
                if (downloadUrl === undefined) return false;
                var gDoxBlob = null;
                var xhr = new XMLHttpRequest();
                xhr.open("GET", downloadUrl);
                // showNonModalWaiting("Downloading file", 500);
                xhr.setRequestHeader('Authorization', 'Bearer ' + accessToken);
                xhr.responseType = "arraybuffer";
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        gDoxBlob = xhr.response;
                        var base64String = arrayBufferToBase64(gDoxBlob);
                        var size = gDoxBlob.length;
                        resolve({ base64Array: base64String, Size: size });
                    } else {
                        var errorMessage = xhr.response || 'Unable to download file';
                        ErrorNotification(errorMessage);
                    }

                }
                xhr.send();

            }
        });
    });

}

function getFileFromDropbox(linkedFile, action, dataSource) {
    if (CloudConnectionData.DropBoxData == null) {
        showAlertDialog("That didn't work. Please check if you have an active Dropbox connection in Core Global settings.");
        closeWaiting();
        return false;
    }
    var accToken = CloudConnectionData.DropBoxData.accessToken;
    var xhr = new XMLHttpRequest();
    xhr.onload = function () {
        if (xhr.status === 200) {
            if (action == ACTION.DOWNLOAD) {
                var blob = new Blob([xhr.response], { type: linkedFile.MimeType });
                downloadBlob(blob, linkedFile.FileName, blob.type);
            } else if (action == ACTION.OPEN) {
                var blob = new Blob([xhr.response], { type: linkedFile.MimeType });
                openBlob(blob, linkedFile.FileName, blob.type);
            } else if (action == ACTION.VIEW) {
                var blob = new Blob([xhr.response], { type: linkedFile.MimeType });
                viewBlob(blob, linkedFile.FileName, blob.type, dataSource);
                setFileAttributes(linkedFile);
            }
            closeWaiting();
        }
        else if (xhr.status === 409) {
            closeWaiting();
            showAlertDialog("File not found in the Dropbox");
        }
        else if (xhr.status === 401) {
            closeWaiting();
            showAlertDialog("Your Dropbox credentials have expired. Please connect to your Dropbox storage again in Global settings!");
        }
        else {
            var errorMessage = xhr.response || 'Unable to download file';
            ErrorNotification(errorMessage);
            closeWaiting();
        }
    };
    xhr.open('POST', 'https://content.dropboxapi.com/2/files/download');
    xhr.setRequestHeader('Authorization', 'Bearer ' + accToken);
    xhr.setRequestHeader('Dropbox-API-Arg', JSON.stringify({
        path: linkedFile.FileURL
    }));
    xhr.responseType = 'arraybuffer';
    xhr.send();
}
//**Function updated from devlopment brach**//

function getLinkedFileAttributes(tr) {
    var ObjInfo = tr.find(".jsObjectInfoDivTR").data("objinfo");
    var storageTypeName = ObjInfo.StorageType;
    var fileName = ObjInfo.FileName;
    var description = ObjInfo.Description;
    var createdOn = ObjInfo.AttachmentDate;
    var createdOnName = ObjInfo.CreatedByFullName;
    var length = ObjInfo.Length;
    var cloundStoage_id = ObjInfo.CloudStorage_ID;
    var fileURL = ObjInfo.FileURL;
    var mimeType = ObjInfo.MimeType;
    var fileType = null;//value never gets filled
    var outlookAttachmentId = ObjInfo.OutlookAttachmentId;
    var outlookFileData = ObjInfo.OutlookFileData;
    var outlookEventId = ObjInfo.OutlookEventId;
    var linkedFile = { FileURL: fileURL, FileName: fileName, CloudStorage_ID: cloundStoage_id, StorageType: storageTypeName, Length: length, Description: description, CreatedOn: createdOn, CreatedByFullName: createdOnName, MimeType: mimeType, FileType: fileType, OutlookAttachmentId: outlookAttachmentId, OutlookFileData: outlookFileData, OutlookEventId: outlookEventId };
    if ($(".jsDownloadBtnOnView").length > 0)
        $(".jsDownloadBtnOnView").attr('file', JSON.stringify(linkedFile));
    return linkedFile;
}

function setFileAttributes(linkedFile) {
    var c_date = linkedFile.CreatedOn;
    $(".jsViewFileUrl").html(linkedFile.FileURL);
    $(".jsViewFileDescription").text(htmlDecode(linkedFile.Description)).attr('title', htmlDecode(linkedFile.Description));
    $(".jsViewFileCreatedOn").html(c_date === "" ? '' : ShortDate(c_date));
    $(".jsViewFileCreatedBy").html(linkedFile.CreatedByFullName);
    $(".jsViewFileName").html(linkedFile.FileName).attr('title', linkedFile.FileName);


    if (linkedFile.FileType) {
        $('.jsViewFileExt').html(linkedFile.FileType);
    }
    else {
        if (linkedFile.MimeType) {
            $('.jsViewFileExt').html(linkedFile.MimeType.split('/')[1].replace('vnd.', '').toUpperCase());
        }
        else if (linkedFile.FileName.indexOf('csv') !== -1) {
            $('.jsViewFileExt').html('CSV');
            $('.jsDownloadBtnOnView').show();
        }
        else {
            $('.jsViewFileExt').html('WEBLINK');
        }
    }
    if ($('.jsViewFileExt').html() !== 'WEBLINK') {
        $('.jsDownloadBtnOnView').show();
        if (typeof linkedFile.Length != typeof undefined) {
            var fileLength = linkedFile.Length.toString();

            if (fileLength.toUpperCase().search('KB') >= 0) {
                $(".jsViewFileSize").html(fileLength);
            }
            else {
                $(".jsViewFileSize").html((parseInt(fileLength) / 1024).toFixed(2) + " KB");
            }
        }
    }
    else {
        $('.jsViewFileSize').html('');
        $('.jsDownloadBtnOnView').hide();
    }
}

function viewFileInDialog(linkedFile, restrictConnectionFalseMesg) {


    $(".jsDownloadBtnOnView").attr('file', JSON.stringify(linkedFile));
    //var totalAttachmentCount=parseInt($(".attachment-count").text());
    if (linkedFile.OutlookAttachmentId != null && linkedFile.OutlookAttachmentId != undefined && linkedFile.OutlookAttachmentId != '') {
        closeNonModalWaiting();
        urltoFile('data:' + linkedFile.MimeType + ';base64,' + linkedFile.OutlookFileData, linkedFile.FileName, linkedFile.MimeType).then(function (data) {
            viewBlob(data, linkedFile.FileName, linkedFile.MimeType, undefined);
            setFileAttributes(linkedFile);
        });
        return;
    }

    if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == ThirdPartySettings.AWSS3) {
        getFileFromAWSS3(linkedFile, ACTION.VIEW);
    }

    else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == ThirdPartySettings.GoogleDrive) {

        if (restrictConnectionFalseMesg && CloudConnectionData.GoogleData == null)
            return false;

        getFileFromGoogleDrive(linkedFile, ACTION.VIEW);
    }
    else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == ThirdPartySettings.Dropbox) {

        if (restrictConnectionFalseMesg && CloudConnectionData.DropBoxData == null)
            return false;

        getFileFromDropbox(linkedFile, ACTION.VIEW);
    }

    else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == ThirdPartySettings.Box) {

        if (restrictConnectionFalseMesg && CloudConnectionData.BoxData == null)
            return false;

        getFileFromBox(linkedFile, ACTION.VIEW);
    }

    else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == ThirdPartySettings.OneDrive) {

        if (restrictConnectionFalseMesg && CloudConnectionData.OneDriveData == null)
            return false;

        getFileFromOneDrive(linkedFile, ACTION.VIEW);
    }

    else {
        viewBlob(linkedFile, linkedFile.FileName, linkedFile.StorageType);
        setFileAttributes(linkedFile);
    }
}

function OpenFileinNewWindow(linkedFile) {
    showNonModalWaiting();
    $(".jsDownloadBtnOnView").attr('file', JSON.stringify(linkedFile));
    if (linkedFile.StorageType == "AWSS3" || linkedFile.StorageType == ThirdPartySettings.AWSS3) {
        getFileFromAWSS3(linkedFile, ACTION.OPEN);
    } else if (linkedFile.StorageType == "GoogleDrive" || linkedFile.StorageType == ThirdPartySettings.GoogleDrive) {
        getFileFromGoogleDrive(linkedFile, ACTION.OPEN);
    } else if (linkedFile.StorageType == "Dropbox" || linkedFile.StorageType == ThirdPartySettings.Dropbox) {
        getFileFromDropbox(linkedFile, ACTION.OPEN);
    } else if (linkedFile.StorageType == "Box" || linkedFile.StorageType == ThirdPartySettings.Box) {
        getFileFromBox(linkedFile, ACTION.OPEN);
    } else if (linkedFile.StorageType == "OneDrive" || linkedFile.StorageType == ThirdPartySettings.OneDrive) {
        getFileFromOneDrive(linkedFile, ACTION.OPEN);
    } else {
        viewBlob(linkedFile, linkedFile.FileName, linkedFile.StorageType);
        setFileAttributes(linkedFile);
    }
}

function setNofNFileViewer(currentRow) {
    var view_wable_rows = getViewAbleFiles(currentRow);
    var currentIndex = view_wable_rows.index(currentRow) + 1;
    $('.jsFileCount').html(currentIndex + ' of ' + view_wable_rows.length + ' file(s).');
}

function getViewAbleFiles(currentRow) {
    var tableRows = currentRow.closest('tbody').find('tr');
    var view_wable_rows = [];
    tableRows.each(function (index, tr) {
        //var fileExt = $(tr).find(".jsFileExtension").html().toLowerCase().trim();
        var fileExt = $(tr).find(".jsFileExtension").attr('title').toLowerCase().trim();
        if (IMAGEEXTENTIONS.indexOf(fileExt) >= 0) {
            view_wable_rows.push(tr);
        }
    });
    return $(view_wable_rows);
}

//not handled delete yet
function checkStorage() {
    if (storageType == 1 && CloudConnectionData != null && CloudConnectionData.AmazonData != null) {
        var message;
        message = CloudConnectionData.AmazonData.StorageUsed.toFixed(3) + ' GB out of ' + CloudConnectionData.AmazonData.StorageContract + ' GB Used';

        if (CloudConnectionData.AmazonData.StorageUsed.toFixed(3) >= CloudConnectionData.AmazonData.StorageContract) {
            message = "<b>You will not be able to attach new documents. There is no cloud storage available.</b>";
            if (isNullorEmpty($("#UserRole").val()) || $("#UserRole").val() == "Standard")
                message += "<br><b>Please contact your administrator to purchase more storage.</b>";
            else
                message += "<br><b>Please purchase more storage.</b>";
            $(".jsShowAWSUsage").html(message).removeClass('hidden');
            return false;
        }

        $(".jsShowAWSUsage").html(message).removeClass('hidden');
    }
    return true;
}

function getFileDescription(current) {
    if (isNullorEmpty(current)) current = $('#add-attachment-modal .tab-header .active-tab').data('target')
    if (current === "from-computer") {
        return $('#jsFileDesc').val();
    }
    else if (current === "hyperlink") {
        return $('#cloudfiledescription').val();
    }
    else if (current === "dropbox") {
        return $('#jsFileDescDbx').val();
    }
    else if (current === "google-drive") {
        return $('#jsFileDescGoogle').val();
    }
    else if (current === "box") {
        return $('#jsFileDescBox').val();
    }
    else if (current === "one-drive") {
        return $('#jsFileDescOnedrive').val();
    }
    return "";
}

function ValidateFileUpload(file) {
    return new Promise(function (resolve, reject) {
        //resolve(true); // commented the below file upload validation. Comment this line and uncomment below for activating the validation check
        if (isIE()) {// TO DO IE validation
            resolve(true);
        } else {

            var freader = new FileReader();
            freader.readAsBinaryString(file);
            freader.onload = function () {
                //console.log(freader.result);
                if (freader !== '' && freader.result !== '') {
                    if (freader.result.indexOf('MZ') === 0) {
                        reject("Unable to upload. Invalid file format.");
                    } else {
                        resolve(true);
                    }

                } else {
                    reject("Unable to upload invalid file or the file is empty.");
                }

            };

            freader.onerror = function (error) {
                //console.log('Error: ', error);
                reject("Unable to upload invalid file");
            };
        }
    });

}

function isIE() {
    ua = navigator.userAgent;
    /* MSIE used to detect old browsers and Trident used to newer ones*/
    var is_ie = ua.indexOf("MSIE ") > -1 || ua.indexOf("Trident/") > -1;

    return is_ie;
}
/////////////////  BOX FILE OPERATIONS START///////////////////////////
// BOX FILE VIEW,DOWNLOAD AND OPEN OPERATIONS.
function getFileFromBox(linkedFile, action, dataSource) {
    return new Promise(function (resolve, reject) {
        if (CloudConnectionData.BoxData == null) {
            showAlertDialog("That didn't work. Please check if you have an active Box connection in Core Global settings.");
            closeWaiting();
            return false;
        }
        var boxTokenInfo = CloudConnectionData.BoxData.accessToken;
        var accTokenInfo = eval("(function(){return " + boxTokenInfo + ";})()");
        var accToken = accTokenInfo.AccessTokenInfo.access_token;
        accToken = 'Bearer ' + accToken;
        //var url = 'https://api.box.com/2.0/files/' + linkedFile.CloudStorage_ID + '/content';
        var url = 'https://api.box.com/2.0/files/' + linkedFile.CloudStorage_ID + '?fields=download_url'
        $.ajax(url,
            {
                type: 'GET',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', accToken);
                    xhr.setRequestHeader('Accept', 'application/json');
                },
                contentType: "application/json; charset=utf-8",
                async: true,
                success: function (data, status, xhr) {
                    if (data != null) {
                        var downloadUrl = data.download_url;
                        var req = new XMLHttpRequest();
                        req.open('GET', downloadUrl, true);
                        req.onreadystatechange = function () {
                            if (req.readyState === 4 && req.status == 200) {
                                if (action == ACTION.DOWNLOAD) {
                                    downloadFileInBrowser(downloadUrl);
                                } else if (action === ACTION.OPEN) {
                                    var blobopen = new Blob([req.response], { type: linkedFile.MimeType });
                                    openBlob(blobopen, linkedFile.FileName, blobopen.type);
                                } else if (action === ACTION.VIEW) {
                                    var blobview = new Blob([req.response], { type: linkedFile.MimeType });
                                    viewBlob(blobview, linkedFile.FileName, blobview.type, dataSource);
                                    setFileAttributes(linkedFile);
                                }
                                closeWaiting();
                            }
                        };
                        req.setRequestHeader('Accept', 'application/json');
                        req.setRequestHeader('Access-Control-Allow-Credentials', true);
                        req.setRequestHeader('Authorization', 'Bearer ' + accToken);
                        req.responseType = "arraybuffer";
                        req.send();
                    }
                },
                error: function (xhr, status, error) {
                    if (xhr.status == 401 || xhr.status == 0) {
                        boxRefreshToken().then(function (boxRefreshToken) {
                            if (boxRefreshToken != null) {
                                getFileFromBox(linkedFile, action);
                            }
                        });
                    } else if (xhr.status == 404) {
                        showAlertDialog("File Not Found on Box Cloud Storage");
                        closeWaiting();
                    }
                }
            });

    });
}

// BOX FILE DOWNLOAD SECTION
function downloadFromBox(linkedFile, TOKEN) {
    var FILE_ID = linkedFile.CloudStorage_ID;
    var FIELD_DOWNLOAD_URL = "download_url";
    //var URL = 'https://api.box.com/2.0/files/${FILE_ID}?fields=${FIELD_DOWNLOAD_URL}';
    var URL = 'https://api.box.com/2.0/files/' + FILE_ID + '?fields=' + FIELD_DOWNLOAD_URL;

    fetch(URL, { headers: { Authorization: 'Bearer ' + TOKEN } })
        .then(function (response) {
            return response.json();
        }).then(function (data) {
            closeWaiting();
            openUrlInsideIframe(data[FIELD_DOWNLOAD_URL]);
        });
}

function downloadFileInBrowser(downloadUrl) {

    openUrlInsideIframe(downloadUrl);
}

// BOX DELETE FILE OPERATION ,CALLING FROM linked-file.js
function DeleteFromCloudStorage(CloudStorage_ID) {
    return new Promise(function (resolve, reject) {
        var boxTokenInfo = CloudConnectionData.BoxData.accessToken;
        var accTokenInfo = eval("(function(){return " + boxTokenInfo + ";})()");
        var accToken = accTokenInfo.AccessTokenInfo.access_token;
        $.ajax('https://api.box.com/2.0/files/' + CloudStorage_ID,
            {
                type: 'DELETE',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + accToken);
                    xhr.setRequestHeader('Accept', 'application/json');
                },
                async: "false",
                success: function (data, status, xhr) {
                    resolve(xhr.status);

                },
                error: function (xhr, status, error) {
                    resolve(xhr.status);
                    // GET REFRESH TOKEN 
                    if (xhr.status == 0) {
                        boxRefreshToken().then(function (boxRefreshToken) {
                            if (boxRefreshToken != null) {
                                DeleteFromCloudStorage(CloudStorage_ID);
                            }
                        })
                    } else if (xhr.status == 404) {
                        reject(xhr.status);
                        closeWaiting();
                    }
                }
            });
    });
}

// BOX DOWNLOAD INTERMEDIATE FUNCTION
function createDownloadIframe() {
    //var iframe = document.querySelector('#boxdownloadiframe'); //Hinders mutiselect download
    //if (!iframe) {
    // if no existing iframe create a new one
    var iframe = document.createElement('iframe');
    //iframe.setAttribute('id', 'boxdownloadiframe');
    iframe.style.display = 'none';
    if (document.body) {
        document.body.appendChild(iframe);
    }
    //}
    // Clean the iframe up
    iframe.contentDocument.write('<head></head><body></body>');
    return iframe;
}

// BOX DOWNLOAD INTERMEDIATE FUNCTION
function openUrlInsideIframe(url) {
    var iframe = createDownloadIframe();
    iframe.src = url;
    return iframe;
}

// BOX  CHECK BQE Core Attachments FOLDER IS AVAILABLE 
function getUploadFolderOnBox(accToken, file, isTokenRefreshed) {
    var callbackAfterUploadComplete = ($(".jsAddAttachment").length > 0 && $(".jsAddAttachment").data('afterfileuploadcomplete').length > 0) ? $(".jsAddAttachment").data('afterfileuploadcomplete') : $("#add-attachment").data('afterfileuploadcomplete');
    return new Promise(function (resolve, reject) {
        // NEED TO UPGRADE FOR PERFORMANCE ISSUES
        /*var xhr = new XMLHttpRequest();
        xhr.open('GET', 'https://api.box.com/2.0/folders/0', true);
        xhr.setRequestHeader('Authorization', 'Bearer ' + accToken);
        xhr.setRequestHeader('Accept', 'application/json');
        //xhr.responseType = 'arraybuffer';
        xhr.onload = function (e) {
            if (this.status == 200) {
                var bqeFolderAvailable = null;
                var data = JSON.parse(xhr.responseText);
                var folderList = data.item_collection.entries;
                for (var i = 0; i < folderList.length; i++) {
                    if (folderList[i].name == 'BQE Core Attachments') {
                        //resolve(folderList[i]);
                        bqeFolderAvailable = folderList[i];
                        break;
                    }
                }
                resolve(bqeFolderAvailable);
            }
            else if (!isTokenRefreshed){
                //  GET BOX REFRESHED TOKEN
                boxRefreshToken().then(function (boxRefreshToken) {
                    if (boxRefreshToken != null) {
                        var objBoxJSON = eval("(function(){return " + boxRefreshToken + ";})()");
                        getUploadFolderOnBox(objBoxJSON.AccessTokenInfo.access_token, file, true).then(function (folder) {
                            if (folder != null) {
                                resolve(folder);
                                //return false;
                            }
                        });

                    } else {
                        return false;
                    }
                });
            }
        };
        xhr.send();
        return false;*/
        $.ajax('https://api.box.com/2.0/folders/0',
            {
                type: 'GET',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + accToken);
                    xhr.setRequestHeader('Accept', 'application/json');
                },
                async: true,
                success: function (data, status, xhr) {
                    // SEARCH FOR THE BOX FOLDER
                    var bqeFolderAvailable = null;
                    var folderList = data.item_collection.entries;
                    for (var i = 0; i < folderList.length; i++) {
                        if (folderList[i].name == 'BQE Core Attachments') {
                            //resolve(folderList[i]);
                            bqeFolderAvailable = folderList[i];
                            break;
                        }
                    }
                    resolve(bqeFolderAvailable);
                },
                error: function (xhr, status, error) {
                    //  GET BOX REFRESHED TOKEN
                    boxRefreshToken().then(function (boxRefreshToken) {
                        if (boxRefreshToken != null) {
                            /*startupload(file, 'box').then(function (linkedFile) {
                                // UPDATE THE DATABASE
                                FileUpload = { TotalFiles: selFiles.length, Uploaded: 0, Failed: 0, LinkedFiles: [] };
                                if (linkedFile != null) {
                                    FileUpload.Uploaded += 1;
                                    FileUpload.LinkedFiles.push(linkedFile);
                                } else {
                                    FileUpload.Failed += 1;
                                }
                                if (FileUpload.Uploaded + FileUpload.Failed == FileUpload.TotalFiles) {
                                    postLinkedFiles(FileUpload.LinkedFiles, callbackAfterUploadComplete);
                                }
                            }, function (error) {
                                FileUpload.Failed += 1;
                                if (FileUpload.Uploaded + FileUpload.Failed == FileUpload.TotalFiles) {
                                    postLinkedFiles(FileUpload.LinkedFiles, callbackAfterUploadComplete);
                                }
                                ErrorNotification(error);
                            });*/

                            var objBoxJSON = eval("(function(){return " + boxRefreshToken + ";})()");
                            getUploadFolderOnBox(objBoxJSON.AccessTokenInfo.access_token, file).then(function (folder) {
                                if (folder != null) {
                                    resolve(folder);
                                    //return false;
                                }
                            });


                        } else {
                            return false;
                        }
                    });
                }
            });

    });

}

// BOX FOLDER CREATION SECTION.
function createUploadFolderOnBox(file) {
    return new Promise(function (resolve, reject) {
        var boxTokenInfo = CloudConnectionData.BoxData.accessToken;
        var objJSON = eval("(function(){return " + boxTokenInfo + ";})()");
        var accessToken = objJSON.AccessTokenInfo.access_token;

        getUploadFolderOnBox(accessToken, file).then(function (folder) {
            if (folder != null) {
                resolve(folder);
                return false;
            } else {
                /*$.ajax('https://api.box.com/2.0/folders',
                    {
                        data: JSON.stringify({ name: 'BQE Core Attachments', parent: { id: '0' } }),
                        type: 'POST',
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + accessToken);
                        },
                        contentType: 'json',
                        success: function (data, status, xhr) {
                            resolve(data);
                        },
                        error: function (xhr, status, error) {
                            //chk to refresh
                            var i = xhr;
                            reject(error);
                            closeWaiting();

                        }
                    });*/
                var http = new XMLHttpRequest();
                var url = 'https://api.box.com/2.0/folders';
                var params = JSON.stringify({
                    name: 'BQE Core Attachments',
                    parent: { id: '0' }
                });
                http.open('POST', url, true);
                http.setRequestHeader('Authorization', 'Bearer ' + accessToken);
                http.setRequestHeader('Content-type', 'application/json');
                http.onreadystatechange = function () {
                    if (http.readyState == 4) {
                        if (http.status === 200 || http.status === 201) {
                            resolve(http.responseText);
                        }
                        else {
                            var errorMessage = http.response || 'Unable to create directory on box drive';
                            reject(errorMessage);
                        }
                    }
                }
                http.send(params);

            }
        });

    });
}

// BOX VERSION FILE UPLOAD
function boxVersionUpload(formData, accessToken, versionFileId) {
    return new Promise(function (resolve, reject) {
        /*var uploadVersionUrl = 'https://upload.box.com/api/2.0/files/' + versionFileId + '/content';
        // The Box OAuth 2 Header. Add your access token.
        var headers = {
            Authorization: 'Bearer ' + accessToken,
        };
        $.ajax({
            url: uploadVersionUrl,
            headers: headers,
            type: 'POST',
            processData: false,
            contentType: false,
            data: formData
        }).complete(function (data) {
            var fileInfo = JSON.parse(data.responseText);
            if (fileInfo.total_count != undefined && fileInfo.total_count != 0) {
                SuccessNotification("File " + fileInfo.entries[0].name + " with new version Uploaded Sucessfully");
                closeWaiting();
                resolve(fileInfo);
            }
            else {
                var errorMessage = data.responseText || 'Unable to upload new version file';
                reject("ERROR");
            }
            // resolve(fileInfo);
            })*/

        var uploadVersionUrl = 'https://upload.box.com/api/2.0/files/' + versionFileId + '/content';

        var xhr = new XMLHttpRequest()
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {

                var fileInfo = JSON.parse(xhr.responseText);

                if (xhr.status == 201) {
                    var fileInfo = JSON.parse(data.responseText);
                    if (fileInfo.total_count != undefined && fileInfo.total_count != 0) {
                        SuccessNotification("File " + fileInfo.entries[0].name + " with new version Uploaded Sucessfully");
                        closeWaiting();
                        resolve(fileInfo);
                    }
                    else {
                        var errorMessage = data.responseText || 'Unable to upload new version file';
                        reject("ERROR");
                    }
                } else {

                    var errorMessage = data.responseText || 'Unable to upload new version file';
                    reject("ERROR");

                }

            }
        }
        xhr.open('POST', uploadVersionUrl, true)
        xhr.setRequestHeader('Authorization', 'Bearer ' + accessToken)
        xhr.send(formData);

    });
}
/////////////////  BOX FILE OPERATIONS END  ///////////////////////////

///////////////// BOX TOKEN HANDLING START////////////////////////////
// BOX GET REFRESH TOKEN FROM ENDPOINT.
function boxRefreshToken() {

    return new Promise(function (resolve, reject) {


        var boxTokenInfo = CloudConnectionData.BoxData.accessToken;
        var tokenInfo = eval("(function(){return " + boxTokenInfo + ";})()");
        var refreshToken = tokenInfo.AccessTokenInfo.refresh_token;
        //var token = tokenInfo.AccessTokenInfo.access_token;

        var clientId = tokenInfo.ConsumerInfo.Token;
        var clientSecretKey = tokenInfo.ConsumerInfo.Secret;

        var form = new FormData();
        form.append("grant_type", "refresh_token");
        form.append("refresh_token", refreshToken);
        form.append("client_id", clientId);
        form.append("client_secret", clientSecretKey);

        var settings = {
            "async": true,
            "crossDomain": true,
            "url": "https://api.box.com/oauth2/token",
            "method": "POST",
            "headers": {
                "Cache-Control": "no-cache",
            },
            "processData": false,
            "contentType": false,
            "mimeType": "multipart/form-data",
            "data": form
        }

        $.ajax(settings)
        .done(function (response) {
            if (response != "") {//refreshed successfully
                updateBoxToken(response).then(function (updateToken) {
                    if (updateToken != null && updateToken.IsSuccessStatusCode) {
                        resolve(updateToken.Response.AccessToken);
                    }
                });
            }

        })
        .fail(function (response) {
            var responseObject = eval("(function(){return " + response.responseText + ";})()");
            if (((responseObject.error_description.indexOf("Refresh token has expired") >= 0) || (responseObject.error_description.indexOf("Invalid refresh token") >= 0)) && (responseObject.error.indexOf("invalid_grant") >= 0)) {
                showAlertDialog("Your Box credentials have expired. Please connect to your Box storage again in Global settings!");
            }
            closeWaiting();
            reject(response);
        });
    });
}

// BOX UPDATE TOKEN  TO DATABASE
function updateBoxToken(refreshResponse) {
    return new Promise(function (resolve, reject) {
        var type = 10, alias = "";
        var appendUrl = "api/ThirdPartySetting/GetStorage?type=" + type + "&alias=" + alias;
        var _url = GetBaseURL() + "Json/GetItem?url=" + encodeURIComponent(appendUrl);
        ajaxCall({
            url: _url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            showWaiting: false,
            type: "GET",
            success: function (response) {
                if (response != null) {
                    var thirdPartyStorageObject = response[0];
                    var boxTokenInfo = thirdPartyStorageObject.AccessToken;
                    var objJSON = eval("(function(){return " + boxTokenInfo + ";})()");
                    objJSON.AccessTokenInfo = JSON.parse(refreshResponse);
                    thirdPartyStorageObject.AccessToken = JSON.stringify(objJSON);
                    var data = JSON.stringify(thirdPartyStorageObject);
                    var _url = GetBaseURL() + "Json/PutObjectGlobalization?url=api/ThirdPartySetting/PutThirdPartySetting&module=ThirdPartySetting";
                    ajaxCall({
                        url: _url,
                        data: data,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        type: "PUT",
                        success: function (response) {
                            if (response != null) {
                                if (response.IsSuccessStatusCode) {
                                    var boxTokenInfo = CloudConnectionData.BoxData.accessToken;
                                    var objJSON = eval("(function(){return " + boxTokenInfo + ";})()");
                                    objJSON.AccessTokenInfo = response.Response.AccessToken;
                                    CloudConnectionData.BoxData.accessToken = objJSON.AccessTokenInfo;
                                    localStorage.removeItem("CloudConnectionData");
                                    setObjectInLocalStorage("CloudConnectionData", CloudConnectionData);
                                    resolve(response);
                                } else {
                                    resolve(response);
                                    ErrorNotification(response.Error.Message);
                                }
                            }
                        }
                    });
                }

            }
        });
    });
}
///////////////////// BOX TOKEN HANDLING END

///ONEDRIVE INTEGRATION START////
var oneDriveBaseEndpoint = "https://graph.microsoft.com";
var IstokenRefreshed = false;
var accessToken_afterRefresh = "";

function createUploadFolderOnOneDrive(file) {
    return new Promise(function (resolve, reject) {
        var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
        var objOneDriveData = eval("(function(){return " + oneDriveTokenInfo + ";})()");
        var objJSON = eval("(function(){return " + objOneDriveData.AccessTokenInfo + ";})()");
        var accessToken = objJSON.access_token;

        getUploadFolderOnOneDrive(accessToken, file).then(function (folder) {

            if (folder != null) {
                resolve(folder);
            }
            else {
                var body = {
                    "name": "BQE Core Attachments",
                    "folder": {},
                    "@microsoft.graph.conflictBehavior": "rename"
                };
                //Execute POST request to get the UploadSession.
                $.ajax({
                    type: "POST",
                    url: oneDriveBaseEndpoint + "/v1.0/me/drive/root/children",
                    headers: { "Accept": "application/json, text/plain, */*", "Content-Type": "application/json", "Authorization": "Bearer " + accessToken },
                    data: JSON.stringify(body)

                }).done(function (response) {
                    console.log(response);
                    resolve(response);
                }).fail(function (response) {
                    var msgErr = "Could not create folder for uploading files: " + response.responseText;
                    console.log(msgErr);
                    reject(msgErr);
                    closeWaiting();
                });

            }
        });

    });
}

function getUploadFolderOnOneDrive(accToken, file) {
    var callbackAfterUploadComplete = ($(".jsAddAttachment").length > 0 && $(".jsAddAttachment").data('afterfileuploadcomplete').length > 0) ? $(".jsAddAttachment").data('afterfileuploadcomplete') : $("#add-attachment").data('afterfileuploadcomplete');
    return new Promise(function (resolve, reject) {

        //Execute GET request to get the folder id.
        $.ajax({
            type: "GET",
            url: oneDriveBaseEndpoint + encodeURIComponent("/v1.0/me/drive/root:/BQE Core Attachments"),
            headers: { "Accept": "application/json, text/plain, */*", "Content-Type": "application/json", "Authorization": "Bearer " + accToken },
        }).done(function (response) {
            console.log(response);
            resolve(response);
        }).fail(function (response) {
            var msgErr = "Could not get folder for uploading files: " + response.responseText;
            console.log(msgErr);
            var responseJSON = eval("(function(){return " + response.responseText + ";})()");
            if (response.status == 404) { //(responseJSON.error.code === "itemNotFound") {
                //resolve(response);   // resolve doesn't work in fail
                var body = {
                    "name": "BQE Core Attachments",
                    "folder": {},
                    "@microsoft.graph.conflictBehavior": "rename"
                };
                //Execute POST request to get the UploadSession.
                $.ajax({
                    type: "POST",
                    url: oneDriveBaseEndpoint + "/v1.0/me/drive/root/children",
                    headers: { "Accept": "application/json, text/plain, */*", "Content-Type": "application/json", "Authorization": "Bearer " + accToken },
                    data: JSON.stringify(body)

                }).done(function (response) {
                    console.log(response);
                    resolve(response);
                }).fail(function (response) {
                    var msgErr = "Could not create folder for uploading files: " + response.responseText;
                    console.log(msgErr);
                    reject(msgErr);
                    closeWaiting();
                });
            }
            else if (response.status == 401) { // unauthorized token or token expired
                oneDriveRefreshToken().then(function (odRefreshToken) {
                    if (odRefreshToken != null) {
                        var objRefresh = odRefreshToken.AccessTokenInfo == undefined ? eval("(function(){return " + odRefreshToken + ";})()") : odRefreshToken;
                        var tokenInfo = objRefresh.AccessTokenInfo.access_token == undefined ? eval("(function(){return " + objRefresh.AccessTokenInfo + ";})()") : objRefresh.AccessTokenInfo;
                        IstokenRefreshed = true;
                        accessToken_afterRefresh = tokenInfo.access_token;
                        //getUploadFolderOnOneDrive(tokenInfo.access_token, file).then(folder => resolve(folder));
                        getUploadFolderOnOneDrive(tokenInfo.access_token, file).then(function (folder) {
                            if (folder != undefined) {
                                resolve(folder);
                            } else {
                                reject(folder);
                            }
                        });
                    }
                });
            }
            else
                reject(msgErr);
            closeWaiting();
        });

    });

}

function clearSpecialSymbolsInFileName(fileName) {
    return fileName.replace(/[%]/g, "");
}

function getOneDriveFileUploadSession(file, token, fileName, current) {
    return new Promise(function (resolve, reject) {
        console.log("getUploadSession method called::");
        showNonModalWaiting("Uploading files");

        var i = file.name.lastIndexOf(".");
        var fileType = file.name.substring(i + 1);
        var name = file.name.substring(0, i);
        var body = {
            "item": {
                "@microsoft.graph.conflictBehavior": "rename"
            }
        };
        //Execute POST request to get the UploadSession.

        $.ajax({
            type: "POST",
            url: oneDriveBaseEndpoint + "/v1.0/me/drive/root:/" + encodeURIComponent(CloudConnectionData.OneDriveData.cloudFileBasePath) + "/" + fileName + ":/createUploadSession",
            headers: { "Accept": "application/json, text/plain, */*", "Content-Type": "application/json", "Authorization": "Bearer " + token },
            body: body

        }).done(function (response) {
            console.log("Successfully got upload session.");
            console.log(response);

            var uploadUrl = response.uploadUrl;
            uploadChunks(file, uploadUrl, token).then(function (data) {
                if (data != undefined) {
                    resolve(data);
                } else {
                    reject(data);
                }
            });

        }).fail(function (response) {

            if (response.status == 401) { // unauthorized token or token expired
                oneDriveRefreshToken().then(function (odRefreshToken) {
                    if (odRefreshToken != null) {
                        var objRefresh = odRefreshToken.AccessTokenInfo == undefined ? eval("(function(){return " + odRefreshToken + ";})()") : odRefreshToken;
                        var tokenInfo = objRefresh.AccessTokenInfo.access_token == undefined ? eval("(function(){return " + objRefresh.AccessTokenInfo + ";})()") : objRefresh.AccessTokenInfo;
                        IstokenRefreshed = true;
                        accessToken_afterRefresh = tokenInfo.access_token;

                        getOneDriveFileUploadSession(file, tokenInfo.access_token, fileName, current).then(function (data) {

                            if (data.status != 409) { // 409 FILE CONFLICT FOR FILE VERSIONING
                                resolve(data);
                                /*var odFile = data.json;
                                if (odFile != undefined) {
                                    /*var linkedFile = { FileURL: odFile.webUrl, FileName: odFile.name, CloudStorage_ID: odFile.id, StorageType: ThirdPartySettings.OneDrive, Length: odFile.size, Description: getFileDescription(current) };
                                    resolve(linkedFile);#/
                                    //return false;
                                    resolve(odFile);
                                }
                                else {
                                    var errorMessage = data.responseText || 'Unable to upload file';
                                    reject(Error(errorMessage));
                                }*/
                            } else {
                                // HANDLE FILE VERSION HANDLING IF EXIST
                            }
                        });


                    }
                });
            }
            else {
                console.log("Could not get upload session: " + response.responseText);
                //reject(response.responseText);
            }
        });
    });

}

function createFileShareableLink(fileData, token) {
    return new Promise(function (resolve, reject) {
        var http = new XMLHttpRequest();
        var url = 'https://graph.microsoft.com/v1.0/me/drive/items/' + fileData.OneDriveFileId + '/createLink';
        var params = JSON.stringify({
            type: "view",
            scope: "anonymous"
        });
        http.open('POST', url, true);

        http.setRequestHeader('Authorization', 'Bearer ' + token);
        http.setRequestHeader('Content-type', 'application/json');

        http.onreadystatechange = function () {
            if (http.readyState == 4) {
                if (http.status === 200 || http.status === 201) {
                    var fileInfo = JSON.parse(http.responseText);
                    fileData.ShareableLink = fileInfo.link.webUrl;
                    resolve(fileData);
                }
                else {
                    var errorMessage = http.response || 'Unable to get link';
                    //reject(errorMessage);
                    //showAlertDialog(errorMessage);
                    resolve(null);
                }

            }
        }
        http.send(params);

    });
}


function uploadChunks(file, uploadUrl, token) {
    return new Promise(function (resolve, reject) {
        var reader = new FileReader();

        // Variables for byte stream position
        var position = 0;
        var chunkLength = 320 * 1024;
        console.log("File size is: " + file.size);

        //Upload file to Onedrive
        //uploadRecursively(position, chunkLength, file, uploadUrl, token).then(data => (data != undefined ? resolve(data) : reject(data)));
        uploadRecursively(position, chunkLength, file, uploadUrl, token).then(function (data) {
            if (data != undefined) {
                resolve(data);
            } else {
                reject(data);
            }
        });
    });
}

function uploadRecursively(position, chunkLength, file, uploadUrl, token) {
    return new Promise(function (resolve, reject) {
        try {

            //Try to read in the chunk
            try {

                var stopByte = position + chunkLength;
                console.log("Sending Asynchronous request to read in chunk bytes from position " + position + " to end " + stopByte);

                readFragmentAsync(file, position, stopByte).then(function (chunk) {

                    if (chunk != null) {

                        console.log("UploadChunks: Chunk read in of " + chunk.byteLength + " bytes.");

                        if (chunk.byteLength > 0) {

                            // Try to upload the chunk.
                            try {

                                console.log("Request sent for uploadFragmentAsync");

                                uploadChunk(chunk, uploadUrl, position, file.size).then(function (res) {

                                    if (res != null) {

                                        // Check the response.
                                        if (res.status !== 202 && res.status !== 201 && res.status !== 200)
                                            throw ("Put operation did not return expected response");

                                        if (res.status === 201 || res.status === 200) {
                                            console.log("Reached last chunk of file.  Status code is: " + res.status);
                                            resolve(res);
                                        }
                                        else {
                                            console.log("Continuing - Status Code is: " + res.status);
                                            position = Number(res.json.nextExpectedRanges[0].split('-')[0]);
                                            console.log("Successful response received from uploadChunk.");
                                            console.log("Position is now " + position);

                                            //Upload next chunk of data to onedrive recursively
                                            //uploadRecursively(position, chunkLength, file, uploadUrl, token).then(data => (data != undefined ? resolve(data) : reject(data)));
                                            uploadRecursively(position, chunkLength, file, uploadUrl, token).then(function (data) {
                                                if (data != undefined) {
                                                    resolve(data);
                                                } else {
                                                    reject(data);
                                                }
                                            });

                                        }

                                    }

                                });

                            }
                            catch (e) {
                                console.log("Error occured when calling uploadChunk::" + e);
                                closeWaiting();
                                reject(e);
                            }

                        }

                        else {
                            closeWaiting();
                            reject(null);
                        }
                        console.log("Chunk bytes received = " + chunk.byteLength);

                    }

                });


            }
            catch (e) {
                console.log("Bytes Received from readFragmentAsync:: " + e);
                closeWaiting();
                reject(e);
            }

        }

        catch (e) {
            closeWaiting();
            reject(e);
        }
        //closeWaiting();
    });
}

// Reads in the chunk and returns a promise.
function readFragmentAsync(file, startByte, stopByte) {

    try {
        var frag = "";
        var reader = new FileReader();
        console.log("startByte :" + startByte + " stopByte :" + stopByte);
        var blob = file.slice(startByte, stopByte);
        reader.readAsArrayBuffer(blob);
        return new Promise(function (resolve, reject) {
            reader.onloadend = function (event) {
                console.log("onloadend called  " + reader.result.byteLength);
                if (reader.readyState === reader.DONE) {
                    frag = reader.result;
                    resolve(frag);
                }
            };
            reader.onerror = function (ev) {
                console.log("file reader " + ev.message);
                reject("file reader " + ev.message);
            };
        });
    }
    catch (e) {
        console.log(e.message);
        reject(e.message);
    }
}
function getFilesListFromOneDrive(token) {

    console.log("Fetching files using Graph API");

    //Execute GET request to Files API.
    //Refer to the API reference for more information: https://msdn.microsoft.com/en-us/office/office365/api/files-rest-operations
    $.ajax({
        type: "GET",
        //url: oneDriveBaseEndpoint + "/_api/v1.0/me/files",
        url: oneDriveBaseEndpoint + "/v1.0/me/drive/root/children",
        headers: { "Authorization": "Bearer " + token }

    }).done(function (response) {
        console.log("Successfully fetched files from OneDrive.");
        console.log(response);

        response.value.forEach(function (item) {
            var typeVal = item["folder"] ? "Folder" : "File";
        });

    }).fail(function () {
        console.log("Fetching files from OneDrive failed.");
    });
}

function uploadChunk(chunk, uploadURL, position, totalLength) {
    var max = position + chunk.byteLength - 1;
    //var contentLength = position + chunk.byteLength;
    //var results = {};
    console.log("Chunk size is: " + chunk.byteLength + " bytes.");

    return new Promise(function (resolve, reject) {
        console.log("uploadURL:: " + uploadURL);

        try {
            console.log('Just before making the PUT call to uploadUrl.');
            var crHeader = "bytes " + position + "-" + max + "/" + totalLength;
            //Execute PUT request to upload the content range.
            $.ajax({
                type: "PUT",
                contentType: "application/octet-stream",
                url: uploadURL,
                data: chunk,
                processData: false,
                headers: { "Content-Range": crHeader }

            }).done(function (data, textStatus, jqXHR) {
                console.log("Content-Range header being set is : " + crHeader);
                if (jqXHR.responseJSON.nextExpectedRanges) {
                    console.log("Next Expected Range is: " + jqXHR.responseJSON.nextExpectedRanges[0]);
                }
                else {
                    console.log("We've reached the end of the chunks.")
                }

                results = {};
                results.status = jqXHR.status;
                results.json = jqXHR.responseJSON;
                resolve(results);

            }).fail(function (response) {
                console.log("Could not upload chunk: " + response.responseText);
                console.log("Content-Range header being set is : " + crHeader);

            });
        } catch (e) {
            console.log("exception inside uploadChunk::  " + e);
            reject(e);
        }
    });
}

function CheckOneDriveType(accessToken) {

    return new Promise(function (resolve, reject) {

        var url = 'https://graph.microsoft.com/v1.0/me/drive/';
        $.ajax(url, {
            type: 'GET',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', accessToken);
                xhr.setRequestHeader('Accept', 'application/json');
            },
            contentType: "application/json; charset=utf-8",
            async: true,
            success: function (drive, status, xhr) {
                resolve(drive);
            },
            error: function (xhr, status, error) {
                if (xhr.status == 401 || xhr.status == 0) {
                    oneDriveRefreshToken().then(function (odRefreshToken) {
                        if (odRefreshToken != null) {
                            var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
                            var objOneDriveData = eval("(function(){return " + oneDriveTokenInfo + ";})()");
                            var tokenInfo = eval("(function(){return " + objOneDriveData.AccessTokenInfo + ";})()");
                            var accessToken = tokenInfo.access_token;
                            //CheckOneDriveType(accessToken);

                            CheckOneDriveType(accessToken).then(function (drive) {
                                if (drive != null) {
                                    resolve(drive);
                                }
                            });


                        }
                    });
                }
                else if (xhr.status == 404) {
                    showAlertDialog("File Not Found on One Drive Cloud Storage");
                    closeWaiting();
                }
                //closeWaiting();
            }
        });
    });
}

function getFileFromOneDrive(linkedFile, action, dataSource) {

    if (CloudConnectionData.OneDriveData == null) {
        showAlertDialog("That didn't work. Please check if you have an active One Drive connection in Core Global settings.");
        closeWaiting();
        return false;
    }

    var mimeType = linkedFile.MimeType;
    var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
    var objOneDriveData = eval("(function(){return " + oneDriveTokenInfo + ";})()");
    var tokenInfo = eval("(function(){return " + objOneDriveData.AccessTokenInfo + ";})()");
    var accessToken = tokenInfo.access_token;
    //var url = 'https://graph.microsoft.com/v1.0/drive/items/' + linkedFile.CloudStorage_ID;
    var url = 'https://graph.microsoft.com/v1.0/drives/';

    CheckOneDriveType(accessToken).then(function (drive) {

        if (drive != null) {

            driveId = drive.id;
            driveType = drive.driveType;

            url += driveId + '/items/' + linkedFile.CloudStorage_ID;

            return new Promise(function (resolve, reject) {

                $.ajax(url, {
                    type: 'GET',
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', accessToken);
                        xhr.setRequestHeader('Accept', 'application/json');
                    },
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    success: function (data, status, xhr) {
                        if (data != null) {

                            if (typeof mimeType === 'undefined' || mimeType === null)
                                mimeType = data.file.mimeType;
                            var downloadUrl = data["@microsoft.graph.downloadUrl"];

                            if (driveType == "business") {

                                if (action === ACTION.DOWNLOAD) {
                                    downloadFileInBrowser(downloadUrl);

                                }
                                else {

                                    if (dataSource != undefined && dataSource.toLowerCase() == 'hrforms') {

                                        $("#jsfileDownload,.jsfileDownload").attr("download", linkedFile.FileName);
                                        if (linkedFile.FileName.search("jpeg") < 0 && linkedFile.FileName.search("jpg") < 0 && linkedFile.FileName.search("gif") < 0 && linkedFile.FileName.search("png") < 0 && linkedFile.FileName.search("pdf") < 0) {

                                            $('.jsobjectDiv').addClass('hidden');
                                            $('.jsNoPreviewDiv').removeClass('hidden');
                                        } else {
                                            $('.jsNoPreviewDiv').addClass('hidden');
                                            $('.jsobjectDiv').removeClass('hidden');
                                            $(".jsfileDownload").attr("href", downloadUrl);

                                            if (linkedFile.FileName.search("pdf") > 0) { // for pdf we need to show that in Object tag
                                                $('.fileObj').css('display', 'block');
                                                $('.jsNoPreviewDiv').removeClass('hidden');
                                                $('.fileObj').attr('data', downloadUrl);
                                                $('.fileImgObj').css("display", 'none');
                                                $('.jsobjectDiv').addClass('hidden');
                                            }
                                            else { // img for image files
                                                $('.fileImgObj').css("display", 'block');
                                                $('.fileObj').css('display', 'none');
                                                $('.fileImgObj').attr("src", downloadUrl);


                                            }
                                        }
                                        $("#jsOptionfileDownload").attr("href", downloadUrl).attr("target", "_blank");


                                    }
                                    else {
                                        $(".fileViewer").attr('src', downloadUrl);
                                        showDialog('#show-attachment-modal');
                                        setFileAttributes(linkedFile);
                                    }
                                }

                                closeWaiting();
                            }
                            else {
                                var req = new XMLHttpRequest();
                                req.open('GET', downloadUrl, true);
                                req.onreadystatechange = function () {
                                    if (req.readyState === 4 && req.status == 200) {
                                        if (action == ACTION.DOWNLOAD) {
                                            downloadFileInBrowser(downloadUrl);
                                        } else if (action === ACTION.OPEN) {
                                            var blobopen = new Blob([req.response], { type: linkedFile.MimeType });
                                            openBlob(blobopen, linkedFile.FileName, blobopen.type);
                                        } else if (action === ACTION.VIEW) {
                                            var blobview = new Blob([req.response], { type: mimeType });
                                            viewBlob(blobview, linkedFile.FileName, blobview.type, dataSource);
                                            setFileAttributes(linkedFile);
                                        }
                                        closeWaiting();
                                    }
                                };
                                req.setRequestHeader('Accept', 'application/json');
                                req.setRequestHeader('Authorization', 'Bearer ' + accessToken);
                                //req.setRequestHeader('Access-Control-Allow-Origin', '*');
                                //req.setRequestHeader('Access-Control-Allow-Credentials', 'true');
                                req.responseType = "arraybuffer";
                                req.send();
                            }
                        }
                    },
                    error: function (xhr, status, error) {
                        if (xhr.status == 401 || xhr.status == 0) {
                            oneDriveRefreshToken().then(function (odRefreshToken) {
                                if (odRefreshToken != null) {
                                    getFileFromOneDrive(linkedFile, action);
                                }
                            });
                        }
                        else if (xhr.status == 404) {
                            showAlertDialog("File Not Found on One Drive Cloud Storage");
                            closeWaiting();
                        }
                    }
                });
            });
        }
    });
}

function oneDriveRefreshToken() {

    return new Promise(function (resolve, reject) {

        var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
        var objOneDriveData = oneDriveTokenInfo.AccessTokenInfo == undefined ? eval("(function(){return " + oneDriveTokenInfo + ";})()") : oneDriveTokenInfo;
        var tokenInfo = objOneDriveData.AccessTokenInfo.access_token == undefined ? eval("(function(){return " + objOneDriveData.AccessTokenInfo + ";})()") : objOneDriveData.AccessTokenInfo;
        var accessToken = tokenInfo.access_token;
        var refreshToken = tokenInfo.refresh_token;
        var clientId = objOneDriveData.ConsumerInfo.Token;
        var clientSecretKey = objOneDriveData.ConsumerInfo.Secret;

        ajaxCall({
            type: "POST",
            dataType: 'html',
            contentType: "text/json",
            url: GetBaseURL() + "GlobalSetting/RedeemOneDriveAccessToken?refreshToken=" + refreshToken,

            error: function (jqXHR, exception) {
                if (jqXHR.status === 0) {
                    showAlertDialog('Not connected Verify Network.');
                } else if (jqXHR.status == 404) {
                    showAlertDialog('Requested page not found. [404]');
                } else if (jqXHR.status == 500) {
                    showAlertDialog('Internal Server Error [500].');
                } else if (exception === 'parsererror') {
                    showAlertDialog('Requested JSON parse failed.');
                } else if (exception === 'timeout') {
                    showAlertDialog('Time out error.');
                } else if (exception === 'abort') {
                    showAlertDialog('Ajax request aborted.');
                } else {
                    showAlertDialog('Uncaught Error.n' + jqXHR.responseText);
                }
            }

        }).done(function (response, textStatus) {
            if (response != "") {//refreshed successfully
                updateOneDriveToken(response).then(function (updateToken) {
                    if (updateToken != null && updateToken.IsSuccessStatusCode) {
                        resolve(updateToken.Response.AccessToken);
                    }
                });
            }
            return;
        });


    });
}

function updateOneDriveToken(refreshResponse) {

    return new Promise(function (resolve, reject) {

        var type = 5, alias = "";
        var appendUrl = "api/ThirdPartySetting/GetStorage?type=" + type + "&alias=" + alias;
        var _url = GetBaseURL() + "Json/GetItem?url=" + encodeURIComponent(appendUrl);
        ajaxCall({
            url: _url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            showWaiting: false,
            type: "GET",
            success: function (response) {
                if (response != null) {

                    saveUpdatedOneDriveToken(refreshResponse, response).then(function (response) {
                        if (response != null) {
                            resolve(response);
                        }
                        else {
                            reject(response);
                            ErrorNotification(response.Error.Message);
                        }
                    });

                }

            }
        });
    });
}


function saveUpdatedOneDriveToken(refreshResponse, response) {

    return new Promise(function (resolve, reject) {

        var thirdPartyStorageObject = response[0];
        var oneDriveTokenInfo = thirdPartyStorageObject.AccessToken;
        var objJSON = oneDriveTokenInfo.AccessTokenInfo == undefined ? eval("(function(){return " + oneDriveTokenInfo + ";})()") : oneDriveTokenInfo;
        objJSON.AccessTokenInfo = refreshResponse;
        thirdPartyStorageObject.AccessToken = JSON.stringify(objJSON);
        var data = JSON.stringify(thirdPartyStorageObject);
        var _url = GetBaseURL() + "Json/PutObjectGlobalization?url=api/ThirdPartySetting/PutThirdPartySetting&module=ThirdPartySetting";
        ajaxCall({
            url: _url,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            type: "PUT",
            success: function (response) {
                if (response != null) {
                    if (response.IsSuccessStatusCode) {
                        var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
                        CloudConnectionData.OneDriveData.accessToken = response.Response.AccessToken;
                        localStorage.removeItem("CloudConnectionData");
                        setObjectInLocalStorage("CloudConnectionData", CloudConnectionData);
                        //getAccessToken();
                        resolve(response);
                    } else {
                        resolve(response);
                        ErrorNotification(response.Error.Message);
                    }
                }
            }
        });

    });
}

// ONEDRIVE DELETE FILE OPERATION ,CALLING FROM linked-file.js
function DeleteFromOneDriveCloudStorage(CloudStorage_ID, rowId) {

    return new Promise(function (resolve, reject) {

        var oneDriveTokenInfo = CloudConnectionData.OneDriveData.accessToken;
        var objOneDriveData = oneDriveTokenInfo.AccessTokenInfo == undefined ? eval("(function(){return " + oneDriveTokenInfo + ";})()") : oneDriveTokenInfo;
        var tokenInfo = objOneDriveData.AccessTokenInfo.access_token == undefined ? eval("(function(){return " + objOneDriveData.AccessTokenInfo + ";})()") : objOneDriveData.AccessTokenInfo;
        accToken = tokenInfo.access_token;

        $.ajax(oneDriveBaseEndpoint + "/v1.0/me/drive/items/" + CloudStorage_ID,
        {
            type: 'DELETE',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + accToken);
            },
            async: "false",
            success: function (data, status, xhr) {
                resolve(xhr.status);

            },
            error: function (xhr, status, error) {
                resolve(xhr.status);
                // GET REFRESH TOKEN 
                if (xhr.status == 401) {
                    oneDriveRefreshToken().then(function (odRefreshToken) {
                        if (odRefreshToken != null) {
                            DeleteFromOneDriveCloudStorage(CloudStorage_ID, rowId).then(function (cloudResponse) {
                                if (cloudResponse == 204) {
                                    DeleteFile(rowId);
                                }
                            });
                        }
                    })
                } else if (xhr.status == 404) {
                    reject(xhr.status);
                    closeWaiting();
                }
            }
        });
    });
}
///ONEDRIVE INTEGRATION END////


function UploadFiles(selFiles, selectedTab, callbackAfterUploadComplete, createFileSharableLink) {
    if ($.isFunction(window[myCallback])) {
        window[myCallback](selFiles, $("#jsDroppable"));
        closeDialog('#add-attachment-modal');
    }
    else {
        if (CloudConnectionData == null) {
            //WarningNotification("Please wait ... getting cloud storage information.");
            showAlertDialog("Please wait ... getting cloud storage information.");
            //setTimeout(function () { $("#warnContainer .closeIcon").click(); }, 3000);
            //closeWaiting();
            return;
        }
        if (checkStorage() == false) {
            //closeWaiting();
            return;
        }
        closeDialog('#add-attachment-modal');

        if ((storageType == ThirdPartySettings.AWSS3 && CloudConnectionData.AmazonData == null) || (storageType == ThirdPartySettings.GoogleDrive && CloudConnectionData.GoogleData == null) || (storageType == ThirdPartySettings.Dropbox && CloudConnectionData.DropBoxData == null) || (storageType == ThirdPartySettings.OneDrive && CloudConnectionData.OneDriveData == null) || (storageType == ThirdPartySettings.Box && CloudConnectionData.BoxData == null)) {
            WarningNotification("Something went wrong while establishing connection. Please try again later.");
            //closeWaiting();
            return true;
        }
        FileUpload = { TotalFiles: selFiles.length, Uploaded: 0, Failed: 0, LinkedFiles: [] };
        showNonModalWaiting("Uploading files", 500);
        //  var outlookCalId = localStorage.getItem('outlookCalId');
        var outlookEventId = $('#OutlookEventId').val();
        if (outlookEventId != null && outlookEventId != undefined && outlookEventId != '') {
            var files = [];
            var count = 0;
            $.each(selFiles, function (index, file) {
                var obj = new Object();
                var attachment = new Object();
                attachment.Name = file.name;
                attachment.Size = file.size;
                attachment.ContentType = file.type;
                getBase64(file).then(function (fileData) {
                    count++;
                    attachment.ContentBytes = fileData;
                    files.push(attachment);
                    if (selFiles.length == count)
                        saveAttachment($('#OutlookEventId').val(), localStorage.getItem('outlookCalId'), files).then(function (response) {
                            closeNonModalWaiting();
                            SuccessNotification(response.SuccessMessage);
                            updateAndRefresh();
                        });

                })
            });
        }
        else {
            $.each(selFiles, function (index, file) {
                ValidateFileUpload(file).then(function (isValid) {
                    if (isValid === true) {
                        startupload(file, selectedTab, createFileSharableLink).then(function (linkedFile) {
                            if (linkedFile != null) {
                                FileUpload.Uploaded += 1;
                                FileUpload.LinkedFiles.push(linkedFile);
                            } else {
                                FileUpload.Failed += 1;
                            }
                            if (createFileSharableLink) {
                                /*var AWSBucketName = CloudConnectionData.AmazonData.AWSPublicBucketName;
                                var AWSHost = AWSBucketName + '.s3.amazonaws.com';
                                var awsFileKey = CloudConnectionData.AmazonData.CompanyFolder + "/" + file.FileName;
                                var fileSharableURL = 'http://' + AWSHost + '/' + AWSBucketName + '/' + awsFileKey;
                                */
                                //return fileSharableURL;//https://bqe-core-crm-nv-usa-01.s3.us-east-1.amazonaws.com/3237857C-21E7-40DB-A777-FA3913A49E11/Cycle.png
                                FileUpload.LinkedFiles = [];
                                FileUpload.LinkedFiles.push(linkedFile);
                                if ($.isFunction(window[callbackAfterUploadComplete])) {
                                    window[callbackAfterUploadComplete](FileUpload.LinkedFiles);
                                }
                            }
                            else if (!createFileSharableLink && FileUpload.Uploaded + FileUpload.Failed == FileUpload.TotalFiles) {
                                postLinkedFiles(FileUpload.LinkedFiles, callbackAfterUploadComplete);
                            }
                        }, function (error) {
                            FileUpload.Failed += 1;
                            if (!createFileSharableLink && FileUpload.Uploaded + FileUpload.Failed == FileUpload.TotalFiles) {
                                postLinkedFiles(FileUpload.LinkedFiles, callbackAfterUploadComplete);
                            }
                            ErrorNotification(error);
                            //closeWaiting();
                        });
                    }
                }, function (error) {
                    ErrorNotification(error);
                    closeWaiting();
                });

            });
        }

    }
}

function AssignResources(resourceIds, parentId, callback) {
    var assignments = [];
    for (var i = 0; i < resourceIds.length; i++) {
        assignments.push({ Master_ID: resourceIds[i], MasterEntryType: 83, Reference_ID: parentId, ReferenceEntryType: moduleid }); // 83 = LinkedFiles, 359 = ResourceLibrary
    }

    ajaxCall({
        url: GetBaseURL() + "Json/PutObjectsGlobalization?url=api/ResourceLibrary/BatchAssign&module=AssignedMappings",
        type: "PUT",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        batchUpdate: true,
        data: JSON.stringify(assignments),
        success: function (data) {
            var errorMessage = "";
            if (data.IsSuccessStatusCode) {
                for (var i = 0; i < data.Response.length; i++) {
                    if (data.Response[i].Error != null) {
                        errorMessage += (i + 1) + ")  " + data.Response[i].Error.Message + ". <br/>";
                    }
                }
                if (errorMessage != "")
                    ErrorNotification(errorMessage, "#resource-library");
                else {
                    closeDialog("#add-attachment-modal");
                    closeOverlay();
                    SuccessNotification(data.SuccessMessage);
                }

                if ($(".jsTabHeader li[data-container=jsDocumentList].active-tab").length > 0) {
                    updateAndRefresh();
                } else {
                    if ($.isFunction(window[callback])) {
                        data["isResourceLibraryDoc"] = true;
                        window[callback](data);
                    }
                }

            } else {
                ErrorNotification(data.Error.Message);
            }
        }, error: function (xhrRq, errorThrown, errorText) {
            ErrorNotification(errorThrown + " : " + errorText);
        }
    });
}

function CopyResourceStructure(structureId, parentId, callback) {
    ajaxCall({
        url: GetBaseURL() + "Resources/AssignResourseGroup?parentId=" + parentId + "&resourceId=" + structureId,
        dataType: "json",
        success: function (data) {
            if (data.IsSuccessStatusCode) {
                SuccessNotification(data.SuccessMessage);
                closeDialog("#add-attachment-modal");
                if (typeof window[callback] == "function") {
                    if (window[callback]());
                }
            } else {
                ErrorNotification(data.Error.Detail);
            }
        }, error: function (xhrRq, errorThrown, errorText) {
            ErrorNotification(errorThrown + " : " + errorText);
        }
    });
}
//////////////OUTLOOK INTEGRATION 
function uploadAttachments(attachmentIds, closePopUp) {
    var i;
    var attachmentEventIds = [];
    if (attachmentIds.indexOf('true') > 0) {
        var ids = attachmentIds.split(',');
        ids.pop();
        attachmentEventIds = JSON.parse(ids);
    }
    if (closePopUp == false) {
        attachmentEventIds = JSON.parse(attachmentIds);
    }
    if (attachmentEventIds != '') {
        getOutlookAccessToken().then(function (outlookToken) {
            if (outlookToken != null) {
                //showNonModalWaiting('Uploading Event Attachments');
                for (i = 0; i < attachmentEventIds.length; i++) {
                    getOulookEventAttachmentsFromOutlook(attachmentEventIds[i], outlookToken, attachmentEventIds.length).then(function (response) {
                    });
                }
            }
            else {
                closeNonModalWaiting();
                ErrorNotification('Event Attachments failed to Upload.Token is not Valid', 500);
                location.reload();
            }
        });
    }
    else {
        reloadEvents();
    }
}

function getOulookEventAttachmentsFromOutlook(eventId, token, totalFiles) {
    return new Promise(function (resolve, reject) {
        var eventApiId = eventId.split('æ')[0];
        var recordLinkId = eventId.split('æ')[1];
        var oulookCalendarEndPoint = "https://graph.microsoft.com/v1.0/me/calendar/Events/" + eventApiId + "/attachments";
        $.ajax(oulookCalendarEndPoint,
        {
            type: 'GET',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
            },
            async: "false",
            success: function (attachments, status, xhr) {
                uploadEventAttachment(attachments.value, recordLinkId, totalFiles).then(function (response) {
                    resolve(response);
                });
            },
            error: function (xhr, status, error) {
                if (xhr.status == 401) {
                    //refresh token
                } else if (xhr.status == 404) {
                    ErrorNotification("File Not Found");
                }
            }
        });

    });

}

function uploadEventAttachment(attachments, recordLinkId, totalFiles) {
    return new Promise(function (resolve, reject) {
        FileUpload = { TotalFiles: attachments.length, Uploaded: 0, Failed: 0, LinkedFiles: [] };
        $.each(attachments, function (index, f) {
            urltoFile('data:' + f.contentType + ';base64,' + f.contentBytes, f.name, f.contentType)
            .then(function (file) {
                file.name = f.name;
                file.type = file.contentType;
                ValidateFileUpload(file).then(function (isValid) {
                    if (isValid === true) {
                        storageType = 1;
                        startupload(file, "from-computer").then(function (linkedFile) {
                            if (linkedFile != null) {
                                linkedFile.LinkedRecord_ID = recordLinkId;
                                FileUpload.Uploaded += 1;
                                linkedFile.EntryType = "125";
                                FileUpload.LinkedFiles.push(linkedFile);
                            } else {
                                FileUpload.Failed += 1;
                            }
                            if (FileUpload.Uploaded + FileUpload.Failed == totalFiles) {
                                postLinkedFiles(FileUpload.LinkedFiles, 'reloadEvents');
                            }

                        }, function (error) {
                            FileUpload.Failed += 1;
                            if (FileUpload.Uploaded + FileUpload.Failed == totalFiles) {
                                postLinkedFiles(FileUpload.LinkedFiles, 'reloadEvents');
                            }
                            ErrorNotification(error);
                        });
                    }
                    resolve(true);
                }, function (error) {
                    ErrorNotification(error);
                });
            });
        });
    });
}
function getOutlookAccessToken() {
    var objParameter = new BQEParameter();
    objParameter.FilterList = [];
    objParameter.FilterList.push({ Field: "Type", Operator: "EqualTo", StartValue: '12', Conjunction: "AND" });
    objParameter.FilterList.push({ Field: "CreatedBy_ID", Operator: "EqualTo", StartValue: $('#LoggedInUser').val(), Conjunction: "AND" });

    return new Promise(function (resolve, reject) {
        var token = '';
        var appendUrl = "api/ThirdPartySetting/ThirdPartySettings";
        var _url = GetBaseURL() + "Json/PostObjectGlobalization?url=" + encodeURIComponent(appendUrl);
        ajaxCall({
            url: _url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            type: "POST",
            data: JSON.stringify(objParameter),
            success: function (response) {
                if (response != null && response.Response != null) {
                    var thirdPartyStorageObject = response.Response[0];
                    var outlookTokenInfo = thirdPartyStorageObject.AccessToken;
                    var objOutlookData = eval("(function(){return " + outlookTokenInfo + ";})()");
                    var objJSON = eval("(function(){return " + objOutlookData.AccessTokenInfo + ";})()");
                    token = objJSON.access_token;
                    resolve(token);
                }
                else {
                    resolve(null);
                }
            }
        });
    });
}
function reloadEvents() {
    closeNonModalWaiting();
    setTimeout(function () { SuccessNotification('Events Synced Successfully'); }, 150);
    location.reload();
}
function urltoFile(url, filename, mimeType) {
    return (fetch(url)
        .then(function (res) { return res.arrayBuffer(); })
        .then(function (buf) { return new File([buf], filename, { type: mimeType }); })
    );
}
function getGeneralSetting() {

    return new Promise(function (resolve, reject) {
        var _url = GetBaseURL() + "Json/GetItem?url=api/Preference/GetGeneralSetting?User_ID=" + $('#LoggedInUser').val();
        ajaxCall({
            url: _url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            showWaiting: false,
            type: "GET",
            success: function (response) {
                if (response != null && response.UseOneDriveAccForOutlookSync != null) {
                    resolve(response.UseOneDriveAccForOutlookSync);
                }
                else {
                    resolve(false);
                }
            }
        });
    });
}
function GetLinkedFileObjects(selectedRsIds, callback) {
    var params = {
        FilterList: [{ Field: "LinkedFile_ID", Operator: "In", DiscreteValues: selectedRsIds }]
    };
    //showNonModalWaiting("Uploading files", 500);
    ajaxCall({
        url: GetBaseURL() + "Json/GetList?url=api/LinkedFiles/LinkedFileCompact",
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        showWaiting: false,
        dataType: "json",
        type: "POST",
        async: false,
        success: function (list) {
            closeDialog("#add-attachment-modal");
            if (list != null && list.length > 0) {
                if ($.isFunction(window[callback])) {
                    list["isResourceLibraryDoc"] = true;
                    window[callback](list);
                }
            }
        }
    });
}


function DownloadOutlookFiles(element) {
    var selectedList = [];
    var table = $(".jsMainList,.jsSecondaryList").find("table[data-gridtype='" + $(element).closest('.jsGridToolbar').data('targetgrid') + "']");
    if (!table.data())
        table = $(element).find('table');

    $.each($(table).find("tbody>tr:not(.new-row) .select-column input[type=checkbox]:checked"), function (i, row) {
        selectedList.push($(this).closest('td').find("input[type=hidden][id$=OutlookAttachmentId]").val());

    });
    $.each(selectedList, function (index, id) {
        id = "\"" + id + "\"";
        var rowSelector = "input[id*=\"OutlookAttachmentId\"][value=" + id + "]";
        var tr = $(rowSelector).closest('.js-linked-file-item')
        var linkedFile = getLinkedFileAttributes(tr);
        urltoFile('data:' + linkedFile.MimeType + ';base64,' + linkedFile.OutlookFileData, linkedFile.FileName, linkedFile.MimeType).then(function (data) {
            downloadBlob(data, linkedFile.FileName, linkedFile.mimeType);
        });
    });
    $('#documentlistTable input[type=checkbox]').attr("checked", false);
    $('#documentlistTable input[type=checkbox]').closest('tr').removeClass("selected-row");
}
function DeleteOutlookBatch(element) {
    var secType = 0;
    var securityCheck = (element.data('skipsecuritycheck') == undefined || element.data('skipsecuritycheck') == null) ? false : element.data('skipsecuritycheck');
    if (element.parents('.jsGridToolbar').data('targetgrid') !== 'MainList')
        secType = 1;

    if (securityCheck === false) {
        if (checkSecurity('Allow_Delete', secType) == false)
            return true;
    }
    var selectedIds = "";

    selectedIds = getOutlookSelectedIDs(element);

    var deleteConfirmMessage = RESOURCE_MSG.getMessage("DELETE_WITH_COUNT_CONFIRMATION");
    var disclaimerMessage = RESOURCE_MSG.getMessage("DELETE_DISCLAIMER_MESSAGE");
    if (selectedIds.length <= 0) {
        showAlertDialog(RESOURCE_MSG.getMessage("NO_RECORD_SELECTED"));
        return true;
    }

    // *********************************************
    //  CONFIRMATION DIALOG - START
    // *********************************************
    $(showCustomisedConfirmDialog("Delete", deleteConfirmMessage, disclaimerMessage, selectedIds.length)["yes"]).click(function () {
        if (!$('#chk-confirm-delete-disclaimerdialog').is(":checked"))
            return false

        showNonModalWaiting("Refreshing List", 500);

        var batchDeleteModel = [];


        for (var i = 0; i < selectedIds.length; i++) {
            batchDeleteModel.push(selectedIds[i]);
        }
        var controller = $(element).data('controller');
        var action = $(element).data('action');
        var url = GetBaseURL() + controller + '/' + action;
        var param = $(element).data('param'); //

        if (isNullorEmpty(param)) {
            param = "";
        } else {
            param = "?" + param;
            url = url + param + "&calendarId=" + localStorage.getItem('outlookCalId');
        }
        var counter = 0;
        var nord = 0; //number of records deleted
        // var _guids = $.param({ ids: selectedIds }, true);
        //   var apiUrl = GetBaseURL() + "Json/DeleteItemsInLoop?url=api/" + url;
        ajaxCall({

            hideBrowserConsoleError: true,
            url: url,
            data: JSON.stringify(batchDeleteModel),
            contentType: "application/json; charset=utf-8",
            type: "PUT",
            success: function (data, textStatus, request) {
                var timer = setTimeout(function () {
                    showApiResponseMessage(data);
                }, 1000);
                updateAndRefresh();

            }, error: function (request, textStatus, errorThrown) {

            }

        });

        //if (nord > 0)
        //    showAlertDialog("Records deleted Successfully");
    });
    // *********************************************
    //  CONFIRMATION DIALOG - END
    // **********************************************
    return true;
}
function getOutlookSelectedIDs(element) {
    var selectedList = [];
    var table = $(".jsMainList,.jsSecondaryList").find("table[data-gridtype='" + $(element).closest('.jsGridToolbar').data('targetgrid') + "']");
    if (!table.data())
        table = $(element).find('table');

    $.each($(table).find("tbody>tr:not(.new-row) .select-column input[type=checkbox]:checked"), function (i, row) {
        selectedList.push($(this).closest('td').find("input[type=hidden][class=jsOutlookAttachment_Id]").val());
    });


    return selectedList;
}

function saveAttachment(eventId, calendarId, files) {
    return new Promise(function (resolve, reject) {
        var appendUrl = "?eventId=" + eventId + '&calendarId=' + calendarId;
        var url = GetBaseURL() + "Outlook/UploadAttachment" + appendUrl;
        ajaxCall({
            url: url,
            type: "PUT",
            dataType: 'JSON',
            data: { 'attachmentList': files },
            success: function (response) {
                if (typeof response.IsSuccessStatusCode != typeof undefined && response.IsSuccessStatusCode != null && response.IsSuccessStatusCode === true) {
                    resolve(response);
                }
                else {
                    ErrorNotification(response.Error.Message);
                    resolve(null);
                }
            },
            error: function (error) {

            }
        });

    });

}
function getBase64(file) {
    return new Promise((resolve, reject) => {
        var reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = function () {
            var base64String = reader.result;
            base64String = base64String.substr(base64String.indexOf(',') + 1);
            resolve(base64String);
        };
        reader.onerror = function (error) {
        };
    });
}
