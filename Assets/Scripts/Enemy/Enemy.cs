using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    public event Action<Enemy> Dead;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out BirdBullet _))
            Dead?.Invoke(this);
    }
}
