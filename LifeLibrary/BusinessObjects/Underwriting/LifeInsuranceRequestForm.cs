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
using CommonLibrary.BusinessObjects.Areas;

namespace LifeLibrary.BusinessObjects.Underwriting
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class LifeInsuranceRequestForm : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public LifeInsuranceRequestForm(Session session)
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
        public string PolicyHolderName { get; set; }
        public DateTime PolicyHolderBirthDate { get; set; }
        public string PolicyHolderBirthPlace { get; set; }
        public Religion PolicyHolderReligion { get; set; }
        public string PolicyHolderIdentityNumber { get; set; }
        public IdentityType PolicyHolderIdentityType { get; set; }
        public string PolicyHolderAddress { get; set; }
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderCountry { get; set; }
        public Province PolicyHolderProvince { get; set; }
        public District PolicyHolderDistrict { get; set; }
        public SubDistrict PolicyHolderSubDistrict { get; set; }
        public string PolicyHolderPostalCode { get; set; }

        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderMailingCountry { get; set; }
        public Province PolicyHolderMailingProvince { get; set; }
        public District PolicyHolderMailingDistrict { get; set; }
        public SubDistrict PolicyHolderMailingSubDistrict { get; set; }
        public string PolicyHolderMailingPostalCode { get; set; }


        public string PolicyHolderHandphone { get; set; }
        public string PolicyHolderEmail { get; set; }
        public string PolicyHolderOccupation { get; set; }
        public string PolicyHolderPosition { get; set; }

        public string PolicyHolderCompany { get; set; }
        public string PolicyHolderCompanyAddress { get; set; }
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderCompanyCountry { get; set; }
        public Province PolicyHolderCompanyProvince { get; set; }
        public District PolicyHolderCompanyDistrict { get; set; }
        public SubDistrict PolicyHolderCompanySubDistrict { get; set; }
        public string PolicyHolderCompanyPostalCode { get; set; }

        public decimal PolicyHolderHeight { get; set; }
        public decimal PolicyHolderWeight { get; set; }



    }
}