// Reply.cs

namespace test_twilio
{
    // builds and formats the reply text strings
    using System.Text;

    public class Reply
    {
        #region Fields

        private const string correct = "Correct! ";
        private const string incorrect = "Wrong! ";
        private const string optionsInstuction = "Text back A, B, C or D as your answer.";
        private const string startGame = "Practice over. ";
        private const string startText = Input.StartText;

        private const string Welcome =
            "Welcome to our version of 'Who Wants to be a Millionaire?' A quick warm-up question: ";

        private const string Winner =
            "Congratulations, you win!! You are now a millionaire!";

        private static readonly string PlayAgainInvite =
            string.Format("To play the game again, text '{0}' to this number.", startText);

        private readonly string generalInstructions =
            string.Format(
                "Text '{0}' to start or text A, B, C or D as your answer.",
                startText);

        private readonly string notifyLoser = "Sorry you lose. " + PlayAgainInvite;
        private readonly StringBuilder reply = new StringBuilder();

        #endregion Fields

        #region Methods

        public static string FormatQuestion(Question question)
        {
            return string.Format(
                "{0} {1} {2}",
                question.QuestionText,
                PosibleAnswers(question),
                optionsInstuction);
        }

        public static string NextLevel(int level)
        {
            return string.Format("You're now at level {0}. Question: ", level);
        }

        public void Correct()
        {
            reply.Append(correct);
        }

        public void GeneralInstructions()
        {
            reply.Append(generalInstructions);
        }

        public void GiveAnswer(Question question)
        {
            string answer = string.Format(
                "The answer is: {0}) {1}. ",
                question.Answer.AnswerCode,
                question.Answer.AnswerText);
            reply.Append(answer);
        }

        public void Incorrect()
        {
            reply.Append(incorrect);
        }

        public void Level(int level)
        {
            reply.Append(NextLevel(level));
        }

        public void NotifyLoser()
        {
            reply.Append(notifyLoser);
        }

        public void NotifyWinner()
        {
            reply.Append(Winner);
        }

        public void Question(Question question)
        {
            reply.Append(FormatQuestion(question));
        }

        public void StartGame()
        {
            reply.Append(startGame);
        }

        public void StartPlay(Question question)
        {
            reply.Append(Welcome);
            reply.Append(FormatQuestion(question));
        }

        public string Text()
        {
            return reply.ToString();
        }

        private static string PosibleAnswers(Question question)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach (Answer answer in question.PosibleAnswers)
            {
                count++;
                // add a full stop to the last line and a question mark to the rest
                sb.AppendFormat(
                    count == question.PosibleAnswers.Count ? "{0}) {1}? " : "{0}) {1}, ",
                    answer.AnswerCode,
                    answer.AnswerText);
            }
            return sb.ToString();
        }

        #endregion Methods
    }
}