using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Security.ClientServer.Remoting;

namespace EIPV17.Web {
    public class Global : System.Web.HttpApplication {
        public Global() {
            InitializeComponent();
        }
		protected void Application_Start(Object sender, EventArgs e) {
			SecurityAdapterHelper.Enable();
			ASPxWebControl.CallbackError += new EventHandler(Application_Error);
			string connectionString = "tcp://localhost:8080/DataServer";
			Hashtable t = new Hashtable();
			t.Add("secure", true);
			t.Add("tokenImpersonationLevel", "impersonation");
			TcpChannel channel = new TcpChannel(t, null, null);
			ChannelServices.RegisterChannel(channel, true);
			this.Application["DataServer"] = Activator.GetObject(typeof(RemoteSecuredDataServer), connectionString);
		}
		protected void Session_Start(Object sender, EventArgs e) {
		    Tracing.Initialize();
            WebApplication.SetInstance(Session, new EIPV17AspNetApplication());
			IDataServer clientDataServer = (IDataServer)this.Application["DataServer"];
			ServerSecurityClient securityClient = new ServerSecurityClient(clientDataServer, new ClientInfoFactory());
			securityClient.SupportNavigationPermissionsForTypes = false;
			WebApplication.Instance.Security = securityClient;
			WebApplication.Instance.CreateCustomObjectSpaceProvider += 
				delegate(object _sender, CreateCustomObjectSpaceProviderEventArgs args) {
					args.ObjectSpaceProvider = new DataServerObjectSpaceProvider(
						clientDataServer, securityClient);
			};
			//DevExpress.ExpressApp.Web.Templates.DefaultVerticalTemplateContentNew.ClearSizeLimit();
            WebApplication.Instance.Settings.DefaultVerticalTemplateContentPath = "DefaultVerticalTemplateContent.ascx";
            WebApplication.Instance.Settings.LogonTemplateContentPath = "CustomLogonTemplateContent.ascx";
            //DefaultVerticalTemplateContent.ClearSizeLimit();
            WebApplication.Instance.SwitchToNewStyle();
            WebApplication.Instance.Setup();
			WebApplication.Instance.Start();
		}
        protected void Application_BeginRequest(Object sender, EventArgs e) {
        }
        protected void Application_EndRequest(Object sender, EventArgs e) {
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
        }
        protected void Application_Error(Object sender, EventArgs e) {
            ErrorHandling.Instance.ProcessApplicationError();
        }
        protected void Session_End(Object sender, EventArgs e) {
            WebApplication.LogOff(Session);
            WebApplication.DisposeInstance(Session);
        }
        protected void Application_End(Object sender, EventArgs e) {
        }
        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
        }
        #endregion
    }
}
