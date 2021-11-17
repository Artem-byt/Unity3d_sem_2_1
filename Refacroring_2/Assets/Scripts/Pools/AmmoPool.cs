using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    [Serializable]
    public class AmmoPool: Pool
    {
        private GameObject _prefab;

        private Transform _container;


        public Transform GetContainer { get => _container; }

        public AmmoPool(GameObject prefab, Transform container, IPoolAutoExpand poolModel) :base (poolModel)
        {


            _prefab = prefab;
            _container = container;
            CreatePool();
        }




        public override GameObject CreateObject(bool isActiveByDefault = false, Transform transform = null)
        {
            var gameObjectBuilder = new GameObjectBuilder(UnityEngine.Object.Instantiate(_prefab, _container));
            var createObject = gameObjectBuilder.Visual.Name("Ammo").Physics.BoxCollider2D().Rigidbody2D(5);
            createObject._gameObject.SetActive(isActiveByDefault);
            PoolOwner.Add(createObject);
            return createObject;
        }

    }
}

