using System.Collections;
using UnityEngine;

public class EnemyShoot : BaseShoot
{
    [SerializeField] private float _delay = 3f;

    private void Start()
    {
        StartCoroutine(Attacking());
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
