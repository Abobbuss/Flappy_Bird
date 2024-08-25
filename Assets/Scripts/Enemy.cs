using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectPool _pool;

    public static Action<Enemy> Dead;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out BirdBullet _))
            Dead?.Invoke(this);
    }
}
