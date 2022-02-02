// ***********************************************************************
// Assembly         : BQECore.Model
// Author           : Administrator
// Created          : 02-13-2014
//
// Last Modified By : Administrator
// Last Modified On : 02-13-2014
// ***********************************************************************
// <copyright file="_ConstantsBQE.cs" company="BQE Software Inc.">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// Container for global constants.
/// </summary>

using System.Collections.Generic;
using System.Transactions;

public static class ConstantsBQE
{
    public const string ActivityGenVac = "GEN:VAC";
    public const string ActivityGenSick = "GEN:SICK";
    public const string ActivityGenHol = "GEN:HOL";
    public const string ActivityGenComp = "GEN:COMP";


    /// <summary>
    /// The project levels
    /// </summary>
    public const int ProjectLevels = 4;

    /// <summary>
    /// The clien t_ retaine r_ unique identifier
    /// </summary>
    public const string CLIENT_RETAINER_GUID = "c0000000-0000-0000-0000-00000000000e";

    /// <summary>
    /// The services
    /// </summary>
    public const string Services = "Services";

    /// <summary>
    /// The less amount
    /// </summary>
    public const string LessAmount = "Less Amount";

    /// <summary>
    /// The bq global_ decimal places
    /// </summary>
    public const int BQGlobal_DecimalPlaces = 2;

    /// <summary>
    /// The project control on top of employee control bit number
    /// </summary>
    public const int ProjectControlOnTopOfEmployeeControlBitNumber = 34;

    /// <summary>
    /// The undeposite d_ fun d_ account
    /// </summary>
    public const string UNDEPOSITED_FUND_ACCOUNT = "D6D8C22C-863B-491C-90B3-F45EF8FEDDD6";

    /// <summary>
    /// The employee control bits
    /// </summary>
    public static Dictionary<ModuleNames, int> EmployeeControlBits;

    /// <summary>
    /// The address default name
    /// </summary>
    public const string AddressDefaultName = "";

    /// <summary>
    /// Initializes static members of the <see cref="ConstantsBQE"/> class.
    /// </summary>
    static ConstantsBQE()
    {
        EmployeeControlBits = new Dictionary<ModuleNames, int>();
        EmployeeControlBits.Add(ModuleNames.Activity, 11);
        EmployeeControlBits.Add(ModuleNames.BillingSchedule, 5);
        EmployeeControlBits.Add(ModuleNames.BillingReview, 12);
        EmployeeControlBits.Add(ModuleNames.Budget, 8);
        EmployeeControlBits.Add(ModuleNames.Client, 15);
        EmployeeControlBits.Add(ModuleNames.TimeEntry, 22);
        EmployeeControlBits.Add(ModuleNames.ExpenseLog, 22);
        EmployeeControlBits.Add(ModuleNames.FeeSchedule, 6);
        EmployeeControlBits.Add(ModuleNames.FeeScheduleExp, 6);
        EmployeeControlBits.Add(ModuleNames.InvoiceReview, 11);
        EmployeeControlBits.Add(ModuleNames.Payment, 10);
        EmployeeControlBits.Add(ModuleNames.Project, 14);
        EmployeeControlBits.Add(ModuleNames.Expense, 11);
        EmployeeControlBits.Add(ModuleNames.Timer, 8);
        EmployeeControlBits.Add(ModuleNames.Import, 1);
        EmployeeControlBits.Add(ModuleNames.Export, 1);
        EmployeeControlBits.Add(ModuleNames.Estimate, 8);
        EmployeeControlBits.Add(ModuleNames.DocumentManagement, 4);
        EmployeeControlBits.Add(ModuleNames.Retainer, 1);
        EmployeeControlBits.Add(ModuleNames.CreditMemo, 5);
        EmployeeControlBits.Add(ModuleNames.PurchaseOrder, 6);
        EmployeeControlBits.Add(ModuleNames.VendorBill, 5);
        EmployeeControlBits.Add(ModuleNames.StandardReportsMenu, 12);
        EmployeeControlBits.Add(ModuleNames.CustomReportsMenu, 4);
        EmployeeControlBits.Add(ModuleNames.Reports, 4);
        EmployeeControlBits.Add(ModuleNames.Allocate, 6);
    }


    /*
    SELECT 'public const int MAXLENGTH_' + TABLE_NAME + '_' + COLUMN_NAME + ' = ' + CONVERT(varchar(20), CHARACTER_MAXIMUM_LENGTH) + ';'
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE DATA_TYPE = 'varchar'
    */

    /// <summary>
    /// The maxlengt h_ account type list_ account type name
    /// </summary>
    public const int MAXLENGTH_AccountTypeList_AccountTypeName = 50;

    /// <summary>
    /// The maxlengt h_ employee project data_ description
    /// </summary>
    public const int MAXLENGTH_EmployeeProjectData_Description = 150;

    /// <summary>
    /// The maxlengt h_ recurring schedule_ recurring name
    /// </summary>
    public const int MAXLENGTH_RecurringSchedule_RecurringName = 65;

    /// <summary>
    /// The maxlengt h_ recurring schedule_ description
    /// </summary>
    public const int MAXLENGTH_RecurringSchedule_Description = 100;

    /// <summary>
    /// The maxlengt h_ recurring schedule_ frequency
    /// </summary>
    public const int MAXLENGTH_RecurringSchedule_Frequency = 20;

    /// <summary>
    /// The maxlengt h_ recurring schedule_ next inv no
    /// </summary>
    public const int MAXLENGTH_RecurringSchedule_NextInvNo = 100;

    /// <summary>
    /// The maxlengt h_ activity_ activity identifier
    /// </summary>
    public const int MAXLENGTH_Activity_ActivityID = 31;

    /// <summary>
    /// The maxlengt h_ activity_ activity code
    /// </summary>
    public const int MAXLENGTH_Activity_ActivityCode = 15;

    /// <summary>
    /// The maxlengt h_ activity_ activity sub
    /// </summary>
    public const int MAXLENGTH_Activity_ActivitySub = 15;

    /// <summary>
    /// The maxlengt h_ activity_ activity description
    /// </summary>
    public const int MAXLENGTH_Activity_ActivityDescription = 100;

    /// <summary>
    /// The maxlengt h_ activity_ qb class identifier
    /// </summary>
    public const int MAXLENGTH_Activity_QBClassID = 36;

    /// <summary>
    /// The maxlengt h_ activity_ other1
    /// </summary>
    public const int MAXLENGTH_Activity_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ activity_ other2
    /// </summary>
    public const int MAXLENGTH_Activity_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ activity_ other3
    /// </summary>
    public const int MAXLENGTH_Activity_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ emp security template_ setting name
    /// </summary>
    public const int MAXLENGTH_EmpSecurityTemplate_SettingName = 65;

    /// <summary>
    /// The maxlengt h_ emp security template_ settings
    /// </summary>
    public const int MAXLENGTH_EmpSecurityTemplate_Settings = 255;

    /// <summary>
    /// The maxlengt h_ activity group_ agid
    /// </summary>
    public const int MAXLENGTH_ActivityGroup_AGID = 15;

    /// <summary>
    /// The maxlengt h_ activity group_ ag desc
    /// </summary>
    public const int MAXLENGTH_ActivityGroup_AGDesc = 50;

    /// <summary>
    /// The maxlengt h_ activity group_ qb class identifier
    /// </summary>
    public const int MAXLENGTH_ActivityGroup_QBClassID = 36;

    /// <summary>
    /// The maxlengt h_ expense_ exp identifier
    /// </summary>
    public const int MAXLENGTH_Expense_ExpID = 31;

    /// <summary>
    /// The maxlengt h_ expense_ exp code
    /// </summary>
    public const int MAXLENGTH_Expense_ExpCode = 15;

    /// <summary>
    /// The maxlengt h_ expense_ exp sub
    /// </summary>
    public const int MAXLENGTH_Expense_ExpSub = 15;

    /// <summary>
    /// The maxlengt h_ expense_ exp description
    /// </summary>
    public const int MAXLENGTH_Expense_ExpDescription = 100;

    /// <summary>
    /// The maxlengt h_ expense_ qb class identifier
    /// </summary>
    public const int MAXLENGTH_Expense_QBClassID = 36;

    /// <summary>
    /// The maxlengt h_ expense_ other1
    /// </summary>
    public const int MAXLENGTH_Expense_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ expense_ other2
    /// </summary>
    public const int MAXLENGTH_Expense_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ expense_ other3
    /// </summary>
    public const int MAXLENGTH_Expense_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ report list_ report name
    /// </summary>
    public const int MAXLENGTH_ReportList_ReportName = 255;

    /// <summary>
    /// The maxlengt h_ report list_ report file name
    /// </summary>
    public const int MAXLENGTH_ReportList_ReportFileName = 255;

    /// <summary>
    /// The maxlengt h_ report list_ report group
    /// </summary>
    public const int MAXLENGTH_ReportList_ReportGroup = 255;

    /// <summary>
    /// The maxlengt h_ report list_ industry
    /// </summary>
    public const int MAXLENGTH_ReportList_Industry = 10;

    /// <summary>
    /// The maxlengt h_ report list_ description
    /// </summary>
    public const int MAXLENGTH_ReportList_Description = 255;

    /// <summary>
    /// The maxlengt h_ expense group_ xgid
    /// </summary>
    public const int MAXLENGTH_ExpenseGroup_XGID = 15;

    /// <summary>
    /// The maxlengt h_ expense group_ xg name
    /// </summary>
    public const int MAXLENGTH_ExpenseGroup_XGName = 35;

    /// <summary>
    /// The maxlengt h_ expense group_ qb class identifier
    /// </summary>
    public const int MAXLENGTH_ExpenseGroup_QBClassID = 36;

    /// <summary>
    /// The maxlengt h_ retainer history_ transaction inv number
    /// </summary>
    public const int MAXLENGTH_RetainerHistory_TransactionInvNum = 21;

    /// <summary>
    /// The maxlengt h_ retainer history_ transaction inv status
    /// </summary>
    public const int MAXLENGTH_RetainerHistory_TransactionInvStatus = 5;

    /// <summary>
    /// The maxlengt h_ ap check details_ check number
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_CheckNumber = 20;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee full name
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeFullName = 100;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee company
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeCompany = 95;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee street1
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeStreet1 = 55;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee street2
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeStreet2 = 55;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee city
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeCity = 45;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee state
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeState = 3;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee zip
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeZip = 10;

    /// <summary>
    /// The maxlengt h_ ap check details_ payee country
    /// </summary>
    public const int MAXLENGTH_APCheckDetails_PayeeCountry = 35;

    /// <summary>
    /// The maxlengt h_ security table_ settings
    /// </summary>
    public const int MAXLENGTH_SecurityTable_Settings = 255;

    /// <summary>
    /// The maxlengt h_ expense log_ el description
    /// </summary>
    public const int MAXLENGTH_ExpenseLog_ELDescription = 100;

    /// <summary>
    /// The maxlengt h_ expense log_ el billed
    /// </summary>
    public const int MAXLENGTH_ExpenseLog_ELBilled = 1;


    /// <summary>
    /// The maxlengt h_ expense log_ other1
    /// </summary>
    public const int MAXLENGTH_ExpenseLog_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ expense log_ other2
    /// </summary>
    public const int MAXLENGTH_ExpenseLog_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ expense log_ other3
    /// </summary>
    public const int MAXLENGTH_ExpenseLog_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ expense log_ classification
    /// </summary>
    public const int MAXLENGTH_ExpenseLog_Classification = 100;

    /// <summary>
    /// The maxlengt h_ terms table_ name
    /// </summary>
    public const int MAXLENGTH_TermsTable_Name = 35;

    /// <summary>
    /// The maxlengt h_ fee schedule_ fsid
    /// </summary>
    public const int MAXLENGTH_FeeSchedule_FSID = 10;

    /// <summary>
    /// The maxlengt h_ fee schedule_ fs name
    /// </summary>
    public const int MAXLENGTH_FeeSchedule_FSName = 35;

    /// <summary>
    /// The maxlengt h_ fee schedule_ status
    /// </summary>
    public const int MAXLENGTH_FeeSchedule_Status = 15;

    /// <summary>
    /// The maxlengt h_ time entry_ te description
    /// </summary>
    public const int MAXLENGTH_TimeEntry_TEDescription = 100;

    /// <summary>
    /// The maxlengt h_ time entry_ te bill status
    /// </summary>
    public const int MAXLENGTH_TimeEntry_TEBillStatus = 3;

    /// <summary>
    /// The maxlengt h_ time entry_ project name
    /// </summary>
    public const int MAXLENGTH_TimeEntry_ProjectName = 50;


    /// <summary>
    /// The maxlengt h_ time entry_ other1
    /// </summary>
    public const int MAXLENGTH_TimeEntry_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ time entry_ other2
    /// </summary>
    public const int MAXLENGTH_TimeEntry_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ time entry_ other3
    /// </summary>
    public const int MAXLENGTH_TimeEntry_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ time entry_ classification
    /// </summary>
    public const int MAXLENGTH_TimeEntry_Classification = 100;

    /// <summary>
    /// The maxlengt h_ deposit detail_ payment method
    /// </summary>
    public const int MAXLENGTH_DepositDetail_PaymentMethod = 50;

    /// <summary>
    /// The maxlengt h_ deposit detail_ pay reference
    /// </summary>
    public const int MAXLENGTH_DepositDetail_PayRef = 60;

    /// <summary>
    /// The maxlengt h_ fee schedule detail_ classification
    /// </summary>
    public const int MAXLENGTH_FeeScheduleDetail_Classification = 100;

    /// <summary>
    /// The maxlengt h_ to do table_ linked record identifier
    /// </summary>
    public const int MAXLENGTH_ToDoTable_LinkedRecordID = 95;

    /// <summary>
    /// The maxlengt h_ to do table_ subject
    /// </summary>
    public const int MAXLENGTH_ToDoTable_Subject = 255;

    /// <summary>
    /// The maxlengt h_ to do table_ status
    /// </summary>
    public const int MAXLENGTH_ToDoTable_Status = 50;

    /// <summary>
    /// The maxlengt h_ fee schedule detail exp_ classification
    /// </summary>
    public const int MAXLENGTH_FeeScheduleDetailExp_Classification = 100;

    /// <summary>
    /// The maxlengt h_ transaction archive_calc last bill inv number
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_calcLastBillInvNum = 95;

    /// <summary>
    /// The maxlengt h_ transaction archive_ transaction inv number
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_TransactionInvNum = 95;

    /// <summary>
    /// The maxlengt h_ transaction archive_ transaction inv send bill flag
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_TransactionInvSendBillFlag = 1;

    /// <summary>
    /// The maxlengt h_ transaction archive_ inv send statement flag
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_InvSendStatementFlag = 1;

    /// <summary>
    /// The maxlengt h_ transaction archive_ transaction inv status
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_TransactionInvStatus = 5;

    /// <summary>
    /// The maxlengt h_ transaction archive_ other1
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ other2
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ other3
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ other4
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_Other4 = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ other5
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_Other5 = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ message on invoice
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_MessageOnInvoice = 255;

    /// <summary>
    /// The maxlengt h_ transaction archive_ reference number
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_ReferenceNum = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ rf number
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_RFNumber = 50;

    /// <summary>
    /// The maxlengt h_ transaction archive_ project po
    /// </summary>
    public const int MAXLENGTH_TransactionArchive_ProjectPO = 50;

    /// <summary>
    /// The maxlengt h_ fee schedule exp_ fs exp identifier
    /// </summary>
    public const int MAXLENGTH_FeeScheduleExp_FSExpID = 10;

    /// <summary>
    /// The maxlengt h_ fee schedule exp_ fs name
    /// </summary>
    public const int MAXLENGTH_FeeScheduleExp_FSName = 35;

    /// <summary>
    /// The maxlengt h_ fee schedule exp_ status
    /// </summary>
    public const int MAXLENGTH_FeeScheduleExp_Status = 9;

    /// <summary>
    /// The maxlengt h_ transaction table_calc last bill inv number
    /// </summary>
    public const int MAXLENGTH_TransactionTable_calcLastBillInvNum = 95;

    /// <summary>
    /// The maxlengt h_ transaction table_ transaction inv number
    /// </summary>
    public const int MAXLENGTH_TransactionTable_TransactionInvNum = 95;

    /// <summary>
    /// The maxlengt h_ transaction table_ transaction inv send bill flag
    /// </summary>
    public const int MAXLENGTH_TransactionTable_TransactionInvSendBillFlag = 1;

    /// <summary>
    /// The maxlengt h_ transaction table_ inv send statement flag
    /// </summary>
    public const int MAXLENGTH_TransactionTable_InvSendStatementFlag = 1;

    /// <summary>
    /// The maxlengt h_ transaction table_ transaction inv status
    /// </summary>
    public const int MAXLENGTH_TransactionTable_TransactionInvStatus = 5;

    /// <summary>
    /// The maxlengt h_ transaction table_ other1
    /// </summary>
    public const int MAXLENGTH_TransactionTable_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ other2
    /// </summary>
    public const int MAXLENGTH_TransactionTable_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ other3
    /// </summary>
    public const int MAXLENGTH_TransactionTable_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ other4
    /// </summary>
    public const int MAXLENGTH_TransactionTable_Other4 = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ other5
    /// </summary>
    public const int MAXLENGTH_TransactionTable_Other5 = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ message on invoice
    /// </summary>
    public const int MAXLENGTH_TransactionTable_MessageOnInvoice = 255;

    /// <summary>
    /// The maxlengt h_ transaction table_ reference number
    /// </summary>
    public const int MAXLENGTH_TransactionTable_ReferenceNum = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ rf number
    /// </summary>
    public const int MAXLENGTH_TransactionTable_RFNumber = 50;

    /// <summary>
    /// The maxlengt h_ transaction table_ project po
    /// </summary>
    public const int MAXLENGTH_TransactionTable_ProjectPO = 50;

    /// <summary>
    /// The maxlengt h_ ap transaction details_ reference
    /// </summary>
    public const int MAXLENGTH_APTransactionDetails_Ref = 60;

    /// <summary>
    /// The maxlengt h_ linked files_ linked record identifier
    /// </summary>
    public const int MAXLENGTH_LinkedFiles_LinkedRecordID = 95;

    /// <summary>
    /// The maxlengt h_ linked files_ file URL
    /// </summary>
    public const int MAXLENGTH_LinkedFiles_FileURL = 255;

    /// <summary>
    /// The maxlengt h_ linked files_ description
    /// </summary>
    public const int MAXLENGTH_LinkedFiles_Description = 255;

    /// <summary>
    /// The maxlengt h_ user registry_ param1
    /// </summary>
    public const int MAXLENGTH_UserRegistry_Param1 = 100;

    /// <summary>
    /// The maxlengt h_ user registry_ param2
    /// </summary>
    public const int MAXLENGTH_UserRegistry_Param2 = 100;

    /// <summary>
    /// The maxlengt h_ ap transaction table_ reference
    /// </summary>
    public const int MAXLENGTH_APTransactionTable_Ref = 60;

    /// <summary>
    /// The maxlengt h_ vendor_ vendor identifier
    /// </summary>
    public const int MAXLENGTH_Vendor_VendorID = 65;

    /// <summary>
    /// The maxlengt h_ vendor_ ven l name
    /// </summary>
    public const int MAXLENGTH_Vendor_VenLName = 45;

    /// <summary>
    /// The maxlengt h_ vendor_ ven mi
    /// </summary>
    public const int MAXLENGTH_Vendor_VenMI = 1;

