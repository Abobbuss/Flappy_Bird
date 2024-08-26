using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            PutObjectToPool(enemy);
    }

    public void SubscribeToEnemy(Enemy enemy)
        => enemy.Dead += PutObjectToPool;

    public void UnsubscribeFromEnemy(Enemy enemy)
        => enemy.Dead -= PutObjectToPool;

    private void PutObjectToPool(Enemy enemy)
    {
        _scoreCounter.UnsubscribeFromEnemy(enemy);
        UnsubscribeFromEnemy(enemy);
        _pool.PutObject(enemy);
    }
}
