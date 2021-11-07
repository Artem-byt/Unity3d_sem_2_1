using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        public GameObject CreateEnemy(Transform container, int indexPrefab);
    }
}

