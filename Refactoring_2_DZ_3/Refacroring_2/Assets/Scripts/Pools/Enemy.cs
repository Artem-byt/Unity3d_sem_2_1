using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public sealed class Enemy
    {
        public int Id;
        public bool IsRocketStarted;

        private GameObject _enemy;
        private Transform _container;
        private AmmoPool _ammoPool;
        private EnemyModel _enemyModel;
        private EnemyContainerModel _enemyContainerModel;

        public GameObject GetEnemy { get => _enemy; }
        public Transform _GetContainer { get => _container; }

        public AmmoPool GetAmmoPoolEnemy { get => _ammoPool; }

        public EnemyModel GetEnemyModel { get => _enemyModel; }

        public Enemy(Transform container, IEnemyFactory enemyFactory, EnemyWeaponMOdel poolModel, int indexPrefab, EnemyContainerModel enemyContainer)
        {
            Id = 0;
            IsRocketStarted = false;

            _enemyContainerModel = enemyContainer;
            _container = container;
            _enemy = enemyFactory.CreateEnemy(_container, indexPrefab);

            _enemyModel = new EnemyModel(_enemy.GetComponentInChildren<BurrelEnemyIdentificator>().transform);
            _ammoPool = new AmmoPool(poolModel.GetAmmoPrefab, _enemy.transform, poolModel);
            _enemy.GetComponent<EnemyCheckingCollider>().OnCollisionEnter += EnemyHealthControl;

        }

        public void CheckActiveRocketsEnemy(GameObject gameObject)
        {
            var element = gameObject.transform;
            element.SetParent(_ammoPool.GetContainer.transform);
            element.position = _ammoPool.GetContainer.transform.position;
            element.gameObject.SetActive(false);
        }

        private void EnemyHealthControl(Collision2D collision2D)
        {
            if (collision2D.gameObject.layer == 3)
            {
                collision2D.gameObject.SetActive(false);
            }
            
            if (_enemyModel.HP <= 0)
            {
                Debug.Log(_container.position);
                _enemy.transform.position = _container.position;
                _enemyModel.SetDefault();
                _enemyContainerModel.IsEnemyActive[Id] = !_enemyContainerModel.IsEnemyActive[Id];

                _enemy.SetActive(false);
            }
            else
            {
                _enemyModel.HP--;
            }
        }
    }
}