    /// <summary>
    /// The maxlengt h_ vendor_ ven f name
    /// </summary>
    public const int MAXLENGTH_Vendor_VenFName = 45;

    /// <summary>
    /// The maxlengt h_ vendor_ ven SSN
    /// </summary>
    public const int MAXLENGTH_Vendor_VenSSN = 20;

    /// <summary>
    /// The maxlengt h_ vendor_ ven title
    /// </summary>
    public const int MAXLENGTH_Vendor_VenTitle = 30;

    /// <summary>
    /// The maxlengt h_ vendor_ ven street
    /// </summary>
    public const int MAXLENGTH_Vendor_VenStreet = 55;

    /// <summary>
    /// The maxlengt h_ vendor_ ven street2
    /// </summary>
    public const int MAXLENGTH_Vendor_VenStreet2 = 55;

    /// <summary>
    /// The maxlengt h_ vendor_ ven city
    /// </summary>
    public const int MAXLENGTH_Vendor_VenCity = 45;

    /// <summary>
    /// The maxlengt h_ vendor_ ven state
    /// </summary>
    public const int MAXLENGTH_Vendor_VenState = 3;

    /// <summary>
    /// The maxlengt h_ vendor_ ven zip
    /// </summary>
    public const int MAXLENGTH_Vendor_VenZip = 10;

    /// <summary>
    /// The maxlengt h_ vendor_ ven contact
    /// </summary>
    public const int MAXLENGTH_Vendor_VenContact = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ven contact relation
    /// </summary>
    public const int MAXLENGTH_Vendor_VenContactRelation = 22;

    /// <summary>
    /// The maxlengt h_ vendor_ ven department
    /// </summary>
    public const int MAXLENGTH_Vendor_VenDepartment = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ven extension
    /// </summary>
    public const int MAXLENGTH_Vendor_VenExtension = 5;

    /// <summary>
    /// The maxlengt h_ vendor_ ven contact phone
    /// </summary>
    public const int MAXLENGTH_Vendor_VenContactPhone = 25;

    /// <summary>
    /// The maxlengt h_ vendor_ ep pay period
    /// </summary>
    public const int MAXLENGTH_Vendor_EPPayPeriod = 11;

    /// <summary>
    /// The maxlengt h_ vendor_ ep fed status
    /// </summary>
    public const int MAXLENGTH_Vendor_EPFedStatus = 11;

    /// <summary>
    /// The maxlengt h_ vendor_ ep state status
    /// </summary>
    public const int MAXLENGTH_Vendor_EPStateStatus = 11;

    /// <summary>
    /// The maxlengt h_ vendor_ ep states wh
    /// </summary>
    public const int MAXLENGTH_Vendor_EPStatesWH = 2;

    /// <summary>
    /// The maxlengt h_ vendor_ ep states UI
    /// </summary>
    public const int MAXLENGTH_Vendor_EPStatesUI = 2;

    /// <summary>
    /// The maxlengt h_ vendor_ ep state w2 identifier
    /// </summary>
    public const int MAXLENGTH_Vendor_EPStateW2ID = 2;

    /// <summary>
    /// The maxlengt h_ vendor_ ep pay items wh
    /// </summary>
    public const int MAXLENGTH_Vendor_EPPayItemsWH = 20;

    /// <summary>
    /// The maxlengt h_ vendor_ ep pay items sui
    /// </summary>
    public const int MAXLENGTH_Vendor_EPPayItemsSUI = 20;

    /// <summary>
    /// The maxlengt h_ vendor_ ep state misc
    /// </summary>
    public const int MAXLENGTH_Vendor_EPStateMisc = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ep local status
    /// </summary>
    public const int MAXLENGTH_Vendor_EPLocalStatus = 11;

    /// <summary>
    /// The maxlengt h_ vendor_ ep local w2 identifier
    /// </summary>
    public const int MAXLENGTH_Vendor_EPLocalW2ID = 8;

    /// <summary>
    /// The maxlengt h_ vendor_ ep state di
    /// </summary>
    public const int MAXLENGTH_Vendor_EPStateDI = 2;

    /// <summary>
    /// The maxlengt h_ vendor_ ep pay items state di
    /// </summary>
    public const int MAXLENGTH_Vendor_EPPayItemsStateDI = 20;

    /// <summary>
    /// The maxlengt h_ vendor_ ven bank RTNG
    /// </summary>
    public const int MAXLENGTH_Vendor_VenBankRtng = 15;

    /// <summary>
    /// The maxlengt h_ vendor_ ven bank acct
    /// </summary>
    public const int MAXLENGTH_Vendor_VenBankAcct = 15;

    /// <summary>
    /// The maxlengt h_ vendor_ ven salt
    /// </summary>
    public const int MAXLENGTH_Vendor_VenSalt = 4;

    /// <summary>
    /// The maxlengt h_ vendor_ ven other3
    /// </summary>
    public const int MAXLENGTH_Vendor_VenOther3 = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ven other4
    /// </summary>
    public const int MAXLENGTH_Vendor_VenOther4 = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ven other5
    /// </summary>
    public const int MAXLENGTH_Vendor_VenOther5 = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ven h phone
    /// </summary>
    public const int MAXLENGTH_Vendor_VenHPhone = 25;

    /// <summary>
    /// The maxlengt h_ vendor_ ven h fax
    /// </summary>
    public const int MAXLENGTH_Vendor_VenHFax = 25;

    /// <summary>
    /// The maxlengt h_ vendor_ ven email
    /// </summary>
    public const int MAXLENGTH_Vendor_VenEmail = 255;

    /// <summary>
    /// The maxlengt h_ vendor_ ven other1
    /// </summary>
    public const int MAXLENGTH_Vendor_VenOther1 = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ ven other2
    /// </summary>
    public const int MAXLENGTH_Vendor_VenOther2 = 50;

    /// <summary>
    /// The maxlengt h_ vendor_ status
    /// </summary>
    public const int MAXLENGTH_Vendor_Status = 15;

    /// <summary>
    /// The maxlengt h_ vendor_ ven country
    /// </summary>
    public const int MAXLENGTH_Vendor_VenCountry = 35;

    /// <summary>
    /// The maxlengt h_ vendor_ ven company
    /// </summary>
    public const int MAXLENGTH_Vendor_VenCompany = 95;

    /// <summary>
    /// The maxlengt h_ vendor_ ven NSS
    /// </summary>
    public const int MAXLENGTH_Vendor_VenNSS = 65;

    /// <summary>
    /// The maxlengt h_ vendor_ ven URL
    /// </summary>
    public const int MAXLENGTH_Vendor_VenURL = 75;

    /// <summary>
    /// The maxlengt h_ vendor_ mobile number
    /// </summary>
    public const int MAXLENGTH_Vendor_MobileNumber = 25;

    /// <summary>
    /// The maxlengt h_ vendor_ qb vendor identifier
    /// </summary>
    public const int MAXLENGTH_Vendor_QBVendorID = 36;

    /// <summary>
    /// The maxlengt h_ vendor_ login identifier
    /// </summary>
    public const int MAXLENGTH_Vendor_LoginID = 65;

    /// <summary>
    /// The maxlengt h_ vendor_ reminder for
    /// </summary>
    public const int MAXLENGTH_Vendor_ReminderFor = 255;

    /// <summary>
    /// The maxlengt h_ automatic complete_ a comp identifier
    /// </summary>
    public const int MAXLENGTH_AutoComplete_ACompID = 50;

    /// <summary>
    /// The maxlengt h_ billing schedule detail_ BSD status
    /// </summary>
    public const int MAXLENGTH_BillingScheduleDetail_BSDStatus = 4;

    /// <summary>
    /// The maxlengt h_ vendor bill_ bill number
    /// </summary>
    public const int MAXLENGTH_VendorBill_BillNumber = 50;

    /// <summary>
    /// The maxlengt h_ vendor bill_ bill reference
    /// </summary>
    public const int MAXLENGTH_VendorBill_BillRef = 60;

    /// <summary>
    /// The maxlengt h_ miscellaneous_ version number
    /// </summary>
    public const int MAXLENGTH_Miscellaneous_VersionNum = 5;

    /// <summary>
    /// The maxlengt h_ miscellaneous_ last inv number
    /// </summary>
    public const int MAXLENGTH_Miscellaneous_LastInvNum = 95;

    /// <summary>
    /// The maxlengt h_ bq license_ product code
    /// </summary>
    public const int MAXLENGTH_BQLicense_ProductCode = 15;

    /// <summary>
    /// The maxlengt h_ bq license_ lic key
    /// </summary>
    public const int MAXLENGTH_BQLicense_LicKey = 65;

    /// <summary>
    /// The maxlengt h_ bq license_ numof users
    /// </summary>
    public const int MAXLENGTH_BQLicense_NumofUsers = 6;

    /// <summary>
    /// The maxlengt h_ web users_ misc1
    /// </summary>
    public const int MAXLENGTH_WebUsers_Misc1 = 50;

    /// <summary>
    /// The maxlengt h_ web users_ misc2
    /// </summary>
    public const int MAXLENGTH_WebUsers_Misc2 = 50;

    /// <summary>
    /// The maxlengt h_ web users_ product identifier
    /// </summary>
    public const int MAXLENGTH_WebUsers_ProductID = 20;

    /// <summary>
    /// The maxlengt h_ BQS table_ parameter name
    /// </summary>
    public const int MAXLENGTH_BQSTable_ParamName = 250;

    /// <summary>
    /// The maxlengt h_ work flow_ linked record identifier
    /// </summary>
    public const int MAXLENGTH_WorkFlow_LinkedRecordID = 95;

    /// <summary>
    /// The maxlengt h_ work flow_ action by
    /// </summary>
    public const int MAXLENGTH_WorkFlow_ActionBy = 65;

    /// <summary>
    /// The maxlengt h_ work flow_ sent to
    /// </summary>
    public const int MAXLENGTH_WorkFlow_SentTo = 65;

    /// <summary>
    /// The maxlengt h_ work flow_ work flow type
    /// </summary>
    public const int MAXLENGTH_WorkFlow_WorkFlowType = 50;

    /// <summary>
    /// The maxlengt h_ notification members_ linked record identifier
    /// </summary>
    public const int MAXLENGTH_NotificationMembers_LinkedRecordID = 95;

    /// <summary>
    /// The maxlengt h_ bq users_ misc1
    /// </summary>
    public const int MAXLENGTH_BQUsers_Misc1 = 50;

    /// <summary>
    /// The maxlengt h_ bq users_ misc2
    /// </summary>
    public const int MAXLENGTH_BQUsers_Misc2 = 50;

    /// <summary>
    /// The maxlengt h_ passwords_ user identifier
    /// </summary>
    public const int MAXLENGTH_Passwords_UserID = 15;

    /// <summary>
    /// The maxlengt h_ passwords_u password
    /// </summary>
    public const int MAXLENGTH_Passwords_uPassword = 255;

    /// <summary>
    /// The maxlengt h_ budget_ budget identifier
    /// </summary>
    public const int MAXLENGTH_Budget_BudgetID = 21;

    /// <summary>
    /// The maxlengt h_ budget_ budget group desc
    /// </summary>
    public const int MAXLENGTH_Budget_BudgetGroupDesc = 50;

    /// <summary>
    /// The maxlengt h_ budget_ status
    /// </summary>
    public const int MAXLENGTH_Budget_Status = 15;

    /// <summary>
    /// The maxlengt h_ payment_ pay method
    /// </summary>
    public const int MAXLENGTH_Payment_PayMethod = 2;

    /// <summary>
    /// The maxlengt h_ payment_ pay reference
    /// </summary>
    public const int MAXLENGTH_Payment_PayRef = 60;

    /// <summary>
    /// The maxlengt h_ payment_ pay memo
    /// </summary>
    public const int MAXLENGTH_Payment_PayMemo = 60;

    /// <summary>
    /// The maxlengt h_ budget activity_ ba description
    /// </summary>
    public const int MAXLENGTH_BudgetActivity_BADescription = 100;

    /// <summary>
    /// The maxlengt h_ budget activity_ other1
    /// </summary>
    public const int MAXLENGTH_BudgetActivity_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ budget activity_ other2
    /// </summary>
    public const int MAXLENGTH_BudgetActivity_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ budget activity_ other3
    /// </summary>
    public const int MAXLENGTH_BudgetActivity_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ payment archive_ pay method
    /// </summary>
    public const int MAXLENGTH_PaymentArchive_PayMethod = 2;

    /// <summary>
    /// The maxlengt h_ payment archive_ pay reference
    /// </summary>
    public const int MAXLENGTH_PaymentArchive_PayRef = 60;

    /// <summary>
    /// The maxlengt h_ payment archive_ pay memo
    /// </summary>
    public const int MAXLENGTH_PaymentArchive_PayMemo = 60;

    /// <summary>
    /// The maxlengt h_ budget expense_ be description
    /// </summary>
    public const int MAXLENGTH_BudgetExpense_BEDescription = 100;

    /// <summary>
    /// The maxlengt h_ budget expense_ other1
    /// </summary>
    public const int MAXLENGTH_BudgetExpense_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ budget expense_ other2
    /// </summary>
    public const int MAXLENGTH_BudgetExpense_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ budget expense_ other3
    /// </summary>
    public const int MAXLENGTH_BudgetExpense_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ change identifier history_ bq table name
    /// </summary>
    public const int MAXLENGTH_ChangeIDHistory_BQTableName = 95;

    /// <summary>
    /// The maxlengt h_ change identifier history_ original identifier
    /// </summary>
    public const int MAXLENGTH_ChangeIDHistory_OriginalID = 95;

    /// <summary>
    /// The maxlengt h_ change identifier history_ new identifier
    /// </summary>
    public const int MAXLENGTH_ChangeIDHistory_NewID = 95;

    /// <summary>
    /// The maxlengt h_ client_ client identifier
    /// </summary>
    public const int MAXLENGTH_Client_ClientID = 65;

    /// <summary>
    /// The maxlengt h_ client_ client fed identifier
    /// </summary>
    public const int MAXLENGTH_Client_FederationID = 20;

    /// <summary>
    /// The maxlengt h_ client_ client company
    /// </summary>
    public const int MAXLENGTH_Client_Company = 55;

    /// <summary>
    /// The maxlengt h_ client_ client street
    /// </summary>
    public const int MAXLENGTH_Client_ClientStreet = 55;

    /// <summary>
    /// The maxlengt h_ client_ client street2
    /// </summary>
    public const int MAXLENGTH_Client_ClientStreet2 = 55;

    /// <summary>
    /// The maxlengt h_ client_ client city
    /// </summary>
    public const int MAXLENGTH_Client_ClientCity = 45;

    /// <summary>
    /// The maxlengt h_ client_ client state
    /// </summary>
    //  public const int MAXLENGTH_Client_ClientState = 3;
    /// <summary>
    /// The maxlengt h_ client_ client zip
    /// </summary>
    public const int MAXLENGTH_Client_ClientZip = 10;

    /// <summary>
    /// The maxlengt h_ client_ client l name
    /// </summary>
    public const int MAXLENGTH_Client_LastName = 45;

    /// <summary>
    /// The maxlengt h_ client_ client f name
    /// </summary>
    public const int MAXLENGTH_Client_FirstName = 45;

    /// <summary>
    /// The maxlengt h_ client_ client mi
    /// </summary>
    public const int MAXLENGTH_Client_MiddleIntial = 1;

    /// <summary>
    /// The maxlengt h_ client_ client main phone
    /// </summary>
    public const int MAXLENGTH_Client_ClientMainPhone = 25;

    /// <summary>
    /// The maxlengt h_ client_ client main ext
    /// </summary>
    public const int MAXLENGTH_Client_ClientMainExt = 5;

    /// <summary>
    /// The maxlengt h_ client_ client main fax
    /// </summary>
    public const int MAXLENGTH_Client_ClientMainFax = 25;

    /// <summary>
    /// The maxlengt h_ client_ client main salt
    /// </summary>
    public const int MAXLENGTH_Client_Salutation = 11;

    /// <summary>
    /// The maxlengt h_ client_ client other3
    /// </summary>
    public const int MAXLENGTH_Client_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ client_ client other4
    /// </summary>
    public const int MAXLENGTH_Client_Other4 = 50;

    /// <summary>
    /// The maxlengt h_ client_ client other5
    /// </summary>
    public const int MAXLENGTH_Client_Other5 = 50;

    /// <summary>
    /// The maxlengt h_ client_ client phone
    /// </summary>
    public const int MAXLENGTH_Client_ClientPhone = 25;

    /// <summary>
    /// The maxlengt h_ client_ client fax
    /// </summary>
    public const int MAXLENGTH_Client_ClientFax = 25;

    /// <summary>
    /// The maxlengt h_ client_ client email
    /// </summary>
    public const int MAXLENGTH_Client_ClientEmail = 255;

    /// <summary>
    /// The maxlengt h_ client_ client URL
    /// </summary>
    public const int MAXLENGTH_Client_ClientURL = 75;

    /// <summary>
    /// The maxlengt h_ client_ client other1
    /// </summary>
    public const int MAXLENGTH_Client_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ client_ client other2
    /// </summary>
    public const int MAXLENGTH_Client_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ client_ status
    /// </summary>
    public const int MAXLENGTH_Client_Status = 15;

    /// <summary>
    /// The maxlengt h_ client_ client country
    /// </summary>
    /// <summary>
    /// The maxlengt h_ client_ mobile number
    /// </summary>
    public const int MAXLENGTH_Client_MobileNumber = 25;

    /// <summary>
    /// The maxlengt h_ client_ message on invoice
    /// </summary>
    public const int MAXLENGTH_Client_MessageOnInvoice = 255;

    /// <summary>
    /// The maxlengt h_ project_ project identifier
    /// </summary>
    public const int MAXLENGTH_Project_ProjectID = 65;

    /// <summary>
    /// The maxlengt h_ project_ project code
    /// </summary>
    public const int MAXLENGTH_Project_ProjectCode = 54;

    /// <summary>
    /// The maxlengt h_ project_ project phase
    /// </summary>
    public const int MAXLENGTH_Project_ProjectPhase = 10;

    /// <summary>
    /// The maxlengt h_ project_ project name
    /// </summary>
    public const int MAXLENGTH_Project_ProjectName = 50;

    /// <summary>
    /// The maxlengt h_ project_ project street
    /// </summary>
    public const int MAXLENGTH_Project_ProjectStreet = 55;

    /// <summary>
    /// The maxlengt h_ project_ project city
    /// </summary>
    public const int MAXLENGTH_Project_ProjectCity = 45;

    /// <summary>
    /// The maxlengt h_ project_ project state
    /// </summary>
    public const int MAXLENGTH_Project_ProjectState = 3;

    /// <summary>
    /// The maxlengt h_ project_ project zip
    /// </summary>
    public const int MAXLENGTH_Project_ProjectZip = 10;

    /// <summary>
    /// The maxlengt h_ project_ project invoice type
    /// </summary>
    public const int MAXLENGTH_Project_ProjectInvoiceType = 8;

    /// <summary>
    /// The maxlengt h_ project_ project invoice file
    /// </summary>
    public const int MAXLENGTH_Project_ProjectInvoiceFile = 95;

    /// <summary>
    /// The maxlengt h_ project_ project statement type
    /// </summary>
    public const int MAXLENGTH_Project_ProjectStatementType = 8;

