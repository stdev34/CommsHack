using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test_twilio
{
    using System.Web.Configuration;
    using Twilio;

    public partial class SendSms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void sendMessage_OnClick(object sender, EventArgs e)
        {
            try
            {
                string accountSid = WebConfigurationManager.AppSettings["ACCOUNT_SID"];
                string authToken = WebConfigurationManager.AppSettings["AUTH_TOKEN"];
                string fromNumber = WebConfigurationManager.AppSettings["TWILIO_NUMBER"];

                TwilioRestClient client = new TwilioRestClient(accountSid, authToken);
                SMSMessage res = client.SendSmsMessage(fromNumber, ToNumber.Text, MyMessage.Text);               
            }
            catch (Exception ex)
            {
                // todo error handling
               Response.Write("Error occcured.Message not sent");
            }          
        }
    }
}