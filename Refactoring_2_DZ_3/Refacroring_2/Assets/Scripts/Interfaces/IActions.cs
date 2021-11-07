using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public interface IActions
    {
        public event Action<float> OnHorizontalAxisChange;
        public event Action<float> OnVerticalAxisChange;
        public event Action<bool> OnFireButtonDown;
        public event Action<bool> OnLeftShiftnDown;
        public event Action<bool> OnLeftShiftnUp;
    }
}

