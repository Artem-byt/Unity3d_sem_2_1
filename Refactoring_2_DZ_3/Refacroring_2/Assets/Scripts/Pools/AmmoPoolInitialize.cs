using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AmmoPoolInitialize
    { 
        private AmmoPool _ammoPool;
        public AmmoPool GetAmmoPool { get => _ammoPool; }



        public AmmoPoolInitialize(PoolModel poolModel, PLayerMoveModel pLayerMoveModel, List<Enemy> enemies)
        {
            _ammoPool = new AmmoPool(poolModel.GetAmmoPrefab, pLayerMoveModel.GetTransform, poolModel);
        }
    }
}

