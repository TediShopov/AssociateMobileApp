using Associate.Models;
using Associate.Models.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Associate.Tests
{
    public class GameStageTests:IDisposable
    {
        List<Team> Teams;
        PlayerOrder PlayerOrder;
        Queue<string> Words;
        public GameStageTests()
        {
            Player player1 = new Player("IvanOne");
            Player player2 = new Player("GoshoOne");
            Player player3 = new Player("PetjoTwo");
            Player player4 = new Player("IvanooTwo");
            Player player5 = new Player("BorkoThree");
            Player player6 = new Player("PetqThree");
            Player player7 = new Player("HristoFour");
            Player player8 = new Player("PeturFour");

            //Arrange
            var teamOne = new Team();
            var teamTwo = new Team();
            var teamThree = new Team();
            var teamFour = new Team();

            teamOne.Members.Add(player1);
            teamOne.Members.Add(player2);
            teamTwo.Members.Add(player3);
            teamTwo.Members.Add(player4);
            teamThree.Members.Add(player5);
            teamThree.Members.Add(player6);
            teamFour.Members.Add(player7);
            teamFour.Members.Add(player8);


            Teams = new List<Team> { teamOne, teamTwo, teamThree, teamFour };
            PlayerOrder = new PlayerOrder(Teams, false);


            Words = new Queue<string>();
        }

        public void Dispose()
        {
            Teams = new List<Team>();
           // PlayerOrder = new PlayerOrder(new Queue<Player>());
            Words = new Queue<string>();
        }

        [Fact]
        public void SetUpPlayerRound_NotNullPlayerOrder_CreatesRoundWithFirstPlayer()
        {
            //Arrange
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(1, 0, 0));


            //Act
            stage.SetUpPlayerRound();


            //Assert
            Assert.Equal("IvanOne",stage.CurrentRound.CurrentPlayer.Name);


        }

        [Theory]
        [InlineData("Rengo")]
        [InlineData("Mengo")]
        [InlineData("Jengo")]
        public void GiveOutNewWordToGuess_NotNullWords_GivesTheNextWord(string wordToReturn)
        {
            //Arrange
            Words.Enqueue(wordToReturn);
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(1, 0, 0));
           
            //Act
           


            //Assert
            Assert.Equal(wordToReturn,stage.GiveOutNewWordToGuess());


        }

        [Theory]
        [InlineData("Rengo")]
        [InlineData("Mengo")]
        [InlineData("Jengo")]
        public void GiveOutNewWordToGuess_NotNullWords_DoesNotAlterWordList(string wordToReturn)
        {
            //Arrange
            Words.Enqueue(wordToReturn);
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(1, 0, 0));
          
            //Act
            stage.GiveOutNewWordToGuess();


            //Assert
            Assert.Equal(1,Words.Count);

        }

        [Fact]     
        public void GuessWordForCurrentPlayer_TimerWorksAndStageIsNotOver_AddGuessedWordsToPlayer()
        {
            //Arrange
            Words.Enqueue("Aa");
            Words.Enqueue("Bb");
            Words.Enqueue("Dd");
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(3, 0, 0));
           
            stage.SetUpPlayerRound();
            stage.CurrentRound.RoundTimer.StartTimer();

            //Act
            stage.GuessWordForCurrentPlayer();
            stage.GuessWordForCurrentPlayer();
            stage.GuessWordForCurrentPlayer();


            //Assert
            Assert.Equal(new List<string> {"Aa","Bb","Dd" }, stage.CurrentRound.CurrentPlayer.GuessedWordsPerStage[stage]);

        }

        [Fact]
        public void GuessWordForCurrentPlayer_TimerOver_DoesNotAddWordsToPlayer()
        {
            //Arrange
            Words.Enqueue("Aa");
            Words.Enqueue("Bb");
            Words.Enqueue("Dd");
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(3, 0, 0));
           
            stage.SetUpPlayerRound();
            stage.CurrentRound.RoundTimer.StartTimer();

            //Act
          
            stage.CurrentRound.RoundTimer.StopTimer();
            stage.GuessWordForCurrentPlayer();


            //Assert
            Assert.Equal(new List<string>(), stage.CurrentRound.CurrentPlayer.GuessedWordsPerStage[stage]);

        }

        [Fact]
        public void GuessWordForCurrentPlayer_TimerNotOverButNotStarted_DoesNotAddWordsToPlayer()
        {
            //Arrange
            Words.Enqueue("Aa");
            Words.Enqueue("Bb");
            Words.Enqueue("Dd");
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(3, 0, 0));
           
            stage.SetUpPlayerRound();
           

            //Act

           
            stage.GuessWordForCurrentPlayer();


            //Assert
            Assert.Equal(new List<string>(), stage.CurrentRound.CurrentPlayer.GuessedWordsPerStage[stage]);

        }

        [Fact]
        public void GuessWordForCurrentPlayer_NoWordsRemaining_DoesNotAddWordsToPlayer()
        {
            //Arrange
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(3, 0, 0));
            stage.SetUpPlayerRound();
            stage.CurrentRound.RoundTimer.StartTimer();

            //Act


            stage.GuessWordForCurrentPlayer();
            stage.GuessWordForCurrentPlayer();
            stage.GuessWordForCurrentPlayer();


            //Assert
            Assert.Equal(new List<string>(), stage.CurrentRound.CurrentPlayer.GuessedWordsPerStage[stage]);

        }


    }
}
