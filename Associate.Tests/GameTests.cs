using Associate.Models.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Associate.Tests
{
   public class GameTests
    {

        public GameTests()
        {

        }

        public void Dispose()
        {
           
        }

        [Fact]
        public void GoToNextStage_NotLastStage_ChangesTheCurrentStage()
        {
            //Arrange
            var mock1 = new Mock<IStage>();


            //Act
            stage.SetUpPlayerRound();


            //Assert
            Assert.Equal("IvanOne", stage.CurrentRound.CurrentPlayer.Name);


        }

        [Fact]
        public void GoToNextStage_AlteringCollection_ChangesTheCurrentStage()
        {
            //Arrange
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(1, 0, 0));


            //Act
            stage.SetUpPlayerRound();


            //Assert
            Assert.Equal("IvanOne", stage.CurrentRound.CurrentPlayer.Name);


        }

        [Fact]
        public void GoToNextStage_LastStage_DoesNothing()
        {
            //Arrange
            Stage stage = new Stage(Words, PlayerOrder, new TimeSpan(1, 0, 0));


            //Act
            stage.SetUpPlayerRound();


            //Assert
            Assert.Equal("IvanOne", stage.CurrentRound.CurrentPlayer.Name);


        }
    }
}
