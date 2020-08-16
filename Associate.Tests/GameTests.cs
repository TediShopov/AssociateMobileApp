using Associate.Models;
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

        

        [Fact]
        public void GoToNextStage_FirstStage_InitializesFirstStage()
        {
            //Arrange
            var mock1 = new Mock<IStage>();
            var mock2 = new Mock<IStage>();
            var mock3 = new Mock<IStage>();
            var mock4 = new Mock<IStage>();

            var listOfStages = new List<IStage> { mock1.Object, mock2.Object, mock3.Object, mock4.Object };

            var game = new Game();
            game.Stages = listOfStages;

            //Act
            game.GoToNextStage();


            //Assert
            Assert.Equal(mock1.Object, game.CurrentStage);


        }

        [Fact]
        public void GoToNextStage_NotLast_ChangesCurrentStage()
        {
            //Arrange
            var mock1 = new Mock<IStage>();
            var mock2 = new Mock<IStage>();
            var mock3 = new Mock<IStage>();
            var mock4 = new Mock<IStage>();

            var listOfStages = new List<IStage> { mock1.Object, mock2.Object, mock3.Object, mock4.Object };

            var game = new Game();
            game.Stages = listOfStages;

            //Act
            game.GoToNextStage();
            game.GoToNextStage();



            //Assert
            Assert.NotEqual(mock1.Object, game.CurrentStage);
            Assert.Equal(mock2.Object, game.CurrentStage);


        }

        [Fact]
        public void GoToNextStage_AlteringCollection_ChangesTheCurrentStage()
        {
            //Arrange
            var mock1 = new Mock<IStage>();
            var mock2 = new Mock<IStage>();
          

            var listOfStages = new List<IStage> { mock1.Object};

            var game = new Game();
            game.Stages = listOfStages;
            game.GoToNextStage();

            //Act


            game.Stages.Add(mock2.Object);
            game.GoToNextStage();
           


            //Assert
            Assert.NotEqual(mock1.Object, game.CurrentStage);
            Assert.Equal(mock2.Object, game.CurrentStage);

        }

        [Fact]
        public void GoToNextStage_LastStage_DoesNothing()
        {
            //Arrange
            var mock1 = new Mock<IStage>();
            var mock2 = new Mock<IStage>();
           
            var listOfStages = new List<IStage> { mock1.Object, mock2.Object};

            var game = new Game();
            game.Stages = listOfStages;
            game.GoToNextStage();
            game.GoToNextStage();
            //Act


            game.GoToNextStage();
            game.GoToNextStage();
            game.GoToNextStage();

            //Assert

            Assert.Equal(mock2.Object, game.CurrentStage);



            
        }
    }
}
