using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        Enemy.Dead += Add;
    }

    private void OnDisable()
    {
        Enemy.Dead += Add;
    }

    public void Add(Enemy enemy)
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
