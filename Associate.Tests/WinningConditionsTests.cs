using Associate.Models;
using Associate.Models.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Associate.Tests
{
    public class WinningConditionsTests
    {
        Mock<IStage> mockStage1;
        Mock<ITeam> teamMock1;
        Mock<ITeam> teamMock2;
        public WinningConditionsTests()
        {
             mockStage1 = new Mock<IStage>();


             teamMock1 = new Mock<ITeam>();

             teamMock2 = new Mock<ITeam>();
           
        }
        [Fact]
        public void MostWordsGuessed_Normal_ReturnsCorrectWinner() 
        {
            //Arrange
            teamMock1.Setup(x => x.GuessedWordsForStage(mockStage1.Object)).Returns(new List<string>() { "aa", "bb", "cc" });
            teamMock2.Setup(x => x.GuessedWordsForStage(mockStage1.Object)).Returns(new List<string>() { "aaa", "bbb", "ccc", "асдасда" });
            MostWordsGuessedWinningCondition mostWordsGuessed = new MostWordsGuessedWinningCondition();
            mostWordsGuessed.Stage = new List<IStage>() { mockStage1.Object };
            mostWordsGuessed.Teams = new List<ITeam>() { teamMock1.Object, teamMock2.Object };
            //Act
            var winner=mostWordsGuessed.GetWinner();

            //Assert
            Assert.Equal(teamMock2.Object, winner);
           
          
        }

        [Fact]
        public void PredeterminedStagePoints_Normal_ReturnsCorrectWinner()
        {
            //Arrange
            var mockStage2 = new Mock<IStage>();

            //Setup words for first round
            teamMock1.Setup(x => x.GuessedWordsForStage(mockStage1.Object)).Returns(new List<string>() { "aa", "bb", "cc" });
            teamMock2.Setup(x => x.GuessedWordsForStage(mockStage1.Object)).Returns(new List<string>() { });

            //Setup words for second round
            teamMock1.Setup(x => x.GuessedWordsForStage(mockStage2.Object)).Returns(new List<string>() {  });
            teamMock2.Setup(x => x.GuessedWordsForStage(mockStage2.Object)).Returns(new List<string>() { "aa","bb"});

            //Setup points for words
            var pointsPerStage = new Dictionary<IStage, int>();
            pointsPerStage.Add(mockStage1.Object, 1);
            pointsPerStage.Add(mockStage2.Object, 2);

            PredeterminedPointsPerStageWinningCondition mostWordsGuessed = new PredeterminedPointsPerStageWinningCondition(pointsPerStage);
            mostWordsGuessed.Teams = new List<ITeam>() { teamMock1.Object, teamMock2.Object };

            //Act
            var winner = mostWordsGuessed.GetWinner();

            //Assert
            Assert.Equal(teamMock2.Object, winner);


        }
    }
}
