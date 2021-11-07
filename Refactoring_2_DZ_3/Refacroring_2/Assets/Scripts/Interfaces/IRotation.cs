using UnityEngine;

namespace Asteroids
{
    public interface IRotation
    {
        void Rotation(Vector3 direction, int i = 0);
    }
}
