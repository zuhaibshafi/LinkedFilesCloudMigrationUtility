var ThirdPartySettings = { NONE: 0, AWSS3: 1, GoogleDrive: 2, Dropbox: 3, WebLink: 4, OneDrive: 5, QuickBooks: 6, Xero: 7, MYOB: 8, Yodlee: 9, Box: 10 };
$(document).on('click', '#jsAddDestination', function () {
    $("#accountName").val("");
    showDialog("#add-destination-modal");
});

var destinationRow = undefined;
$(document).on('click', '#jsUpdateDestination', function () {   
    //destinationRow = $(this).closest('.tr');
    destinationRow = $('.jsSelectedDropdown').closest('div.tr');
    $('#updatedStorageName').val(destinationRow.find(".jsAccountID").text());
    showDialog("#update-destination-modal");
});

$(document).off('click.newEventMakeDefault').on('click.newEventMakeDefault', '.jsMakeDefault', function () {
    var element = this;
    var confirmMessage = "Are you sure you want to change the default storage?";
    var btnArray = showConfirmDialog(confirmMessage);
    btnArray["yes"].click(function () {
        ChangeStatusToDefault(element);
    });
    btnArray["no"].click(function () {
        $("#tabAttachments tbody tr").each(function (index, tr) {
            if ($(tr).find('[id$=IsDefault]').val().toLowerCase() == "true") {
                $(tr).find('.jsMakeDefault').prop('checked', true);
            } else {
                $(tr).find('.jsMakeDefault').prop('checked', false);
            }
        });
    });
});

$(document).off('click.newEventUpdateCloud').on('click.newEventUpdateCloud', '.jsUpdateCloudSetting', function () {
    ChangeStatusToDefault($(destinationRow), $('#updatedStorageName').val(), $('#chk-set-default').is(':checked'));
});

