using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PLayerMoveModel
    {

        public float Speed;
        private float _acceleration;
        private Transform _transform;
        private IActions _actionMove;


        private float _horizontal;
        private float _vertical;
        private bool _isLeftShiftDown;
        private bool _isLeftShiftUp;

        public float GetAcceleration { get => _acceleration; }
        public Transform GetTransform { get => _transform; }

        public float GetHorizontal { get => _horizontal; }
        public float GetVertical { get => _vertical; }
        public bool GetLeftShiftDown { get => _isLeftShiftDown; }
        public bool GetLeftShiftUp { get => _isLeftShiftUp; }

        public PLayerMoveModel(IActions actions)
        {
            Speed = Resources.Load<PlayerMoveInfo>("PlayerMoveInfo").GetSpeed;
            _acceleration = Resources.Load<PlayerMoveInfo>("PlayerMoveInfo").GetAcceleration;
            _transform = GameObject.FindObjectOfType<PlayerCollisionView>().transform; //Resources.Load<PlayerMoveInfo>("PlayerMoveInfo").GetTransform;

            _actionMove = actions;

            _actionMove.OnHorizontalAxisChange += GetHorizontalAxis;
            _actionMove.OnVerticalAxisChange += GetVerticalAxis;
            _actionMove.OnLeftShiftnDown += GetLeftShiftButtonDown;
            _actionMove.OnLeftShiftnUp += GetLeftShiftButtonUp;

        }

        public void GetHorizontalAxis(float f)
        {
            _horizontal = f;
        }

        public void GetVerticalAxis(float f)
        {
            _vertical = f;
        }

        public void GetLeftShiftButtonDown(bool f)
        {
            _isLeftShiftDown = f;
        }

        public void GetLeftShiftButtonUp(bool f)
        {
            _isLeftShiftUp = f;
        }
    }
}

