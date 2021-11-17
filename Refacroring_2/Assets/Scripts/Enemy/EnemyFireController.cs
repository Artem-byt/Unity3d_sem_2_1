using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyFireController : IExecute
    {

        private EnemyFireInitialization _enemyFireInitialization;
        private PLayerMoveModel _playerMoveModel;
        private TimerModel _timerModel;


        private const float MAGNITUDE_OF_EYE_ENEMY_FOR_START_ROCKET = 9f;
        private const float TIME_OF_ROCKET_START = 2f;

        public EnemyFireController( EnemyFireInitialization enemyFireInitialization, PLayerMoveModel playerMoveModel, TimerModel timerModel)
        {
            _timerModel = timerModel;
            _playerMoveModel = playerMoveModel;
            _enemyFireInitialization = enemyFireInitialization;
        }


        public void Execute(float deltaTime)
        {
            var enemies = ServiceLocator.Resolve<EnemyPoolContainerInitialization>().Enemies;
            for (int i =0; i< enemies.Count; i++)
            {
                var enemy = ServiceLocator.Resolve<EnemyPoolContainerInitialization>().Enemies[i];
                var distance = (enemy.GameObject.transform.position - _playerMoveModel.GetTransform.position).magnitude;
                if (distance <= MAGNITUDE_OF_EYE_ENEMY_FOR_START_ROCKET && !enemy.GetEnemyModel.IsRocketStarted && enemy.GameObject.activeInHierarchy)
                {
                    enemy.GetEnemyModel.IsRocketStarted = !enemy.GetEnemyModel.IsRocketStarted;
                    _enemyFireInitialization.Fire(enemy);
                    var timer = new TimeData(TIME_OF_ROCKET_START, enemy, null);
                    timer.OnTimerEndForEnemy += ChangeFlag;
                    _timerModel.Timers.Add(timer);

                }
            }     
        }

        public void ChangeFlag(Enemy enemy)
        {
            enemy.GetEnemyModel.IsRocketStarted = !enemy.GetEnemyModel.IsRocketStarted;
        }

    }
}

