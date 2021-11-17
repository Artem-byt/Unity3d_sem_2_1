using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class AmmoPool: Pool
    {
        private GameObject _prefab;
        private Transform _container;
        private PoolModel PoolModel;

        public GameObject GetPrefab { get => _prefab; }
        public Transform GetContainer { get => _container; }



        public AmmoPool(GameObject prefab, Transform container, IPoolAutoExpand poolModel) :base (poolModel)
        {
            _prefab = prefab;
            _container = container;
            CreatePool();
        }



        public override GameObject CreateObject(bool isActiveByDefault = false, Transform transform = null)
        {
            var createObject = Object.Instantiate(_prefab, _container);
            createObject.gameObject.SetActive(isActiveByDefault);
            PoolOwner.Add(createObject);
            return createObject;
        }

    }
}

