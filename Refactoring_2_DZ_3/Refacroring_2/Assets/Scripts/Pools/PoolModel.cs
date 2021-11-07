using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PoolModel: IPoolAutoExpand
    {
        private bool _autoExpand = false;
        private GameObject _ammoPrefab;

        public bool IsAutoExpand { get => _autoExpand; set => _autoExpand = value; }
        public GameObject GetAmmoPrefab { get => _ammoPrefab; }

        public PoolModel()
        {
            _ammoPrefab = Resources.Load<PlayerWeaponInfo>("PlayerWeaponInfo").GetBullet.gameObject;
        }
    }
}

