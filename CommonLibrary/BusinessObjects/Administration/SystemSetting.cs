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
using CommonLibrary.BusinessObjects.Areas;
using DevExpress.ExpressApp.Editors;

namespace CommonLibrary.BusinessObjects.Administration
{

    [NavigationItem("Administration")]
    [RuleObjectExists("AnotherSystemSettingExists", DefaultContexts.Save, "True", InvertResult = true,
    CustomMessageTemplate = "Another System Setting already exists.")]
    [RuleCriteria("CannotDeleteSystemSetting", DefaultContexts.Delete, "False", CustomMessageTemplate = "Cannot delete System Setting.")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SystemSetting : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SystemSetting(Session session)
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

        public string CompanyName { get; set; }

        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.StringPropertyEditor)]
        [ModelDefault("RowCount", "3")]
        public string Address { get; set; }

        public string PostalCode { get; set; }

        [ImmediatePostData]
        public Areas.Country Country { get; set; }

        [ImmediatePostData]
        [DataSourceProperty("Country.Provinces")]
        public Province Provice { get; set; }

        [ImmediatePostData]
        [DataSourceProperty("Province.Districts")]
        public District District { get; set; }

        [DataSourceProperty("District.SubDistricts")]
        public SubDistrict SubDistrict { get; set; }

        [ImageEditor(ImageSizeMode = ImageSizeMode.Zoom, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 200, DetailViewImageEditorFixedWidth = 300)]
        public MediaDataObject Logo { get; set; }
    }
}