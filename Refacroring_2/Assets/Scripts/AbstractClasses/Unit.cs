using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public abstract class Unit: IUnit, IDisposable
    {
        public event Action<GameObject> OnTinerEndWithGameObject = delegate (GameObject gameObject) { };

        private GameObject _rocket;

        public GameObject GetActiveRocket { get => _rocket; }

        public Unit(GameObject rocket)
        {
            _rocket = rocket;
        }

        public void InvokeTimerEndActionWithGameObject()
        {
            OnTinerEndWithGameObject?.Invoke(_rocket);
        }

        public virtual void Dispose()
        {
            //Debug.Log("Вызвано");
            OnTinerEndWithGameObject = null;
        }
    }
}

