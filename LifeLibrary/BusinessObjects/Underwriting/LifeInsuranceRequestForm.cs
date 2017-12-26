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
using DevExpress.ExpressApp.Editors;

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

        public Product Product { get; set; }

        [ModelDefault("Caption", "Full Name")]
        public string PolicyHolderName { get; set; }
        [ModelDefault("Caption", "Birth Date")]
        public DateTime PolicyHolderBirthDate { get; set; }
        [ModelDefault("Caption", "Birth Place")]
        public string PolicyHolderBirthPlace { get; set; }
        [ModelDefault("Caption", "Religion")]
        public Religion PolicyHolderReligion { get; set; }
        [ModelDefault("Caption", "Identity Type")]
        public IdentityType PolicyHolderIdentityType { get; set; }
        [ModelDefault("Caption", "Identity Number")]
        public string PolicyHolderIdentityNumber { get; set; }


        [ModelDefault("Caption", "Address")]
        [ModelDefault("RowCount", "3")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [Size(SizeAttribute.Unlimited)]
        public string PolicyHolderAddress { get; set; }
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderCountry { get; set; }
        [ModelDefault("Caption", "State/Province")]
        public Province PolicyHolderProvince { get; set; }
        [ModelDefault("Caption", "District/Regency")]
        public District PolicyHolderDistrict { get; set; }
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict PolicyHolderSubDistrict { get; set; }
        [ModelDefault("Caption", "Postal Code")]
        public string PolicyHolderPostalCode { get; set; }


        [ModelDefault("Caption", "Address")]
        [ModelDefault("RowCount", "3")]
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        public string PolicyHolderMailingAddress { get; set; }
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderMailingCountry { get; set; }
        [ModelDefault("Caption", "State/Province")]
        public Province PolicyHolderMailingProvince { get; set; }
        [ModelDefault("Caption", "District/Regency")]
        public District PolicyHolderMailingDistrict { get; set; }
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict PolicyHolderMailingSubDistrict { get; set; }
        [ModelDefault("Caption", "Postal Code")]
        public string PolicyHolderMailingPostalCode { get; set; }

        [ModelDefault("Caption", "Handphone")]
        public string PolicyHolderHandphone { get; set; }
        [ModelDefault("Caption", "E-Mail")]
        public string PolicyHolderEmail { get; set; }
        [ModelDefault("Caption", "Occupation")]
        public string PolicyHolderOccupation { get; set; }
        [ModelDefault("Caption", "Position")]
        public string PolicyHolderPosition { get; set; }

        [ModelDefault("Caption", "Company")]
        public string PolicyHolderCompany { get; set; }
        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string PolicyHolderCompanyAddress { get; set; }
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderCompanyCountry { get; set; }
        [ModelDefault("Caption", "State/Province")]
        public Province PolicyHolderCompanyProvince { get; set; }
        [ModelDefault("Caption", "District/Regency")]
        public District PolicyHolderCompanyDistrict { get; set; }
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict PolicyHolderCompanySubDistrict { get; set; }
        [ModelDefault("Caption", "Postal Code")]
        public string PolicyHolderCompanyPostalCode { get; set; }

        [ModelDefault("Caption", "Height")]
        public decimal PolicyHolderHeight { get; set; }
        [ModelDefault("Caption", "Weight")]
        public decimal PolicyHolderWeight { get; set; }

        [ModelDefault("Caption", "Full Name")]
        public string InsuredName { get; set; }
        [ModelDefault("Caption", "Birth Date")]
        public DateTime InsuredBirthDate { get; set; }
        [ModelDefault("Caption", "Birth Place")]
        public string InsuredBirthPlace { get; set; }
        [ModelDefault("Caption", "Religion")]
        public Religion InsuredReligion { get; set; }
        [ModelDefault("Caption", "Identity Number")]
        public string InsuredIdentityNumber { get; set; }
        [ModelDefault("Caption", "Identity Type")]
        public IdentityType InsuredIdentityType { get; set; }

        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string InsuredAddress { get; set; }
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country InsuredCountry { get; set; }
        [ModelDefault("Caption", "State/Province")]
        public Province InsuredProvince { get; set; }
        [ModelDefault("Caption", "District/Regency")]
        public District InsuredDistrict { get; set; }
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict InsuredSubDistrict { get; set; }
        [ModelDefault("Caption", "Postal Code")]
        public string InsuredPostalCode { get; set; }


        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string InsuredMailingAddress { get; set; }
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country InsuredMailingCountry { get; set; }
        [ModelDefault("Caption", "State/Province")]
        public Province InsuredMailingProvince { get; set; }
        [ModelDefault("Caption", "District/Regency")]
        public District InsuredMailingDistrict { get; set; }
        [ModelDefault("Caption", "Sub-District")]
        public SubDistrict InsuredMailingSubDistrict { get; set; }
        [ModelDefault("Caption", "Postal Code")]
        public string InsuredMailingPostalCode { get; set; }

        [ModelDefault("Caption", "Handphone")]
        public string InsuredHandphone { get; set; }
        [ModelDefault("Caption", "E-Mail")]
        public string InsuredEmail { get; set; }
        [ModelDefault("Caption", "Occupation")]
        public string InsuredOccupation { get; set; }
        [ModelDefault("Caption", "Position")]
        public string InsuredPosition { get; set; }

        [ModelDefault("Caption", "Company")]
        public string InsuredCompany { get; set; }
        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string InsuredCompanyAddress { get; set; }
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country InsuredCompanyCountry { get; set; }
        [ModelDefault("Caption", "State/Province")]
        public Province InsuredCompanyProvince { get; set; }
        [ModelDefault("Caption", "District/Regency")]
        public District InsuredCompanyDistrict { get; set; }
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict InsuredCompanySubDistrict { get; set; }
        [ModelDefault("Caption", "Postal Code")]
        public string InsuredCompanyPostalCode { get; set; }

        [ModelDefault("Caption", "Height")]
        public decimal InsuredHeight { get; set; }
        [ModelDefault("Caption", "Weight")]
        public decimal InsuredWeight { get; set; }

        public InsuredRelationship Relationship { get; set; }
        [ModelDefault("Caption", "Other")]
        public string OtherRelationship { get; set; }

        [Association("LifeInsuranceRequestForm-Beneficiaries"), DevExpress.Xpo.Aggregated]
        public XPCollection<Beneficiary> Beneficiaries
        {
            get
            {
                return GetCollection<Beneficiary>("Benefeciaries");
            }
        }
    }
}