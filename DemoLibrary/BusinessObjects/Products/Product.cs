﻿using System;
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
using DevExpress.ExpressApp.Editors;

namespace DemoLibrary.BusinessObjects.Products
{
    [DefaultClassOptions]
    [ImageName("BO_Product")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Product : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Product(Session session)
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
        string name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField]
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

        ProductCategory category;
        [Association("ProductCategory-Products")]
        [VisibleInLookupListView(true)]
        public ProductCategory Category
        {
            get
            {
                return category;
            }
            set
            {
                SetPropertyValue("Category", ref category, value);
            }
        }

        decimal price;
        [VisibleInLookupListView(true)]
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                SetPropertyValue("Price", ref price, value);
            }
        }

        MediaDataObject image;
        public MediaDataObject Image
        {
            get
            {
                return image;
            }
            set
            {
                SetPropertyValue("Image", ref image, value);
            }
        }

        string description;
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.HtmlPropertyEditor)]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                SetPropertyValue("Description", ref description, value);
            }
        }

        [Association("Product-Notes"), DevExpress.Xpo.Aggregated]
        public XPCollection<ProductNote> Notes
        {
            get
            {
                return GetCollection<ProductNote>("Notes");
            }
        }
    }
}