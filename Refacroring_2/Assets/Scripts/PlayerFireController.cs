using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerFireController : IExecute, IShot
    {
        private PlayerWeaponModel _playerWeaponModel;
        private IActions _actionFire;
        private bool _isButtonDown;

        public PlayerFireController(PlayerWeaponModel playerWeaponModel, IActions actions)
        {
            _playerWeaponModel = playerWeaponModel;
            _actionFire = actions;
            _actionFire.OnFireButtonDown += GetButtonDown;
        }

        public void GetButtonDown(bool f)
        {
            _isButtonDown = f;
        }



        public void Execute(float deltaTime)
        {
            Shot();
        }

        public void Shot()
        {
            if (_isButtonDown)
            {
                var temAmmunition = GameObject.Instantiate(_playerWeaponModel.GetBullet, _playerWeaponModel.GetBarrel.position, _playerWeaponModel.GetBarrel.rotation);
                temAmmunition.AddForce(temAmmunition.transform.up * _playerWeaponModel.GetForce);
            }
        }


    }
}

