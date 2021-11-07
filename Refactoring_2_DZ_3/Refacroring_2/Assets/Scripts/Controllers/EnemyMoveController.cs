using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyMoveController : RotationEnemy, IFixedExecute
    {
        private List<Enemy> _enemies;
        private PLayerMoveModel _playerMoveModel;
        private List<Rigidbody2D> _enemiesRigidBody;
        private EnemyFireInitialization _fireInitialization;
        private TimerModel _timerModel;

        private const float SPEED = 0.1f;
        private const float MAGNITUDE_OF_EYE_ENEMY = 16f;
        public EnemyMoveController(List<Enemy> enemies, PLayerMoveModel pLayerMoveModel, EnemyFireInitialization enemyFireInitialization, TimerModel timerModel) : base(enemies, pLayerMoveModel)
        {
            _timerModel = timerModel;
            _fireInitialization = enemyFireInitialization;
            _enemiesRigidBody = new List<Rigidbody2D>();
            _playerMoveModel = pLayerMoveModel;
            _enemies = enemies;

            for(int i =0; i< _enemies.Count; i++)
            {
                _enemiesRigidBody.Add(_enemies[i].GetEnemy.GetComponent<Rigidbody2D>());
            }
        }

        public void FixedExecute(float deltaTime)
        {
            
            for (int i = 0; i < _enemies.Count; i++)
            {
                var direction = _playerMoveModel.GetTransform.position - _enemies[i].GetEnemy.transform.position;
                var distance = (_enemies[i].GetEnemy.transform.position - _playerTransform.position).magnitude;
                if (distance <= MAGNITUDE_OF_EYE_ENEMY)
                {
                    _enemiesRigidBody[i].WakeUp();
                    Rotation(direction, i);
                    _enemiesRigidBody[i].AddForce(direction * SPEED, ForceMode2D.Impulse);


                }
                else
                {
                   _enemiesRigidBody[i].Sleep();
                }
            }
        }
    }
}

