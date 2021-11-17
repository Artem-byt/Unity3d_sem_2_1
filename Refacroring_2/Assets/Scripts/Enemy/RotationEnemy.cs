using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class RotationEnemy : RotationShip
    {



        public RotationEnemy(PLayerMoveModel pLayerMoveModel) : base(pLayerMoveModel.GetTransform)
        {
        }

        public override void Rotation(Vector3 direction, int i)
        {
            var angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

            ServiceLocator.Resolve<EnemyPoolContainerInitialization>().Enemies[i].GameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
}

