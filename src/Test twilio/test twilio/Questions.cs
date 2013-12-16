// Questions.cs

namespace test_twilio
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides the lists of questions
    /// </summary>
    public class Questions
    {
        #region Fields

        private readonly List<string> fileNames = new List<string>
        {"level_1.json", "level_2.json", "level_3.json", "level_4.json", "level_5.json"};

        //todo get these filenames from the config?
        private readonly List<List<Question>> questionLists = new List<List<Question>>();

        #endregion Fields

        #region Methods

        public Question GetQuestion(int level)
        {
            Random rnd = new Random();
            int maxIndex = questionLists[level].Count - 1;
            int randomIndex = rnd.Next(0, maxIndex);
            return questionLists[level][randomIndex];
        }

        public void Load()
        {
            // Load warmup question as level zero
            List<Question> levelZero = new List<Question> {GetWarmupQuestion()};
            questionLists.Add(levelZero);

            //read questions from files
            foreach (var fileName in fileNames)
            {
                //read the file
                const string folderName = "QuizQuestions";
                string path =
                    HttpContext.Current.Server.MapPath(Path.Combine(folderName, fileName));
                string text = File.ReadAllText(path);

                //parse the Json and create the question list
                List<QuestionContent> contents =
                    JsonConvert.DeserializeObject<List<QuestionContent>>(text);
                List<Question> list =
                    contents.Select(content => new Question(content)).ToList();
                questionLists.Add(list);
            }
        }

        private Question GetWarmupQuestion()
        {
            Question question = new Question();
            question.QuestionText = "What's your favorite colour? ";
            List<Answer> posible = new List<Answer>();
            posible.Add(new Answer {AnswerCode = AnswerCode.A, AnswerText = "Red"});
            posible.Add(new Answer {AnswerCode = AnswerCode.B, AnswerText = "Blue"});
            posible.Add(new Answer {AnswerCode = AnswerCode.C, AnswerText = "Green"});
            posible.Add(
                new Answer {AnswerCode = AnswerCode.D, AnswerText = "None of the above"});

            question.PosibleAnswers = posible;
            question.Answer = posible[1];
            return question;
        }

        #endregion Methods
    }
}