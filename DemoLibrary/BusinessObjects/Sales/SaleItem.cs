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
using DemoLibrary.BusinessObjects.Products;

namespace DemoLibrary.BusinessObjects.Sales
{
    [DefaultClassOptions]
    [ImageName("BO_Sale_Item")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [NavigationItem(false)]
    [CreatableItem(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SaleItem : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SaleItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Quantity = 1;
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

        Invoice invoice;
        [Association("Invoice-SaleItems")]
        public Invoice Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                SetPropertyValue("Invoice", ref invoice, value);
            }
        }

        Product product;
        [RuleRequiredField]
        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                SetPropertyValue("Product", ref product, value);
            }
        }

        int quantity;
        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 1)]
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                SetPropertyValue("Quantity", ref quantity, value);
            }
        }

        [PersistentAlias("Product.Price * Quantity")]
        [ModelDefault("DisplayFormat", "n2")]
        public decimal? Amount
        {
            get
            {
                if (Product == null)
                {
                    return 0;
                }
                else
                {
                    return (decimal)EvaluateAlias("Amount");
                }
            }
        }
    }
}