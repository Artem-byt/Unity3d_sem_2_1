using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyFireController : IExecute
    {


        private List<Enemy> _enemies;
        private EnemyFireInitialization _enemyFireInitialization;
        private PLayerMoveModel _playerMoveModel;
        private TimerModel _timerModel;


        private const float MAGNITUDE_OF_EYE_ENEMY_FOR_START_ROCKET = 9f;
        private const float TIME_OF_ROCKET_START = 2f;

        public EnemyFireController(List<Enemy> enemies, EnemyFireInitialization enemyFireInitialization, PLayerMoveModel playerMoveModel, TimerModel timerModel)
        {
            _timerModel = timerModel;
            _playerMoveModel = playerMoveModel;
            _enemies = enemies;
            _enemyFireInitialization = enemyFireInitialization;
        }


        public void Execute(float deltaTime)
        {
            for(int i =0; i< _enemies.Count; i++)
            {
                var distance = (_enemies[i].GetEnemy.transform.position - _playerMoveModel.GetTransform.position).magnitude;
                if (distance <= MAGNITUDE_OF_EYE_ENEMY_FOR_START_ROCKET && !_enemies[i].IsRocketStarted && _enemies[i].GetEnemy.activeInHierarchy)
                {
                    _enemies[i].IsRocketStarted = !_enemies[i].IsRocketStarted;
                    _enemyFireInitialization.Fire(_enemies[i]);
                    var timer = new TimeData(TIME_OF_ROCKET_START, _enemies[i], null);
                    timer.OnTimerEndForEnemy += ChangeFlag;
                    _timerModel.Timers.Add(timer);

                }
            }     
        }

        public void ChangeFlag(Enemy enemy)
        {
            enemy.IsRocketStarted = !enemy.IsRocketStarted;
        }

    }
}

