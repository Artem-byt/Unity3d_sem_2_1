using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids
{
    public class PlayerFireController : IExecute, IShot, IPlayerRocket
    {
        private PlayerWeaponModel _playerWeaponModel;
        private TimerModel _timerModel;
        private AmmoPool _ammoPool;
        private IActions _actionFire;
        private bool _isButtonDown;

        private const float TIME_OF_LIVING_ROCKET = 2f;

        public PlayerFireController(PlayerWeaponModel playerWeaponModel, IActions actions, AmmoPool ammoPool, TimerModel timerModel)
        {
            _timerModel = timerModel;
            _ammoPool = ammoPool;
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
                if (_ammoPool.HasFreeElement(out var element))
                {
                    element.transform.position = _playerWeaponModel.GetBarrel.position;
                    element.transform.rotation = _playerWeaponModel.GetBarrel.rotation;
                    var timer = new TimeData(TIME_OF_LIVING_ROCKET, null, element);
                    timer.OnTinerEndWithGameObject += CheckActiveRocketsPlayer;
                    _timerModel.Timers.Add(timer);
                }
            }
        }


        public void CheckActiveRocketsPlayer(GameObject gameObject)
        {
            var element = gameObject.transform;
            element.SetParent(_ammoPool.GetContainer.transform);
            element.position = _ammoPool.GetContainer.transform.position;
            element.gameObject.SetActive(false);
        }

    }
}

