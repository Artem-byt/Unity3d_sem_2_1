using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New PlayerMoveInfo")]
    public class PlayerMoveInfo : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Transform _transform;

        public float GetSpeed { get => _speed; }
        public float GetAcceleration { get => _acceleration; }
        public Transform GetTransform { get => _transform; }
    }
}

