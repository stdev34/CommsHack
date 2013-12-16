// QuestionContent.cs

namespace test_twilio
{
    using System.Collections.Generic;

    /// <summary>
    /// Maps to the format of the saved question content to enable auto conversion from Json.
    /// </summary>
    public class QuestionContent
    {
        #region Properties

        public string answer { get; set; }

        public List<string> possible { get; set; }

        public string Question { get; set; }

        #endregion Properties
    }
}