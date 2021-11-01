using UnityEngine;

namespace Asteroids
{
    public class MoveTransform : IMove
    {
        private readonly Rigidbody2D _playerRigidBody;
        private readonly Transform _playerTransform;
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MoveTransform(PLayerMoveModel pLayerMoveModel)
        {
            _playerRigidBody = pLayerMoveModel.GetTransform.GetComponent<Rigidbody2D>();
            _playerTransform = pLayerMoveModel.GetTransform;
            Speed = pLayerMoveModel.GetSpeed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _move = _playerTransform.TransformDirection(_move);
            _playerRigidBody.AddForce(_move, ForceMode2D.Force);
        }
    }
}