$(document).off('click.newEvenTP', ".thirdPartySettingDelete").on('click.newEvenTP', '.thirdPartySettingDelete', function () {
    
    var tr = $('.jsSelectedDropdown').closest('div.tr');
    var confirmMessage = "Are you sure you want to remove this record?";
    $(showConfirmDialog(confirmMessage)["yes"]).click(function () {

        // $.each($(".mainList tr"), function (i, row) {
        // if ($(this).find(".select-column").find("input[type=checkbox]").is(":checked")) {        
        //var ids = $('.jsSelectedDropdown').closest('div.tr').find("input[type=hidden][id*=ThirdPartySetting_ID]").val();

        var id = tr.find("input[type=hidden][id*=ThirdPartySetting_ID]").val();
        var storageType = tr.find("input[type=hidden][id*=Type]").val();
        var isDefault = tr.find("input[type=hidden][id*=IsDefault]").val();

        if (isDefault.toLowerCase() === 'false') {// Not default storageType
            if (storageType == "AWSS3" || storageType == ThirdPartySettings.AWSS3) {
                storageType = ThirdPartySettings.AWSS3;
            }
            else if (storageType == "GoogleDrive" || storageType == ThirdPartySettings.GoogleDrive) {
                storageType = ThirdPartySettings.GoogleDrive;
            }
            else if (storageType == "Dropbox" || storageType == ThirdPartySettings.Dropbox) {
                storageType = ThirdPartySettings.Dropbox;
            }
            else if (storageType == "Box" || storageType == ThirdPartySettings.Box) {
                storageType = ThirdPartySettings.Box;
            }
            else if (storageType == "OneDrive" || storageType == ThirdPartySettings.OneDrive) {
                storageType = ThirdPartySettings.OneDrive;
            }
            else if (storageType == "WebLink" || storageType == ThirdPartySettings.WebLink) {
                storageType = ThirdPartySettings.WebLink;
            }

            var parameters = new BQEParameter();
            parameters.FilterList.push({ Field: "storageType", Operator: "EqualTo", StartValue: storageType });

            var appendUrl = "api/LinkedFiles/LinkedFiles/";
            var _url = GetBaseURL() + "Json/GetList?url=" + encodeURIComponent(appendUrl);

            ajaxCall({
                url: _url,
                data: JSON.stringify(parameters),
                contentType: "application/json; charset=utf-8",
                type: "POST",
                dataType: "Json"
            }).done(function (data) {
                showNonModalWaiting("Loading", 500);
                LinkedFiles = data;
                if (false && typeof LinkedFiles != typeof undefined && LinkedFiles != null && LinkedFiles.length > 0 && storageType != ThirdPartySettings.GoogleDrive) { //No Need to remove files from personal storage
                    var confirmMessage = "The storage has documents linked to it. Deleting the destination storage will remove the linked documents as well. Do you want to continue?";
                    $(showConfirmDialog(confirmMessage)["yes"]).click(function () {
                        var LinkedFileIDs = new Array();
                        LinkedFileIDs = [];
                        for (var i = 0; i < LinkedFiles.length; i++)
                            LinkedFileIDs.push(LinkedFiles[i].LinkedFile_ID);
                        var batchDelete = {
                            EntityList: LinkedFileIDs,
                            UserPrompts : null
                        };
                        ajaxCall({
                            type: 'PUT',
                            contentType: "application/json; charset=utf-8",
                            url: GetBaseURL() + "Documents/DeleteDocumentBatch/",
                            data: JSON.stringify(batchDelete),
                            dataType: 'json'
                        }).done(function (data) {
                            ajaxCall({
                                type: 'DELETE',
                                contentType: "application/json; charset=utf-8",
                                url: GetBaseURL() + "GLobalSetting/ThirdPartySettingDelete?id=" + id + "&storageType=" + storageType,
                                actiontype: "GridDeleteOperation",
                                success: function (data, textStatus, request) {
                                    showApiResponseMessage(data);
                                    if (data.IsSuccessStatusCode) {
                                        localStorage.removeItem("CloudConnectionData");
                                        //FillTabs($('.jsTabHeader li[data-container=jsAttachmentsContainer]'));
                                        RenderHtml(GetListObjectFromData("DocumentsObjectInfo"));

                                    }
                                }, error: function (request, textStatus, errorThrown) {
                                }
                            });
                        });                      
                    });
                }
                else {
                    ajaxCall({
                        type: 'DELETE',
                        contentType: "application/json; charset=utf-8",
                        url: GetBaseURL() + "GLobalSetting/ThirdPartySettingDelete?id=" + id + "&storageType=" + storageType,
                        actiontype: "GridDeleteOperation",
                        success: function (data, textStatus, request) {
                            showApiResponseMessage(data);
                            if (data.IsSuccessStatusCode) {
                                localStorage.removeItem("CloudConnectionData");
                                //FillTabs($('.jsTabHeader li[data-container=jsAttachmentsContainer]'));
                                RenderHtml(GetListObjectFromData("DocumentsObjectInfo"));
                            }
                        }, error: function (request, textStatus, errorThrown) {
                        }
                    });
                }

            });
        }
        else {
            ajaxCall({
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                url: GetBaseURL() + "GLobalSetting/ThirdPartySettingDelete?id=" + id + "&storageType=" + storageType,
                actiontype: "GridDeleteOperation",
                success: function (data, textStatus, request) {
                    showApiResponseMessage(data);
                    if (data.IsSuccessStatusCode) {
                        localStorage.removeItem("CloudConnectionData");
                        //FillTabs($('.jsTabHeader li[data-container=jsAttachmentsContainer]'));
                        RenderHtml(GetListObjectFromData("DocumentsObjectInfo"));
                    }
                }, error: function (request, textStatus, errorThrown) {
                }
            });

            //}
            // });
        }
    });
});

$(document).off('click.newEventCloudStorage', '.btnCloudAuthorize').on('click.newEventCloudStorage', '.btnCloudAuthorize', function (e) {
    //var storageType = $("#cloudStorageDrive").val() == "2" ? "GoogleDrive" : "Dropbox";
    var selectiontype = $("#cloudStorageDrive").val();
    var storageType = "";
    if (selectiontype == ThirdPartySettings.GoogleDrive) {
        storageType = "GoogleDrive";
    } else if (selectiontype == ThirdPartySettings.Dropbox) {
        storageType = "DropBox";
    } else if (selectiontype == ThirdPartySettings.Box) {
        storageType = "Box";
    } else if (selectiontype == ThirdPartySettings.OneDrive) {
        storageType = "OneDrive";
    }
    var AlreadyAdded = false;
    $(".jsSettingsListContainer .tr").each(function (index, tr) {
        var type = $(tr).find("input[id$=Type]").val();
        if (type != undefined && type.toLocaleLowerCase() == storageType.toLocaleLowerCase()) {
            AlreadyAdded = true;
        }
    });

    if (AlreadyAdded) {
        //WarningNotification("Clound storage drive already added to list.");
        //ErrorNotification("Clound storage drive already added to list.", 'jsInvoiceTemplateForm');
        showAlertDialog("Storage drive already added to list.\n\nChoose other storage.");
        return;
    }

    AuthorizeCloudStorage();
});

