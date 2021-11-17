using UnityEngine;

namespace Asteroids
{
    public class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        public AccelerationMove(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel)
        {
            _acceleration = pLayerMoveModel.GetAcceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
