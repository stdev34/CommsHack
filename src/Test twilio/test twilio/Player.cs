// Player.cs

namespace test_twilio
{
    /// <summary>
    /// Holds details of a player.
    /// </summary>
    public class Player
    {
        #region Fields

        private const int MaxLevel = 5;

        #endregion Fields

        #region Constructors

        public Player(string playerNumber)
        {
            PlayerNumber = playerNumber;
        }

        #endregion Constructors

        #region Properties

        public Question CurrentQuestion { get; set; }

        public int Level { get; set; }

        public PlayerMode PlayerMode { get; set; }

        public string PlayerNumber { get; set; }

        #endregion Properties

        #region Methods

        public void IncrementLevel()
        {
            Level = Level + 1;
        }

        public bool IsCorrectAnswer(AnswerCode answerCode)
        {
            return CurrentQuestion.IsCorrectAnswer(answerCode);
        }

        public bool IsMaxLevel()
        {
            return Level >= MaxLevel;
        }

        #endregion Methods
    }
}