using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            PutObjectToPool(enemy);
    }

    private void PutObjectToPool(Enemy enemy)
        => _pool.PutObject(enemy);

    public void SubscribeToEnemy(Enemy enemy)
    {
        enemy.Dead += PutObjectToPool;
    }

    public void UnsubscribeFromEnemy(Enemy enemy)
    {
        enemy.Dead -= PutObjectToPool;
    }
}
