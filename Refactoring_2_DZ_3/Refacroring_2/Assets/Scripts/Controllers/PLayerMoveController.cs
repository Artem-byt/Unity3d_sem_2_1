using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PLayerMoveController : MoveTransform, IFixedExecute
    {
        private PLayerMoveModel _playerMoveModel;

        public PLayerMoveController(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel)
        {
            _playerMoveModel = pLayerMoveModel;
        }

        public void FixedExecute(float deltatime)
        {
            Move(_playerMoveModel.GetHorizontal, _playerMoveModel.GetVertical, Time.deltaTime);
        }
    }
}

