using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class PlayerOrder : IPlayerOrder
    {
        public Queue<IPlayer> Order { get { return playerOrder; } }
        private Queue<IPlayer> playerOrder;
        private List<Team> teamOrder;
        public PlayerOrder(List<Team> teams, bool toShuffle)
        {
            if (toShuffle)
            {
                SetShuffledTeamOrder(teams);
            }
            else
            {
                this.teamOrder = teams;
            }
            
            InitializePlayerOrder();
        }

        private  void SetShuffledTeamOrder(List<Team> teams)
        {
            Random random = new Random();


            for (int i = teams.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                Team value = teams[rnd];
                teams[rnd] = teams[i];
                teams[i] = value;
            }
            this.teamOrder = teams;
        }

        public PlayerOrder(Queue<IPlayer> playerOrder)
        {
            this.playerOrder=playerOrder;
        }
        public void InitializePlayerOrder()
        {
            int playerListIndex = 0;
            while (playerListIndex==this.teamOrder.Count-1)
            {
                foreach (var team in this.teamOrder)
                {
                    this.playerOrder.Enqueue(team.Members[playerListIndex]);
            }
                playerListIndex++;
            }
            
        }

        public IPlayer PeekNextPlayer()
        {
            return this.playerOrder.Peek();
        }

        public IPlayer GoToNextPlayer()
        {
            var playerToReturn=this.playerOrder.Dequeue();
            this.playerOrder.Enqueue(playerToReturn);
            return playerToReturn;
        }
    }
}
