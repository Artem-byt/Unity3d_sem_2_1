using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollisionView : MonoBehaviour
{
    public event Action<Collision2D> OnCollisionEnter = delegate (Collision2D other) { };

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollisionEnter?.Invoke(other);
    }
}