$(document).on('change', '#cloudStorageDrive', function () {
    var selectiontype = $("#cloudStorageDrive").val();
    if (selectiontype == ThirdPartySettings.OneDrive) 
        $(".clsOutlookCalendar").removeClass("hidden");
    else
        $(".clsOutlookCalendar").addClass("hidden");
});

function ChangeStatusToDefault(element, storageAlias, isChecked) {
    var objChangeStatus = new Object();
    
    //$.each($(".mainList tr"), function (i, row) {
    //   if ($(this).find(".select-column").find("input[type=checkbox]").is(":checked")) {
    var tr = $(element).closest('.tr');
    objChangeStatus.ThirdPartySetting_ID = tr.find("input[type=hidden][id*=ThirdPartySetting_ID]").val();
    if (isChecked != undefined)
        objChangeStatus.IsDefault = isChecked ? 1 : 0;
    else
        objChangeStatus.IsDefault = 1;
    if (typeof storageAlias == typeof undefined || isNullorEmpty(storageAlias))
        objChangeStatus.AccountID = tr.find(".jsAccountID").text();
    else
        objChangeStatus.AccountID = storageAlias;
    objChangeStatus.AccessToken = tr.find("input[type=hidden][id*=AccessToken]").val();
    objChangeStatus.Status = tr.find("input[type=hidden][id*=Status]").val();
    objChangeStatus.Type = tr.find("input[type=hidden][id*=Type]").val();
    objChangeStatus.IsStorage = tr.find("input[type=hidden][id*=IsStorage]").val();
    objChangeStatus.LastSyncDate = tr.find("input[type=hidden][id*=LastSyncDate]").val();

    objChangeStatus.CreatedBy_ID = tr.find("input[type=hidden][id*=CreatedBy_ID]").val();
    objChangeStatus.CreatedOn = tr.find("input[type=hidden][id*=CreatedOn]").val();
    objChangeStatus.LastUpdated = tr.find("input[type=hidden][id*=LastUpdated]").val();
    objChangeStatus.LastUpdatedBy_ID = tr.find("input[type=hidden][id*=LastUpdatedBy_ID]").val();
    objChangeStatus.MyState = tr.find("input[type=hidden][id*=MyState]").val();
    objChangeStatus.RecordTimeStamp = tr.find("input[type=hidden][id*=RecordTimeStamp]").val();
    objChangeStatus.RetrievalTimeStamp = tr.find("input[type=hidden][id*=RetrievalTimeStamp]").val();
    //    }
    // });

    UpdateCloudSetting(objChangeStatus);

}

function UpdateCloudStorage() {

}
function UpdateCloudSetting(objChangeStatus) {
    var _url = GetBaseURL() + "Json/PutObjectGlobalization?url=api/ThirdPartySetting/PutThirdPartySetting&module=ThirdPartySetting";

    ajaxCall({
        url: _url,
        data: JSON.stringify(objChangeStatus),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "PUT",
        success: function (response) {
            if (response != null) {
                if (response.IsSuccessStatusCode) {
                    SuccessNotification(response["SuccessMessage"]);
                    localStorage.removeItem("CloudConnectionData");
                    //FillTabs($('.jsTabHeader li[data-container=jsAttachmentsContainer]'));
                    RenderHtml(GetListObjectFromData("DocumentsObjectInfo"));
                } else {
                    ErrorNotification(response.Error.Message);
                }
            }
            closeDialog('#update-destination-modal');
        }
    });
}

function AuthorizeCloudStorage() {
    var storageType = $("#cloudStorageDrive").val();
    //var storageType = $("#cloudStorageDrive option:selected").text();
    var storageName = $("#accountName").val();
    var isDefaultStorage = $("#chk-make-default").is(':checked');
    ajaxCall({
        type: "POST",
        dataType: 'html',
        contentType: "text/json",
        url: GetBaseURL() + "GlobalSetting/AuthorizeCloudStorage?storageType=" + storageType + "&accountName=" + storageName + "&isDefault=" + isDefaultStorage,

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

    }).done(function (data, textStatus) {
        localStorage.removeItem("CloudConnectionData");
        if (data.indexOf('http') == 0 || data.indexOf('https') == 0) {
            //$(location).attr('href', data);
            var left = (screen.width-900) / 2;
            var top = (screen.height-600) / 4;
            var popupWin = window.open(data, 'name', 'height=600,width=900,top=' + top + ', left=' + left);
            if (window.focus) {
                popupWin.focus();
            }
        }
        return;
    });

    return false;
}
