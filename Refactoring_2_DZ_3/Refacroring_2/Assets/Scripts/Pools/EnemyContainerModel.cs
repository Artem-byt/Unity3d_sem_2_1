using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyContainerModel
    {
        public List<bool> IsEnemyActive;


        private bool _autoExpand;
        private Transform _enemyPoolRespawn;
        private List<GameObject> _typeOfEnemy;
        private List<Transform> _transformsOfEnemyRespawns;


        public Transform GetEnemyPoolRespawn { get => _enemyPoolRespawn; }
        public bool IsAutoExpand { get => _autoExpand; }
        public List<GameObject> GetTypesOfEnemy { get => _typeOfEnemy; }
        public List<Transform> GetEnemyRespawns {get => _transformsOfEnemyRespawns;}

        public EnemyContainerModel()
        {
            _transformsOfEnemyRespawns = Resources.Load<EnemyInfo>("EnemyInfo").GetEnemyRespawns;
            IsEnemyActive = new List<bool>(_transformsOfEnemyRespawns.Count);
            for(int i = 0; i< _transformsOfEnemyRespawns.Count; i++)
            {
                IsEnemyActive.Add(false);
            }
            _autoExpand = Resources.Load<EnemyInfo>("EnemyInfo").IsAutoExpandEnemyPool;

            _enemyPoolRespawn = GetEnemyTransformRespawns();
            _typeOfEnemy = Resources.Load<EnemyInfo>("EnemyInfo").GetTypeOfEnemy;
        }

        private Transform GetEnemyTransformRespawns()
        {
            return GameObject.FindObjectOfType<EnemyTransformIdentificator>().transform;
        }
    }
}