    /// <summary>
    /// The maxlengt h_ project_ project statement file
    /// </summary>
    public const int MAXLENGTH_Project_ProjectStatementFile = 95;

    /// <summary>
    /// The maxlengt h_ project_ project mi type
    /// </summary>
    public const int MAXLENGTH_Project_ProjectMIType = 8;

    /// <summary>
    /// The maxlengt h_ project_ project mi file
    /// </summary>
    public const int MAXLENGTH_Project_ProjectMIFile = 95;

    /// <summary>
    /// The maxlengt h_ project_ project con type
    /// </summary>
    public const int MAXLENGTH_Project_ProjectConType = 20;

    /// <summary>
    /// The maxlengt h_ project_ project status
    /// </summary>
    public const int MAXLENGTH_Project_ProjectStatus = 15;

    /// <summary>
    /// The maxlengt h_ project_ project bill sched freq
    /// </summary>
    public const int MAXLENGTH_Project_ProjectBillSchedFreq = 15;

    /// <summary>
    /// The maxlengt h_ project_ profile code
    /// </summary>
    public const int MAXLENGTH_Project_ProfileCode = 5;

    /// <summary>
    /// The maxlengt h_ project_ project joint inv type
    /// </summary>
    public const int MAXLENGTH_Project_ProjectJointInvType = 8;

    /// <summary>
    /// The maxlengt h_ project_ project joint inv file
    /// </summary>
    public const int MAXLENGTH_Project_ProjectJointInvFile = 95;

    /// <summary>
    /// The maxlengt h_ project_ phase description
    /// </summary>
    public const int MAXLENGTH_Project_PhaseDescription = 50;

    /// <summary>
    /// The maxlengt h_ project_ project other1
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther1 = 50;

    /// <summary>
    /// The maxlengt h_ project_ project other2
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther2 = 50;

    /// <summary>
    /// The maxlengt h_ project_ project other3
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther3 = 50;

    /// <summary>
    /// The maxlengt h_ project_ project other4
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther4 = 50;

    /// <summary>
    /// The maxlengt h_ project_ project other5
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther5 = 50;

    /// <summary>
    /// The maxlengt h_ project_ project street2
    /// </summary>
    public const int MAXLENGTH_Project_ProjectStreet2 = 55;

    /// <summary>
    /// The maxlengt h_ project_ project po number
    /// </summary>
    public const int MAXLENGTH_Project_ProjectPONum = 35;

    /// <summary>
    /// The maxlengt h_ project_ project country
    /// </summary>
    public const int MAXLENGTH_Project_ProjectCountry = 35;

    /// <summary>
    /// The maxlengt h_ project_ project other6
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther6 = 55;

    /// <summary>
    /// The maxlengt h_ project_ project other7
    /// </summary>
    public const int MAXLENGTH_Project_ProjectOther7 = 55;

    /// <summary>
    /// The maxlengt h_ project_ qb class identifier
    /// </summary>
    public const int MAXLENGTH_Project_QBClassID = 36;

    /// <summary>
    /// The maxlengt h_ project_ message on invoice
    /// </summary>
    public const int MAXLENGTH_Project_MessageOnInvoice = 255;

    /// <summary>
    /// The maxlengt h_ project_ inv prefix
    /// </summary>
    public const int MAXLENGTH_Project_InvPrefix = 65;

    /// <summary>
    /// The maxlengt h_ project_ inv number
    /// </summary>
    public const int MAXLENGTH_Project_InvNum = 21;

    /// <summary>
    /// The maxlengt h_ project_ inv post fix
    /// </summary>
    public const int MAXLENGTH_Project_InvPostFix = 65;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con identifier
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConID = 15;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con f name
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConFName = 45;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con l name
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConLName = 45;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con mi
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConMI = 1;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con w phone
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConWPhone = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con ext
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConExt = 5;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con w fax
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConWFax = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con email
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConEmail = 255;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con pager
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConPager = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con mobile
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConMobile = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con h fax
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConHFax = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con dept
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConDept = 50;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con h phone
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConHPhone = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con title
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConTitle = 50;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con salt
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConSalt = 11;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con company
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConCompany = 55;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con street
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConStreet = 55;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con street2
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConStreet2 = 55;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con city
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConCity = 45;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con state
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConState = 3;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con zip
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConZip = 10;

    /// <summary>
    /// The maxlengt h_ client contact_ cli con country
    /// </summary>
    public const int MAXLENGTH_ClientContact_CliConCountry = 35;

    /// <summary>
    /// The maxlengt h_ client contact_ mobile number
    /// </summary>
    public const int MAXLENGTH_ClientContact_MobileNumber = 25;

    /// <summary>
    /// The maxlengt h_ client contact_ other1
    /// </summary>
    public const int MAXLENGTH_ClientContact_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ client contact_ other2
    /// </summary>
    public const int MAXLENGTH_ClientContact_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ client contact_ other3
    /// </summary>
    public const int MAXLENGTH_ClientContact_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ project control_ classification
    /// </summary>
    public const int MAXLENGTH_ProjectControl_Classification = 100;

    /// <summary>
    /// The maxlengt h_ client group_ cgid
    /// </summary>
    public const int MAXLENGTH_ClientGroup_CGID = 15;

    /// <summary>
    /// The maxlengt h_ client group_ cg name
    /// </summary>
    public const int MAXLENGTH_ClientGroup_CGName = 35;

    /// <summary>
    /// The maxlengt h_ project group_ pgid
    /// </summary>
    public const int MAXLENGTH_ProjectGroup_PGID = 15;

    /// <summary>
    /// The maxlengt h_ project group_ pg name
    /// </summary>
    public const int MAXLENGTH_ProjectGroup_PGName = 35;

    /// <summary>
    /// The maxlengt h_ project group_ qb class identifier
    /// </summary>
    public const int MAXLENGTH_ProjectGroup_QBClassID = 36;

    /// <summary>
    /// The maxlengt h_ company_ co address
    /// </summary>
    public const int MAXLENGTH_Company_CoAddress = 55;

    /// <summary>
    /// The maxlengt h_ company_ co city
    /// </summary>
    public const int MAXLENGTH_Company_CoCity = 45;

    /// <summary>
    /// The maxlengt h_ company_ co state
    /// </summary>
    public const int MAXLENGTH_Company_CoState = 3;

    /// <summary>
    /// The maxlengt h_ company_ co zip
    /// </summary>
    public const int MAXLENGTH_Company_CoZip = 10;

    /// <summary>
    /// The maxlengt h_ company_ co address2
    /// </summary>
    public const int MAXLENGTH_Company_CoAddress2 = 35;

    /// <summary>
    /// The maxlengt h_ company_ co tax identifier
    /// </summary>
    public const int MAXLENGTH_Company_CoTaxID = 20;

    /// <summary>
    /// The maxlengt h_ company_ co employer identifier
    /// </summary>
    public const int MAXLENGTH_Company_CoEmployerID = 9;

    /// <summary>
    /// The maxlengt h_ company_ lic key
    /// </summary>
    public const int MAXLENGTH_Company_LicKey = 50;

    /// <summary>
    /// The maxlengt h_ company_ co name
    /// </summary>
    public const int MAXLENGTH_Company_CoName = 95;

    /// <summary>
    /// The maxlengt h_ company_ co phone
    /// </summary>
    public const int MAXLENGTH_Company_CoPhone = 25;

    /// <summary>
    /// The maxlengt h_ company_ co fax
    /// </summary>
    public const int MAXLENGTH_Company_CoFax = 25;

    /// <summary>
    /// The maxlengt h_ company_ co email
    /// </summary>
    public const int MAXLENGTH_Company_CoEmail = 150;

    /// <summary>
    /// The maxlengt h_ company_ co URL
    /// </summary>
    public const int MAXLENGTH_Company_CoURL = 75;

    /// <summary>
    /// The maxlengt h_ company_ co country
    /// </summary>
    public const int MAXLENGTH_Company_CoCountry = 35;

    /// <summary>
    /// The maxlengt h_ company_ other1
    /// </summary>
    public const int MAXLENGTH_Company_Other1 = 50;

    /// <summary>
    /// The maxlengt h_ company_ other2
    /// </summary>
    public const int MAXLENGTH_Company_Other2 = 50;

    /// <summary>
    /// The maxlengt h_ company_ other3
    /// </summary>
    public const int MAXLENGTH_Company_Other3 = 50;

    /// <summary>
    /// The maxlengt h_ company_ other4
    /// </summary>
    public const int MAXLENGTH_Company_Other4 = 50;

    /// <summary>
    /// The maxlengt h_ company_ other5
    /// </summary>
    public const int MAXLENGTH_Company_Other5 = 50;

    /// <summary>
    /// The maxlengt h_ company_ message on invoice
    /// </summary>
    public const int MAXLENGTH_Company_MessageOnInvoice = 255;

    /// <summary>
    /// The maxlengt h_ project journal_ link identifier
    /// </summary>
    public const int MAXLENGTH_ProjectJournal_LinkID = 95;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ billing schedule detail_ project identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_BillingScheduleDetail_ProjectID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ billing schedule detail_ BSD status
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_BillingScheduleDetail_BSDStatus = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ billing schedule detail_ BSD notes
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_BillingScheduleDetail_BSDNotes = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ security table_ employee identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_SecurityTable_EmployeeID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ security table_ settings
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_SecurityTable_Settings = -1;

    /// <summary>
    /// The maxlengt h_ project journaltype_ description
    /// </summary>
    public const int MAXLENGTH_ProjectJournaltype_Description = 65;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_calc last bill inv number
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_calcLastBillInvNum = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ project identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_ProjectID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ transaction inv number
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_TransactionInvNum = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ transaction inv send bill flag
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_TransactionInvSendBillFlag = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ inv send statement flag
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_InvSendStatementFlag = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ transaction inv status
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_TransactionInvStatus = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ transaction memo
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_TransactionMemo = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ transaction memo2
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_TransactionMemo2 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ client identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_ClientID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ cli con identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_CliConID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ other1
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_Other1 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ other2
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_Other2 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ other3
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_Other3 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ other4
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_Other4 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ other5
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_Other5 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ qb link identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_QBLinkID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ employee identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_EmployeeID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ currency data format
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_CurrencyDataFormat = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ message on invoice
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_MessageOnInvoice = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ submitted by
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_SubmittedBy = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ approved by
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_ApprovedBy = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ reference number
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_ReferenceNum = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ rf number
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_RFNumber = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ transaction table_ project po
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_TransactionTable_ProjectPO = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ user registry_ employee identifier
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_UserRegistry_EmployeeID = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ user registry_ param1
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_UserRegistry_Param1 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ user registry_ param2
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_UserRegistry_Param2 = -1;

    /// <summary>
    /// The maxlengt h_ conv_ temp_ user registry_ param3
    /// </summary>
    public const int MAXLENGTH_Conv_Temp_UserRegistry_Param3 = -1;

    /// <summary>
    /// The maxlengt h_ currency multiplier_ country
    /// </summary>
    public const int MAXLENGTH_CurrencyMultiplier_Country = 64;

    /// <summary>
    /// The maxlengt h_ currency multiplier_ decimal character
    /// </summary>
    public const int MAXLENGTH_CurrencyMultiplier_DecimalChar = 1;

    /// <summary>
    /// The maxlengt h_ currency multiplier_ separator character
    /// </summary>
    public const int MAXLENGTH_CurrencyMultiplier_SeparatorChar = 1;

    /// <summary>
    /// The maxlengt h_ currency multiplier_ country code
    /// </summary>
    public const int MAXLENGTH_CurrencyMultiplier_CountryCode = 5;

    /// <summary>
    /// The maxlengt h_ currency multiplier_ currency symbol
    /// </summary>
    public const int MAXLENGTH_CurrencyMultiplier_CurrencySymbol = 10;

    /// <summary>
    /// The maxlengt h_ customdd list_ list name
    /// </summary>
    public const int MAXLENGTH_CustomddList_ListName = 100;

    /// <summary>
    /// The maxlengt h_ pt payroll_ payroll item
    /// </summary>
    public const int MAXLENGTH_PTPayroll_PayrollItem = 95;

    /// <summary>
    /// The maxlengt h_ customdd list detail_ description
    /// </summary>
    public const int MAXLENGTH_CustomddListDetail_Description = 100;

    /// <summary>
    /// The maxlengt h_ purchase order_ po number
    /// </summary>
    public const int MAXLENGTH_PurchaseOrder_PONumber = 50;

    /// <summary>
    /// The maxlengt h_ custom label_c table name
    /// </summary>
    public const int MAXLENGTH_CustomLabel_cTableName = 35;

    /// <summary>
    /// The maxlengt h_ custom label_c field name
    /// </summary>
    public const int MAXLENGTH_CustomLabel_cFieldName = 50;

    /// <summary>
    /// The maxlengt h_ custom label_c field caption
    /// </summary>
    public const int MAXLENGTH_CustomLabel_cFieldCaption = 30;

    /// <summary>
    /// The maxlengt h_ custom label_c field mask
    /// </summary>
    public const int MAXLENGTH_CustomLabel_cFieldMask = 95;

    /// <summary>
    /// The maxlengt h_ custom label_c field type
    /// </summary>
    public const int MAXLENGTH_CustomLabel_cFieldType = 15;

    /// <summary>
    /// The maxlengt h_ custom label_ UI type
    /// </summary>
    public const int MAXLENGTH_CustomLabel_UIType = 20;

    /// <summary>
    /// The maxlengt h_ purchase order detail_ description
    /// </summary>
    public const int MAXLENGTH_PurchaseOrderDetail_Description = 100;

    /// <summary>
    /// The maxlengt h_ employee_ employee identifier
    /// </summary>
    public const int MAXLENGTH_Employee_EmployeeID = 65;

    /// <summary>
    /// The maxlengt h_ employee_ emp l name
    /// </summary>
    public const int MAXLENGTH_Employee_EmpLName = 45;

    /// <summary>
    /// The maxlengt h_ employee_ emp mi
    /// </summary>
    public const int MAXLENGTH_Employee_EmpMI = 1;

    /// <summary>
    /// The maxlengt h_ employee_ emp f name
    /// </summary>
    public const int MAXLENGTH_Employee_EmpFName = 45;

    /// <summary>
    /// The maxlengt h_ employee_ emp SSN
    /// </summary>
    public const int MAXLENGTH_Employee_EmpSSN = 20;

    /// <summary>
    /// The maxlengt h_ employee_ emp title
    /// </summary>
    public const int MAXLENGTH_Employee_EmpTitle = 30;

    /// <summary>
    /// The maxlengt h_ employee_ emp street
    /// </summary>
    public const int MAXLENGTH_Employee_EmpStreet = 55;

    /// <summary>
    /// The maxlengt h_ employee_ emp street2
    /// </summary>
    public const int MAXLENGTH_Employee_EmpStreet2 = 55;

    /// <summary>
    /// The maxlengt h_ employee_ emp city
    /// </summary>
    public const int MAXLENGTH_Employee_EmpCity = 45;

    /// <summary>
    /// The maxlengt h_ employee_ emp state
    /// </summary>
    public const int MAXLENGTH_Employee_EmpState = 3;

    /// <summary>
    /// The maxlengt h_ employee_ emp zip
    /// </summary>
    public const int MAXLENGTH_Employee_EmpZip = 10;

    /// <summary>
    /// The maxlengt h_ employee_ emp contact
    /// </summary>
    public const int MAXLENGTH_Employee_EmpContact = 50;

    /// <summary>
    /// The maxlengt h_ employee_ emp contact relation
    /// </summary>
    public const int MAXLENGTH_Employee_EmpContactRelation = 22;

    /// <summary>
    /// The maxlengt h_ employee_ emp department
    /// </summary>
    public const int MAXLENGTH_Employee_EmpDepartment = 50;

    /// <summary>
    /// The maxlengt h_ employee_ emp extension
    /// </summary>
    public const int MAXLENGTH_Employee_EmpExtension = 5;

    /// <summary>
    /// The maxlengt h_ employee_ emp contact phone
    /// </summary>
    public const int MAXLENGTH_Employee_EmpContactPhone = 25;

    /// <summary>
    /// The maxlengt h_ employee_ ep pay period
    /// </summary>
    public const int MAXLENGTH_Employee_EPPayPeriod = 11;

    /// <summary>
    /// The maxlengt h_ employee_ ep fed status
    /// </summary>
    public const int MAXLENGTH_Employee_EPFedStatus = 11;

    /// <summary>
    /// The maxlengt h_ employee_ ep state status
    /// </summary>
    public const int MAXLENGTH_Employee_EPStateStatus = 11;

    /// <summary>
    /// The maxlengt h_ employee_ ep states wh
    /// </summary>
    public const int MAXLENGTH_Employee_EPStatesWH = 2;

    /// <summary>
    /// The maxlengt h_ employee_ ep states UI
    /// </summary>
    public const int MAXLENGTH_Employee_EPStatesUI = 2;

    /// <summary>
    /// The maxlengt h_ employee_ ep state w2 identifier
    /// </summary>
    public const int MAXLENGTH_Employee_EPStateW2ID = 2;

    /// <summary>
    /// The maxlengt h_ employee_ ep pay items wh
    /// </summary>
    public const int MAXLENGTH_Employee_EPPayItemsWH = 20;

    /// <summary>
    /// The maxlengt h_ employee_ ep pay items sui
    /// </summary>
    public const int MAXLENGTH_Employee_EPPayItemsSUI = 20;

    /// <summary>
    /// The maxlengt h_ employee_ ep state misc
    /// </summary>
    public const int MAXLENGTH_Employee_EPStateMisc = 50;

    /// <summary>
    /// The maxlengt h_ employee_ ep local status
    /// </summary>
    public const int MAXLENGTH_Employee_EPLocalStatus = 11;

    /// <summary>
    /// The maxlengt h_ employee_ ep local w2 identifier
    /// </summary>
    public const int MAXLENGTH_Employee_EPLocalW2ID = 8;

    /// <summary>
    /// The maxlengt h_ employee_ ep state di
    /// </summary>
    public const int MAXLENGTH_Employee_EPStateDI = 2;

    /// <summary>
    /// The maxlengt h_ employee_ ep pay items state di
    /// </summary>
    public const int MAXLENGTH_Employee_EPPayItemsStateDI = 20;

    /// <summary>
    /// The maxlengt h_ employee_ emp bank RTNG
    /// </summary>
    public const int MAXLENGTH_Employee_EmpBankRtng = 15;

    /// <summary>
    /// The maxlengt h_ employee_ emp bank acct
    /// </summary>
    public const int MAXLENGTH_Employee_EmpBankAcct = 15;

    /// <summary>
    /// The maxlengt h_ employee_ emp salt
    /// </summary>
    public const int MAXLENGTH_Employee_EmpSalt = 4;

    /// <summary>
    /// The maxlengt h_ employee_ emp other3
    /// </summary>
    public const int MAXLENGTH_Employee_EmpOther3 = 50;

    /// <summary>
    /// The maxlengt h_ employee_ emp other4
    /// </summary>
    public const int MAXLENGTH_Employee_EmpOther4 = 50;

    /// <summary>
    /// The maxlengt h_ employee_ emp other5
    /// </summary>
    public const int MAXLENGTH_Employee_EmpOther5 = 50;

    /// <summary>
    /// The maxlengt h_ employee_ emp h phone
    /// </summary>
    public const int MAXLENGTH_Employee_EmpHPhone = 25;

