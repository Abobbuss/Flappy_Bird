using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> Changed;

    public void SubscribeToEnemy(Enemy enemy)
    {
        enemy.Dead += Add;
    }

    public void UnsubscribeFromEnemy(Enemy enemy)
    {
        enemy.Dead -= Add;
    }

    public void Add(Enemy enemy)
    {
        _score++;
        Changed?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }
}
