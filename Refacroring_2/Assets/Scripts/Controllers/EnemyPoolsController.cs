using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class EnemyPoolsController : IExecute
    {
        private EnemyContainerModel _enemyContainer;
        private TimerModel _timerModel;
        private PLayerMoveModel _playerMoveModel;
        private IEnemyFactory _enemyFactory;
        private EnemyWeaponMOdel _enemyWeapon;



        private const float MAGNITUDE_OF_EYE_ENEMY = 9f;
        public EnemyPoolsController(TimerModel timerModel, PLayerMoveModel playerMoveModel, IEnemyFactory enemyFactory, EnemyWeaponMOdel enemyWeapon)
        {
            _enemyWeapon = enemyWeapon;
            _enemyFactory = enemyFactory;
            _playerMoveModel = playerMoveModel;
            _timerModel = timerModel;
            _enemyContainer = ServiceLocator.Resolve<EnemyPoolContainerInitialization>().GetContainerModel;
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemyContainer.GetEnemyRespawns.Count; i++)
            {
                var distance = (_enemyContainer.GetEnemyRespawns[i].position - _playerMoveModel.GetTransform.position).magnitude;
                bool poolHasFreeElement = ServiceLocator.Resolve<EnemyPoolContainerInitialization>().HasFreeElement(out var enemy);

                if (distance <= MAGNITUDE_OF_EYE_ENEMY && poolHasFreeElement && !_enemyContainer.HasActiveEnemy[i])
                {
                    SetClone(enemy, i);
                }

            }
        }

        private void SetClone(Enemy enemy, int i)
        {
            Enemy enemyClone = enemy.DeepCopy();
            enemyClone.SetNonSerializedParameters(_enemyFactory, _enemyWeapon, _enemyContainer.GetEnemyRespawns[i]);
            enemyClone.GetEnemyModel.OnEnemyDead += _enemyContainer.SetInActiveStatusEnemy;
            enemyClone.GameObject.transform.position = _enemyContainer.GetEnemyRespawns[i].position;
            _enemyContainer.HasActiveEnemy[i] = !_enemyContainer.HasActiveEnemy[i];


            var timer = new TimeData(2f, enemyClone, null);
            timer.OnTimerEndForEnemy += SetActivationEnemy;
            _timerModel.Timers.Add(timer);
        }

        public void SetActivationEnemy(Enemy enemy)
        {
            //Debug.Log("Good Evening");
            enemy.GameObject.SetActive(true);
        }
    }
}

