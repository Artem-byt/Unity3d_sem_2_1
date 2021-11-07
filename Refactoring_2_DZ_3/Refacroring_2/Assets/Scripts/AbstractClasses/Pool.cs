using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Pool
    {

        public List<GameObject> PoolOwner;

        private IPoolAutoExpand _poolModel;
        private const int DEFAULT_COUNT_OF_AMMO = 5;


        public Pool(IPoolAutoExpand poolModel)
        {
            _poolModel = poolModel;
        }
        public virtual void CreatePool()
        {
            PoolOwner = new List<GameObject>();
            for (int i = 0; i < DEFAULT_COUNT_OF_AMMO; i++)
            {
                CreateObject();
            }
        }

        public virtual bool HasFreeElement(out GameObject element)
        {
            foreach (var poolElement in PoolOwner)
            {
                if (!poolElement.gameObject.activeInHierarchy)
                {
                    element = poolElement;
                    poolElement.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }


        public virtual GameObject GetFreeElement(int numberOfPool)
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            if (_poolModel.IsAutoExpand)
            {
                return CreateObject(true);
            }

            return null;
        }

        public abstract GameObject CreateObject(bool isActiveByDefault = false, Transform transform = null);

    }
}

