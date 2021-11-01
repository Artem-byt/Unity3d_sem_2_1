using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public class InputKeyBoardInitialization : IInvokeKeyBoard, IActions
    {
        public event Action<float> OnHorizontalAxisChange = delegate (float f) { };
        public event Action<float> OnVerticalAxisChange = delegate (float f) { };
        public event Action<bool> OnFireButtonDown = delegate (bool f) { };
        public event Action<bool> OnLeftShiftnDown = delegate (bool f) { };
        public event Action<bool> OnLeftShiftnUp = delegate (bool f) { };


        public void GetInvokeKeyBoard()
        {
            OnHorizontalAxisChange?.Invoke(Input.GetAxis(PlayInputAxisManager.Horizontal));
            OnVerticalAxisChange?.Invoke(Input.GetAxis(PlayInputAxisManager.Vertical));
            OnFireButtonDown?.Invoke(Input.GetButtonDown(PlayInputAxisManager.Fire1));
            OnLeftShiftnDown?.Invoke(Input.GetKeyDown(KeyCode.LeftShift));
            OnLeftShiftnUp?.Invoke(Input.GetKeyUp(KeyCode.LeftShift));
        }
    }
}

