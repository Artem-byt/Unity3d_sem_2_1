using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyModel
    {
        public List<bool> IsEnemyInRespawn;


        public int HP;
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


    }
}

