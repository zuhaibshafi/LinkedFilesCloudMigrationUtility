
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;


namespace LinkedFilesCloudMigrationUtility.Models
{


    /// <summary>
    /// Enum ModuleNames
    /// </summary>
    /// Enum ModuleNames
    /*public enum ModuleNames
    {

        /// <summary>
        /// The main
        /// </summary>
        None = 0,
        /// <summary>
        /// The activity
        /// </summary>
        [Description("Activity")]
        [ModuleEnum(CustomLabels, Audit, DefaultScreen)]
        Activity = 1,
        /// <summary>
        /// The billing schedule
        /// </summary>
        [Description("Billing Schedule")]
        [ModuleEnum(Audit)]
        BillingSchedule = 2,
        /// <summary>
        /// The archive restore
        /// </summary>
        [Description("Archive Restore")]
        ArchiveRestore = 3,
        /// <summary>
        /// The billing review
        /// </summary>
        [Description("Billing Functions")]
        [ModuleEnum(Audit)]
        BillingReview = 4,
        /// <summary>
        /// The budget
        /// </summary>
        [Description("Budget")]
        [ModuleEnum(Dashboard, Audit, CustomLabels, DefaultScreen, WorkFlow)]
        Budget = 5,
        /// <summary>
        /// The client
        /// </summary>
        [Description("Client")]
        [ModuleEnum(CustomLabels, Note, ToDoTask, DocumentManagement, Audit, DefaultScreen, ReportBuilder)]
        Client = 6,
        /// <summary>
        /// The company
        /// </summary>
        [Description("Company Profile")]
        [ModuleEnum(CustomLabels, Audit)]
        Company = 7,
        /// <summary>
        /// The time entry
        /// </summary>
        [Description("Time Entry")]
        [ModuleEnum(CustomLabels, Dashboard, Audit, DefaultScreen, WorkFlow)]
        TimeEntry = 8,
        /// <summary>
        /// The employee
        /// </summary>
        [Description("Employee")]
        [ModuleEnum(CustomLabels, Note, ToDoTask, DocumentManagement, Audit, DefaultScreen, ReportBuilder)]
        Employee = 9,
        /// <summary>
        /// The expense log
        /// </summary>
        [Description("Expense Entry")]
        [ModuleEnum(CustomLabels, Dashboard, Audit, DefaultScreen, WorkFlow)]
        ExpenseLog = 10,
        /// <summary>
        /// The fee schedule
        /// </summary>
        [Description("Fee Schedule")]
        [ModuleEnum(Audit, DefaultScreen)]
        FeeSchedule = 11,
        /// <summary>
        /// The fee schedule exp
        /// </summary>
        [Description("Expense Fee Schedule")]
        [ModuleEnum(Audit)]
        FeeScheduleExp = 12,
        /// <summary>
        /// The invoice review
        /// </summary>
        [Description("Invoices")]
        [ModuleEnum(Dashboard, Audit, ToDoTask, Note, CustomLabels, DefaultScreen, WorkFlow)]
        InvoiceReview = 13,
        /// <summary>
        /// The payment
        /// </summary>
        [Description("Payment")]
        [ModuleEnum(Audit, DefaultScreen, CustomLabels)]
        Payment = 14,
        /// <summary>
        /// The preferences
        /// </summary>
        [Description("User Preferences")]
        [ModuleEnum(Audit)]
        Preference = 15,
        /// <summary>
        /// The project
        /// </summary>
        [Description("Project")]
        [ModuleEnum(CustomLabels, Note, ToDoTask, DocumentManagement, Dashboard, Audit, DefaultScreen, ReportBuilder)]
        Project = 16,
        /// <summary>
        /// The standard reports menu
        /// </summary>
        [Description("Standard Reports")]
        StandardReportsMenu = 17,
        /// <summary>
        /// The custom reports menu
        /// </summary>
        [Description("Custom Reports")]
        CustomReportsMenu = 18,
        /// <summary>
        /// The reports
        /// </summary>
        [Description("Reports")]
        [ModuleEnum(Audit)]
        Reports = 19,
        /// <summary>
        /// The settings
        /// </summary>
        [Description("Settings")]
        Settings = 20,
        /// <summary>
        /// The expense code
        /// </summary>
        [Description("Expense")]
        [ModuleEnum(CustomLabels, Audit, DefaultScreen)]
        Expense = 21,
        /// <summary>
        /// The utilities
        /// </summary>
        [Description("Utilities")]
        Utilities = 22,
        /// <summary>
        /// The timer
        /// </summary>
        [Description("Timer")]
        [ModuleEnum(Audit, DefaultScreen)]
        Timer = 23,
        /// <summary>
        /// The import
        /// </summary>
        [Description("Import")]
        Import = 24,
        /// <summary>
        /// The export
        /// </summary>
        [Description("Export")]
        Export = 25,
        /// <summary>
        /// The reminder
        /// </summary>
        [Description("Reminder")]
        [ModuleEnum(Audit)]
        Reminder = 26,
        /// <summary>
        /// The search
        /// </summary>
        [Description("Find")]
        Search = 27,
        /// <summary>
        /// The security
        /// </summary>
        [Description("Security")]
        [ModuleEnum(Audit, DefaultScreen)]
        Security = 28,
        /// <summary>
        /// The vendor
        /// </summary>
        [Description("Vendor")]
        [ModuleEnum(CustomLabels, Note, ToDoTask, DocumentManagement, Audit, DefaultScreen)]
        Vendor = 29,
        /// <summary>
        /// The custom labels
        /// </summary>
        [Description("Custom Labels")]
        [ModuleEnum(Audit)]
        CustomLabels = 30,
        /// <summary>
        /// The project control
        /// </summary>
        [Description("Project Assignment")]
        [ModuleEnum(DefaultScreen)]
        ProjectControl = 31,
        /// <summary>
        /// The quick books
        /// </summary>
        [Description("Quick Books")]
        QuickBooks = 32,
        /// <summary>
        /// The estimate
        /// </summary>
        [Description("Estimate")]
        [ModuleEnum(Dashboard, Audit, CustomLabels, DefaultScreen)]
        Estimate = 33,
        /// <summary>
        /// The document management
        /// </summary>
        [Description("Document Management")]
        [ModuleEnum(Audit)]
        DocumentManagement = 34,
        /// <summary>
        /// The log viewer
        /// </summary>
        [Description("Log Viewer")]
        LogViewer = 35,
        /// <summary>
        /// The currency multiplier
        /// </summary>
        [Description("Currency Manager")]
        CurrencyMultiplier = 36,
        /// <summary>
        /// The message
        /// </summary>
        [Description("Message")]
        [ModuleEnum(Audit)]
        Message = 37,
        ///// <summary>
        ///// The terms
        ///// </summary>
        //[StringValue("Terms")]
        //Terms = 38,
        /// <summary>
        /// The terms Table
        /// </summary>
        [Description("Terms Table")]
        [ModuleEnum(Audit)]
        Terms = 38,
        /// <summary>
        /// The retainer history
        /// </summary>
        [Description("Retainers")]
        [ModuleEnum(Audit, DefaultScreen, InvoiceReview)]
        Retainer = 39,
        /// <summary>
        /// The automatic complete
        /// </summary>
        [Description("Auto Complete")]
        [ModuleEnum(DefaultScreen)]
        AutoComplete = 40,
        /// <summary>
        /// The credit memo
        /// </summary>
        [Description("Credit Memo")]
        [ModuleEnum(Audit, DefaultScreen, CustomLabels)]
        CreditMemo = 41,
        /// <summary>
        /// The project journal
        /// </summary>
        [Description("Notes")]
        [ModuleEnum(Audit, DefaultScreen)]
        Note = 42,
        /// <summary>
        /// The navigator
        /// </summary>
        [Description("Navigator")]
        Navigator = 43,
        /// <summary>
        /// The purchase order
        /// </summary>
        [Description("Purchase Order")]
        [ModuleEnum(Dashboard, Audit, DefaultScreen, CustomLabels, DocumentManagement, WorkFlow)]
        PurchaseOrder = 44,
        /// <summary>
        /// The chart of accounts
        /// </summary>
        [ModuleEnum(Audit, DefaultScreen, CustomLabels)]
        [Description("Chart Of Accounts")]
        ChartOfAccounts = 45,
        /// <summary>
        /// The vendor bill
        /// </summary>
        [Description("Vendor Bill")]
        [ModuleEnum(Dashboard, Audit, DefaultScreen, CustomLabels, DocumentManagement, WorkFlow)]
        VendorBill = 46,
        /// <summary>
        /// The dashboard
        /// </summary>
        [Description("Dashboard")]
        Dashboard = 47,
        /// <summary>
        /// The project journal category
        /// </summary>
        [Description("Project Journal Category")]
        ProjectNoteCategory = 48,
        /// <summary>
        /// The personal time off
        /// </summary>
        [Description("Personal Time Off")]
        [ModuleEnum(Dashboard, Audit, DefaultScreen, WorkFlow)]
        PTO = 49,
        /// <summary>
        /// The reviewer
        /// </summary>
        [Description("Reviewer")]
        [ModuleEnum(Audit, DefaultScreen)]
        Reviewer = 50,

        /// <summary>
        /// The assign
        /// </summary>
        [Description("Assign")]
        Assign = 52,
        /// <summary>
        /// The recurring schedule
        /// </summary>
        [Description("Recurring Schedule")]
        [ModuleEnum(Audit)]
        RecurringSchedule = 53,
        /// <summary>
        /// The allocate hours units
        /// </summary>
        [Description("Allocation and Forecasting")]
        [ModuleEnum(Audit, DefaultScreen)]
        Allocate = 54,
        /// <summary>
        /// To do tasks
        /// </summary>
        [Description("To Do")]
        [ModuleEnum(DefaultScreen)]
        ToDoTask = 55,
        /// <summary>
        /// The work flow
        /// </summary>
        [Description("WorkFlow")]
        [ModuleEnum(Audit)]
        WorkFlow = 56,
        /// <summary>
        /// The deposit
        /// </summary>
        [Description("Deposit")]
        [ModuleEnum(Audit, DefaultScreen, CustomLabels, DocumentManagement)]
        Deposit = 57,
        /// <summary>
        /// The pay vendor bills
        /// </summary>
        [Description("Bill Payment")]
        [ModuleEnum(Audit, DefaultScreen)]
        BillPayment = 58,
        /// <summary>
        /// The check
        /// </summary>
        [Description("Checks")]
        [ModuleEnum(Audit, DefaultScreen, DocumentManagement, CustomLabels)]
        Check = 59,
        /// <summary>
        /// The fund transfer
        /// </summary>
        [Description("Fund Transfer")]
        [ModuleEnum(Audit, DefaultScreen, CustomLabels)]
        FundTransfer = 60,
        /// <summary>
        /// The general journal
        /// </summary>
        [Description("General Journal")]
        [ModuleEnum(Audit, DefaultScreen, CustomLabels, DocumentManagement)]
        GeneralJournal = 61,
        /// <summary>
        /// The accounts payable
        /// </summary>
        [Description("Accounts Payable")]
        AccountsPayable = 62,
        /// <summary>
        /// The accounts receivable
        /// </summary>
        [Description("Accounts Receivable")]
        AccountsReceivable = 63,
        /// <summary>
        /// The account journal
        /// </summary>
        [Description("Account Journal")]
        AccountJournal = 64,
        /// <summary>
        /// The bank account journal
        /// </summary>
        [Description("Bank Account Journal")]
        BankAccountJournal = 65,
        /// <summary>
        /// The credit card
        /// </summary>
        [Description("Credit Card")]
        [ModuleEnum(DefaultScreen, DocumentManagement, CustomLabels, DocumentManagement)]
        CreditCardTransaction = 66,
        /// <summary>
        /// The credit card payment
        /// </summary>
        [Description("Credit Card Payment")]
        CreditCardPayment = 67,
        /// <summary>
        /// The bill credit
        /// </summary>
        [Description("Bill Credit")]
        BillCredit = 68,
        /// <summary>
        /// A p_ print checks
        /// </summary>
        [Description("Print Checks")]
        AP_PrintChecks = 69,
        /// <summary>
        /// The reconcile
        /// </summary>
        [Description("Account Reconciliation")]
        [ModuleEnum(Audit)]
        AccountReconciliation = 70,
        /// <summary>
        /// The project center
        /// </summary>
        [Description("Project Center")]
        ProjectCenter = 71,
        /// <summary>
        /// The collections
        /// </summary>
        [Description("Collection Center")]
        [ModuleEnum(DefaultScreen)]
        Collections = 72,
        /// <summary>
        /// The recalculate overtime
        /// </summary>
        [Description("Recalculate Overtime")]
        RecalculateOvertime = 73,
        /// <summary>
        /// The employee group
        /// </summary>
        [Description("Employee Group")]

        EmployeeGroup = 74,         //TODO EmployeeGroup is not actually present in Security table
        /// <summary>
        /// The employee group detail
        /// </summary>
        [Description("Employee Group Detail")]
        EmployeeGroupDetail = 75,   //TODO EmployeeGroup is not actually present in Security table
        /// <summary>
        /// The client contact
        /// </summary>
        [Description("Contact")]
        [ModuleEnum(Audit)]
        Contact = 76,         //TODO ClientContact is not actually present in Security table
        /// <summary>
        /// The employee control
        /// </summary>
        [Description("Employee Control")]
        [ModuleEnum(DefaultScreen)]
        EmployeeControl = 77,

        /// <summary>
        /// The manual invoice
        /// </summary>
        [Description("Manual Invoice")]
        ManualInvoice = 78,       //TODO Manual Invoice is not actually present in Security Table.
        /// <summary>
        /// The custom list
        /// </summary>
        [Description("Custom List")]
        CustomList = 79,
        /// <summary>
        /// The group details
        /// </summary>
        [Description("Group Details")]
        [ModuleEnum(DefaultScreen)]
        Group = 80,

        /// <summary>
        /// The account pool list
        /// </summary>
        [Description("Account Pool List")]
        CostPoolList = 81,
        /// <summary>
        /// The vendor credit
        /// </summary>
        [Description("Vendor Credit")]
        [ModuleEnum(Audit, DefaultScreen, CustomLabels)]
        VendorCredit = 82,

        LinkedFiles = 83,

        AccountsPayableRegistryJournal = 84,

        AccountsReceivableRegistryJournal = 85,

        AccountRegistryJournal = 86,

        /// <summary>
        /// The Agent
        /// </summary>
        Agent = 87,
        /// <summary>
        /// The ReportSchedule
        /// </summary>
        ReportSchedule = 88,
        /// <summary>
        /// The EmailTracking
        /// </summary>
        EmailTracking = 89,
        /// <summary>
        /// The ExpenseMonitor
        /// </summary>
        ExpenseMonitor = 90,

        /// <summary>
        /// The ReportGroup
        /// </summary>
        ReportScheduleDetail = 91,

        /// <summary>
        /// The AlertBaseTable
        /// </summary>
        AlertBaseTable = 92,

        /// <summary>
        /// The AlertDetails
        /// </summary>
        AlertDetails = 93,

        /// <summary>
        /// The Attachments
        /// </summary>
        Attachments = 94,

        /// <summary>
        /// The EnterCredit
        /// </summary>
        EnterCredit = 95,

        /// <summary>
        /// The GlobalSettings
        /// </summary>
        GlobalSettings = 96,

        /// <summary>
        /// The Integration
        /// </summary>
        Integration = 97,

        /// <summary>
        /// The MakeDeposits
        /// </summary>
        MakeDeposits = 98,

        /// <summary>
        /// The OvertimeCalculator
        /// </summary>
        OTCalculator = 99,

        /// <summary>
        /// The OvertimeCalculator
        /// </summary>
        Report = 100,

        /// <summary>
        /// The BudgetActivity
        /// </summary>
        BudgetActivity = 101,

        /// <summary>
        /// The BudgetExpense
        /// </summary>
        BudgetExpense = 102,

        /// <summary>
        /// The BillingScheduleDetail
        /// </summary>
        BillingScheduleDetail = 103,

        /// <summary>
        /// The ReviewSection
        /// </summary>
        ReviewSection = 104,

        /// <summary>
        /// The Benefit
        /// </summary>
        Benefit = 105,

        /// <summary>
        /// The Benefit
        /// </summary>
        NoteStatus = 106,

        /// <summary>
        /// The JournalType
        /// </summary>
        NoteCategory = 107,

        /// <summary>
        /// The EmployeePayroll
        /// </summary>
        EmployeePayroll = 108,

        /// <summary>
        /// The EmployeeReview
        /// </summary>
        EmployeeReview = 109,


        /// <summary>
        /// The EmployeeIncident
        /// </summary>
        EmployeeIncident = 110,

        /// <summary>
        /// The EmployeeSalaryHistory
        /// </summary>
        EmployeeSalaryHistory = 111,

        /// <summary>
        /// The EmployeeBenefit
        /// </summary>
        EmployeeBenefit = 112,

        /// <summary>
        /// The BenefitUsage
        /// </summary>
        EmployeeBenefitUsage = 113,

        /// <summary>
        /// The EmployeeTermination
        /// </summary>
        EmployeeTermination = 114,
        NotApplicable = 115,
        /// <summary>
        /// The EmployeeTermination
        /// </summary>
        Drawing = 116,
        /// <summary>
        /// The EmployeeTermination
        /// </summary>
        RFI = 117,
        /// <summary>
        /// The EmployeeTermination
        /// </summary>
        Submittal = 118,

        /// <summary>
        /// The EmployeeTermination
        /// </summary>
        ValueLists = 120,

        /// <summary>
        /// The EmployeeTermination
        /// </summary>

        /// <summary>
        /// The SkillTable
        /// </summary>
        SkillTable = 123,
        /// <summary>
        /// The SkillAssignment
        /// </summary>
        SkillAssignment = 124,
        /// <summary>
        /// The Event
        /// </summary>
        Event = 125,
        /// <summary>
        /// The MemorizeReports
        /// </summary>
        MemorizeReports = 126,
        /// <summary>
        /// The EventAttendee
        /// </summary>
        [Description("EventAttendee")]
        EventAttendee = 127,
        /// <summary>
        /// The EventType
        /// </summary>
        [Description("EventType")]
        EventType = 128,
        /// <summary>
        /// the CustomField
        /// </summary>
        [Description("CustomField")]
        CustomField = 129,
        /// <summary>
        /// 
        /// </summary>
        [Description("ModelCustomField")]
        ModelCustomField = 130,
        /// <summary>
        /// 
        /// </summary>
        [Description("EntityCustomField")]
        EntityCustomField = 131,
        /// <summary>
        /// 
        /// </summary>
        [Description("ThirdPartySetting")]
        ThirdPartySetting = 132,
        /// <summary>
        /// 
        /// </summary>
        [Description("ClassList")]

        ClassList = 133,
        /// <summary>
        /// 
        /// </summary>
        [Description("ColumnChooser")]
        ColumnChooser = 134,
        /// <summary>
        /// 
        /// </summary>
        [Description(" ColumnChooserDetail")]
        ColumnChooserDetail = 135,
        /// <summary>
        /// 
        /// </summary>
        [Description(" Vendor Group")]

        VendorGroup = 136,
        /// <summary>
        /// 
        /// </summary>
        [Description("Client Group")]

        ClientGroup = 137,
        /// <summary>
        /// 
        /// </summary>
        [Description("Project Group")]

        ProjectGroup = 138,
        /// <summary>
        /// 
        /// </summary>
        [Description("Activity Group")]
        ActivityGroup = 139,
        /// <summary>
        /// 
        /// </summary>
        [Description("Expense Group")]
        ExpenseGroup = 140,
        /// <summary>
        /// 
        /// </summary>
        [Description("Communication Type")]
        CommunicationTypes = 141,
        /// <summary>
        /// 
        /// </summary>
        [Description("Contact Group")]
        ContactGroup = 142,
        /// <summary>
        /// 
        /// </summary>
        [Description("General")]
        [ModuleEnum(ModuleNames.EmailTemplate)]
        General = 143,
        /// <summary>
        /// 
        /// </summary>
        [Description("EventRecurrencePattern")]
        EventRecurrencePattern = 144,
        SubmittalStatusHistory = 145,


        /// <summary>
        /// ProjectTemplate   
        /// </summary>
        [ModuleEnum(ToDoTask)]
        [Description("Project Template")]
        ProjectTemplate = 146,

        /// <summary>
        /// MonitorProfile
        /// </summary>
        [Description("MonitorProfile")]
        MonitorProfile = 147,

        [Description("Cloud Feed")]
        [ModuleEnum(DefaultScreen)]
        BankFeed = 148,

        [Description("Client Contact")]
        ClientContact = 149,

        [Description("Client Notes")]
        ClientNotes = 150,

        [Description("Client ToDo")]
        ClientToDos = 151,

        [Description("Employee Contact")]
        EmployeeContact = 152,


        [Description("Employee Notes")]
        EmployeeNotes = 153,

        [Description("Employee ToDo")]
        EmployeeToDo = 154,

        [Description("Project Notes")]
        ProjectNotes = 155,

        [Description("Project ToDo")]
        ProjectToDo = 156,

        [Description("Vendor Contact")]
        VendorContact = 157,


        [Description("Vendor Notes")]
        VendorNotes = 158,

        [Description("Vendor ToDo")]
        VendorToDo = 159,

        [Description("Employee Documents")]
        EmployeeDocuments = 160,

        [Description("Vendor Documents")]
        VendorDocuments = 161,

        [Description("Project Documents")]
        ProjectDocuments = 162,

        [Description("Client Documents")]
        ClientDocuments = 163,

        [Description("Time Card")]
        [ModuleEnum(Audit, DefaultScreen)]
        STC = 164,

        [Description("Statements")]
        [ModuleEnum(Audit, DefaultScreen)]
        Statement = 165,

        [Description("Estimate Expense")]
        [ModuleEnum(CustomField)]
        EstimateExpense = 166,
        /// <summary>
        /// The recurring checks
        /// </summary>
        [Description("Recurring Check")]
        [ModuleEnum(Audit, DefaultScreen)]
        RecurringCheck = 167,
        /// <summary>
        /// The recurring Bills
        /// </summary>
        [Description("Recurring Bills")]
        [ModuleEnum(Audit, DefaultScreen)]
        RecurringBill = 168,
        /// <summary>
        /// Account
        /// </summary>
        [Description("Account")]
        Account = 169,

        /// <summary>
        /// Account
        /// </summary>
        [Description("Account")]
        ReceiveItems = 170,

        /// <summary>
        /// Visit
        /// </summary>
        [Description("Visit")]
        Visit = 171,

        /// <summary>
        /// Favourite
        /// </summary>
        [Description("Favourite")]
        Favourite = 172,

        /// <summary>
        /// Recurring Invoices
        /// </summary>
        [Description("Recurring Invoices")]
        [ModuleEnum(Audit, DefaultScreen)]
        RecurringInvoice = 173,

        [Description("Activity Documents")]
        ActivityDocuments = 174,

        [Description("Expense Documents")]
        ExpenseDocuments = 175,

        [Description("TimeEntry Documents")]
        TimeEntryDocuments = 176,

        [Description("ExpenseEntry Documents")]
        ExpenseLogDocuments = 177,

        [Description("Personal Time Off Documents")]
        PTODocuments = 178,

        [Description("VendorBills Documents")]
        VendorBillsDocuments = 179,

        [Description("Payment Documents")]
        PaymentDocuments = 180,

        [Description("PurchaseOrder Documents")]
        PurchaseOrderDocuments = 181,


        [Description("Quick Report")]
        AccountQuickReport = 182,

        [Description("Quick Report Cash")]
        AccountQuickReportCash = 183,

        UndepositAccountRegister = 184,

        MSTAccountRegister = 185,
        METAccountRegister = 186,
        ServiceTaxRegister = 187,
        ExpenseTaxRegister = 188,
        PayrollRegister = 189,
        OpeningBalanceRegister = 190,
        RetainerRegister = 191,
        LegacyPaymentRegister = 192,
        Forcasting = 193,
        FeedRule = 194,
        FeedRuleSpent = 195,
        FeedRuleReceived = 196,
        ListWidgets = 197,
        GraphWidgets = 198,
        FutureTimePeriods = 199,
        /// <summary>
        /// The EmployeeReviewDetail
        /// </summary>
        [Description("Employee Review Detail")]
        EmployeeReviewDetail = 200,
        Image = 201,
        InvoiceTemplate = 202,
        /// <summary>
        /// Audit Trail
        /// </summary>
        [Description("Audit Trail")]
        Audit = 203,
        /// <summary>
        /// Manager Subscriptions
        /// </summary>
        [Description("Manage Subscriptions")]
        ManageSubscriptions = 204,
        /// <summary>
        /// Manager Users
        /// </summary>
        [Description("Manage Users")]
        ManageUsers = 205,
        /// <summary>
        /// Manage Companies
        /// </summary>
        [Description("Manage Companies")]
        [ModuleEnum(DefaultScreen)]
        ManageCompanies = 206,

        /// <summary>
        /// The EstimateActivity
        /// </summary>
        [Description("Estimate Activity")]
        [ModuleEnum(CustomField)]
        EstimateActivity = 207,
        /// <summary>
        /// Task Allocation-Project
        /// </summary>
        [Description("Task Allocation Project")]
        TaskAllocationProject = 208,

        /// <summary>
        /// Task Allocation-Employee
        /// </summary>
        [Description("Task Allocation Employee")]
        TaskAllocationEmployee = 209,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Distributive Employee Monthly")]
        DistributiveEmployeeMonthly = 210,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Distributive Employee Weekly")]
        DistributiveEmployeeWeekly = 211,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Distributive Project Monthly")]
        DistributiveProjectMonthly = 212,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Distributive Project Weekly")]
        DistributiveProjectWeekly = 213,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Smart Employee Monthly")]
        SmartEmployeeMonthly = 214,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Smart Employee Weekly")]
        SmartEmployeeWeekly = 215,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Smart Project Monthly")]
        SmartProjectMonthly = 216,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("Smart Project Weekly")]
        SmartProjectWeekly = 217,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("StartWeek Employee Monthly")]
        StartWeekEmployeeMonthly = 218,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("StartWeek Employee Weekly")]
        StartWeekEmployeeWeekly = 219,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("StartWeek Project Monthly")]
        StartWeekProjectMonthly = 220,


        /// <summary>
        /// Forcasting Allocation-Employee
        /// </summary>
        [Description("StartWeek Project Weekly")]
        StartWeekProjectWeekly = 221,


        /// <summary>
        /// Address
        /// </summary>
        [Description("Address")]
        Address = 222,

        /// <summary>
        /// Item Activity/Expense
        /// </summary>
        [Description("Item")]
        Item = 223,

        /// <summary>
        /// Item Notification
        /// </summary>
        [Description("Notification")]
        Notification = 224,

        /// <summary>
        /// Performance Filters
        /// </summary>
        [Description("Performance")]
        Performance = 225,


        /// <summary>
        /// Reimbursable Expense
        /// </summary>
        [Description("Reimbursable")]
        Reimbursable = 226,


        /// <summary>
        /// Reimbursable Expense
        /// </summary>
        [Description("RetainedEarning")]
        RetainedEarning = 227,
        /// <summary>
        /// Used to handle subscription of module register
        /// </summary>
        [ModuleEnum(DefaultScreen)]
        Register = 228,
        /// <summary>
        /// used to handle subscription of module bankfeed
        /// </summary>
        ConnectedBank = 229,
        ActivityExpenseGroup = 230,
        FinancialReports = 231,
        TimeEntryDetail = 232,
        ExpenseEntryDetail = 233,
        ManualInvoiceTimeDetail = 234,
        ManualInvoiceExpenseDetail = 235,
        FeedRuleAmount = 236,
        [Description("Employee Manager")]
        EmployeeManager = 237,
        [Description("Forecasting")]
        Forecasting = 238,
        Ledes = 239,
        [Description("Gantt Chart")]
        GanttChart = 240,
        IntegrationSchedule = 241,
        DepositClientLineItems = 242,
        [Description("HR Forms")]
        [ModuleEnum(DefaultScreen)]
        HrForm = 243,
        [Description("Review Template")]
        ReviewTemplate = 244,
        [Description("Question")]
        Question = 245,
        [Description("Question Type")]
        QuestionType = 246,
        [Description("Response")]
        Response = 247,

        [Description("Lead")]
        [ModuleEnum(ModuleNames.EmailTemplate, ToDoTask, FollowUp, ModuleNames.CustomLabels, Note, DefaultScreen)]
        CrmLead = 248,
        [Description("Prospect")]
        [ModuleEnum(ModuleNames.EmailTemplate, ModuleNames.ToDoTask, FollowUp, ModuleNames.CustomLabels, Note, DefaultScreen)]
        Prospect = 249,
        [Description("Prospect Group")]
        ProspectGroup = 250,
        [Description("Opportunity")]
        [ModuleEnum(FollowUp, ToDoTask, Note, DefaultScreen, CustomLabels)]
        Opportunity = 251,
        [Description("Industry")]
        CrmIndustry = 252,
        [Description("Lead Source")]
        LeadSource = 253,
        [Description("Region")]
        Region = 254,
        [Description("Campaign Type")]
        CampaignType = 255,
        [Description("Proposal")]
        [ModuleEnum(ModuleNames.EmailTemplate, Note, DefaultScreen, FollowUp, ToDoTask, WorkFlow)]
        Proposal = 256,
        [Description("Proposal Template")]
        ProposalTemplate = 257,
        [Description("Commission Profile")]
        [ModuleEnum(DefaultScreen)]
        CommissionProfile = 258,
        [Description("CommissionProfile Template")]
        CommissionProfileDetail = 259,
        [Description("Email Template")]
        EmailTemplate = 260,
        [Description("Campaign Status")]
        CampaignStatus = 261,
        [Description("Commission Type")]
        CommissionType = 262,
        [Description("Competition")]
        Competition = 263,
        [Description("Opportunity Stage")]
        OpportunityStage = 264,
        [Description("Priority")]
        Priority = 265,
        [Description("Campaign")]
        [ModuleEnum(ModuleNames.EmailTemplate, ModuleNames.ToDoTask, FollowUp, ModuleNames.CustomLabels, Note, DefaultScreen, WorkFlow)]
        Campaign = 266,
        [Description("Campaign Recipient")]
        CampaignRecipient = 267,
        [Description("Promotion")]
        [ModuleEnum(DefaultScreen)]
        Promotion = 268,
        [Description("Promotion Detail")]
        PromotionDetail = 269,
        [Description("Opportunity Type")]
        OpportunityType = 270,
        [Description("Source")]
        Source = 271,
        [Description("Sales Goal")]
        [ModuleEnum(FollowUp, DefaultScreen)]
        SalesGoal = 272,
        [Description("Sales Goal Detail")]
        SalesGoalDetail = 273,
        [Description("Reseller")]

        Reseller = 274,
        [Description("CrmStatus")]
        CrmStatus = 275,
        /// <summary>
        /// The EmployeeBenefitUsage Documents
        /// </summary>
        [Description("Benefit Usage")]
        EmployeeBenefitUsageDocuments = 276,
        [Description("Salary History Documents")]
        EmployeeSalaryHistoryDocuments = 277,
        [Description("Incident Types")]
        IncidentType = 278,

        [Description("Journal")]
        Journal = 279,

        [Description("Journal Type")]
        JournalType = 280,
        [Description("Journal Status")]
        JournalStatus = 281,
        [Description("ToDo Type")]
        ToDoType = 282,
        [Description("Lead Group")]
        LeadGroup = 283,
        [Description("Fee Schedule Documents")]
        FeeScheduleDocuments = 284,
        [Description("Tags")]
        Tags = 285,
        [Description("Budget Documents")]
        BudgetDocuments = 286,
        [Description("Estimate Documents")]
        EstimateDocuments = 287,
        [Description("Employee Review Documents")]
        EmployeeReviewDocuments = 288,
        [Description("Message Documents")]
        MessageDocuments = 289,
        [Description("Resources")]
        Resources = 290,
        [Description("Opportunity Group")]
        OpportunityGroup = 291,
        [Description("Xero")]
        Xero = 292,
        [Description("AccountRight")]
        AccountRight = 293,
        [Description("Employee Incident Documents")]
        EmployeeIncidentDocuments = 294,
        [Description("Employee Journal Documents")]
        EmployeeJournalDocuments = 295,
        [Description("BillPaymentDetails")]
        BillPaymentDetails = 296,
        [Description("Agency")]
        [ModuleEnum(Note, ToDoTask)]
        [AllowedPackages(PackageEnum.PayrollBeta)]
        Agency = 297,
        [Description("Workers Compensation")]
        CompensationCode = 298,
        [Description("WorkPosition")]
        WorkPosition = 299,
        [Description("Withholding")]
        Withholding = 300,
        [Description("Lead Campaign")]
        LeadCampaign = 301,
        [Description("Prospect Campaign")]
        ProspectCampaign = 302,
        [Description("Quote")]
        [ModuleEnum(FollowUp, Note, ToDoTask, WorkFlow, DefaultScreen)]
        Quote = 303,
        [Description("Payment Category")]
        PaymentCategory = 304,
        [Description("Employee Bank Information")]
        EmployeeBankInfo = 305,
        [Description("Employee Dependent")]
        EmployeeDependent = 306,
        [Description("Employee Recurring")]
        EmployeeRecurringPayment = 307,
        [Description("Employee Tax")]
        EmployeeTax = 308,
        [Description("Employee Withholding")]
        EmployeeWithholding = 309,
        [Description("Pay Item")]
        PayCode = 310,
        [Description("Balance Sheet Widget")]
        BalanceSheetWidget = 311,
        [Description("Profit And Loss Widget")]
        ProfitAndLossWidget = 312,
        [Description("Account Reconciliation Widget")]
        AccountReconciliationWidget = 313,
        [Description("EmployeePosition")]
        EmployeePosition = 314,
        [Description("Activity Fee Schedule")]
        FeeScheduleActivity = 315,
        [Description("PurchaseOrder Transaction")]
        PurchaseOrderTransaction = 316,
        [Description("Find Match Transaction")]
        BankFeedMatchedTransaction = 317,
        [Description("Event Documents")]
        EventDocuments = 318,
        [Description("Invoice Documents")]
        InvoiceDocuments = 319,
        [Description("RFI Documents")]
        RFIDocuments = 320,
        [Description("Submittal Documents")]
        SubmittalDocuments = 321,
        [Description("ToDoTask Documents")]
        ToDoTaskDocuments = 322,
        [Description("Invoice Review Documents")]
        InvoiceReviewDocuments = 323,
        [Description("Payroll Tax")]
        PayrollTaxCode = 324,
        [Description("PayrollEmployerTaxCode")]
        PayrollEmployerTaxCode = 325,
        [Description("WithholdingCategory")]
        WithholdingCategory = 326,
        [Description("PayrollCycle")]
        PayrollCycle = 327,
        [Description("PayrollTimeExpense")]
        PayrollTimeExpense = 328,
        [Description("Payroll Tax Type")]
        PayrollTaxtype = 329,
        [Description("Device Info")]
        DeviceInfo = 330,
        [Description("Drawing Documents")]
        DrawingDocuments = 331,
        [Description("Note Documents")]
        NoteDocuments = 332,
        [Description("Incidents")]
        Incidents = 333,
        [Description("Employee Journal")]
        EmployeeJournals = 334,
        [Description("Hr Information")]
        HrInformation = 335,
        [Description("DropDown Filter")]
        DropDown = 336,
        [Description("Screen Filter")]
        ScreenFilter = 337,
        [Description("PaymentService")]
        PaymentService = 338,
        [Description("Quote Activity")]
        [ModuleEnum(CustomLabels)]
        QuoteActivity = 339,
        [Description("Quote Expense")]
        [ModuleEnum(CustomLabels)]
        QuoteExpense = 340,
        [Description("QuoteTemplate")]
        QuoteTemplate = 341,
        [Description("QuoteTemplate Activity")]
        QuoteTemplateActivity = 342,
        [Description("QuoteTemplate Expense")]
        QuoteTemplateExpense = 343,
        [Description("General Journal Documents")]
        GeneralJournalDocuments = 344,
        [Description("Deposit Documents")]
        DepositDocuments = 345,
        [Description("Employee Security")]
        EmployeeSecurity = 346,
        [Description("Vendor Security")]
        VendorSecurity = 347,
        DefaultScreen = 348,
        ProspectPerformanceWidget = 349,
        OpportunityPerformanceWidget = 350,
        [Description("Opportunity Documents")]
        OpportunityDocuments = 351,
        [Description("Campaign Documents")]
        CampaignDocuments = 352,
        [Description("Lead Documents")]
        LeadDocuments = 353,
        [Description("Prospect Documents")]
        ProspectDocuments = 354,
        [Description("Quote Documents")]
        QuoteDocuments = 355,
        [Description("ProsPect ToDo")]
        ProspectTODO = 356,
        [Description("Campaign ToDo")]
        CampaignTODO = 357,
        [Description("Quote Template Documents")]
        QuoteTemplateDocuments = 358,
        [Description("Resource Library")]
        ResourceLibrary = 359,
        [Description("Lead ToDo")]
        LeadTODO = 360,
        [Description("Email History")]
        EmailHistory = 361,
        [Description("Financial Budget")]
        FinancialBudget = 362,
        [Description("Follow Up")]
        [ModuleEnum(DefaultScreen, Note)]
        FollowUp = 363,
        [Description("Lead Notes")]
        LeadNotes = 364,
        [Description("Prospect Notes")]
        ProspectNotes = 365,
        [Description("Opportunity Notes")]
        OpportunityNotes = 366,
        [Description("Proposal Notes")]
        ProposalNotes = 367,
        [Description("Campaign Notes")]
        CampaignNotes = 368,
        [Description("Invoice Time Details")]
        InvoiceReviewTimeDetails = 369,
        [Description("Invoice Expense Details")]
        InvoiceReviewExpenseDetails = 370,
        [Description("Client Transactions")]
        ClientTransactions = 371,
        [Description("Deposit Detail")]
        DepositDetail = 372,
        [Description("Trust Fund Account Journal")]
        TrustFundAccountJournal = 373,
        [Description("Vendor Expense Entry Detail")]
        VendorExpenseEntryDetail = 374,
        [Description("Task Allocation Widget")]
        TaskAllocationWidget = 375,
        [Description("Payroll Employee")]
        PayrollEmployee = 376,
        [Description("Payroll Wages")]
        PayrollWages = 377,
        [Description("PayrollGroups")]
        PayrollGroups = 378,
        [Description("On Demand PayCheck")]
        OnDemandPayCheck = 379,
        [Description("Payroll Taxes")]
        PayrollTaxes = 380,
        [Description("Payroll Deduction")]
        PayrollDeduction = 381,
        [Description("Payroll")]
        [ModuleEnum(DefaultScreen, ToDoTask)]
        Payroll = 382,
        [Description("Opportunity TO Do")]
        OpportunityToDo = 383,
        [Description("Check Document")]
        CheckDocument = 384,
        [Description("Credit Card Transaction Document")]
        CreditCardTransactionDocument = 385,
        [Description("Agency ToDo")]
        AgencyToDo = 386,
        [Description("Agency Notes")]
        AgencyNotes = 387,
        [Description("Agency Documents")]
        AgencyDocuments = 388,
        [Description("Prospect Contact")]
        ProspectContact = 389,
        [Description("Score")]
        Score = 390,
        [Description("NoteType")]
        NoteType = 391,
        [Description("Quote Notes")]
        QuoteNotes = 392,
        [Description("Follow-up Notes")]
        FollowUpNotes = 393,
        [Description("Employee Postion Detail")]
        EmployeePositionDetail = 394,
        [Description("Proposal ToDo")]
        ProposalTODO = 395,
        [Description("Quote ToDo")]
        QuoteToDo = 396,
        [Description("Employee PayItems")]
        EmployeePayItems = 397,
        [Description("Agency Payable")]
        AgencyPayable = 398,
        [Description("Vendor Withholding")]
        VendorWithholding = 399,
        [Description("Fund Transfer Document")]
        FundTransferDocuments = 400,
        [Description("Chart of Accounts Document")]
        ChartOfAccountsDocuments = 401,

        [Description("CRM")]
        CRM = 402,
        [Description("Account Reconciliation Item")]
        AccountReconciliationItem = 403,
        [Description("Vendor Dependent")]
        VendorDependent = 404,

        [Description("Company Document")]
        CompanyDocument = 405,

        [Description("Retainer Transfer")]
        RetainerTransfer = 406,

        [Description("Vendor Credit Documents")]
        VendorCreditDocuments = 407,
        [Description("Agency Contact")]
        AgencyContact = 408,

        [Description("Credit Memo Documents")]
        CreditMemoDocuments = 409,

        [Description("Email Workflow Opearation ")]
        EmailWorkFlowOperation = 410,

        [Description("Project Control Activity")]
        ProjectControlActivity = 411,

        [Description("Project Control Expense")]
        ProjectControlExpense = 412,

        [Description("Project Control TeamMembers")]
        ProjectControlTeamMembers = 413,

        BackgroundTask = 414,
        [Description("Credit Memo Refund")]
        CreditMemoRefund = 415,
        [ModuleEnum(InvoiceReview)]
        [Description("Trust Fund Retainer")]
        TrustFundRetainer = 416,
        [Description("Project Structure Contract Analysis")]
        ProjectStructureContractAnalysis = 417,
        [Description("Project Structure Budget Comparison")]
        ProjectStructureBudgetComparison = 418,
        [Description("Reply Email")]
        ReplyEmail = 419,
        [Description("Forward Email")]
        ForwardEmail = 420,

        [Description("Sales Forecast")]
        [ModuleEnum(DefaultScreen)]
        SalesForecast = 421,

        SalesForecastDistributive = 422,

        SalesForecastSummarized = 423,

        [Description("Sales Forecast")]
        SalesForecast_Opportunity = 424,


        [Description("CSV Mapping")]
        CSVMapping = 425,

        [Description("Google")]
        Google = 426,

        /// <summary>
        /// The DocuSign
        /// </summary>
        [Description("DocuSign")]
        DocuSign = 427,

        [Description("Payroll Forms")]
        PayrollForms = 428,

        [Description("Business Activity Statement")]
        BusinessActivityStatement = 429,

        [Description("Employee Contact Notes")]
        EmployeeContactNotes = 430,

        [Description("Vendor Contact Notes")]
        VendorContactNotes = 431,

        [Description("Client Contact Notes")]
        ClientContactNotes = 432,

        [Description("Prospect Contact Notes")]
        ProspectContactNotes = 433,
        [Description("Time Performance Widget")]
        TimePerformanceWidget = 434,
        [Description("Vendor Tax")]
        VendorTax = 435,
        [Description("Vendor Bank Information")]
        VendorBankInfo = 436,
        [Description("Vendor Recurring Payment")]
        VendorRecurringPayment = 437,
        [Description("Vendor PayItems")]
        VendorPayItems = 438,
        [Description("Project Template ToDo")]
        ProjectTemplateToDo = 439,
        [Description("Agency Contact Notes")]
        AgencyContactNotes = 440,

        CloudFeedPending = 441,
        CloudFeedIncludedInCore = 442,
        CloudFeedIgnored = 443,
        [Description("Payroll ToDo")]
        PayrollToDo = 444,
        [Description("Invoice ToDo")]
        InvoiceToDo = 445,
        ReportBuilder = 446,
        TwoFactorAuthentication = 447,
        [Description("Time Entry and Expense Entry Documents")]
        TimeEntryAndExpenseEntryDocuments = 448,
        [Description("Time Entry, Expense Entry and Vendor Bills Documents")]
        TimeEntryExpenseEntryAndVendorBillDocuments = 449,
        [Description("Payment Line item Details")]
        PaymentLineitemDetails = 450,
        [Description("Proposal Documents")]
        ProposalDocuments = 451,
    }
    */
    /// <summary>
    /// Enum StorageMedium
    /// </summary>
    public enum ThirdPartySettings
    {

