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

    private void OnEnable()
    {
        Enemy.Dead += PutObjectToPool;   
    }

    private void OnDisable()
    {
        Enemy.Dead -= PutObjectToPool;
    }
}
