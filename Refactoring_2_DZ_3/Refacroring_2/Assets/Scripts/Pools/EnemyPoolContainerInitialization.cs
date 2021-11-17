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

        public EnemyContainerModel GetContainerModel { get => _containerModel; }

        public EnemyPoolContainerInitialization(IEnemyFactory enemyFactory, EnemyWeaponMOdel poolModel)
        {
            _poolModel = poolModel;
            Enemies = new List<Enemy>();
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
            var createObject = new Enemy(transform, _enemyFactory, _poolModel, prefabNumber, _containerModel);
            createObject.GetEnemyModel.SetDefault();
            createObject.GetEnemy.SetActive(isActiveByDefault);
            Enemies.Add(createObject);
            return createObject;
        }

        public bool HasFreeElement(out Enemy element)
        {
            foreach (var poolElement in Enemies)
            {
                if (!poolElement.GetEnemy.activeInHierarchy)
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