    /// <summary>
    /// The maxlengt h_ employee_ emp other1
    /// </summary>
    public const int MAXLENGTH_Employee_EmpOther1 = 50;

    /// <summary>
    /// The maxlengt h_ employee_ emp other2
    /// </summary>
    public const int MAXLENGTH_Employee_EmpOther2 = 50;

    /// <summary>
    /// The maxlengt h_ employee_ status
    /// </summary>
    public const int MAXLENGTH_Employee_Status = 15;

    /// <summary>
    /// The maxlengt h_ employee_ emp country
    /// </summary>
    public const int MAXLENGTH_Employee_EmpCountry = 35;

    /// <summary>
    /// The maxlengt h_ employee_ emp company
    /// </summary>
    public const int MAXLENGTH_Employee_EmpCompany = 95;


    /// <summary>
    /// The maxlengt h_ employee_ emp URL
    /// </summary>
    public const int MAXLENGTH_Employee_EmpURL = 75;

    /// <summary>
    /// The maxlengt h_ employee_ mobile number
    /// </summary>
    public const int MAXLENGTH_Employee_MobileNumber = 25;

    /// <summary>
    /// The maxlengt h_ employee_ qb vendor identifier
    /// </summary>
    public const int MAXLENGTH_Employee_QBVendorID = 36;

    /// <summary>
    /// The maxlengt h_ employee_ login identifier
    /// </summary>
    public const int MAXLENGTH_Employee_LoginID = 65;

    /// <summary>
    /// The maxlengt h_ employee_ reminder for
    /// </summary>
    public const int MAXLENGTH_Employee_ReminderFor = 255;

    /// <summary>
    /// The maxlengt h_ qb payroll_ payroll item
    /// </summary>
    public const int MAXLENGTH_QBPayroll_PayrollItem = 95;

    /// <summary>
    /// The maxlengt h_ employee group_ egid
    /// </summary>
    public const int MAXLENGTH_EmployeeGroup_EGID = 15;

    /// <summary>
    /// The maxlengt h_ employee group_ eg name
    /// </summary>
    public const int MAXLENGTH_EmployeeGroup_EGName = 35;

    /// <summary>
    /// The maxlengt h_ account list_ account identifier
    /// </summary>
    public const int MAXLENGTH_AccountList_AccountID = 50;

    /// <summary>
    /// The maxlengt h_ account list_ account name
    /// </summary>
    public const int MAXLENGTH_AccountList_AccountName = 65;

    /// <summary>
    /// The maxlengt h_ account list_ account desc
    /// </summary>
    public const int MAXLENGTH_AccountList_AccountDesc = 255;

    /// <summary>
    /// The maxlengt h_ account list_ last journal entry number
    /// </summary>
    public const int MAXLENGTH_AccountList_LastJournalEntryNumber = 95;

    /// <summary>
    /// The maxlengt h_ address_ address1
    /// </summary>
    public const int MAXLENGTH_Address_Address1 = 55;

    /// <summary>
    /// The maxlengt h_ address_ address2
    /// </summary>
    public const int MAXLENGTH_Address_Address2 = 55;

    /// <summary>
    /// The maxlengt h_ address_ zip
    /// </summary>
    public const int MAXLENGTH_Address_Zip = 15;

    /// <summary>
    /// The maxlengt h_ address_ city
    /// </summary>
    public const int MAXLENGTH_Address_City = 45;

    /// <summary>
    /// The maxlengt h_ address_ first_ name
    /// </summary>
    public const int MAXLENGTH_Address_First_Name = 50;

    /// <summary>
    /// The maxlengt h_ address_ last_ name
    /// </summary>
    public const int MAXLENGTH_Address_Last_Name = 50;

    /// <summary>
    /// The maxlengt h_ address_ middle_ initial
    /// </summary>
    public const int MAXLENGTH_Address_Middle_Initial = 6;

    /// <summary>
    /// The maxlengt h_ address_ company_ name
    /// </summary>
    public const int MAXLENGTH_Address_Company_Name = 100;

    /// <summary>
    /// The maxlengt h_ address_ salutation
    /// </summary>
    public const int MAXLENGTH_Address_Salutation = 50;

    /// <summary>
    /// The maxlengt h_ address_ country
    /// </summary>
    public const int MAXLENGTH_Address_Country = 50;

    /// <summary>
    /// The maxlengt h_ address_ state
    /// </summary>
    public const int MAXLENGTH_Address_State = 50;

    /// <summary>
    /// The maxlengt h_ query_ query name
    /// </summary>
    public const int MAXLENGTH_Query_QueryName = 50;

    /// <summary>
    /// The maxlengt h_ query_ q1 field
    /// </summary>
    public const int MAXLENGTH_Query_Q1Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q1 to
    /// </summary>
    public const int MAXLENGTH_Query_Q1To = 50;

    /// <summary>
    /// The maxlengt h_ query_ q2 field
    /// </summary>
    public const int MAXLENGTH_Query_Q2Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q2 to
    /// </summary>
    public const int MAXLENGTH_Query_Q2To = 50;

    /// <summary>
    /// The maxlengt h_ query_ q3 field
    /// </summary>
    public const int MAXLENGTH_Query_Q3Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q4 field
    /// </summary>
    public const int MAXLENGTH_Query_Q4Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q5 field
    /// </summary>
    public const int MAXLENGTH_Query_Q5Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q6 field
    /// </summary>
    public const int MAXLENGTH_Query_Q6Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q3 to
    /// </summary>
    public const int MAXLENGTH_Query_Q3To = 50;

    /// <summary>
    /// The maxlengt h_ query_ q4 to
    /// </summary>
    public const int MAXLENGTH_Query_Q4To = 50;

    /// <summary>
    /// The maxlengt h_ query_ q5 to
    /// </summary>
    public const int MAXLENGTH_Query_Q5To = 50;

    /// <summary>
    /// The maxlengt h_ query_ q6 to
    /// </summary>
    public const int MAXLENGTH_Query_Q6To = 50;

    /// <summary>
    /// The maxlengt h_ query_ query report
    /// </summary>
    public const int MAXLENGTH_Query_QueryReport = 100;

    /// <summary>
    /// The maxlengt h_ query_ q1 date range
    /// </summary>
    public const int MAXLENGTH_Query_Q1DateRange = 50;

    /// <summary>
    /// The maxlengt h_ query_ q2 date range
    /// </summary>
    public const int MAXLENGTH_Query_Q2DateRange = 50;

    /// <summary>
    /// The maxlengt h_ query_ q7 field
    /// </summary>
    public const int MAXLENGTH_Query_Q7Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q7 to
    /// </summary>
    public const int MAXLENGTH_Query_Q7To = 50;

    /// <summary>
    /// The maxlengt h_ query_ q8 field
    /// </summary>
    public const int MAXLENGTH_Query_Q8Field = 50;

    /// <summary>
    /// The maxlengt h_ query_ q8 to
    /// </summary>
    public const int MAXLENGTH_Query_Q8To = 50;

    /// <summary>
    /// The maxlengt h_ query_ memorized group
    /// </summary>
    public const int MAXLENGTH_Query_MemorizedGroup = 255;

    /// <summary>
    /// The maxlengt ClassName of ClassList
    /// </summary>
    public const int MAXLENGTH_ClassList_ClassName = 255;


    public const string UserPromptPreference = "USERPROMPT_PREFERENCE";

}



/// <summary>
/// 
/// </summary>
public static class Constants
{
    public const uint DigitsAfterDecimalForAmount = 2U;

    public const uint BillingReviewMinRecordCount = 25U;

    public const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadCommitted;

    public const string ListCustomFieldFilter = "List%_CustomField&_Field";
    /// <summary>
    /// 
    /// </summary>
    public class MasterInformation
    {
        /// <summary>
        /// Automatic increment project identifier instance.
        /// </summary>
        public const string AutoIncrementProjectID = "AUTO_PROJECTID";

        /// <summary>
        /// Last project code instance.
        /// </summary>
        public const string LastProjectCode = "LAST_PROJECTID";

        /// <summary>
        /// Track important project changes instance.
        /// </summary>
        public const string TrackImportantProjectChanges = "FRMPROJECT_PROJECT_TRACKING";

        /// <summary>
        /// Project contract amount includes taxes instance.
        /// </summary>
        public const string ProjectContractAmountIncludesTaxes = "FRMBILLREV_CONTRACT_AMOUNT_TAX";

        /// <summary>
        /// Use rates from activity instance.
        /// </summary>
        public const string UseRatesFromActivity = "FRMPROJECT_USE_RATES_IN_ACTIVITY_CODES";

        /// <summary>
        /// Employee hours per day instance.
        /// </summary>
        public const string EmployeeHoursPerDay = "FRMEMP_STDDAYHRS";

        /// <summary>
        /// Employee hours per week instance.
        /// </summary>
        public const string EmployeeHoursPerWeek = "FRMEMP_STDWEEKHRS";

        /// <summary>
        /// Vacation time off activity identifier instance.
        /// </summary>
        public const string VacationTimeOffActivityID = "ACTIVITY_VAC";

        /// <summary>
        /// Expense part of contract amount instance.
        /// </summary>
        public const string ExpensePartOfContractAmount = "FRMPROJECT_EXPENSE_PART_OF_CONTRACT";

        /// <summary>
        /// Efficiency threshold instance.
        /// </summary>
        public const string EfficiencyThreshold = "EFFICIENCY_THRESHOLD";

        /// <summary>
        /// Sick time off activity identifier instance.
        /// </summary>
        public const string SickTimeOffActivityID = "ACTIVITY_SICK";

        /// <summary>
        /// Holiday time off activity identifier instance.
        /// </summary>
        public const string HolidayTimeOffActivityID = "ACTIVITY_HOL";

        /// <summary>
        /// Comp time off activity identifier instance.
        /// </summary>
        public const string CompTimeOffActivityID = "ACTIVITY_COMP";

        /// <summary>
        /// Ignore time off when calculating overtime instance.
        /// </summary>
        public const string IgnoreTimeOffWhenCalculatingOvertime = "FRMTIMECARD_IGNORE_OT";

        /// <summary>
        /// Target utilization percent instance.
        /// </summary>
        public const string TargetUtilizationPercent = "TARGET_UTILIZATION_PERCENT";

        /// <summary>
        /// Target profit percent instance.
        /// </summary>
        public const string TargetProfitPercent = "TARGET_PROFIT_PERCENT";


        /// <summary>
        /// Target profit percent instance.
        /// </summary>
        public const string ProjectWatchedFieldString = "PROJECT_WATCHED_FIELDS";


        /// <summary>
        /// The contract amount include item tax
        /// </summary>
        public const string ContractAmountExcludeItemTax = "CONTRACT_AMOUNT_EXCLUDE_ITEM_TAX";


        /// <summary>
        /// The company industry type
        /// </summary>
        public const string CompanyIndustryType = "COMPANY_INDUSTRY_TYPE";

        /// <summary>
        /// The automatic increment quote identifier
        /// </summary>
        public const string AutoIncrementQuoteID = "AUTO_QUOTEID";

        /// <summary>
        /// The last quote identifier
        /// </summary>
        public const string LastQuoteID = "LAST_QUOTECODE";

    }


    /// <summary>
    /// 
    /// </summary>
    public class TimeExpenseSetting
    {
        /// <summary>
        /// Skip entry evaluation instance.
        /// </summary>
        public const string SkipEntryEvaluation = "FRMTIMECARD_SKIP_EVAL";

        /// <summary>
        /// Compare amount against total budget instance.
        /// </summary>
        public const string CompareAmountAgainstTotalBudget = "GENERAL_COMPAREAMOUNTSPENTWITHBUDGET";

        /// <summary>
        /// Evaluate entry billable status on value instance.
        /// </summary>
        public const string EvaluateEntryBillableStatusOnValue = "FRMTIMECARD_EVALTEBILLABLEHRSONLY";

        /// <summary>
        /// Remind to submit new entries instance.
        /// </summary>
        public const string RemindToSubmitNewEntries = "FRMTIMECARD_PROMPT_SUBMIT_TE_ENTRIES";

        /// <summary>
        /// Add entry memos to journal instance.
        /// </summary>
        public const string AddEntryMemosToJournal = "FRMTIMECARDMEMO_MEMOONJOURNAL";

        /// <summary>
        /// Smallest increment instance.
        /// </summary>
        public const string SmallestIncrement = "FRMTIMECARD_TIMEINCR";

        /// <summary>
        /// Smallest start stop increment instance.
        /// </summary>
        public const string SmallestStartStopIncrement = "FRMTIMECARD_SSTIMEINCR";

        /// <summary>
        /// Ignore save delete time entry older than instance.
        /// </summary>
        public const string IgnoreSaveDeleteTimeEntryOlderThan = "FRMTIMECARD_TEDATELIMIT";

        /// <summary>
        /// Ignore save delete time entry newer than instance.
        /// </summary>
        public const string IgnoreSaveDeleteTimeEntryNewerThan = "FRMTIMECARD_TEDATELIMITFORWARD";

        /// <summary>
        /// Time entry memo required instance.
        /// </summary>
        public const string TimeEntryMemoRequired = "FRMPROJECT_TE_MEMO_REQUIRED";

        /// <summary>
        /// Project automatic approve time entries instance.
        /// </summary>
        public const string ProjectAutoApproveTimeEntries = "FRMTIMECARD_AUTOPOST";

        /// <summary>
        /// Employee automatic approve time instance.
        /// </summary>
        public const string EmployeeAutoApproveTime = "FRMEMP_AUTO_APPROVE_TE_EMP";

        /// <summary>
        /// Allow negative time entry instance.
        /// </summary>
        public const string AllowNegativeTimeEntry = "FRMTIMECARD_ALLOW_NEGATIVE_ENTRY";

        /// <summary>
        /// Allow zero hour time entry instance.
        /// </summary>
        public const string AllowZeroHourTimeEntry = "FRMTIMECARD_ALLOW_ZEROHOUR_ENTRY";

        /// <summary>
        /// Adjust stop time instance.
        /// </summary>
        public const string AdjustStopTime = "FRMTIMECARD_START_STOP_B_HOURS_ONLY";

        /// <summary>
        /// Ignore save delete expense entry older than instance.
        /// </summary>
        public const string IgnoreSaveDeleteExpenseEntryOlderThan = "FRMEXPLOG_ELDATELIMIT";

        /// <summary>
        /// Ignore save delete expense entry newer than instance.
        /// </summary>
        public const string IgnoreSaveDeleteExpenseEntryNewerThan = "FRMEXPLOG_ELDATELIMITFORWARD";

        /// <summary>
        /// Expense entry memo required instance.
        /// </summary>
        public const string ExpenseEntryMemoRequired = "FRMPROJECT_EL_MEMO_REQUIRED";

        /// <summary>
        /// Project automatic approve expense entries instance.
        /// </summary>
        public const string ProjectAutoApproveExpenseEntries = "FRMEXPLOG_AUTOPOST";

        /// <summary>
        /// Employee automatic approve expense instance.
        /// </summary>
        public const string EmployeeAutoApproveExpense = "FRMEMP_AUTO_APPROVE_EL_EMP";

        /// <summary>
        /// Apply smallest increment billable hours only instance.
        /// </summary>
        public const string ApplySmallestIncrementBillableHoursOnly = "FRMTIMECARD_B_HOURS_ONLY";

        /// <summary>
        /// Monitor frequency instance.
        /// </summary>
        public const string MonitorFrequency = "FRMTIMECARD_MONITOR_FREQUENCY";

        /// <summary>
        /// Pto project instance.
        /// </summary>
        public const string PTOProject = "PTO_Project";

        /// <summary>
        /// Time entry memo required instance.
        /// </summary>
        public const string TimeEntryRejectionMemoRequired = "FRMPROJECT_TE_REJECTION_MEMO_REQUIRED";

        /// <summary>
        /// Expense entry memo required instance.
        /// </summary>
        public const string ExpenseEntryRejectionMemoRequired = "FRMPROJECT_EL_REJECTION_MEMO_REQUIRED";

        /// <summary>
        /// The create allocation entry on pto approval
        /// </summary>
        public const string CreateAllocationEntryOnPtoApproval = "CREATE_ALLOCATION_ON_PTO_APPROVAL";

    }


    /// <summary>
    /// 
    /// </summary>
    public class MonitorNotificationSetting
    {
        /// <summary>
        /// Default time card email text instance.
        /// </summary>
        public const string DefaultTimeCardEmailText = "TEDefaultEmailText";

        /// <summary>
        /// Default expense email text instance.
        /// </summary>
        public const string DefaultExpenseEmailText = "ExpDefaultEmailText";

        /// <summary>
        /// Time card maximum email notification instance.
        /// </summary>
        public const string TimeCardMaxEmailNotification = "TimeCard_MaxEmailNotification";

        /// <summary>
        /// Expense maximum email notification instance.
        /// </summary>
        public const string ExpenseMaxEmailNotification = "Expense_MaxEmailNotification";

        /// <summary>
        /// Email time card to manager instance.
        /// </summary>
        public const string EmailTimeCardToManager = "Email_TimeCardToManager";

        /// <summary>
        /// Email expense to manager instance.
        /// </summary>
        public const string EmailExpenseToManager = "Email_ExpenseToManager";

        /// <summary>
        /// Time card maximum email count instance.
        /// </summary>
        public const string TimeCardMaxEmailCount = "TimeCard_MaxEmailCount";

        /// <summary>
        /// Expense maximum email count instance.
        /// </summary>
        public const string ExpenseMaxEmailCount = "Expense_MaxEmailCount";
    }


    /// <summary>
    /// 
    /// </summary>
    public class OnBoardSetting
    {
        /// <summary>
        /// Smallest increment instance.
        /// </summary>
        public const string SmallestIncrement = "FRMTIMECARD_TIMEINCR";
        /// <summary>
        /// Interest per month instance.
        /// </summary>
        public const string InterestPerMonth = "INTEREST_RATE";
        /// <summary>
        /// Charge interest after instance.
        /// </summary>
        public const string ChargeInterestAfter = "INTEREST_DAYS";
        /// <summary>
        /// Employee hours per day instance.
        /// </summary>
        public const string EmployeeHoursPerDay = "FRMEMP_STDDAYHRS";
        /// <summary>
        /// Employee hours per week instance.
        /// </summary>
        public const string EmployeeHoursPerWeek = "FRMEMP_STDWEEKHRS";
        /// <summary>
        /// Report basis instance.
        /// </summary>
        public const string ReportBasis = "AP_REPORT_BASIS";
        /// <summary>
        /// First day of week instance.
        /// </summary>
        public const string FirstDayOfWeek = "WEEK_WEEKBEGINDAY";
    }

