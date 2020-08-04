using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Associate.Models
{
    public class Game : IGame
    {
        private IStage currentStage;
        private bool isFinished;
        private int currentStageIndex;
        public Game()
        {
            this.currentStageIndex = -1;
            this.isFinished = false;
            this.Stages = new List<IStage>();
            this.Teams = new List<ITeam>();
            this.winningCondition =new MostWordsGuessedWinningCondition(this.Stages);
            
        }
        public Game(IWinningCondition winningCondition)
        {
            this.currentStageIndex = -1;
            this.isFinished = false;
            this.Stages = new List<IStage>();
            this.Teams = new List<ITeam>();
            this.winningCondition = winningCondition;

        }

        public IStage CurrentStage { get { return currentStage; } }
        public IWinningCondition winningCondition { get; set; }

        public List<IStage> Stages { get; set; }

        public List<ITeam> Teams { get; set; }

        public bool IsFinished { get { return isFinished; } }

        public int NumberOfStages
        {
            get
            {
                if (this.Stages!=null)
                {
                    return this.Stages.Count;
                }
                else
                {
                    return 0;
                }
            } }

        public int NumberOfPlayers {
            get 
            {
                if (this.Teams != null)
                {
                    return this.Teams.Count * this.Teams[0].Members.Count;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int CurrentStageNumber { get { return this.currentStageIndex + 1; } }

       


        public void GoToNextStage()
        {
            if (this.currentStageIndex < this.Stages.Count - 1)
            {
                this.currentStageIndex++;
                this.currentStage = this.Stages[currentStageIndex];
            }
            else 
            {
                this.isFinished = true;
            }      
        }
    }
}
