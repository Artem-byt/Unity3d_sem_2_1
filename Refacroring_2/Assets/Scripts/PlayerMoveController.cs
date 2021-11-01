using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PlayerMoveController : AccelerationMove, IExecute
{
        private PLayerMoveModel _playerMoveModel;

        public PlayerMoveController(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel)
        {
            _playerMoveModel = pLayerMoveModel;

        }

        public void Execute(float deltaTime)
        {
            Move(_playerMoveModel.GetHorizontal, _playerMoveModel.GetVertical, Time.deltaTime);

            if (_playerMoveModel.GetLeftShiftDown)
            {
                AddAcceleration();
            }

            if (_playerMoveModel.GetLeftShiftUp)
            {
                RemoveAcceleration();
            }
        }
    }
}