    /// <summary>
    /// 
    /// </summary>
    public class TemplateSetting
    {
        /// <summary>
        /// Fixed invoice instance.
        /// </summary>
        public const string FixedInvoice = "REPORTS_FIXEDINV";
        /// <summary>
        /// Hourly invoice instance.
        /// </summary>
        public const string HourlyInvoice = "REPORTS_HOURLYINV";
        /// <summary>
        /// Hourly not to exceed invoice instance.
        /// </summary>
        public const string HourlyNotToExceedInvoice = "REPORTS_HNTEINV";
        /// <summary>
        /// Marketing invoice instance.
        /// </summary>
        public const string MarketingInvoice = "REPORTS_MARKETINGINV";
        /// <summary>
        /// Overhead invoice instance.
        /// </summary>
        public const string OverheadInvoice = "REPORTS_OVERHEADINV";
        /// <summary>
        /// Percent invoice instance.
        /// </summary>
        public const string PercentInvoice = "REPORTS_PERCENTAGEINV";
        /// <summary>
        /// Recurring invoice instance.
        /// </summary>
        public const string RecurringInvoice = "REPORTS_RECURRINGINV";
        /// <summary>
        /// Recurring not to exceed invoice instance.
        /// </summary>
        public const string RecurringNotToExceedInvoice = "REPORTS_RNTEINV";
        /// <summary>
        /// Manual invoice instance.
        /// </summary>
        public const string ManualInvoice = "REPORTS_MANUALINV";
        /// <summary>
        /// Joint invoice template instance.
        /// </summary>
        public const string JointInvoiceTemplate = "REPORTS_JOINTINV";
        /// <summary>
        /// Cost plus invoice instance.
        /// </summary>
        public const string CostPlusInvoice = "REPORTS_COSTPLUSINV";
        /// <summary>
        /// Retainer invoice instance.
        /// </summary>
        public const string RetainerInvoice = "REPORTS_RETAINERINVOICE";
        /// <summary>
        /// Fixed statement instance.
        /// </summary>
        public const string FixedStatement = "REPORTS_FIXEDST";
        /// <summary>
        /// Hourly statement instance.
        /// </summary>
        public const string HourlyStatement = "REPORTS_HOURLYST";
        /// <summary>
        /// Hourly not to exceed statement instance.
        /// </summary>
        public const string HourlyNotToExceedStatement = "REPORTS_HNTEST";
        /// <summary>
        /// Marketing statement instance.
        /// </summary>
        public const string MarketingStatement = "REPORTS_MARKETINGST";
        /// <summary>
        /// Overhead statement instance.
        /// </summary>
        public const string OverheadStatement = "REPORTS_OVERHEADST";
        /// <summary>
        /// Percent statement instance.
        /// </summary>
        public const string PercentStatement = "REPORTS_PERCENTAGEST";
        /// <summary>
        /// Recurring statement instance.
        /// </summary>
        public const string RecurringStatement = "REPORTS_RECURRINGST";
        /// <summary>
        /// Recurring not to exceed statement instance.
        /// </summary>
        public const string RecurringNotToExceedStatement = "REPORTS_RNTEST";
        /// <summary>
        /// Manual statement instance.
        /// </summary>
        public const string ManualStatement = "REPORTS_MANUALST";
        /// <summary>
        /// Void invoice template instance.
        /// </summary>
        public const string VoidInvoiceTemplate = "REPORTS_VOIDINVOICEST";
        /// <summary>
        /// Late fee invoice template instance.
        /// </summary>
        public const string LateFeeInvoiceTemplate = "REPORTS_LATEFEEINVOICEST";
        /// <summary>
        /// Recurring plus hourly invoice instance.
        /// </summary>
        public const string RecurringPlusHourlyInvoice = "REPORTS_RECURRINGPLUSHOURLYINV";
        /// <summary>
        /// Void late fee invoice template instance.
        /// </summary>
        public const string VoidLateFeeInvoiceTemplate = "REPORTS_VOIDLATEFEEINVOICEST";
        /// <summary>
        /// Void manual invoice template instance.
        /// </summary>
        public const string VoidManualInvoiceTemplate = "REPORTS_VOIDMANUALINVOICE";
        /// <summary>
        /// Void manual invoice template instance.
        /// </summary>
        public const string SplitBillingInvoiceTemplate = "REPORTS_SPLITINVOICETEMPLATE";
    }


    /// <summary>
    /// 
    /// </summary>
    public class BillingSetting
    {
        /// <summary>
        /// Minimum bill amount instance.
        /// </summary>
        public const string MinimumBillAmount = "FRMBILLREV_MINAMT";
        /// <summary>
        /// Reverse write up write down instance.
        /// </summary>
        public const string ReverseWriteUpWriteDown = "FRMINVREV_REVERSE_WUD";
        /// <summary>
        /// Mark projects completed instance.
        /// </summary>
        public const string MarkProjectsCompleted = "FRMBILLREV_AUTO_COMPLETED";
        /// <summary>
        /// Automatic apply retainer instance.
        /// </summary>
        public const string AutoApplyRetainer = "FRMBILLREV_AUTOAPPLYRETAINER";
        /// <summary>
        /// Apply discount to pre tax instance.
        /// </summary>
        public const string ApplyDiscountToPreTax = "GENERAL_APPLYDISCOUNTTOPRETAXAMOUNT";
        /// <summary>
        /// Link expense attachments to invoices instance.
        /// </summary>
        public const string LinkExpenseAttachmentsToInvoices = "FRMBILLREV_LINK_ELATTACHMENTS";
        /// <summary>
        /// Currency exchange rate lookup URL instance.
        /// </summary>
        public const string CurrencyExchangeRateLookupUrl = "CURRENCY_EXCHANGE_RATES_URL";
        /// <summary>
        /// Aging period instance.
        /// </summary>
        public const string AgingPeriod = "FRMREPORTS_AGING";
        /// <summary>
        /// Link time attachments to invoices instance.
        /// </summary>
        public const string LinkTimeAttachmentsToInvoices = "FRMBILLREV_LINK_TEATTACHMENTS";
        /// <summary>
        /// Print posted invoices statement instance.
        /// </summary>
        public const string PrintPostedInvoicesStatement = "FRMINVREV_PREPRINTSTATEMENT";
        /// <summary>
        /// Interest per month instance.
        /// </summary>
        public const string InterestPerMonth = "INTEREST_RATE";
        /// <summary>
        /// Charge interest after instance.
        /// </summary>
        public const string ChargeInterestAfter = "INTEREST_DAYS";
        /// <summary>
        /// Show billing through invoices instance.
        /// </summary>
        public const string ShowBillingThroughInvoices = "FRMBILLREV_BILLINGTHROUGH";
        /// <summary>
        /// Show account summary instance.
        /// </summary>
        public const string ShowAccountSummary = "FRMPROJECT_SHOW_ACCOUNT_SUMMARY";
        /// <summary>
        /// Show retainer summary instance.
        /// </summary>
        public const string ShowRetainerSummary = "FRMPROJECT_SHOW_RETAINER_SUMMARY";
        /// <summary>
        /// Show GST separately instance.
        /// </summary>
        public const string ShowGstSeparately = "FRMPROJECT_SHOW_GST";
        /// <summary>
        /// Email payment receipts instance.
        /// </summary>
        public const string EmailPaymentReceipts = "GENERAL_EMAIL_INVOICE_ON_PAYMENT_RECEIVE";
        /// <summary>
        /// Email retainer payment receipts instance.
        /// </summary>
        public const string EmailRetainerPaymentReceipts = "GENERAL_EMAIL_ON_RETAINER_RECEIVE";
        /// <summary>
        /// Show time expense memo on detail invoice instance.
        /// </summary>
        public const string ShowTimeExpenseMemoOnDetailInvoice = "FRMPROJECT_SHOW_TE_MEMO";
        /// <summary>
        /// Show time expense memo instance.
        /// </summary>
        public const string ShowTimeExpenseMemo = "FRMTIMECARDMEMO_MEMOONINVOICES";
        /// <summary>
        /// Show project memo instance.
        /// </summary>
        public const string ShowProjectMemo = "FRMBILLREV_USEMEMO2";
        /// <summary>
        /// Hide non billable time instance.
        /// </summary>
        public const string HideNonBillableTime = "MISC_HIDE_NO_CHARGE_TIMEENTRIES";
        /// <summary>
        /// Hide non billable expense instance.
        /// </summary>
        public const string HideNonBillableExpense = "MISC_HIDE_NO_CHARGE_EXPENTRIES";
        /// <summary>
        /// Show country in client address instance.
        /// </summary>
        public const string ShowCountryInClientAddress = "MISC_SHOW_COUNTRY_IN_CLIENT_ADDRESS";
        /// <summary>
        /// Retainer invoice prefix instance.
        /// </summary>
        public const string RetainerInvoicePrefix = "RETAINER_INV_NUMBER_PREFIX";
        /// <summary>
        /// Retainer invoice suffix instance.
        /// </summary>
        public const string RetainerInvoiceSuffix = "RETAINER_INV_NUMBER_SUFIX";
        /// <summary>
        /// Retainer invoice instance.
        /// </summary>
        public const string RetainerInvoice = "RETAINER_INV_NUMBER";
        /// <summary>
        /// Reference calculation method instance.
        /// </summary>
        public const string ReferenceCalculationMethod = "GENERAL_ELECTRONIC_INVOICE_CALC_METHOD";
        /// <summary>
        /// Show reference calculation method instance.
        /// </summary>
        public const string ShowReferenceCalculationMethod = "GENERAL_SHOW_ELECTRONIC_REFERENCENO_ON_INVOICE";
        /// <summary>
        /// Default class identifier instance.
        /// </summary>
        public const string DefaultClassId = "GENERAL_PROJECT_CLASS";
        /// <summary>
        /// Payment term identifier instance.
        /// </summary>
        public const string PaymentTermId = "GENERAL_CLIENT_TERM";
        /// <summary>
        /// Skip extra time entry wud instance.
        /// </summary>
        public const string SkipExtraTimeEntryWud = "FRMBILLREV_WUD_XTRATIME";
        /// <summary>
        /// Last invoice prefix instance.
        /// </summary>
        public const string LastInvoicePrefix = "LASTINVOICENUMBER_PREFIX";
        /// <summary>
        /// Last invoice suffix instance.
        /// </summary>
        public const string LastInvoiceSuffix = "LASTINVOICENUMBER_SUFFIX";
        /// <summary>
        /// Allow zero rate in service fee schedules instance.
        /// </summary>
        public const string AllowZeroRateInServiceFeeSchedules = "GENERAL_ALLOW_ZERO_RATES_IN_SFS";
        /// <summary>
        /// Last draft invoice number instance.
        /// </summary>
        public const string LastDraftInvoiceNumber = "LASTDRAFTINVOICENUMBER";
        
        /// <summary>
        /// Draft invoice prefix instance.
        /// </summary>
        public const string DraftInvoicePrefix = "DRAFTINVOICEPREFIX";
        
        /// <summary>
        /// The restrict joint invoice to entity
        /// </summary>
        public const string RestrictJointInvoiceToEntity = "BILLING_JOINT_PARENT";

        /// <summary>
        /// Message on invoice instance.
        /// </summary>
        public const string MessageOnInvoice = "BILLING_MESSAGE_ON_INVOICE";

        /// <summary>
        /// Show company tax identifier on invoice instance.
        /// </summary>
        public const string ShowCompanyTaxIdOnInvoice = "SHOW_TAXID_ON_INVOICE";

        /// <summary>
        /// The restrict combine invoices on
        /// </summary>
        public const string RestrictCombineInvoicesOn = "BILLING_JOINT_INVOICE_ON";

        /// The enable split billing
        /// </summary>
        public const string EnableSplitBilling = "ENABLE_SPLIT_BILLING";

        /// The enable  HideRetainerInvoiceTextMessage
        /// </summary>
        public const string HideRetainerInvoiceTextMessage = "HIDE_RETAINERINVOICE_TEXTMESSAGE";


        public const string RetainerMessage = "BILLING_RETAINER_MESSAGE";

    }


    /// <summary>
    /// 
    /// </summary>
    public class TaxSetting
    {
        /// <summary>
        /// Main service tax instance.
        /// </summary>
        public const string MainServiceTax = "TAXES_MAIN_SERVICE_TAX";
        /// <summary>
        /// Main expense tax instance.
        /// </summary>
        public const string MainExpenseTax = "TAXES_MAIN_EXPENSE_TAX";
        /// <summary>
        /// Main service tax ceiling instance.
        /// </summary>
        public const string MainServiceTaxCeiling = "TAXES_MSTCEILING";
        /// <summary>
        /// Main expense tax ceiling instance.
        /// </summary>
        public const string MainExpenseTaxCeiling = "TAXES_METCEILING";
        /// <summary>
        /// MST excludes item tax instance.
        /// </summary>
        public const string MSTExcludesItemTax = "MSTEXCLUDESERVICETAX";
        /// <summary>
        /// Met excludes item tax instance.
        /// </summary>
        public const string METExcludesItemTax = "METEXCLUDEEXPENSESTAX";

        /// <summary>
        /// Default tax1 instance.
        /// </summary>
        public const string DefaultTax1 = "TAXES_TAX1AMT";
        /// <summary>
        /// Default tax2 instance.
        /// </summary>
        public const string DefaultTax2 = "TAXES_TAX2AMT";
        /// <summary>
        /// Default tax3 instance.
        /// </summary>
        public const string DefaultTax3 = "TAXES_TAX3AMT";


        /// <summary>
        /// Hide tax1 on sheet view instance.
        /// </summary>
        public const string HideTax1OnSheetView = "FRMTIMECARD_TAX1HIDE";
        /// <summary>
        /// Hide tax2 on sheet view instance.
        /// </summary>
        public const string HideTax2OnSheetView = "FRMTIMECARD_TAX2HIDE";
        /// <summary>
        /// Hide tax3 on sheet view instance.
        /// </summary>
        public const string HideTax3OnSheetView = "FRMTIMECARD_TAX3HIDE";

        /// <summary>
        /// Hide tax1 on expense log instance.
        /// </summary>
        public const string HideTax1OnExpenseLog = "FRMEXPLOG_TAX1HIDE";
        /// <summary>
        /// Hide tax2 on expense log instance.
        /// </summary>
        public const string HideTax2OnExpenseLog = "FRMEXPLOG_TAX2HIDE";
        /// <summary>
        /// Hide tax3 on expense log instance.
        /// </summary>
        public const string HideTax3OnExpenseLog = "FRMEXPLOG_TAX3HIDE";
    }


    /// <summary>
    /// 
    /// </summary>
    public class UserInterfaceSetting
    {
        /// <summary>
        /// Digits after decimal for amount instance.
        /// </summary>
        public const string DigitsAfterDecimalForAmount = "MISC_DECIMAL_PLACES";
        /// <summary>
        /// Digits after decimal for units instance.
        /// </summary>
        public const string DigitsAfterDecimalForUnits = "MISC_DECIMAL_PLACES_UNITS";
        /// <summary>
        /// Digits after decimal for rate instance.
        /// </summary>
        public const string DigitsAfterDecimalForRate = "MISC_DECIMAL_PLACES_RATE";
        /// <summary>
        /// First day of week instance.
        /// </summary>
        public const string FirstDayOfWeek = "WEEK_WEEKBEGINDAY";
        /// <summary>
        /// First day of bi weekly period instance.
        /// </summary>
        public const string FirstDayOfBiWeeklyPeriod = "BIWEEKLY_BIWEEKLYSTARTDAY";
        /// <summary>
        /// Is sunday working day instance.
        /// </summary>
        public const string IsSundayWorkingDay = "GENERAL_CHK_SUN";
        /// <summary>
        /// Is monday working day instance.
        /// </summary>
        public const string IsMondayWorkingDay = "GENERAL_CHK_MON";
        /// <summary>
        /// Is tuesday working day instance.
        /// </summary>
        public const string IsTuesdayWorkingDay = "GENERAL_CHK_TUE";
        /// <summary>
        /// Is wednesday working day instance.
        /// </summary>
        public const string IsWednesdayWorkingDay = "GENERAL_CHK_WED";
        /// <summary>
        /// Is thursday working day instance.
        /// </summary>
        public const string IsThursdayWorkingDay = "GENERAL_CHK_THU";
        /// <summary>
        /// Is friday working day instance.
        /// </summary>
        public const string IsFridayWorkingDay = "GENERAL_CHK_FRI";
        /// <summary>
        /// Is saturday working day instance.
        /// </summary>
        public const string IsSaturdayWorkingDay = "GENERAL_CHK_SAT";
        /// <summary>
        /// Maximum number of records instance.
        /// </summary>
        public const string MaxNumberOfRecords = "GENERAL_MAXIMUMRECORDS";
        /// <summary>
        /// Default memo font size instance.
        /// </summary>
        public const string DefaultMemoFontSize = "MEMO_FONT_SIZE";
        /// <summary>
        /// Default memo font name instance.
        /// </summary>
        public const string DefaultMemoFontName = "MEMO_FONT";
        /// <summary>
        /// Memo font unchangeable instance.
        /// </summary>
        public const string MemoFontUnchangeable = "ALLOW_CHANGE_MEMO_FONT";
        /// <summary>
        /// Display account as instance.
        /// </summary>
        public const string DisplayAccountAs = "DISPLAY_ACCOUNT_AS";
        /// <summary>
        /// Display project as instance.
        /// </summary>
        public const string DisplayProjectAs = "DISPLAY_PROJECT_AS";
        /// <summary>
        /// Display phase as instance.
        /// </summary>
        public const string DisplayPhaseAs = "DISPLAY_PROJECTPHASE_AS";
        /// <summary>
        /// The digits after decimal for benefits
        /// </summary>
        public const string DigitsAfterDecimalForBenefits = "MISC_DECIMAL_PLACES_BENEFITS";

        public const string ShowFooterOnInvoice = "SHOW_FOOTER_ON_INVOICE";

    }


    /// <summary>
    /// 
    /// </summary>
    public class EmailSetting
    {
        /// <summary>
        /// User preferences override global setting instance.
        /// </summary>
        public const string UserPreferencesOverrideGlobalSetting = "UP_OVERRIDE_GS_EMAIL_SETTINGS";
        /// <summary>
        /// SMTP server instance.
        /// </summary>
        public const string SmtpServer = "EMAIL_SMTPSERVERADDRESS";
        /// <summary>
        /// Use SSL instance.
        /// </summary>
        public const string UseSSL = "EMAIL_USESSL";
        /// <summary>
        /// SMTP requires authentication instance.
        /// </summary>
        public const string SmtpRequiresAuthentication = "EMAIL_AUTHENTICATE";

        /// <summary>
        /// Allow Employess to use their own email service.
        /// </summary>
        public const string AllowEmployeesUseTheirEmailService = "EMAIL_ALLOWEMPLOYEES_USE_THEIR_EMAIL_SERVICE";


        /// <summary>
        /// User name instance.
        /// </summary>
        public const string UserName = "EMAIL_DISPLAYNAME";
        /// <summary>
        /// Email from instance.
        /// </summary>
        public const string EmailFrom = "EMAIL_ADDRESS";
        /// <summary>
        /// c cmail to instance.
        /// </summary>
        public const string CCmailTo = "EMAIL_CCMAILTO";
        /// <summary>
        /// Bc cmail to instance.
        /// </summary>
        public const string BCCmailTo = "EMAIL_BCCMAILTO";


        /// <summary>
        /// Logon user name instance.
        /// </summary>
        public const string LogonUserName = "EMAIL_USERNAME";
        /// <summary>
        /// Logon password instance.
        /// </summary>
        public const string LogonPassword = "EMAIL_PASSWORD";
        /// <summary>
        /// Delivery method instance.
        /// </summary>
        public const string DeliveryMethod = "EMAIL_DELIVERY";
        /// <summary>
        /// Directory name instance.
        /// </summary>
        public const string DirectoryName = "EMAIL_DIRNAME";


