// Input.cs

namespace test_twilio
{
    using System;

    /// <summary>
    /// Represents the input from the player.
    /// </summary>
    public class Input
    {
        #region Fields

        public const string StartText = "play";

        private readonly string inputText;

        #endregion Fields

        #region Constructors

        public Input(string inputText)
        {
            this.inputText = inputText;
        }

        #endregion Constructors

        #region Properties

        public string InputText
        {
            get { return inputText; }
        }

        #endregion Properties

        #region Methods

        public bool IsStart()
        {
            return string.Equals(InputText, StartText, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsValidAnswer()
        {
            return Answer.IsValidAnswerCode(InputText);
        }

        #endregion Methods
    }
}