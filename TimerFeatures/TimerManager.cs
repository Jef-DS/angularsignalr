using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace angularsignalr.TimerFeatures
{
    public class TimerManager
    {
        private readonly Timer _timer;
        private readonly Action _action;
        public DateTime TimerStarted { get; set; }
        public TimerManager(Action action)
        {
            this._action = action;
            this._timer = new Timer(Execute, null, 1000, 1000);
            this.TimerStarted = DateTime.Now;
        }
        public void Execute(object stateInfo)
        {
            _action();
            if((DateTime.Now - TimerStarted).Seconds > 20)
            {
                _timer.Dispose();
            }
        }
    }
}
