using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerRotationController : RotationShip, IExecute
    {
        private PLayerMoveModel _playerMoveModel;
        private Camera _camera;

        public PlayerRotationController(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel)
        {
            _camera = Camera.main;
            _playerMoveModel = pLayerMoveModel;
        }


        public void Execute(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerMoveModel.GetTransform.position);
            Rotation(direction);
        }

    }
}

