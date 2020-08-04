using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IPlayerOrder
    {
        IPlayer GoToNextPlayer();
        IPlayer PeekNextPlayer();

        Queue<IPlayer> Order { get; }
    }
}
