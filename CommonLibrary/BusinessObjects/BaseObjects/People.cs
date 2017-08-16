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
using DevExpress.ExpressApp.Editors;
using CommonLibrary.BusinessObjects.Areas;

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

      string address;
      [EditorAlias(EditorAliases.StringPropertyEditor)]
      [Size(SizeAttribute.Unlimited)]
      [ModelDefault("RowCount", "3")]
      public string Address
      {
         get
         {
            return address;
         }
         set
         {
            SetPropertyValue("Address", ref address, value);
         }
      }

      CommonLibrary.BusinessObjects.Areas.Country country;
      [ImmediatePostData]
      public CommonLibrary.BusinessObjects.Areas.Country Country
      {
         get
         {
            return country;
         }
         set
         {
            SetPropertyValue("Country", ref country, value);
         }
      }

      Province province;
      [ImmediatePostData]
      [DataSourceProperty("Country.Provinces")]
      public Province Province
      {
         get
         {
            return province;
         }
         set
         {
            SetPropertyValue("Province", ref province, value);
         }
      }

      District district;
      [ImmediatePostData]
      [DataSourceProperty("Province.Districts")]
      public District District
      {
         get
         {
            return district;
         }
         set
         {
            SetPropertyValue("District", ref district, value);
         }
      }

      SubDistrict subDistrict;
      [DataSourceProperty("District.SubDistricts")]
      public SubDistrict SubDistrict
      {
         get
         {
            return subDistrict;
         }
         set
         {
            SetPropertyValue("SubDistrict", ref subDistrict, value);
         }
      }
   }
}