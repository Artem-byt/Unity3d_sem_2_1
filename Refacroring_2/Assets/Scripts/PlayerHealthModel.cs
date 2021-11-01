using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PlayerHealthModel
    {
        public float _hp;
        private PlayerCollisionView _playerCollisionView;

        public PlayerCollisionView GetPlayerCollision { get => _playerCollisionView; }

        public PlayerHealthModel()
        {
            _hp = Resources.Load<PlayerHealthInfo>("PLayerHealthInfo").GetHP;
            _playerCollisionView = GameObject.FindObjectOfType<PlayerCollisionView>();
        }
    }
}

