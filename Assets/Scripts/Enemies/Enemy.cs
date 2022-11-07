using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _speed;
    [SerializeField] private int _healpoints;
    [SerializeField] private int _reward;
    [SerializeField] private Healthbar _healthbar;

    private Vector3 _target;
    private float _maxDistanceToTarget = 0.25f;
    private int _targetIndex;

    [SerializeField] private bool _isBoss;
    public void ApplyDamage(int damage)
    {
        if (damage >= _healpoints)
            Kill();
        else
        {
            _healpoints -= damage;
            _healthbar.SetValue(_healpoints);
        }
    }
    private void Start()
    {
        NextTarget();
        _healthbar.SetupSlider(_healpoints);
    }

    private void Kill()
    {
        Balance.AddMoney(_reward);
        KilledEnemiesCounter.AddKill();
        Destroy(gameObject);

        if (_isBoss)
        {
            Level.WinGame();
        }

    }
    private void Update()
    {
        FollowTarget();
    }

    private void NextTarget()
    {
        _target = Path.GetWaypointPosition(_targetIndex);
        _targetIndex++;
        transform.LookAt(new Vector3(_target.x, transform.position.y, _target.z));
    }

    private void FollowTarget()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target) < _maxDistanceToTarget)
            NextTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            Destroy(gameObject);

            if (!_isBoss)
                crystal.ApplyDamage(1);
            else
                crystal.DestroyCrystal();
        }
    }
}
