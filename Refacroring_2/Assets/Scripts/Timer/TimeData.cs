using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Asteroids
{
    public class TimeData : EnemyUnit, IDisposable
    {

        public event Action OnTimerEnd = delegate () { };


        private readonly float _startTime;
        private readonly float _deltaTime;

        public float GetStartTime { get => _startTime; }
        public float GetDeltaTime { get => _deltaTime; }

        public TimeData(float deltaTime, Enemy enemy, GameObject _activeRocket): base(enemy, _activeRocket)
        {
            _startTime = Time.time;
            _deltaTime = deltaTime;
        }


        public void InvokeTimerEnd()
        {
            OnTimerEnd.Invoke();
        }

        public override void Dispose()
        {
            base.Dispose();
            OnTimerEnd = null;
        }
    }
}

