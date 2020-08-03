using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        Dictionary<int,int> Points { get; set; }

        void AddPointsOnStage();




    }
}