        None = 0,

        
        AWSS3 = 1,

        
        GoogleDrive = 2,

        
        Dropbox = 3,

        WebLink = 4,

        OneDrive = 5,

        QuickBooks = 6,

        Xero = 7,

        MYOB = 8,


        Yodlee = 9,

        Box = 10,

        /// <summary>
        /// stripe payment service
        /// </summary>
        StripeConnect = 11,

        
        OutlookCalendar = 12,

        AffiniPayConnect = 13,

        LawPayConnect = 14,

        ClientPayConnect = 15,

        CpaChargeConnect = 16,
        Google = 17,
        DocuSign = 18
    }

    public enum HTTPRequestVerb
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        GET = 1,

        /// <summary>
        /// 
        /// </summary>
        POST = 2,

        /// <summary>
        /// 
        /// </summary>
        PUT = 3,

        /// <summary>
        /// 
        /// </summary>
        DELETE = 4,
    }

    /// <summary>
    /// Enum BOState
    /// </summary>
    public enum BOState
    {
        /// <summary>
        /// An enum constant representing the new option.
        /// </summary>
        New = 0,
        /// <summary>
        /// An enum constant representing the old option.
        /// </summary>
        Old = 1,
        /// <summary>
        /// An enum constant representing the dirty option.
        /// </summary>
        Dirty = 2,
        /// <summary>
        /// An enum constant representing the deleted option.
        /// </summary>
        Deleted = 3,

        /// <summary>
        /// An enum constant representing the assigned option.
        /// </summary>
        Assigned,

        /// <summary>
        /// An enum constant representing the un assigned option.
        /// </summary>
        UnAssigned

    }

}