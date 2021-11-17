using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    [Serializable]
    public sealed class Enemy
    {

        [NonSerialized]
        private GameObject _enemy;

        [NonSerialized]
        public Transform CurrentContainer;

        [NonSerialized]
        private AmmoPool _ammoPool;
        [NonSerialized]
        private EnemyModel _enemyModel;
        private int _id;

        public GameObject GameObject { get => _enemy; set => _enemy = value; }
        public AmmoPool GetAmmoPoolEnemy { get => _ammoPool; }
        public EnemyModel GetEnemyModel { get => _enemyModel; }
        public Enemy(Transform container, IEnemyFactory enemyFactory, EnemyWeaponMOdel poolModel, int indexPrefab)
        {
            CurrentContainer = container;

            _id = indexPrefab;

            _enemy = enemyFactory.CreateEnemy(CurrentContainer, indexPrefab);

            _enemyModel = new EnemyModel(_enemy.GetComponentInChildren<BurrelEnemyIdentificator>().transform);
            _enemyModel.IsRocketStarted = false;

            _ammoPool = new AmmoPool(poolModel.GetAmmoPrefab, _enemy.transform, poolModel);
            _enemy.GetComponent<EnemyCheckingCollider>().OnCollisionEnter += EnemyHealthControl;

        }

        public void SetNonSerializedParameters(IEnemyFactory enemyFactory, EnemyWeaponMOdel poolModel, Transform container)
        {
            CurrentContainer = container;

            _enemy = enemyFactory.CreateEnemy(CurrentContainer, _id);
            _enemyModel = new EnemyModel(_enemy.GetComponentInChildren<BurrelEnemyIdentificator>().transform);
            _enemyModel.IsRocketStarted = false;

            _ammoPool = new AmmoPool(poolModel.GetAmmoPrefab, _enemy.transform, poolModel);
            _enemy.GetComponent<EnemyCheckingCollider>().OnCollisionEnter += EnemyHealthControl;
            ServiceLocator.Resolve<EnemyPoolContainerInitialization>().Enemies.Add(this);
            ServiceLocator.Resolve<EnemyPoolContainerInitialization>().EnemiesRigidBody.Add(this.GameObject.GetComponent<Rigidbody2D>());
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
                _enemyModel.SetDefault();
                _enemy.transform.position = CurrentContainer.position;
                _enemyModel.InvokeOnEnemyDead(CurrentContainer);
                _enemy.SetActive(false);
            }
            else
            {
                _enemyModel.HP--;
            }
        }
    }
}

