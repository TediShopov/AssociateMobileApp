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
        IEnumerator<IStage> stageEnumerator;
        public Game()
        {
            this.currentStageIndex = -1;
            this.isFinished = false;
            this.Stages = new List<IStage>();
            this.stageEnumerator = this.Stages.GetEnumerator();
            this.Teams = new List<ITeam>();
            this.WinningCondition =new MostWordsGuessedWinningCondition();
            
        }
        public Game(IWinningCondition winningCondition)
        {
            
            this.isFinished = false;
            this.Stages = new List<IStage>();
            this.Teams = new List<ITeam>();
            this.WinningCondition = winningCondition;

        }

        public IStage CurrentStage { get { return this.Stages[currentStageIndex]; } }

        private IWinningCondition winningCondition;

        public IWinningCondition WinningCondition
        {
            get {
                
                  winningCondition.Teams = this.Teams;
                winningCondition.Stage = this.Stages;
                return winningCondition;
            }
            set { winningCondition = value; }
        }

       

        public List<IStage> Stages { get; set; }

        public List<ITeam> Teams { get; set; }

        public bool IsFinished { get { return isFinished; } }

        public bool OnLastStage { get { return CurrentStage == this.Stages.Last(); } }

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

            //With IEnumerator()
            //if (this.Stages.GetEnumerator().MoveNext()==false)
            //{
            //    this.isFinished = true;
            //}

        }
    }
}
