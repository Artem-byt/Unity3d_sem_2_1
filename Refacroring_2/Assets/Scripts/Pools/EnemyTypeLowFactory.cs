using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyTypeLowFactory : IEnemyFactory
    {
        private List<GameObject> _enemyPrefabs;


        public EnemyTypeLowFactory(List<GameObject> enemiesPrefab)
        {
            _enemyPrefabs = enemiesPrefab;
        }

        public GameObject CreateEnemy(Transform container, int indexPrefab)
        {
            var gameObject = Object.Instantiate(_enemyPrefabs[indexPrefab]);
            gameObject.transform.position = container.position;

            return gameObject;
        }
    }
}

