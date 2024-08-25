using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ObjectRemover _remover;

    private void Start()
    {
        StartCoroutine(GenerateEnemis());
    }

    private IEnumerator GenerateEnemis()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled) 
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _pool.GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;

        _scoreCounter.SubscribeToEnemy(enemy);
        _remover.SubscribeToEnemy(enemy);
    }
}
