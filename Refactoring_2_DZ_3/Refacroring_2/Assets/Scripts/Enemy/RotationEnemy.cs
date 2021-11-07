using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class RotationEnemy : RotationShip
    {
        private readonly List<Enemy> _enemies;



        public RotationEnemy(List<Enemy> enemies, PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel.GetTransform)
        {
            _enemies = enemies;
        }

        public override void Rotation(Vector3 direction, int i)
        {
            var angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

            _enemies[i].GetEnemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        }
    }
}

