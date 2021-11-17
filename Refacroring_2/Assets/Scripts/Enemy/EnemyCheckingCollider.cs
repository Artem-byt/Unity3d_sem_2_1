using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Asteroids
{
    
    public class EnemyCheckingCollider : MonoBehaviour
    {
        public event Action<Collision2D> OnCollisionEnter = delegate (Collision2D collision) { };

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 3)
            {
                OnCollisionEnter?.Invoke(collision);
            }
            
        }
        
    }
}

