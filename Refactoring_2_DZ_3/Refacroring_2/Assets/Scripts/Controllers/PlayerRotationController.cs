using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids
{
    public class PlayerRotationController : RotationShip, IExecute
    {
        private PLayerMoveModel _playerMoveModel;
        private Camera _camera;

        public PlayerRotationController(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel.GetTransform)
        {
            _camera = Camera.main;
            _playerMoveModel = pLayerMoveModel;
        }


        public void Execute(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerMoveModel.GetTransform.position);
            Rotation(direction);
        }

        public override void Rotation(Vector3 direction, int i = 0)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

