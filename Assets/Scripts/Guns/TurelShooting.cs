using UnityEngine;

public class TurelShooting : GunShooting
{
    [SerializeField] private Transform[] _shootPoints;

    private int _shootPointId;
    public override void Shoot(Enemy target)
    {
        _shootPointId = (_shootPointId == 0) ? 1 : 0;

        GameObject bullet = Instantiate(_bulletPrefab, _shootPoints[_shootPointId].position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetupBullet(target, _damage);
    }
}
