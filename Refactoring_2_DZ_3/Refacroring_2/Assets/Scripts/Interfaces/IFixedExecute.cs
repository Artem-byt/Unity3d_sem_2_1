using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IFixedExecute: IController
    {
        public void FixedExecute(float deltatime);
    }
}

