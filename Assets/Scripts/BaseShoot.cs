using UnityEngine;

public class BaseShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 5f;

    public void Attack()
    {
        Bullet spawnedBullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        spawnedBullet.SetDirection(_firePoint.right * _bulletSpeed);
    }
}
