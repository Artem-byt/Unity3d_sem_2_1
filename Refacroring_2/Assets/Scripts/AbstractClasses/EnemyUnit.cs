using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public abstract class EnemyUnit : Unit, IDisposable
    {
        public event Action<Enemy> OnTimerEndForEnemy = delegate (Enemy enemy) { };

        private Enemy _enemy;

        public EnemyUnit(Enemy enemy ,GameObject rocket) : base (rocket)
        {
            _enemy = enemy;
        }

        public void InvokeTimerEndActionForEnemy()
        {
            OnTimerEndForEnemy?.Invoke(_enemy);
        }

        public override void Dispose()
        {
            base.Dispose();
            OnTimerEndForEnemy = null;
        }
    }
}

