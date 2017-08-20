using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using CommonLibrary.BusinessObjects.Administration;

namespace DemoLibrary.BusinessObjects.Sales
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    [DefaultProperty("Name")]
    [ModelDefault("IsCloneable", "true")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Invoice : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Invoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            InvoiceDate = DateTime.Now;
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        int iD;
        [Key(AutoGenerate = true)]
        [ModelDefault("DisplayFormat", "0000000")]
        [VisibleInDetailView(true), VisibleInListView(true)]
        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                SetPropertyValue("ID", ref iD, value);
            }
        }

        [PersistentAlias("Concat([Customer], ' ', [ID], ' ', [InvoiceDate])")]
        [VisibleInListView(false), VisibleInDetailView(true)]
        public string Name
        {
            get
            {
                return (string)EvaluateAlias("Name");
            }
        }

        DateTime invoiceDate;
        [RuleRequiredField]
        public DateTime InvoiceDate
        {
            get
            {
                return invoiceDate;
            }
            set
            {
                SetPropertyValue("InvoiceDate", ref invoiceDate, value);
            }
        }

        Customer customer;
        [ImmediatePostData]
        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                SetPropertyValue("Customer", ref customer, value);
                if (!IsLoading && customer != null)
                {
                    Owner = Session.GetObjectByKey<Employee>(Customer.Owner.Oid);
                }
            }
        }

        Employee owner;
        public Employee Owner
        {
            get
            {
                return owner;
            }
            set
            {
                SetPropertyValue("Owner", ref owner, value);
            }
        }

        [PersistentAlias("SaleItems.Sum(Amount)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        public decimal DetailAmount
        {
            get
            {
                if (SaleItems.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return (decimal)EvaluateAlias("DetailAmount");
                }
            }
        }

        decimal discountAmount;
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        public decimal DiscountAmount
        {
            get
            {
                return discountAmount;
            }
            set
            {
                SetPropertyValue("DiscountAmount", ref discountAmount, value);
            }
        }

        decimal discountPercent;
        [ModelDefault("DisplayFormat", "{0:n2}%")]
        [ModelDefault("EditMask", "n2")]
        public decimal DiscountPercent
        {
            get
            {
                return discountPercent;
            }
            set
            {
                SetPropertyValue("DiscountPercent", ref discountPercent, value);
            }
        }

        [PersistentAlias("DetailAmount - DiscountAmount")]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInReports(false)]
        public decimal SubTotal
        {
            get
            {
                return (decimal)EvaluateAlias("SubTotal");
            }
        }

        [PersistentAlias("SubTotal - ((SubTotal- DiscountAmount) * (DiscountPercent/100))")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        public decimal Amount
        {
            get
            {
                return (decimal)EvaluateAlias("Amount");
            }
        }

        [Association("Invoice-SaleItems"), DevExpress.Xpo.Aggregated]
        public XPCollection<SaleItem> SaleItems
        {
            get
            {
                return GetCollection<SaleItem>("SaleItems");
            }
        }
    }
}