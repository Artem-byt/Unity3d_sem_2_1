using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyPoolContainerInitialization
    {
        private IEnemyFactory _enemyFactory;
        private EnemyContainerModel _containerModel;
        private EnemyWeaponMOdel _poolModel;

        public List<Enemy> Enemies;
        public List<Rigidbody2D> EnemiesRigidBody;

        public EnemyContainerModel GetContainerModel { get => _containerModel; }

        public EnemyPoolContainerInitialization(IEnemyFactory enemyFactory, EnemyWeaponMOdel poolModel)
        {
            _poolModel = poolModel;
            Enemies = new List<Enemy>();
            EnemiesRigidBody = new List<Rigidbody2D>();
            _containerModel = new EnemyContainerModel();
            _enemyFactory = enemyFactory;
            CreatePool();
        }

        public void CreatePool()
        {
            for (int j = 0; j < _containerModel.GetTypesOfEnemy.Count; j++)
            {
                CreateEnemy(_containerModel.GetEnemyPoolRespawn, default, j);
            }
        }


        public Enemy CreateEnemy(Transform transform = null, bool isActiveByDefault = false, int prefabNumber = 0)
        {
            var createObject = new Enemy(transform, _enemyFactory, _poolModel, prefabNumber);
            createObject.GetEnemyModel.OnEnemyDead += _containerModel.SetInActiveStatusEnemy;
            createObject.GetEnemyModel.SetDefault();
            createObject.GameObject.SetActive(isActiveByDefault);
            Enemies.Add(createObject);
            EnemiesRigidBody.Add(createObject.GameObject.GetComponent<Rigidbody2D>());
            return createObject;
        }

        public bool HasFreeElement(out Enemy element)
        {
            foreach (var poolElement in Enemies)
            {
                if (!poolElement.GameObject.activeInHierarchy)
                {
                    element = poolElement;
                    return true;
                }
            }

            element = null;
            return false;
        }

        public Enemy GetFreeElement(EnemyContainerModel enemyContainerModel)
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            if (enemyContainerModel.IsAutoExpand)
            {
                return CreateEnemy(default, true);
            }

            return null;
        }
    }
}

