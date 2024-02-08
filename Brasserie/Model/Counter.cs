using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model
{
    public class Counter
    {
        public Counter()
        {
            CounterValue = 0;
            LimitMax = 10;
            PreAlarmThresold = 8;
            UpdatePreAlarmStatus();
        }
        public int CounterValue { get; set; }
        public int LimitMax { get; set; }
        public int PreAlarmThresold { get; set; }
        public bool IsInPreAlarm { get; set; }
        public void IncrementCounter()
        {
            if (CounterValue + 1 <= LimitMax)
            {
                CounterValue++;
                UpdatePreAlarmStatus();
            }
        }
        private void UpdatePreAlarmStatus()
        {
            IsInPreAlarm = (CounterValue >= PreAlarmThresold);
        }
    }
}
