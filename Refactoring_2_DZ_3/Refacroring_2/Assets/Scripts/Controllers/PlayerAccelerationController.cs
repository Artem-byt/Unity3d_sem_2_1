using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PlayerAccelerationController : AccelerationMove, IExecute
{
        private PLayerMoveModel _playerMoveModel;

        public PlayerAccelerationController(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel)
        {
            _playerMoveModel = pLayerMoveModel;

        }

        public void Execute(float deltaTime)
        {
            

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

