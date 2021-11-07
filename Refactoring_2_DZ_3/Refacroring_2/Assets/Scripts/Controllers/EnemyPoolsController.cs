using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class EnemyPoolsController : IExecute
    {
        private EnemyContainerModel _enemyContainer;
        private EnemyPoolContainerInitialization _enemyPool;
        private TimerModel _timerModel;
        private PLayerMoveModel _playerMoveModel;



        private const float MAGNITUDE_OF_EYE_ENEMY = 9f;
        public EnemyPoolsController(EnemyPoolContainerInitialization enemyPool, TimerModel timerModel, PLayerMoveModel playerMoveModel)
        {
            _playerMoveModel = playerMoveModel;
            _timerModel = timerModel;
            _enemyPool = enemyPool;
            _enemyContainer = enemyPool.GetContainerModel;
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemyContainer.GetEnemyRespawns.Count; i++)
            {
                var distance = (_enemyContainer.GetEnemyRespawns[i].position - _playerMoveModel.GetTransform.position).magnitude;
                if (distance <= MAGNITUDE_OF_EYE_ENEMY && _enemyPool.HasFreeElement(out var enemy) && !_enemyContainer.IsEnemyActive[i])
                {
                    enemy.Id = i;
                    _enemyContainer.IsEnemyActive[enemy.Id] = !_enemyContainer.IsEnemyActive[enemy.Id];
                    enemy.GetEnemy.transform.position = _enemyContainer.GetEnemyRespawns[i].position;
                    var timer = new TimeData(2f, enemy, null);
                    timer.OnTimerEndForEnemy += SetActivationEnemy;
                    _timerModel.Timers.Add(timer);
                }

            }
        }

        public void SetActivationEnemy(Enemy enemy)
        {
            //Debug.Log("Good Evening");
            enemy.GetEnemy.SetActive(true);
        }
    }
}

