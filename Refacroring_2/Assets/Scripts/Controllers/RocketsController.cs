using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids
{
    public class RocketsController : IFixedExecute
    {
        private PlayerWeaponModel _playerWeaponModel;
        private TimerModel _timerModel;


        public RocketsController(PlayerWeaponModel playerWeaponModel, TimerModel timerModel)
        {
            _timerModel = timerModel;
            _playerWeaponModel = playerWeaponModel;
        }

        public void FixedExecute(float deltatime)
        {
            AddRocketForcePlayer();
        }

        public void AddRocketForcePlayer()
        {
            for (int i = 0; i < _timerModel.Timers.Count; i++)
            {
                if (_timerModel.Timers[i].GetActiveRocket != null)
                {
                    //Debug.Log("Ракета");
                    _timerModel.Timers[i].GetActiveRocket.transform.parent = null;
                    _timerModel.Timers[i].GetActiveRocket.GetComponent<Rigidbody2D>().AddForce(_timerModel.Timers[i].GetActiveRocket.transform.up * _playerWeaponModel.GetForce, ForceMode2D.Force);
                }

            }
        }
    }
}

