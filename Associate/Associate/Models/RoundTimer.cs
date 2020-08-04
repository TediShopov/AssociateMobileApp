using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;

namespace Associate.Models
{
    public class RoundTimer : IRoundTimer
    {
        public RoundTimer(TimeSpan timeSpan)
        {
            this.timeLeft = timeSpan;
            SetTimer();
            this.isStarted = false;
            this.isOver = false;
        }
        private TimeSpan timeLeft;
        public TimeSpan TimeLeft { get { return timeLeft; } }

        public Action OnEachTick { get; set; }

        private Timer timer;

        private bool isOver;
        public bool IsOver { get { return isOver; } }

        private bool isStarted;
        public bool IsStarted { get { return isStarted; } }

        private  void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
          
        }

        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (this.timeLeft.TotalSeconds == 1)
            {
                StopTimer();
            }
            else
            {
                this.timeLeft = this.TimeLeft.Subtract(new TimeSpan(0, 0, 1));

                if (this.OnEachTick == null)
                {
                    this.OnEachTick.Invoke();
                }
            }
           
        }

        public void StartTimer()
        {
            timer.Start();
            this.isStarted = true;
        }

        public void StopTimer()
        {
            timer.Stop();
            this.isOver = true;
        }
    }
}
