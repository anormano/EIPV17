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
using DevExpress.ExpressApp.Editors;
using CommonLibrary.BusinessObjects.Administration;

namespace DemoLibrary.BusinessObjects.Other
{
   [DefaultClassOptions]
   [ImageName("BO_Note")]
   [DefaultProperty("Subject")]
   [FileAttachment("Attachment")]
   [CreatableItem(false)]
   [NavigationItem(false)]
   //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
   //[Persistent("DatabaseTableName")]
   // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
   public class NoteBase : BaseObject
   { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
      public NoteBase(Session session)
          : base(session)
      {
      }
      public override void AfterConstruction()
      {
         base.AfterConstruction();
         // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
         Date = DateTime.Now;
         Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
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

      string subject;
      [Size(SizeAttribute.DefaultStringMappingFieldSize)]
      [RuleRequiredField]
      public string Subject
      {
         get
         {
            return subject;
         }
         set
         {
            SetPropertyValue("Subject", ref subject, value);
         }
      }

      DateTime date;
      public DateTime Date
      {
         get
         {
            return date;
         }
         set
         {
            SetPropertyValue("Date", ref date, value);
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

      string note;
      [Size(SizeAttribute.Unlimited)]
      [EditorAlias(EditorAliases.HtmlPropertyEditor)]
      public string Note
      {
         get
         {
            return note;
         }
         set
         {
            SetPropertyValue("Note", ref note, value);
         }
      }

      FileData attachment;
      public FileData Attachment
      {
         get
         {
            return attachment;
         }
         set
         {
            SetPropertyValue("Attachment", ref attachment, value);
         }
      }
   }
}