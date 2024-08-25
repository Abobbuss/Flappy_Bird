using System.Collections;
using UnityEngine;

public class EnemyShoot : BaseShoot
{
    [SerializeField] private float _delay = 3f;

    private Coroutine _attackingCoroutine;

    private void OnEnable()
    {
        _attackingCoroutine ??= StartCoroutine(Attacking());
    }

    private void OnDisable()
    {
        if (_attackingCoroutine != null)
        {
            StopCoroutine(_attackingCoroutine);
            _attackingCoroutine = null;
        }
    }

    private IEnumerator Attacking()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Attack();

            yield return wait;
        }
    }
}
