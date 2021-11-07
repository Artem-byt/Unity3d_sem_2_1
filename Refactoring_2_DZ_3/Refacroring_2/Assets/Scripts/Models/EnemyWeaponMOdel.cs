using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class EnemyWeaponMOdel : IPoolAutoExpand
    {
        private bool _autoExpand = false;
        private GameObject _ammoPrefab;

        public bool IsAutoExpand { get => _autoExpand; set => _autoExpand = value; }
        public GameObject GetAmmoPrefab { get => _ammoPrefab; }

        public EnemyWeaponMOdel()
        {
            _ammoPrefab = Resources.Load<PlayerWeaponInfo>("EnemyWeaponInfo").GetBullet.gameObject;
        }
    }
}

