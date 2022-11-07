using UnityEngine;

public class CannonShooting : GunShooting
{
    [SerializeField] private Transform _shootPoint;

    public override void Shoot(Enemy target)
    {
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetupBullet(target, _damage);
    }
}
