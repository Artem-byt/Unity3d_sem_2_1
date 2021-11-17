using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New EnemyInfo")]
    public class EnemyInfo : ScriptableObject
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _countOfActiveRockets;
        [SerializeField] private List<Transform> _enemyRespawns;
        [SerializeField] private List<GameObject> _typeOfEnemy;
        [SerializeField] private bool IsAutoExpand;
        [SerializeField] private int _numberOfEnemyInRespawn;

        public int GetEnemyHP { get => _hp; }

        public int GetCountOfActiveRockets { get => _countOfActiveRockets; }

        public List<Transform> GetEnemyRespawns { get => _enemyRespawns; }

        public List<GameObject> GetTypeOfEnemy { get => _typeOfEnemy; }

        public bool IsAutoExpandEnemyPool { get => IsAutoExpand; }

        public int GetNumberOfEnemyInReapswn { get => _numberOfEnemyInRespawn; }
    }
}

