using System.Collections;
using UnityEngine;

public abstract class GunShooting : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _shootInterval;
    [SerializeField] protected GameObject _bulletPrefab;

    protected Enemy _target;
    protected bool _isShooting;

    public abstract void Shoot(Enemy target);
    public virtual void SetTarget(Enemy target)
    {
        _target = target;

        if (!_isShooting)
            StartCoroutine(Shooting());
    }
    public virtual void ClearTarget()
    {
        _target = null;
    }

    protected virtual IEnumerator Shooting()
    {
        _isShooting = true;
        while (_target)
        {
            yield return new WaitForSeconds(_shootInterval);
            Shoot(_target);
        }
        _isShooting = false;
    }
}
