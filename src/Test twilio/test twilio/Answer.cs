// Answer.cs

namespace test_twilio
{
    using System;
    using System.Linq;

    /// <summary>
    /// Holds the answer details.
    /// </summary>
    public class Answer
    {
        #region Properties

        public AnswerCode AnswerCode { get; set; }

        public string AnswerText { get; set; }

        #endregion Properties

        #region Methods

        // Get the code corresponding to the text, will throw if invalid
        public static AnswerCode GetAnswerCode(string text)
        {
            AnswerCode code;
            // case insensitive comparison
            var valid = Enum.TryParse(text, true, out code);
            if (!valid)
            {
                throw new ArgumentOutOfRangeException(text);
            }

            return code;
        }

        public static bool IsValidAnswerCode(string text)
        {
            string[] answerList = Enum.GetNames(typeof (AnswerCode));
            return answerList.Contains(text.ToUpper());
        }

        #endregion Methods
    }
}