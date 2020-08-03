using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface ITeam
    {
        List<IPlayer> Members { get; set; }
        int TotalPoints { get; }


    }
}
