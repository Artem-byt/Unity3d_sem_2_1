using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Asteroids
{
    public abstract class RotationShip : IRotation
    {
        public readonly Transform _playerTransform;

        public RotationShip(Transform pLayerMoveModel)
        {
            _playerTransform = pLayerMoveModel;
        }

        public abstract void Rotation(Vector3 direction, int i = 0);

    }
}
