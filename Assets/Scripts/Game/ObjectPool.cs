using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ObjectRemover _remover;

    private Queue<Enemy> _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            var pipe = Instantiate(_prefab);
            pipe.transform.parent = _container;

            return pipe;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
        _scoreCounter.UnsubscribeFromEnemy(enemy);
        _remover.UnsubscribeFromEnemy(enemy);
    }
}
