using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerWeaponModel
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;

        public Rigidbody2D GetBullet { get => _bullet; }
        public Transform GetBarrel { get => _barrel; }
        public float GetForce { get => _force; }

        public PlayerWeaponModel()
        {
            _bullet = Resources.Load<PlayerWeaponInfo>("PlayerWeaponInfo").GetBullet;
            _barrel = GameObject.FindObjectOfType<BurrelIdentificationObject>().transform;
            Debug.Log(_barrel);
            _force = Resources.Load<PlayerWeaponInfo>("PlayerWeaponInfo").GetForce;
        }
}
}

