using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage { get; set; }

    [SerializeField] protected float _speed;
    protected Enemy _target;
    
    public void SetupBullet(Enemy target, int damage)
    {
        _target = target;
        Damage = damage;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_target)
            transform.LookAt(_target.transform.position);
        else
            Destroy(gameObject);

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            KillEnemy(enemy);
        }
    }

    protected virtual void KillEnemy(Enemy enemy)
    {
        enemy.ApplyDamage(Damage);
        Destroy(gameObject);
    }
}
