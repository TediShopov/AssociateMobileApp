using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IRound
    {
        IPlayer CurrentPlayer { get; }
        IRoundTimer RoundTimer { get; }
        
        int PointsScored { get; }
    }
}
