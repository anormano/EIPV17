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
using static CommonLibrary.BusinessObjects.BaseObjects.EnumLibrary;

namespace CommonLibrary.BusinessObjects.BaseObjects
{
   [NavigationItem(false), CreatableItem(false), DefaultProperty("DisplayName"), VisibleInReports(false), ImageName("BO_Employee")]
   //[ImageName("BO_Contact")]
   //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
   //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
   //[Persistent("DatabaseTableName")]
   // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
   public class People : BaseObject
   { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
      public People(Session session)
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
      [PersistentAlias("Concat([FirstName], ' ', [LastName])")]
      public string DisplayName
      {
         get
         {
            return (string)EvaluateAlias("DisplayName");
         }
      }

      string firstName;
      [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData(true)]
      public string FirstName
      {
         get
         {
            return firstName;
         }
         set
         {
            SetPropertyValue("FirstName", ref firstName, value);
         }
      }

      string lastName;
      [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData(true)]
      public string LastName
      {
         get
         {
            return lastName;
         }
         set
         {
            SetPropertyValue("LastName", ref lastName, value);
         }
      }

      DateTime birthDate;
      public DateTime BirthDate
      {
         get
         {
            return birthDate;
         }
         set
         {
            SetPropertyValue("BirthDate", ref birthDate, value);
         }
      }

      string birthPlace;
      [Size(SizeAttribute.DefaultStringMappingFieldSize)]
      public string BirthPlace
      {
         get
         {
            return birthPlace;
         }
         set
         {
            SetPropertyValue("BirthPlace", ref birthPlace, value);
         }
      }

      MediaDataObject photo;
      public MediaDataObject Photo
      {
         get
         {
            return photo;
         }
         set
         {
            SetPropertyValue("Photo", ref photo, value);
         }
      }

      Gender gender;
      public Gender Gender
      {
         get
         {
            return gender;
         }
         set
         {
            SetPropertyValue("Gender", ref gender, value);
         }
      }
   }
}