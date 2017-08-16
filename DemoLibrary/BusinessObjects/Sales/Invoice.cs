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
   //[ImageName("BO_Contact")]
   //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
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
      [Key]
      [RuleRequiredField]
      [RuleUniqueValue]
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

      string name;
      public string Name
      {
         get
         {
            return name;
         }
         set
         {
            SetPropertyValue("Name", ref name, value);
         }
      }

      Customer customer;
      public Customer Customer
      {
         get
         {
            return customer;
         }
         set
         {
            SetPropertyValue("Customer", ref customer, value);
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
      public decimal DetailAmount
      {
         get
         {
            if (SaleItems.Count == 0)
            {
               return 0;
            } else
            {
               return (decimal)EvaluateAlias("DetailAmount");
            }
         }
      }

      decimal discountAmount;
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

      [PersistentAlias("(DetailAmount - DiscountAmount) - ((DetailAmount - DiscountAmount) * (DiscountPercent/100))")]
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