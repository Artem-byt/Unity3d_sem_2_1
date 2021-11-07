using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerHealthInitialization
    {
        private PlayerHealthModel _playerHealthModel;
        private GameObject gameObject;

        public PlayerHealthInitialization(PlayerHealthModel playerHealthModel, GameObject player)
        {
            _playerHealthModel = playerHealthModel;
            gameObject = player;
            _playerHealthModel.GetPlayerCollision.OnCollisionEnter += PlayerHealthControl;
        }
        
        public void PlayerHealthControl()
        {

            if (_playerHealthModel._hp <= 0)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                _playerHealthModel._hp--;
            }
        }

    }
}