        /// <summary>
        /// Port instance.
        /// </summary>
        public const string Port = "EMAIL_PORT";
        /// <summary>
        /// Authentication type instance.
        /// </summary>
        public const string AuthenticationType = "EMAIL_AUTHENTICATION";
        /// <summary>
        /// Statements default subject instance.
        /// </summary>
        public const string StatementsDefaultSubject = "EMAIL_SUBJECT_STMTS";
        /// <summary>
        /// Statements default PDF name instance.
        /// </summary>
        public const string StatementsDefaultPDFName = "EMAIL_ATTACHMENT_STMTS";
        /// <summary>
        /// Statements default email message instance.
        /// </summary>
        public const string StatementsDefaultEmailMessage = "EMAIL_MESSAGESTATEMENTS";


        /// <summary>
        /// Reports default subject instance.
        /// </summary>
        public const string ReportsDefaultSubject = "EMAIL_SUBJECT_REPORTS";
        /// <summary>
        /// Reports default PDF name instance.
        /// </summary>
        public const string ReportsDefaultPdfName = "EMAIL_ATTACHMENT_REPORTS";
        /// <summary>
        /// Reports default email message instance.
        /// </summary>
        public const string ReportsDefaultEmailMessage = "EMAIL_MESSAGEREPORTS";

        /// <summary>
        /// Purchase order reports default email message instance.
        /// </summary>
        public const string PurchaseOrderReportsDefaultEmailMessage = "EMAIL_MESSAGE_PORDER";

        /// <summary>
        /// Purchase order reports default PDF name instance.
        /// </summary>
        public const string PurchaseOrderReportsDefaultPdfName = "EMAIL_ATTACHMENT_PORDER";

        /// <summary>
        /// Purchase order reports default subject instance.
        /// </summary>
        public const string PurchaseOrderReportsDefaultSubject = "EMAIL_SUBJECT_PORDER";

        /// <summary>
        /// Payment default subject instance.
        /// </summary>
        public const string PaymentDefaultSubject = "EMAIL_SUBJECT_PAYMENTRECEIPT";
        /// <summary>
        /// Payment default email message instance.
        /// </summary>
        public const string PaymentDefaultEmailMessage = "EMAIL_MESSAGE_PAYMENTRECEIPT";


        /// <summary>
        /// Invoice default subject instance.
        /// </summary>
        public const string InvoiceDefaultSubject = "EMAIL_SUBJECT_INV";
        /// <summary>
        /// Invoice default pd fname instance.
        /// </summary>
        public const string InvoiceDefaultPDFname = "EMAIL_ATTACHMENT_INV";
        /// <summary>
        /// Joint invoice default PDF name instance.
        /// </summary>
        public const string JointInvoiceDefaultPDFName = "EMAIL_ATTACHMENT_JINV";
        /// <summary>
        /// Invoice default email message instance.
        /// </summary>
        public const string InvoiceDefaultEmailMessage = "EMAIL_MESSAGE";

        /// <summary>
        /// Send Email Attachments as Single file.
        /// </summary>
        public const string EmailAttachmentsAsSingleFile = "EMAIL_ATTACHMENTS_AS_SINGLE_FILE";

        /// <summary>
        /// Max attachment size limit
        /// </summary>
        public const string EmailAttachmentSizeLimit = "EMAIL_ATTACHMENT_SIZE_LIMIT";


        public const string CopyclientwhensendingemailstoClientContact =
            "EMAIL_Copy_client_when_sending_emails_to_Client_Contact";

        /// <summary>
        /// Max attachment size limit
        /// </summary>
        public const string EmailAttachmentBufferSizeLimit = "EMAIL_ATTACHMENT_BUFFER_SIZE_LIMIT";
    }


    /// <summary>
    /// 
    /// </summary>
    public class SecuritySetting
    {
        /// <summary>
        /// Make dcaa compliant instance.
        /// </summary>
        public const string MakeDCAACompliant = "GENERAL_CMPT";
        /// <summary>
        /// Password req on closing date change instance.
        /// </summary>
        public const string PasswordReqOnClosingDateChange = "GENERAL_CLOSINGDATEPWD";
        /// <summary>
        /// Closing date password instance.
        /// </summary>
        public const string ClosingDatePassword = "GENERAL_CLOSINGPASSWORD";
        /// <summary>
        /// Dcaa password instance.
        /// </summary>
        public const string DCAAPassword = "GENERAL_DCAAPASSWORD";

        /// <summary>
        /// Password case sensitive instance.
        /// </summary>
        public const string PasswordCaseSensitive = "GENERAL_MPCS";
        /// <summary>
        /// Show database location instance.
        /// </summary>
        public const string ShowDatabaseLocation = "GENERAL_HIDEDBLOC";
        /// <summary>
        /// Prompt user te disclaimer instance.
        /// </summary>
        public const string PromptUserTEDisclaimer = "SECURITY_CHKSHOWDISCLAIMER";
        /// <summary>
        /// Te disclaimer message instance.
        /// </summary>
        public const string TEDisclaimerMessage = "SECURITY_TXTDISCLAIMER";


        /// <summary>
        /// Database current password instance.
        /// </summary>
        public const string DatabaseCurrentPassword = "SQLsaPwd";
        /// <summary>
        /// Application backup reminder instance.
        /// </summary>
        public const string AppBackupReminder = "APPBACKUP_REMINDER";
        /// <summary>
        /// Application backup week day instance.
        /// </summary>
        public const string AppBackupWeekDay = "APPBACKUP_WEEKLYON";
        /// <summary>
        /// Application backup month day instance.
        /// </summary>
        public const string AppBackupMonthDay = "REMINDER_DAYON";
    }


    /// <summary>
    /// 
    /// </summary>
    public class MerchantSetting
    {
        /// <summary>
        /// Innovative merchant link on invoice instance.
        /// </summary>
        public const string InnovativeMerchantLinkOnInvoice = "SHOW_CC_ON_INVOICES";
        /// <summary>
        /// Innovative web link instance.
        /// </summary>
        public const string InnovativeWebLink = "CC_WEBSITE_LINK";
        /// <summary>
        /// Account email instance.
        /// </summary>
        public const string AccountEmail = "CC_ACCOUNT_EMAIL";
        /// <summary>
        /// Account identifier instance.
        /// </summary>
        public const string AccountId = "CC_ACCOUNT_ID";
        /// <summary>
        /// Password instance.
        /// </summary>
        public const string Password = "CC_ACCOUNT_PWD";
        /// <summary>
        /// Currency instance.
        /// </summary>
        public const string Currency = "CC_CURRENCY_TYPE";

        /// <summary>
        /// Pay pal link on invoice instance.
        /// </summary>
        public const string PayPalLinkOnInvoice = "SHOW_PAYPAL_ON_INVOICES";
        /// <summary>
        /// Pay pal web link instance.
        /// </summary>
        public const string PayPalWebLink = "PAYPAL_WEBSITE_LINK";
        /// <summary>
        /// Pay pal account email instance.
        /// </summary>
        public const string PayPalAccountEmail = "PAYPAL_ACCOUNT_EMAIL";
        /// <summary>
        /// Pay pal currency instance.
        /// </summary>
        public const string PayPalCurrency = "PAYPAL_CURRENCY_TYPE";
        /// <summary>
        /// Server required authentication instance.
        /// </summary>
        public const string ServerRequiredAuthentication = "SMTP_SERVER_REQUIRED_AUTHENTICATION";
        /// <summary>
        /// Add credit card processing instance.
        /// </summary>
        public const string AddCreditCardProcessing = "CC_ADD_CC_PROCESSING";
    }


    /// <summary>
    /// 
    /// </summary>
    public class FolderSetting
    {
        /// <summary>
        /// Backup folder location instance.
        /// </summary>
        public const string BackupFolderLocation = "MISC_BACKUPDIR_LOC";
        /// <summary>
        /// Log file location instance.
        /// </summary>
        public const string LogFileLocation = "MISC_LOGDIR_LOCATION";
        /// <summary>
        /// Automatic log actions instance.
        /// </summary>
        public const string AutoLogActions = "MISC_LOG_EVENTS";
        /// <summary>
        /// Report files location instance.
        /// </summary>
        public const string ReportFilesLocation = "Reports";
        /// <summary>
        /// Report designer location instance.
        /// </summary>
        public const string ReportDesignerLocation = "ReportDesigner";
        /// <summary>
        /// Custom reports location instance.
        /// </summary>
        public const string CustomReportsLocation = "GENERAL_LOCATION_CUSTOM_REPORTS";
        /// <summary>
        /// Invoice templates location instance.
        /// </summary>
        public const string InvoiceTemplatesLocation = "GENERAL_CUSTOM_FOLDER_LOC";
        /// <summary>
        /// Custom invoices location instance.
        /// </summary>
        public const string CustomInvoicesLocation = "GENERAL_LOCATION_CUSTOM_INVOICES";
        /// <summary>
        /// Automatic update files location instance.
        /// </summary>
        public const string AutoUpdateFilesLocation = "GENERAL_UPDATE_FOLDER";
        /// <summary>
        /// Attachments location instance.
        /// </summary>
        public const string AttachmentsLocation = "GENERAL_SHARED_FOLDER";
        /// <summary>
        /// PDF files location instance.
        /// </summary>
        public const string PdfFilesLocation = "GENERAL_FOLDER_LOC";
    }


    /// <summary>
    /// 
    /// </summary>
    public class IntegrationSetting
    {
        /// <summary>
        /// Accounting software used instance.
        /// </summary>
        public const string AccountingSoftwareUsed = "GENERAL_ACCOUNTING_SOFTWARE_TO_USE";
        /// <summary>
        /// Qb synchronize reminder instance.
        /// </summary>
        public const string QBSyncReminder = "QB_REMINDER";
        /// <summary>
        /// Qb reminder week day instance.
        /// </summary>
        public const string QBReminderWeekDay = "QB_REMINDER_WEEKLYON";
        /// <summary>
        /// Qb reminder month day instance.
        /// </summary>
        public const string QBReminderMonthDay = "QB_REMINDER_DAYON";

        /// <summary>
        /// Pt synchronize reminder instance.
        /// </summary>
        public const string PTSyncReminder = "PT_REMINDER";
        /// <summary>
        /// Pt reminder week day instance.
        /// </summary>
        public const string PTReminderWeekDay = "PT_REMINDER_WEEKLYON";
        /// <summary>
        /// Pt reminder month day instance.
        /// </summary>
        public const string PTReminderMonthDay = "PT_REMINDER_DAYON";

        /// <summary>
        /// Synchronized delete with qb instance.
        /// </summary>
        public const string SynchronizedDeleteWithQB = "ALLOW_QB_DELETE";
        /// <summary>
        /// Send purchase tax to qb instance.
        /// </summary>
        public const string SendPurchaseTaxToQB = "GENERAL_SendPurchaseTaxAmount";

        /// <summary>
        /// Myob synchronize reminder instance.
        /// </summary>
        public const string MYOBSyncReminder = "MYOB_REMINDER";
        /// <summary>
        /// Myob reminder week day instance.
        /// </summary>
        public const string MYOBReminderWeekDay = "MYOB_REMINDER_WEEKLYON";
        /// <summary>
        /// Myob reminder month day instance.
        /// </summary>
        public const string MYOBReminderMonthDay = "MYOB_REMINDER_DAYON";

        /// <summary>
        /// Sba synchronize reminder instance.
        /// </summary>
        public const string SBASyncReminder = "SBA_REMINDER";
        /// <summary>
        /// Sba reminder week day instance.
        /// </summary>
        public const string SBAReminderWeekDay = "SBA_REMINDER_WEEKLYON";
        /// <summary>
        /// Sba reminder month day instance.
        /// </summary>
        public const string SBAReminderMonthDay = "SBA_REMINDER_DAYON";
        /// <summary>
        /// Send purchase tax with vendor bill instance.
        /// </summary>
        public const string SendPurchaseTaxWithVendorBill = "GENERAL_SendVBPurchaseTaxAmount";
    }


    /// <summary>
    /// 
    /// </summary>
    public class AccountingSetting
    {
        /// <summary>
        /// Last vendor bill number instance.
        /// </summary>
        public const string LastVendorBillNumber = "VB_LASTVBNUM";
        /// <summary>
        /// Allow duplicate vendor bill instance.
        /// </summary>
        public const string AllowDuplicateVendorBill = "VB_ALLOW_DUPLICATE_VB_NUMBER";
        /// <summary>
        /// Last purchase order instance.
        /// </summary>
        public const string LastPurchaseOrder = "PO_LASTPONUM";
        /// <summary>
        /// Allow duplicate purchase order instance.
        /// </summary>
        public const string AllowDuplicatePurchaseOrder = "PO_ALLOW_DUPLICATE_PO_NUMBER";

        /// <summary>
        /// Do not allow receiving items against unapproved purchase order instance.
        /// </summary>
        public const string DoNotAllowReceivingItemsAgainstUnapprovedPurchaseOrder = "FRMPURCHASEORDER_ALLOWRECEIVEUNAPPROVEDPO";
        /// <summary>
        /// Report basis instance.
        /// </summary>
        public const string ReportBasis = "AP_REPORT_BASIS";
        /// <summary>
        /// Voucher check style instance.
        /// </summary>
        public const string VoucherCheckStyle = "AP_VOUCHER_CHECK_STYLE";


        /// <summary>
        /// Check account identifier instance.
        /// </summary>
        public const string CheckAccountId = "AP_DEFAULT_ACC_WRITE_CHECKS";
        /// <summary>
        /// Pay bill account identifier instance.
        /// </summary>
        public const string PayBillAccountId = "AP_DEFAULT_ACC_PAY_BILLS";
        /// <summary>
        /// Deposit account identifier instance.
        /// </summary>
        public const string DepositAccountId = "AP_DEFAULT_ACC_MAKE_DEPOSITS";
        /// <summary>
        /// Income account identifier without service items instance.
        /// </summary>
        public const string IncomeAccountIdWithoutServiceItems = "AP_DEFAULT_INCOME_ACCOUNT_INVOICES_WO_ITEMS";
        /// <summary>
        /// Income account identifier without expense items instance.
        /// </summary>
        public const string IncomeAccountIdWithoutExpenseItems = "AP_DEFAULT_INCOME_ACCOUNT_INVOICES_WO_EXP_ITEMS";


        /// <summary>
        /// Receivable account identifier instance.
        /// </summary>
        public const string ReceivableAccountId = "AP_SYSTEM_DEFAULT_ACC_ACCOUNTSRECEIVABLE";
        /// <summary>
        /// Payable account identifier instance.
        /// </summary>
        public const string PayableAccountId = "AP_SYSTEM_DEFAULT_ACC_ACCOUNTSPAYABLE";
        /// <summary>
        /// Un deposited fund account identifier instance.
        /// </summary>
        public const string UnDepositedFundAccountId = "AP_SYSTEM_DEFAULT_ACC_UNDEPOSITEDFUNDS";
        /// <summary>
        /// Income account identifier instance.
        /// </summary>
        public const string IncomeAccountId = "AP_SYSTEM_DEFAULT_ACC_INCOMEACCOUNT";
        /// <summary>
        /// Expense account identifier instance.
        /// </summary>
        public const string ExpenseAccountId = "AP_SYSTEM_DEFAULT_ACC_EXPENSEACCOUNT";
        /// <summary>
        /// Retainer liability account identifier instance.
        /// </summary>
        public const string RetainerLiabilityAccountId = "AP_SYSTEM_DEFAULT_ACC_RETAINERANDLIABILITYACCOUNT";

        /// <summary>
        /// Main service tax payable account identifier instance.
        /// </summary>
        public const string MainServiceTaxPayableAccountId = "AP_SYSTEM_DEFAULT_ACC_TAX_MSTP";
        /// <summary>
        /// Main expense tax payable account identifier instance.
        /// </summary>
        public const string MainExpenseTaxPayableAccountId = "AP_SYSTEM_DEFAULT_ACC_TAX_METP";
        /// <summary>
        /// Service tax payable account identifier instance.
        /// </summary>
        public const string ServiceTaxPayableAccountId = "AP_SYSTEM_DEFAULT_ACC_TAX_STP";
        /// <summary>
        /// Expense tax payable account identifier instance.
        /// </summary>
        public const string ExpenseTaxPayableAccountId = "AP_SYSTEM_DEFAULT_ACC_TAX_ETP";

        /// <summary>
        /// Last vendor bill suffix instance.
        /// </summary>
        public const string LastVendorBillSuffix = "VB_LASTVBNUM_SUFFIX";
        /// <summary>
        /// Last vendor bill prefix instance.
        /// </summary>
        public const string LastVendorBillPrefix = "VB_LASTVBNUM_PREFIX";

        /// <summary>
        /// Last purchase order number prefix instance.
        /// </summary>
        public const string LastPurchaseOrderNumberPrefix = "PO_LASTPONUM_PREFIX";
        /// <summary>
        /// Last purchase order number suffix instance.
        /// </summary>
        public const string LastPurchaseOrderNumberSuffix = "PO_LASTPONUM_SUFFIX";
        /// <summary>
        /// Payment term identifier instance.
        /// </summary>
        public const string PaymentTermId = "GENERAL_VENDOR_TERM";

        /// <summary>
        /// AP Discount account identifier instance.
        /// </summary>
        //public const string DiscountAccountId = "AP_SYSTEM_DEFAULT_ACC_DISCOUNT";

        /// <summary>
        /// EFT account identifier instance.
        /// </summary>
        public const string EFTAccountId = "AP_SYSTEM_DEFAULT_ACC_EFT";

        /// <summary>
        /// PayrollTaxes account identifier instance.
        /// </summary>
        public const string PayrollTaxesId = "AP_SYSTEM_DEFAULT_ACC_PAYROLLTAXES";

        /// <summary>
        /// NonPayrollTaxes account identifier instance.
        /// </summary>
        public const string NonPayrollTaxesId = "AP_SYSTEM_DEFAULT_ACC_NONPAYROLLTAXES";

        public const string ApDiscountAccountId = "AP_SYSTEM_DEFAULT_ACC_DISCOUNT";

        /// <summary>
        /// AR Discount account identifier instance.
        /// </summary>
        public const string ArDiscountAccountId = "AR_SYSTEM_DEFAULT_ACC_DISCOUNT";


        /// <summary>
        /// The late fee account identifier
        /// </summary>
        public const string LateFeeAccountId = "AR_SYSTEM_DEFAULT_ACC_LATEFEE";


        public const string EnableFundAccounting = "ENABLE_FUND_ACCOUNTING";

        /// <summary>
        /// Check default  instance.
        /// </summary>
        public const string PayrollExpenseAccountID = "Payroll_PayrollExpenseAccountID";

        /// <summary>
        /// Check default  instance.
        /// </summary>
        public const string WithholdingLiabilityAccountID = "Payroll_WithholdingLiabilityAccountID";

        /// <summary>
        /// Check default  instance.
        /// </summary>
        public const string WithholdingExpenseAccountID = "Payroll_WithholdingExpenseAccountID";

        /// <summary>
        /// Check default  instance.
        /// </summary>
        public const string TaxesLiabilityAccountID = "Payroll_TaxesLiabilityAccountID";

        /// <summary>
        /// Check default  instance.
        /// </summary>
        public const string TaxesExpenseAccountID = "Payroll_TaxesExpenseAccountID";
        public const string AddVendorBillNumberToBillPaymentCheckMemo = "ADD_VB_NUMBER_TO_BILLPAYMENT_CHECK_MEMO"; 

    }

    /// <summary>
    /// 
    /// </summary>
    public class LedesSetting
    {
        /// <summary>
        /// Company name instance.
        /// </summary>
        public const string CompanyName = "LEDES_CompanyName";
        /// <summary>
        /// Company identifier instance.
        /// </summary>
        public const string CompanyID = "LEDES_CompanyID";

