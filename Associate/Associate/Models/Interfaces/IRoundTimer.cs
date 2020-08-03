using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Associate.Models.Interfaces
{
    public interface IRoundTimer
    {
        TimeSpan TimeLeft { get; }
        Action OnEachTick { get; set; }
    }
}
