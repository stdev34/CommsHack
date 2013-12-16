// sms.aspx.cs

namespace test_twilio
{
    using System;
    using System.IO;
    using System.Security.Policy;
    using System.Text;
    using System.Web.UI;
    using System.Xml.Linq;

    // This class is the page that receives the message from Twilio.
    // It passes the input to the Game which creates the reply text.
    // The reply is sent to Twilio by outputting the reply text in
    // a specified xml format to the response.
    public partial class sms : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Players players = (Players) Application["players"];
                Questions questions = (Questions) Application["questions"];

                // extract the user input from the incoming request
                string playerNumber = Request["From"];
                string input = Request["Body"].Trim();

                if ((String.IsNullOrWhiteSpace(playerNumber)) ||
                    (String.IsNullOrWhiteSpace(input))) return;

                Game game = new Game(players, questions);
                Reply reply = game.Play(playerNumber, input);

                SendReply(reply.Text());

                // save the players state
                Application["players"] = game.Players;
                // todo save to a database
                // todo consider multithreading issues here
            }
            catch (Exception ex)
            {
                // todo error handling here
                //throw;
            }
        }

        private void SendReply(string text)
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(
                    "Response",
                    new XElement("Message", text)));

            doc.Declaration = new XDeclaration("1.0", "utf-8", null);
            StringWriter writer = new Utf8StringWriter();
            doc.Save(writer, SaveOptions.None);

            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.
            Response.Write(writer);         
        }

        #endregion Methods

        #region Nested Types

        private class Utf8StringWriter : StringWriter
        {
            #region Properties

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}