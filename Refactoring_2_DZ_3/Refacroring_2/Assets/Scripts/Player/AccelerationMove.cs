using UnityEngine;

namespace Asteroids
{
    public class AccelerationMove
    {

        private PLayerMoveModel _playerMoveModel;

        public AccelerationMove(PLayerMoveModel pLayerMoveModel)
        {
            _playerMoveModel = pLayerMoveModel;
        }

        public void AddAcceleration()
        {
            _playerMoveModel.Speed += _playerMoveModel.GetAcceleration;
        }

        public void RemoveAcceleration()
        {
            _playerMoveModel.Speed -= _playerMoveModel.GetAcceleration;
        }
    }
}
