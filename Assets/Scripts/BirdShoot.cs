using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 5f;

    private KeyCode _keyShoot = KeyCode.G;

    private void Update()
    {
        if (Input.GetKeyDown(_keyShoot))
            Attack();
    }

    public void Attack()
    {
        Bullet spawnedBullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        spawnedBullet.SetDirection(_firePoint.right * _bulletSpeed);
    }
}
