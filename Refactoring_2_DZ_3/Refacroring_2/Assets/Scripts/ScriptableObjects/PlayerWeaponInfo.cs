using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New PlayerWeaponInfo")]
    public class PlayerWeaponInfo : ScriptableObject
    {
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        public Rigidbody2D GetBullet { get => _bullet; }
        public Transform GetBarrel { get => _barrel; }
        public float GetForce { get => _force; }
    }
}

