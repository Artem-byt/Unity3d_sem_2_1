using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Asteroids
{
    public class EnemyModel
    {

        public event Action<Transform> OnEnemyDead;

        public List<bool> IsEnemyInRespawn;
        public int HP;
        public bool IsRocketStarted;
        private Transform _barrelEnemyPosition;

        public Transform GetBarrelEnemyPosition { get => _barrelEnemyPosition; }

        public EnemyModel(Transform barrelEnemyPosition)
        {
            _barrelEnemyPosition = barrelEnemyPosition;
            IsEnemyInRespawn = new List<bool>();
        }

        public void SetDefault()
        {
            HP = Resources.Load<EnemyInfo>("EnemyInfo").GetEnemyHP;
        }

        public void InvokeOnEnemyDead(Transform CurrentContainer)
        {
            OnEnemyDead?.Invoke(CurrentContainer);
        }


    }
}

