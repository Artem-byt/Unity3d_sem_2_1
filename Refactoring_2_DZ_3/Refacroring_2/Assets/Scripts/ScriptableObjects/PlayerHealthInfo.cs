using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New PlayerHealthInfo")]
    public class PlayerHealthInfo : ScriptableObject
    {
        [SerializeField] private float _hp;

        public float GetHP { get => _hp; }
    }
}

