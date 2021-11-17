using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class EnemyFireInitialization
    {
        private TimerModel _timerModel;

        private const float TIME_OF_LIVING_ROCKET = 3f;

        public EnemyFireInitialization(TimerModel timerModel)
        {
            _timerModel = timerModel;
        }

        public void Fire(Enemy enemy)
        {
            if (enemy.GetAmmoPoolEnemy.HasFreeElement(out var element))
            {
                element.transform.position = enemy.GetEnemyModel.GetBarrelEnemyPosition.position;
                element.transform.rotation = enemy.GetEnemyModel.GetBarrelEnemyPosition.rotation;
                var timer = new TimeData(TIME_OF_LIVING_ROCKET, null, element);
                timer.OnTinerEndWithGameObject += enemy.CheckActiveRocketsEnemy;
                _timerModel.Timers.Add(timer);
            }
        }


    }
}

