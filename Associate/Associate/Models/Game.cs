using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Associate.Models
{
    public class Game : IGame
    {
        public Game()
        {
            this.currentStageIndex = -1;
            this.isFinished = false;
            this.Stages = new List<IStage>();
            this.Teams = new List<ITeam>();
            
        }
        private IStage currentStage;
        public IStage CurrentStage { get { return currentStage; } }

        public List<IStage> Stages { get; set; }

        public List<ITeam> Teams { get; set; }

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

        private bool isFinished;
        public bool IsFinished { get; }

        private int currentStageIndex;
        public int CurrentStageNumber { get { return this.currentStageIndex + 1; } }

        public ITeam GetWinner()
        {
            throw new NotImplementedException();
        }

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
