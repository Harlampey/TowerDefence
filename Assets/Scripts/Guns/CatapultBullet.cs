using UnityEngine;

public class CatapultBullet : Bullet
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private GameObject _explodeParticles;
    protected override void KillEnemy(Enemy enemy)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Enemy enemyInRadius))
                enemyInRadius.ApplyDamage(Damage);

            
        }

        Instantiate(_explodeParticles, transform.position, Quaternion.identity);
    }
}