        /// <summary>
        /// Client custom field identifier instance.
        /// </summary>
        public const string ClientCustomField_ID = "LEDES_ClientCustomFieldID";
        /// <summary>
        /// Matter custom field identifier instance.
        /// </summary>
        public const string MatterCustomField_ID = "LEDES_MatterCustomFieldID";

        /// <summary>
        /// Client Matter Option
        /// </summary>
        public const string ClientMatterOption = "Ledes_ClientMatterOption";

        /// <summary>
        /// Export option instance.
        /// </summary>
        public const string ExportOption = "LEDES_ExportOption";
        /// <summary>
        /// Export format instance.
        /// </summary>
        public const string ExportFormat = "LEDES_ExportFormat";
        /// <summary>
        /// Use custom separator instance.
        /// </summary>
        public const string UseCustomSeparator = "LEDES_UseCustomSeparator";
        /// <summary>
        /// Time keeper identifier instance.
        /// </summary>
        public const string TimeKeeperId = "LEDES_TimeKeeperId";
        /// <summary>
        /// Invoice start date end date instance.
        /// </summary>
        public const string InvoiceStartDateEndDate = "LEDES_InvoiceStartDateEndDate";
        /// <summary>
        /// Invoice custom start date instance.
        /// </summary>
        public const string InvoiceCustomStartDate = "LEDES_InvoiceCustomStartDate";
        /// <summary>
        /// Invoice custom end date instance.
        /// </summary>
        public const string InvoiceCustomEndDate = "LEDES_InvoiceCustomEndDate";
        /// <summary>
        /// Replace colon with space instance.
        /// </summary>
        public const string ReplaceColonWithSpace = "LEDES_ReplaceColonWithSpace";
        /// <summary>
        /// Invoice date instance.
        /// </summary>
        public const string InvoiceDate = "LEDES_InvoiceDate";

        /// <summary>
        /// Use customized mapping for expense items instance.
        /// </summary>
        public const string UseCustomizedMappingForExpenseItems = "LEDES_UseCustomizedMappingForExpenseItems";
        /// <summary>
        /// Send matters on joint invoice as separate files instance.
        /// </summary>
        public const string SendMattersOnJointInvoiceAsSeparateFiles =
            "LEDES_SendMattersOnJointInvoiceAsSeparateFiles";
        /// <summary>
        /// Export sales tax as separate line item instance.
        /// </summary>
        public const string ExportSalesTaxAsSeparateLineItem = "LEDES_ExportSalesTaxAsSeparateLineItem";
        /// <summary>
        /// Replace zero with blank for line item units unit cost and total instance.
        /// </summary>
        public const string ReplaceZeroWithBlankForLineItemUnitsUnitCostAndTotal =
            "LEDES_ReplaceZeroWithBlankForLineItemUnitsUnitCostAndTotal";
        /// <summary>
        /// Map invoice custom1 with invoice description instance.
        /// </summary>
        public const string MapInvoiceCustom1WithInvoiceDescription =
            "LEDES_MapInvoiceCustom1WithInvoiceDescription";
        /// <summary>
        /// Lede S1998 b to appear in fist line instance.
        /// </summary>
        public const string LEDES1998_BToAppearInFistLine = "LEDES_LEDES1998_BToAppearInFistLine";
        /// <summary>
        /// Exclude service details for fixed fee matters instance.
        /// </summary>
        public const string ExcludeServiceDetailsForFixedFeeMatters =
            "LEDES_ExcludeServiceDetailsForFixedFeeMatters";
        /// <summary>
        /// No space between line items instance.
        /// </summary>
        public const string NoSpaceBetweenLineItems = "LEDES_NoSpaceBetweenLineItems";
        /// <summary>
        /// Do not send timekeeper identifier name for expense items instance.
        /// </summary>
        public const string DoNotSendTimekeeperIDNameForExpenseItems =
            "LEDES_DoNotSendTimekeeperIDNameForExpenseItems";
        /// <summary>
        /// With colons between time keeper i ds instance.
        /// </summary>
        public const string WithColonsBetweenTimeKeeperIDs = "LEDES_WithColonsBetweenTimeKeeperIDs";
        /// <summary>
        /// First name first initial instance.
        /// </summary>
        public const string FirstNameFirstInitial = "LEDES_FirstNameFirstInitital";
        /// <summary>
        /// Use this billing start and end date instance.
        /// </summary>
        public const string UseThisBillingStartAndEndDate = "LEDES_UseThisBillingStartAndEndDate";
        /// <summary>
        /// Send summarized single line item per matter instance.
        /// </summary>
        public const string SendSummarizedSingleLineItemPerMatter = "LEDES_SendSummarizedSingleLineItemPerMatter";
        /// <summary>
        /// Export timeand expense details of invoices in chronological order instance.
        /// </summary>
        public const string ExportTimeandExpenseDetailsOfInvoicesInChronologicalOrder =
            "LEDES_ExportTimeandExpenseDetailsOfInvoicesInChronologicalOrder";
        /// <summary>
        /// Set invoice date to the last date of service instance.
        /// </summary>
        public const string SetInvoiceDateToTheLastDateOfService = "LEDES_SetInvoiceDateToTheLastDateOfService";
        /// <summary>
        /// Do not send timekeeper classification for expense items instance.
        /// </summary>
        public const string DoNotSendTimekeeperClassificationForExpenseItems =
            "LEDES_DoNotSendTimekeeperClassificationForExpenseItems";
        /// <summary>
        /// Set invoice start and end date to first and last service date instance.
        /// </summary>
        public const string SetInvoiceStartAndEndDateToFirstAndLastServiceDate =
            "LEDES_SetInvoiceStartAndEndDateToFirstAndLastServiceDate";
        /// <summary>
        /// Replace client identifier with client matter identifier instance.
        /// </summary>
        public const string ReplaceClientIDWithClientMatterID = "LEDES_ReplaceClientIDWithClientMatterID";
        /// <summary>
        /// Separator to use between timekeeper firstand last name instance.
        /// </summary>
        public const string SeparatorToUseBetweenTimekeeperFirstandLastName =
            "LEDES_SeparatorToUseBetweenTimekeeperFirstandLastName";
        /// <summary>
        /// First name then last name instance.
        /// </summary>
        public const string FirstNameThenLastName = "LEDES_FirstNameThenLastName";
        /// <summary>
        /// Exclude non billable time and expenses instance.
        /// </summary>
        public const string ExcludeNonBillableTimeAndExpenses = "LEDES_ExcludeNonBillableTimeAndExpenses";
        /// <summary>
        /// Line Item Tax Type, the values include VAT, GST or Other.
        /// </summary>
        public const string LineItemTaxType = "LEDES_LineItemTaxType";
    }


    /// <summary>
    /// 
    /// </summary>
    public class AppearancePreference
    {
        /// <summary>
        /// Theme instance.
        /// </summary>
        public const string Theme = "USER_THEME";
        /// <summary>
        /// Message opacity instance.
        /// </summary>
        public const string MessageOpacity = "MSG_OPACITY";
        /// <summary>
        /// Message duration instance.
        /// </summary>
        public const string MessageDuration = "MSG_DURATION";
        /// <summary>
        /// Activity prefix instance.
        /// </summary>
        public const string ActivityPrefix = "ACT_PREFIX";
        /// <summary>
        /// Expense prefix instance.
        /// </summary>
        public const string ExpensePrefix = "EXP_PREFIX";
        /// <summary>
        /// Display account as instance.
        /// </summary>
        public const string DisplayAccountAs = "DISPLAY_ACT_AS";
        /// <summary>
        /// Display project as instance.
        /// </summary>
        public const string DisplayProjectAs = "DISPLAY_PROJECT_AS";
        /// <summary>
        /// Show project assign tab in project instance.
        /// </summary>
        public const string ShowProjectAssignTabInProject = "PROJECT_ASSIGN_TAB";
        /// <summary>
        /// Show employee assign tab in employees instance.
        /// </summary>
        public const string ShowEmployeeAssignTabInEmployees = "EMPLOYEE_ASSIGN_TAB";
    }


    /// <summary>
    /// 
    /// </summary>
    public class GeneralPreference
    {
        /// <summary>
        /// Synchronize qb records on deletion instance.
        /// </summary>
        public const string SyncQBRecordsOnDeletion = "SYNC_QB_DELETE";
        /// <summary>
        /// Turn off un approved notification on invoicing instance.
        /// </summary>
        public const string TurnOffUnApprovedNotificationOnInvoicing = "UNAPPROVED_NOTIFY_INVOICING";
        /// <summary>
        /// Turn off automatic complete instance.
        /// </summary>
        public const string TurnOffAutoComplete = "IS_AUTOCOMPLETE_OFF";
        /// <summary>
        /// Remember last visited page instance.
        /// </summary>
        public const string RememberLastVisitedPage = "REMEMBER_LASTPAGE";
        /// <summary>
        /// Default invoices message instance.
        /// </summary>
        public const string DefaultInvoicesMessage = "DEFAULT_INVOICE_MSG";
        /// <summary>
        /// Default statements message instance.
        /// </summary>
        public const string DefaultStatementsMessage = "DEFAULT_STATEMENT_MSG";
        /// <summary>
        /// Default reports message instance.
        /// </summary>
        public const string DefaultReportsMessage = "DEFAULT_REPORT_MSG";
        /// <summary>
        /// Theme instance.
        /// </summary>
        public const string Theme = "USER_THEME";

        public const string IncludeVendorsInEmployeeDropDown = "INCLUDE_VENDORS_IN_EMPLOYEE_DROPDOWN";

        public const string IncludeInactiveEmployees = "INCLUDE_INACTIVE_EMPLOYEES";

        public const string IncludeInactiveVendors = "INCLUDE_INACTIVE_VENDORS";

        public const string IncludeInactiveActivites = "INCLUDE_INACTIVE_ACTIVITES";

        public const string IncludeInactiveExpenses = "INCLUDE_INACTIVE_EXPENSES";

        public const string IncludeNonActiveProjects = "INCLUDE_NONACTIVE_PROJECTS";

        public const string DefaultScreenOption = "DEFAULT_SCREEN_OPTION";

        public const string DefaultScreen = "DEFAULT_SCREEN";

        public const string IncludeInactiveFinancialBudget = "INCLUDE_INACTIVE_FINANCIAL_BUDGET";

        public const string IncludeInactiveReviewTemplates = "INCLUDE_INACTIVE_REVIEW_TEMPLATES";

        /// <summary>
        /// Turn off recent suggestions.
        /// </summary>
        public const string TurnOffRecentSuggestions = "IS_RECENT_SUGGESTIONS_OFF";

        public const string DisbleAJAXSave = "Disable_AJAX_Save";

        //Not displayed from UI
        public const string IsAutomaticInvoiceProcessed = "IS_AUTOMATIC_INVOICE_PROCESSED";

        public const string IsAutomaticBillProcessed = "IS_AUTOMATIC_BILL_PROCESSED";

        public const string IsAutomaticCheckProcessed = "IS_AUTOMATIC_CHECK_PROCESSED";

        public const string DropDownSearch = "Drop_Down_Search";
        //Not displayed from UI
    }

    public class Office365Preference
    {
        public const string Office365Setting = "OFFICE_365_SETTING"; //OFFICE_365_SETTING use comment one
    }
    public class GooglePreference
    {
        public const string GoogleSetting = "GOOGLE_SETTING"; //
    }

    public class SideNavigationPreferences
    {
        public const string MenuSortOrder = "MENU_SORT_ORDER";
    }
    /// <summary>
    /// 
    /// </summary>
    public class NotificationPreferences
    {
        /// <summary>
        /// Notify by email instance.
        /// </summary>
        public const string NotifyByEmail = "NOTIFY_EMAIL";
        /// <summary>
        /// Notify by internal MSG instance.
        /// </summary>
        public const string NotifyByInternalMsg = "NOTIFY_MSG";
        /// <summary>
        /// Notify approved time and expenses instance.
        /// </summary>
        public const string NotifyApprovedTimeAndExpenses = "NOTIFY_TIMEEXPENSE_APPROVAL";
        /// <summary>
        /// Notify rejected time and expenses instance.
        /// </summary>
        public const string NotifyRejectedTimeAndExpenses = "NOTIFY_TIMEEXPENSE_REJECTION";
        /// <summary>
        /// Notify invoices approval status instance.
        /// </summary>
        public const string NotifyInvoicesApprovalStatus = "NOTIFY_INVOICES_APPROVAL";
        /// <summary>
        /// Notify purchase order approval status instance.
        /// </summary>
        public const string NotifyPurchaseOrderApprovalStatus = "NOTIFY_PURCHASEORDER_APPROVAL";
        /// <summary>
        /// Notify vendor bills approval status instance.
        /// </summary>
        public const string NotifyVendorBillsApprovalStatus = "NOTIFY_VENDORBILL_APPROVAL";
        /// <summary>
        /// Notify time off approval status instance.
        /// </summary>
        public const string NotifyTimeOffApprovalStatus = "NOTIFY_TIMEOFF_APPROVAL";
        /// <summary>
        /// Notify budget approval status instance.
        /// </summary>
        public const string NotifyBudgetApprovalStatus = "NOTIFY_BUDGET_APPROVAL";
        /// <summary>
        /// Notify estimate approval status instance.
        /// </summary>
        public const string NotifyEstimateApprovalStatus = "NOTIFY_ESTIMATE_APPROVAL";
        /// <summary>
        /// Notify new assigned to do instance.
        /// </summary>
        public const string NotifyNewAssignedToDo = "NOTIFY_NEW_TODO";
        /// <summary>
        /// Notify hours and units allocated instance.
        /// </summary>
        public const string NotifyHoursAndUnitsAllocated = "NOTIFY_HOURS_ALLOCATED";
        /// <summary>
        /// Project due date instance.
        /// </summary>
        public const string ProjectDueDate = "NOTIFY_DUEDATE";
        /// <summary>
        /// Time and expenses submitted for approval instance.
        /// </summary>
        public const string TimeAndExpensesSubmittedForApproval = "NOTIFY_TIMEEXPENSE_SUBMIT";
        /// <summary>
        /// Invoices submitted for approval instance.
        /// </summary>
        public const string InvoicesSubmittedForApproval = "NOTIFY_INVOICE_SUBMIT";
        /// <summary>
        /// Purchase orders submitted for approval instance.
        /// </summary>
        public const string PurchaseOrdersSubmittedForApproval = "NOTIFY_PURCHASEORDER_SUBMIT";
        /// <summary>
        /// Time off submitted for approval instance.
        /// </summary>
        public const string TimeOffSubmittedForApproval = "NOTIFY_TIMEOFF_SUBMIT";
        /// <summary>
        /// Budget submitted for approval instance.
        /// </summary>
        public const string BudgetSubmittedForApproval = "NOTIFY_BUDGET_SUBMIT";
        /// <summary>
        /// Vendor bills submitted for approval instance.
        /// </summary>
        public const string VendorBillsSubmittedForApproval = "NOTIFY_VendorBill_SUBMIT";
        /// <summary>
        /// Estimate submitted for approval instance.
        /// </summary>
        public const string EstimateSubmittedForApproval = "NOTIFY_ESTIMATE_SUBMIT";
        /// <summary>
        /// Remind due date ahead instance.
        /// </summary>
        public const string RemindDueDateAhead = "REMIND_DUEDATE_AHEAD";

        /// <summary>
        /// The review assigned to reviewer
        /// </summary>
        public const string ReviewAssignedToReviewer = "REVIEW_ASSIGNED_TO_REVIEWER";
        /// <summary>
        /// RFI's are submitted.
        /// </summary>
        public const string RFISubmitted = "NOTIFY_RFI_SUBMIT";
        /// <summary>
        /// Submittal's are submitted.
        /// </summary>
        public const string SubmittalSubmitted = "NOTIFY_SUBMITTAL_SUBMIT";
        public const string NotifyAssignedLead = "NOTIFY_ASSIGNED_LEAD";
        public const string NotifyAssignedProspect = "NOTIFY_ASSIGNED_PROSPECT";
        public const string NotifyAssignedSalesGoal = "NOTIFY_ASSIGNED_SALESGOAL";
        public const string CampaignSubmittedForApproval = "CAMPAIGN_SUBMITTED_FOR_APPROVAL";
        //public const string NotifyApprovedCampaign = "NOTIFY_APPROVED_CAMPAIGN";
        //public const string NotifyRejectedCampaign = "NOTIFY_REJECTED_CAMPAIGN";
        public const string NotifyCampaignsApprovalStatus = "NOTIFY_CAMPAIGNS_APPROVAL";
        public const string NotifyProjectAssigned = "NOTIFY_PROJECT_ASSIGNED";
        public const string ProposalSubmittedForApproval = "PROPOSAL_SUBMITTED_FOR_APPROVAL";

        public const string NotifyOpportunityAssigned = "NOTIFY_OPPORTUNITY_ASSIGNED";
    }


    /// <summary>
    /// 
    /// </summary>
    public class ReminderPreference
    {
        /// <summary>
        /// Remind billing instance.
        /// </summary>
        public const string RemindBilling = "REMIND_BILLING";
        /// <summary>
        /// Remind employee important dates instance.
        /// </summary>
        public const string RemindEmployeeImportantDates = "REMIND_EMPLOYEE_IMPORTANT_DATES";
        /// <summary>
        /// Remind employee instance.
        /// </summary>
        public const string RemindEmployee = "REMIND_EMPLOYEE";
        /// <summary>
        /// Remind expense entry instance.
        /// </summary>
        public const string RemindExpenseEntry = "REMIND_EXPENSEENTRY";
        /// <summary>
        /// Remind expense entry un submitted instance.
        /// </summary>
        public const string RemindExpenseEntryUnSubmitted = "REMIND_EXPENSEENTRY_UNSUBMITTED";
        /// <summary>
        /// Remind invoice entry instance.
        /// </summary>
        public const string RemindInvoiceEntry = "REMIND_INVOICEENTRY";
        /// <summary>
        /// Remind late to do tasks assigned to me instance.
        /// </summary>
        public const string RemindLateToDoTasksAssignedToMe = "REMIND_LATE_TODOTASKS_ASSIGNEDTOME";
        /// <summary>
        /// Remind late to do tasks my tasks instance.
        /// </summary>
        public const string RemindLateToDoTasksMyTasks = "REMIND_LATE_TODOTASKS_MYTASKS";
        /// <summary>
        /// Remind late to do tasks projects i manage instance.
        /// </summary>
        public const string RemindLateToDoTasksProjectsIManage = "REMIND_LATE_TODOTASKS_PROJECTS_IMANAGE";
        /// <summary>
        /// Remind minimum retainer instance.
        /// </summary>
        public const string RemindMinimumRetainer = "REMIND_MINIMUMRETAINER";
        /// <summary>
        /// Remind past due vendor bills instance.
        /// </summary>
        public const string RemindPastDueVendorBills = "REMIND_PASTDUE_VENDORBILLS";
        /// <summary>
        /// Remind project instance.
        /// </summary>
        public const string RemindProject = "REMIND_PROJECT";
        /// <summary>
        /// Remind pto request instance.
        /// </summary>
        public const string RemindPTORequest = "REMIND_PTO_REQUEST";
        /// <summary>
        /// Remind purchase order entry instance.
        /// </summary>
        public const string RemindPurchaseOrderEntry = "REMIND_PURCHASEORDER_ENTRY";
        /// <summary>
        /// Remind time entry instance.
        /// </summary>
        public const string RemindTimeEntry = "REMIND_TIMEENTRY";
        /// <summary>
        /// Remind time entry un submitted instance.
        /// </summary>
        public const string RemindTimeEntryUnSubmitted = "REMIND_TIMEENTRY_UNSUBMITTED";
        /// <summary>
        /// Remind timer instance.
        /// </summary>
        public const string RemindTimer = "REMIND_TIMER";
        /// <summary>
        /// Remind to do tasks assigned to me instance.
        /// </summary>
        public const string RemindToDoTasksAssignedToMe = "REMIND_TODOTASKS_ASSIGNEDTOME";
        /// <summary>
        /// Remind to do tasks my tasks instance.
        /// </summary>
        public const string RemindToDoTasksMyTasks = "REMIND_TODOTASKS_MYTASKS";
        /// <summary>
        /// Remind un posted invoices instance.
        /// </summary>
        public const string RemindUnPostedInvoices = "REMIND_UNPOSTEDINVOICES";
        /// <summary>
        /// Remind vendor bill entry instance.
        /// </summary>
        public const string RemindVendorBillEntry = "REMIND_VENDORBILL_ENTRY";
        /// <summary>
        /// Remind vendor instance.
        /// </summary>
        public const string RemindVendor = "REMIND_VENDOR";
        /// <summary>
        /// Project due date days instance.
        /// </summary>
        public const string ProjectDueDateDays = "NOTIFY_DUEDATE_DAYS";
        /// <summary>
        /// Remind Billing Schedule instance.
        /// </summary>
        public const string RemindBillingSchedule = "REMIND_BILLING_SCHEDULE";

