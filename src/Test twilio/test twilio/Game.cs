// Game.cs

namespace test_twilio
{
    using System;

    /// <summary>
    /// Contains the logic for the game
    /// </summary>
    public class Game
    {
        #region Fields

        private readonly Players players;
        private readonly Questions questions;
     

        #endregion Fields

        #region Constructors

        public Game(Players players, Questions questions)
        {
            this.players = players;
            this.questions = questions;
        }

        #endregion Constructors

        #region Properties

        public Players Players
        {
            get { return players; }
        }

        #endregion Properties

        #region Methods

        // play the game, this is the main entry point to the game. 
        public Reply Play(string playerNumber, string inputText)
        {            
            Input input = new Input(inputText);
            Reply reply = new Reply();

            if (input.IsStart())
            {
                StartPlay(reply, playerNumber);
            }
            else if (input.IsValidAnswer())
            {
               
                ContinuePlay(reply, playerNumber, input.InputText);
            }
            else
            {
                reply.GeneralInstructions();
            }

            return reply;
        }

        private void ContinuePlay(Reply reply, string playerNumber, string input)
        {
            AnswerCode answerCode = Answer.GetAnswerCode(input);
            Player player = players.GetPlayer(playerNumber);
            Question question = player.CurrentQuestion;

            switch (player.PlayerMode)
            {
                case PlayerMode.Startup:
                    ProcessStartupAnswer(reply, answerCode, player, question);
                    break;
                case PlayerMode.Playing:
                    ProcessAnswer(reply, answerCode, player, question);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
      
        private void MoveToNextLevel(Reply reply, Player player)
        {
            // move the player up a level and set them the next question
            player.IncrementLevel();
            player.CurrentQuestion = questions.GetQuestion(player.Level);
            reply.Level(player.Level);
            reply.Question(player.CurrentQuestion);
            players.UpdatePlayer(player);
        }

        private void ProcessAnswer(
            Reply reply,
            AnswerCode answerCode,
            Player player,
            Question question)
        {
            if (player.IsCorrectAnswer(answerCode))
            {
                reply.Correct();
                reply.GiveAnswer(question);
                if (player.IsMaxLevel())
                {
                    reply.NotifyWinner();
                }
                else
                {
                    MoveToNextLevel(reply, player);
                }
            }
            else
            {
                reply.Incorrect();
                reply.GiveAnswer(question);
                reply.NotifyLoser();
                players.Remove(player);
            }
        }

        private void ProcessStartupAnswer(
            Reply reply,
            AnswerCode answerCode,
            Player player,
            Question question)
        {
            if (player.IsCorrectAnswer(answerCode))
            {
                reply.Correct();
            }
            else
            {
                reply.Incorrect();
            }
            reply.GiveAnswer(question);
            reply.StartGame();
            player.PlayerMode = PlayerMode.Playing;
            MoveToNextLevel(reply, player);
        }

       
        private void StartPlay(Reply reply, string playerNumber)
        {
            // add the new player and set them the warm up question
            Player player = players.AddNewPlayer(playerNumber);
            player.CurrentQuestion = questions.GetQuestion(player.Level);
            reply.StartPlay(player.CurrentQuestion);
            players.UpdatePlayer(player);
        }

        #endregion Methods
    }
}