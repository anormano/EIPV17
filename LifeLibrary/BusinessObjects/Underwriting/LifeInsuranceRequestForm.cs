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
using CommonLibrary.BusinessObjects.Administration;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace LifeLibrary.BusinessObjects.Underwriting
{
    [DefaultClassOptions]
    [Appearance("HideInsured", "IsNotInsured=False", TargetItems = "InsuredGroup", Visibility = ViewItemVisibility.Hide, AppearanceItemType = "LayoutItem")]
    //[Appearance("ShowInsured", "IsNotInsured=True", TargetItems = "InsuredGroup", Visibility = ViewItemVisibility.Show, AppearanceItemType = "LayoutItem")]
    [Appearance("HideOtherEntry", "Other=False", TargetItems = "OtherEntry", Enabled = false, AppearanceItemType = "ViewItem")]
    [Appearance("ShowOtherEntry", "Other=True", TargetItems = "OtherEntry", Enabled = true, AppearanceItemType = "ViewItem")]
    [Appearance("ShowExplanation", "IsHospitalized = true or IsDiabetic = true or IsCancer = true or IsHepatitic = true or IsKedneyDefect = true or IsBoneDefect = true or IsBloodDefect = true or IsHormonalDefect = true or IsAsthma = true or IsAids = true or IsCongenital = true or Other = true", TargetItems = "Explanation", Enabled = true, AppearanceItemType = "ViewItem")]
    [Appearance("HideExplanation", "IsHospitalized = false and IsDiabetic = false and IsCancer = false and IsHepatitic = false and IsKedneyDefect = false and IsBoneDefect = false and IsBloodDefect = false and IsHormonalDefect = false and IsAsthma = false and IsAids = false and IsCongenital = false and Other = false", TargetItems = "Explanation", Enabled = false, AppearanceItemType = "ViewItem")]

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

        public string FormNumber { get; set; }
        [ImmediatePostData]
        public Product Product { get; set; }
        public Employee Agent { get; set; }
        public LifeInsuranceRequestFormStatus Status { get; set; }
        [DataSourceProperty("Product.InvestmentAllocations")]
        public InvestmentAllocation InvestmentAllocation { get; set; }
        [DataSourceProperty("Product.SumInsuredSpecifications")]
        public SumInsuredSpecification SumInsured { get; set; }

        [ModelDefault("Caption", "Full Name")]
        public string PolicyHolderName { get; set; }
        [ModelDefault("Caption", "Birth Date")]
        [VisibleInListView(false)]
        public DateTime PolicyHolderBirthDate { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Birth Place")]
        public string PolicyHolderBirthPlace { get; set; }
        [ModelDefault("Caption", "Religion")]
        [VisibleInListView(false)]
        public Religion PolicyHolderReligion { get; set; }
        [ModelDefault("Caption", "Identity Type")]
        [VisibleInListView(false)]
        public IdentityType PolicyHolderIdentityType { get; set; }
        [ModelDefault("Caption", "Identity Number")]
        [VisibleInListView(false)]
        public string PolicyHolderIdentityNumber { get; set; }


        [ModelDefault("Caption", "Address")]
        [ModelDefault("RowCount", "2")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        public string PolicyHolderAddress { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderCountry { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "State/Province")]
        public Province PolicyHolderProvince { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "District/Regency")]
        public District PolicyHolderDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict PolicyHolderSubDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Postal Code")]
        public string PolicyHolderPostalCode { get; set; }


        [VisibleInListView(false)]
        [ModelDefault("Caption", "Address")]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        public string PolicyHolderMailingAddress { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderMailingCountry { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "State/Province")]
        public Province PolicyHolderMailingProvince { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "District/Regency")]
        public District PolicyHolderMailingDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict PolicyHolderMailingSubDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Postal Code")]
        public string PolicyHolderMailingPostalCode { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Handphone")]
        public string PolicyHolderHandphone { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "E-Mail")]
        public string PolicyHolderEmail { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Occupation")]
        public string PolicyHolderOccupation { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Position")]
        public string PolicyHolderPosition { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Company")]
        public string PolicyHolderCompany { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string PolicyHolderCompanyAddress { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country PolicyHolderCompanyCountry { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "State/Province")]
        public Province PolicyHolderCompanyProvince { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "District/Regency")]
        public District PolicyHolderCompanyDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict PolicyHolderCompanySubDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Postal Code")]
        public string PolicyHolderCompanyPostalCode { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Height")]
        public decimal PolicyHolderHeight { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Weight")]
        public decimal PolicyHolderWeight { get; set; }

        [ModelDefault("Caption", "Policy Holder is not Insured")]
        [ImmediatePostData]
        public bool IsNotInsured { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Full Name")]
        public string InsuredName { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Birth Date")]
        public DateTime InsuredBirthDate { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Birth Place")]
        public string InsuredBirthPlace { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Religion")]
        public Religion InsuredReligion { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Identity Number")]
        public string InsuredIdentityNumber { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Identity Type")]
        public IdentityType InsuredIdentityType { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string InsuredAddress { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country InsuredCountry { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "State/Province")]
        public Province InsuredProvince { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "District/Regency")]
        public District InsuredDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict InsuredSubDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Postal Code")]
        public string InsuredPostalCode { get; set; }


        [VisibleInListView(false)]
        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string InsuredMailingAddress { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country InsuredMailingCountry { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "State/Province")]
        public Province InsuredMailingProvince { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "District/Regency")]
        public District InsuredMailingDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Sub-District")]
        public SubDistrict InsuredMailingSubDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Postal Code")]
        public string InsuredMailingPostalCode { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Handphone")]
        public string InsuredHandphone { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "E-Mail")]
        public string InsuredEmail { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Occupation")]
        public string InsuredOccupation { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Position")]
        public string InsuredPosition { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Company")]
        public string InsuredCompany { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Address")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "2")]
        [Size(SizeAttribute.Unlimited)]
        public string InsuredCompanyAddress { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Country")]
        public CommonLibrary.BusinessObjects.Areas.Country InsuredCompanyCountry { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "State/Province")]
        public Province InsuredCompanyProvince { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "District/Regency")]
        public District InsuredCompanyDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Sub District")]
        public SubDistrict InsuredCompanySubDistrict { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Postal Code")]
        public string InsuredCompanyPostalCode { get; set; }

        [VisibleInListView(false)]
        [ModelDefault("Caption", "Height")]
        public decimal InsuredHeight { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Weight")]
        public decimal InsuredWeight { get; set; }

        [VisibleInListView(false)]
        public InsuredRelationship Relationship { get; set; }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Other")]
        public string OtherRelationship { get; set; }
        #region Desease
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsHospitalized { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsDiabetic { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsCancer { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsHepatitic { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsKedneyDefect { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsBoneDefect { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsBloodDefect { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsHormonalDefect { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsAsthma { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsAids { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool IsCongenital { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public bool Other { get; set; }
        [VisibleInListView(false)]
        [ImmediatePostData(true)]
        public string OtherEntry { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        public string Explanation { get; set; }
        #endregion

        [Association("LifeInsuranceRequestForm-Beneficiaries"), DevExpress.Xpo.Aggregated]
        public XPCollection<Beneficiary> Beneficiaries
        {
            get
            {
                return GetCollection<Beneficiary>("Beneficiaries");
            }
        }
    }
}