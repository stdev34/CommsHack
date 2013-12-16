// Question.cs

namespace test_twilio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Holds details of the question, its posible and actual answers
    /// </summary>
    public class Question
    {
        #region Constructors

        public Question()
        {
            PosibleAnswers = new List<Answer>();
        }

        public Question(QuestionContent content)
        {
            PosibleAnswers = new List<Answer>();
            QuestionText = content.Question;

            // add the posible answers
            for (int i = 0; i < content.possible.Count; i++)
            {
                Answer answer = new Answer();
                answer.AnswerText = content.possible[i];
                answer.AnswerCode = (AnswerCode) i;

                PosibleAnswers.Add(answer);
            }

            // add the actual answer
            AnswerCode answerCode =
                (AnswerCode) Enum.Parse(typeof (AnswerCode), content.answer);
            Answer = PosibleAnswers.First(p => p.AnswerCode == answerCode);
        }

        #endregion Constructors

        #region Properties

        public Answer Answer { get; set; }

        public List<Answer> PosibleAnswers { get; set; }

        public string QuestionText { get; set; }

        #endregion Properties

        #region Methods

        public bool IsCorrectAnswer(AnswerCode answer)
        {
            return answer == Answer.AnswerCode;
        }

        #endregion Methods
    }
}