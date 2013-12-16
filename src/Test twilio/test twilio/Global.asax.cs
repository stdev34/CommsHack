namespace test_twilio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;

    /// <summary>
    /// Read in application data on start up
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        #region Methods

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // start with an empty list of players
            // todo read in persisted player data
            Application["players"] = new Players();
            Questions questions = new Questions();
            questions.Load();
            Application["questions"] = questions;
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}