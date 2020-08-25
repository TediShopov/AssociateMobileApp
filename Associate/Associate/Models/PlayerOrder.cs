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
        private List<ITeam> teamOrder;
        public PlayerOrder(List<ITeam> teams, bool toShuffle)
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

        private  void SetShuffledTeamOrder(List<ITeam> teams)
        {
            Random random = new Random();


            for (int i = teams.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                ITeam value = teams[rnd];
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
            this.playerOrder = new Queue<IPlayer>();
            int playerListIndex = 0;
            while (playerListIndex!=this.teamOrder[0].Members.Count)
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
