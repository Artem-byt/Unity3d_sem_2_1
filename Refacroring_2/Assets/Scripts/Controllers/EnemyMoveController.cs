using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyMoveController : RotationEnemy, IFixedExecute
    {
        private PLayerMoveModel _playerMoveModel;


        private const float SPEED = 0.1f;
        private const float MAGNITUDE_OF_EYE_ENEMY = 9f;
        public EnemyMoveController(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel)
        {
            _playerMoveModel = pLayerMoveModel;
        }

        public void FixedExecute(float deltaTime)
        {
            
            for (int i = 0; i < ServiceLocator.Resolve<EnemyPoolContainerInitialization>().Enemies.Count; i++)
            {
                var enemy = ServiceLocator.Resolve<EnemyPoolContainerInitialization>().Enemies[i];
                var enemyRigidBody = ServiceLocator.Resolve<EnemyPoolContainerInitialization>().EnemiesRigidBody[i];
                var direction = _playerMoveModel.GetTransform.position - enemy.GameObject.transform.position;
                var distance = (enemy.GameObject.transform.position - _playerTransform.position).magnitude;

                if (distance <= MAGNITUDE_OF_EYE_ENEMY)
                {
                    enemyRigidBody.WakeUp();
                    Rotation(direction, i);
                    enemyRigidBody.AddForce(direction * SPEED, ForceMode2D.Impulse);
                }
                else
                {
                    enemyRigidBody.Sleep();
                }
            }
        }
    }
}