        public const string RemindEmployeeReview = "REMIND_EMPLOYEE_REVIEW";
        public const string RemindOverDueOpportunities = "REMIND_OVERDUE_OPPORTUNITIES";
        public const string RemindOpportunitiesWithNoActivity = "REMIND_OPPORTUNITIES_WITH_NO_ACTIVITY";
        public const string RemindFollowUpsAssignedToMe = "REMIND_FOLLOW_UPS";
        // public const string RemindFollowUps = "REMIND_FOLLOW_UPS";
        // public const string RemindFollowUpLeads = "REMIND_FOLLOW_UP_LEADS";
        //public const string RemindFollowUpOpportunities = "REMIND_FOLLOW_UP_OPPORTUNITIES";
        public const string LastWeekTimeCardHours = "REMIND_LASTWEEK_TIMECARD_HOURS";

        public const string RemindIncompleteTimeCardDaily = "REMIND_INCOMPLETE_TIMECARD_DAILY";

        public const string DailyTimeCardHours = "REMIND_DAILY_TIMECARD_HOURS";
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmailPreference
    {
        /// <summary>
        /// User preferences override global setting instance.
        /// </summary>
        public const string UserPreferencesOverrideGlobalSetting = "UP_OVERRIDE_GS_EMAIL_SETTINGS";
        /// <summary>
        /// SMTP server instance.
        /// </summary>
        public const string SmtpServer = "EMAIL_SMTPSERVERADDRESS";
        /// <summary>
        /// Use SSL instance.
        /// </summary>
        public const string UseSSL = "EMAIL_USESSL";
        /// <summary>
        /// SMTP requires authentication instance.
        /// </summary>
        public const string SmtpRequiresAuthentication = "EMAIL_AUTHENTICATE";

        /// <summary>
        /// User name instance.
        /// </summary>
        public const string UserName = "EMAIL_DISPLAYNAME";
        /// <summary>
        /// Email from instance.
        /// </summary>
        public const string EmailFrom = "EMAIL_ADDRESS";
        /// <summary>
        /// c cmail to instance.
        /// </summary>
        public const string CCmailTo = "EMAIL_CCMAILTO";
        /// <summary>
        /// Bc cmail to instance.
        /// </summary>
        public const string BCCmailTo = "EMAIL_BCCMAILTO";


        /// <summary>
        /// Logon user name instance.
        /// </summary>
        public const string LogonUserName = "EMAIL_USERNAME";
        /// <summary>
        /// Logon password instance.
        /// </summary>
        public const string LogonPassword = "EMAIL_PASSWORD";
        /// <summary>
        /// Delivery method instance.
        /// </summary>
        public const string DeliveryMethod = "EMAIL_DELIVERY";
        /// <summary>
        /// Directory name instance.
        /// </summary>
        public const string DirectoryName = "EMAIL_DIRNAME";


        /// <summary>
        /// Port instance.
        /// </summary>
        public const string Port = "EMAIL_PORT";
        /// <summary>
        /// Authentication type instance.
        /// </summary>
        public const string AuthenticationType = "EMAIL_AUTHENTICATION";
        /// <summary>
        /// Statements default subject instance.
        /// </summary>
        public const string StatementsDefaultSubject = "EMAIL_SUBJECT_STMTS";
        /// <summary>
        /// Statements default PDF name instance.
        /// </summary>
        public const string StatementsDefaultPDFName = "EMAIL_ATTACHMENT_STMTS";
        /// <summary>
        /// Statements default email message instance.
        /// </summary>
        public const string StatementsDefaultEmailMessage = "EMAIL_MESSAGESTATEMENTS";


        /// <summary>
        /// Reports default subject instance.
        /// </summary>
        public const string ReportsDefaultSubject = "EMAIL_SUBJECT_REPORTS";
        /// <summary>
        /// Reports default PDF name instance.
        /// </summary>
        public const string ReportsDefaultPDFName = "EMAIL_ATTACHMENT_REPORTS";
        /// <summary>
        /// Reports default email message instance.
        /// </summary>
        public const string ReportsDefaultEmailMessage = "EMAIL_MESSAGEREPORTS";

        /// <summary>
        /// Purchase order reports default email message instance.
        /// </summary>
        public const string PurchaseOrderReportsDefaultEmailMessage = "EMAIL_MESSAGE_PORDER";
        /// <summary>
        /// Purchase order reports default pd fname instance.
        /// </summary>
        public const string PurchaseOrderReportsDefaultPDFname = "EMAIL_ATTACHMENT_PORDER";
        /// <summary>
        /// Purchase order reports default subject instance.
        /// </summary>
        public const string PurchaseOrderReportsDefaultSubject = "EMAIL_SUBJECT_PORDER";

        /// <summary>
        /// Payment default subject instance.
        /// </summary>
        public const string PaymentDefaultSubject = "EMAIL_SUBJECT_PAYMENTRECEIPT";
        /// <summary>
        /// Payment default email message instance.
        /// </summary>
        public const string PaymentDefaultEmailMessage = "EMAIL_MESSAGE_PAYMENTRECEIPT";


        /// <summary>
        /// Invoice default subject instance.
        /// </summary>
        public const string InvoiceDefaultSubject = "EMAIL_SUBJECT_INV";
        /// <summary>
        /// Invoice default PDF name instance.
        /// </summary>
        public const string InvoiceDefaultPDFName = "EMAIL_ATTACHMENT_INV";
        /// <summary>
        /// Joint invoice default PDF name instance.
        /// </summary>
        public const string JointInvoiceDefaultPDFName = "EMAIL_ATTACHMENT_JINV";
        /// <summary>
        /// Invoice default email message instance.
        /// </summary>
        public const string InvoiceDefaultEmailMessage = "EMAIL_MESSAGE";
    }

    /// <summary>
    /// 
    /// </summary>
    public class TimeExpensePreference
    {
        /// <summary>
        /// Automatic fill timer instance.
        /// </summary>
        public const string AutoFillTimer = "AUTOFILL_TIMER";
        /// <summary>
        /// Automatic fill time card instance.
        /// </summary>
        public const string AutoFillTimeCard = "AUTOFILL_TIME";
        /// <summary>
        /// The time card automatic fill type
        /// </summary>
        public const string AutoFillType = "AUTOFILLTYPE_TIME";
        /// <summary>
        /// Automatic set start stop time instance.
        /// </summary>
        public const string AutoSetStartStopTime = "AUTO_STARTTIME";
        /// <summary>
        /// Check default start time instance.
        /// </summary>
        public const string CheckDefaultStartTime = "CHK_DEFAUTL_STARTTIME";
        /// <summary>
        /// Check default stop time instance.
        /// </summary>
        public const string CheckDefaultStopTime = "CHK_DEFAULT_STOPTIME";
        /// <summary>
        /// Default start time instance.
        /// </summary>
        public const string DefaultStartTime = "DEFAULT_STARTTIME";
        /// <summary>
        /// Default stop time instance.
        /// </summary>
        public const string DefaultStopTime = "DEFAULT_STOPTIME";
        /// <summary>
        /// Default appointment view instance.
        /// </summary>
        public const string DefaultAppointmentView = "DEFAULT_APPOINT_VIEW";
        /// <summary>
        /// Number of project activities instance.
        /// </summary>
        public const string NumberOfProjectActivities = "PROJ_ACT_NUMBER";
        /// <summary>
        /// Number of project activities instance.
        /// </summary>
        public const string NumberOfTimerEntries = "TIMER_NUMBER";
        /// <summary>
        /// Default current week in time card instance.
        /// </summary>
        public const string DefaultCurrentWeekInTimeCard = "TIMECARD_DEFAULT_WEEK";
        /// <summary>
        /// Number of rows to show in time card instance.
        /// </summary>
        public const string NumberOfRowsToShowInTimeCard = "TIMECARD_MAX_ROWS";
        /// <summary>
        /// Show time in universal format instance.
        /// </summary>
        public const string ShowTimeInUniversalFormat = "TIME_FORMAT_UNIVERSAL";
        /// <summary>
        /// Show allocation summary by default
        /// </summary>
        public const string ShowAllocationSummary = "SHOW_ALLOCATION_SUMMARY";
    }

    public static class PayrollSetting
    {
        /// <summary>
        /// Check default PrimarySUTATaxID instance.
        /// </summary>
        public const string PrimarySUTATaxID = "Payroll_PrimarySUTATaxID";

        /// <summary>
        /// Check default PrimaryStateTaxID instance.
        /// </summary>
        public const string PrimaryStateTaxID = "Payroll_PrimaryStateTaxID";

        /// <summary>
        /// Check default OrganizationType instance.
        /// </summary>
        public const string OrganizationType = "Payroll_OrganizationType";

        /// <summary>
        /// Check default TaxFilingCategory instance.
        /// </summary>
        public const string TaxFilingCategory = "Payroll_TaxFilingCategory";

        /// <summary>
        /// Check default BusinessCategory instance.
        /// </summary>
        public const string BusinessCategory = "Payroll_BusinessCategory";

        /// <summary>
        /// Check default YearEstablished instance.
        /// </summary>
        public const string YearEstablished = "Payroll_YearEstablished";

        /// <summary>
        /// Check default LastQuarterEnd instance.
        /// </summary>
        public const string LastQuarterEnd = "Payroll_LastQuarterEnd";


        /// <summary>
        /// Check default DoingBusinessAs instance.
        /// </summary>
        public const string DoingBusinessAs = "Payroll_DoingBusinessAs";

        /// <summary>
        /// Check default PayrollGroup_ID instance.
        /// </summary>
        public const string PayrollGroup_ID = "Payroll_PayrollGroup_ID";

        /// <summary>
        /// Check default NormalPayItemOnly.
        /// </summary>
        public const string NormalPayItemOnly = "Payroll_NormalPayItemOnly";

        /// <summary>
        /// Check default ExcludeSickVacHolComp.
        /// </summary>
        public const string ExcludeSickVacHolComp = "Payroll_ExcludeSickVacHolComp";

        /// <summary>
        /// Check default ExcludeSickVacHolComp.
        /// </summary>
        public const string EmployeesWithLessSalaryForGarnishments = "WAGEGARNISHMENTEMPLOYEES_";

        public const string AddDefaultDataOfpayrollForExistingEmployees = "PAYROLL_ADD_DEFAULTDATA_FOREXISTING_EMPLOYEES";

        public const string ShowPromptForSuccessfulAdditionOfDefaultData = "PAYROLL_SHOW_PROMPT_SUCCESSFUL_DATA_ADDITION";

        public const string ReimbursableExpense= "Reimbursable Expense";
    }

    public static class Packages
    {
        public const string HR = "HR";
        public const string TimeAndExpense = "Time And Expense";
        public const string Manager = "Manager";
        public const string Accounting = "Accounting";
        public const string Billing = "Billing";
        public const string HRUser = "HR User";
    }


    public static class UserInteractionOptions
    {
        public static readonly string CreateAllocationOnPtoApproval = $"{(int)UserPromptsEnum.PTO_CreateTimeEntryForPTO}_CREATE_ALLOCATION";
    }

    public static class NoteCategory
    {
        public const string FollowUp = "Follow-Up";

        public const string Campaign = "Campaign";

        public const string Lead = "Lead";

        public const string Prospect = "Prospect";

        public const string Opportunity = "Opportunity";

        public const string Quote = "Quote";

        public const string Proposal = "Proposal";

        public const string ToDo = "To-Do";
    }

    public static class QueryPlaceHolder
    {
        public const string NoteDate = "[42_NOTE_DATE]";

        public const string LoginUserID = "[LOGIN_USER_ID]";

        public const string  NoteEntityFromDate= "[42_FROM_DATE]";

        public const string NoteEntityToDate = "[42_TO_DATE]";

    }

    public static class USAStates
    {
        public const string GEORGIA = "Georgia";
        public const string Oregon = "Oregon";
        public const string Colorado = "Colorado";
    }


    public static class WebhookEvents
    {
        /// <summary>
        /// The account created
        /// </summary>
        public const string AccountCreated = "account.create";

        /// <summary>
        /// The account updated
        /// </summary>
        public const string AccountUpdated = "account.update";

        /// <summary>
        /// The account deleted
        /// </summary>
        public const string AccountDeleted = "account.delete";

        /// <summary>
        /// The activity created
        /// </summary>
        public const string ActivityCreated = "activity.create";

        /// <summary>
        /// The activity updated
        /// </summary>
        public const string ActivityUpdated = "activity.update";

        /// <summary>
        /// The activity deleted
        /// </summary>
        public const string ActivityDeleted = "activity.delete";

        /// <summary>
        /// The allocation created
        /// </summary>
        public const string AllocationCreated = "allocation.create";

        /// <summary>
        /// The allocation updated
        /// </summary>
        public const string AllocationUpdated = "allocation.update";

        /// <summary>
        /// The allocation deleted
        /// </summary>
        public const string AllocationDeleted = "allocation.delete";

        /// <summary>
        /// The bill created
        /// </summary>
        public const string BillCreated = "bill.create";

        /// <summary>
        /// The bill updated
        /// </summary>
        public const string BillUpdated = "bill.update";

        /// <summary>
        /// The bill deleted
        /// </summary>
        public const string BillDeleted = "bill.delete";

        /// <summary>
        /// The billing schedule created
        /// </summary>
        public const string BillingScheduleCreated = "billing schedule.create";

        /// <summary>
        /// The billing schedule updated
        /// </summary>
        public const string BillingScheduleUpdated = "billing schedule.update";

        /// <summary>
        /// The billing schedule deleted
        /// </summary>
        public const string BillingScheduleDeleted = "billing schedule.delete";

        /// <summary>
        /// The budget created
        /// </summary>
        public const string BudgetCreated = "budget.create";

        /// <summary>
        /// The budget updated
        /// </summary>
        public const string BudgetUpdated = "budget.update";

        /// <summary>
        /// The budget deleted
        /// </summary>
        public const string BudgetDeleted = "budget.delete";

        /// <summary>
        /// The client created
        /// </summary>
        public const string ClientCreated = "client.create";

        /// <summary>
        /// The client updated
        /// </summary>
        public const string ClientUpdated = "client.update";

        /// <summary>
        /// The client deleted
        /// </summary>
        public const string ClientDeleted = "client.delete";

        /// <summary>
        /// The contact created
        /// </summary>
        public const string ContactCreated = "contact.create";

        /// <summary>
        /// The contact updated
        /// </summary>
        public const string ContactUpdated = "contact.update";

        /// <summary>
        /// The contact deleted
        /// </summary>
        public const string ContactDeleted = "contact.delete";

        /// <summary>
        /// The employee created
        /// </summary>
        public const string EmployeeCreated = "employee.create";

        /// <summary>
        /// The employee updated
        /// </summary>
        public const string EmployeeUpdated = "employee.update";

        /// <summary>
        /// The employee deleted
        /// </summary>
        public const string EmployeeDeleted = "employee.delete";

        /// <summary>
        /// The estimate created
        /// </summary>
        public const string EstimateCreated = "estimate.create";

        /// <summary>
        /// The estimate updated
        /// </summary>
        public const string EstimateUpdated = "estimate.update";

        /// <summary>
        /// The estimate deleted
        /// </summary>
        public const string EstimateDeleted = "estimate.delete";

        /// <summary>
        /// The expense created
        /// </summary>
        public const string ExpenseCreated = "expense.create";

        /// <summary>
        /// The expense updated
        /// </summary>
        public const string ExpenseUpdated = "expense.update";

        /// <summary>
        /// The expense deleted
        /// </summary>
        public const string ExpenseDeleted = "expense.delete";

        /// <summary>
        /// The expense entry created
        /// </summary>
        public const string ExpenseEntryCreated = "expenseentry.create";

        /// <summary>
        /// The expense entry updated
        /// </summary>
        public const string ExpenseEntryUpdated = "expenseentry.update";

        /// <summary>
        /// The expense entry deleted
        /// </summary>
        public const string ExpenseEntryDeleted = "expenseentry.delete";

        /// <summary>
        /// The invoice created
        /// </summary>
        public const string InvoiceCreated = "invoice.create";

        /// <summary>
        /// The invoice updated
        /// </summary>
        public const string InvoiceUpdated = "invoice.update";

        /// <summary>
        /// The invoice deleted
        /// </summary>
        public const string InvoiceDeleted = "invoice.delete";

        /// <summary>
        /// The invoice voided
        /// </summary>
        public const string InvoiceVoided = "invoice.void";

        /// <summary>
        /// The payment created
        /// </summary>
        public const string PaymentCreated = "payment.create";

        /// <summary>
        /// The payment updated
        /// </summary>
        public const string PaymentUpdated = "payment.update";

        /// <summary>
        /// The payment deleted
        /// </summary>
        public const string PaymentDeleted = "payment.delete";

        /// <summary>
        /// The payment voided
        /// </summary>
        public const string PaymentVoided = "payment.void";

        /// <summary>
        /// The project created
        /// </summary>
        public const string ProjectCreated = "project.create";

        /// <summary>
        /// The project updated
        /// </summary>
        public const string ProjectUpdated = "project.update";

        /// <summary>
        /// The project deleted
        /// </summary>
        public const string ProjectDeleted = "project.delete";

        /// <summary>
        /// The time entry created
        /// </summary>
        public const string TimeEntryCreated = "timeentry.create";

        /// <summary>
        /// The time entry updated
        /// </summary>
        public const string TimeEntryUpdated = "timeentry.update";

        /// <summary>
        /// The time entry deleted
        /// </summary>
        public const string TimeEntryDeleted = "timeentry.delete";

        /// <summary>
        /// The vendor created
        /// </summary>
        public const string VendorCreated = "vendor.create";

        /// <summary>
        /// The vendor updated
        /// </summary>
        public const string VendorUpdated = "vendor.update";

        /// <summary>
        /// The vendor deleted
        /// </summary>
        public const string VendorDeleted = "vendor.delete";

    }

}
