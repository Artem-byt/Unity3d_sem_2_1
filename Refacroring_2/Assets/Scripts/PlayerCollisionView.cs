using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollisionView : MonoBehaviour
{
    public event Action OnCollisionEnter = delegate () { };

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollisionEnter?.Invoke();

    }
}
