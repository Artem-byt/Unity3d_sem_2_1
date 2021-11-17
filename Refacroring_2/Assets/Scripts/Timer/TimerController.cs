using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TimerController : IExecute
    {
        private TimerModel _timerModel;

       // private const float REQUIRED_FOR_DELETING_TIMER_TIME = 60f;

        public TimerController(TimerModel timerModel)
        {
            _timerModel = timerModel;
        }

        public void RemoveTimeData(TimeData timeData)
        {
            _timerModel.Timers.Remove(timeData);
            
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _timerModel.Timers.Count; i++)
            {
                var deltaTimerTime = (Time.time - _timerModel.Timers[i].GetStartTime);
                if (deltaTimerTime >= _timerModel.Timers[i].GetDeltaTime)
                {
                    _timerModel.Timers[i].InvokeTimerEnd();
                    _timerModel.Timers[i].InvokeTimerEndActionForEnemy();
                    _timerModel.Timers[i].InvokeTimerEndActionWithGameObject();
                    _timerModel.Timers[i].Dispose();
                    RemoveTimeData(_timerModel.Timers[i]);
                }
            }
        }
    }
}

