using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 5f;
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

    public void Attack()
    {
        Bullet spawnedBullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        spawnedBullet.SetDirection(-_firePoint.right * _bulletSpeed);
    }
}
