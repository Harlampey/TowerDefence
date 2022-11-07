using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Price;
    public float Radius => _radius;

    [SerializeField] protected float _radius;
    [SerializeField] private Enemy _target;
    [SerializeField] private GunShooting _shooting;

    private WaitForSeconds _checkInterval;

    private void Start()
    {
        _checkInterval = new WaitForSeconds(0.3f);

        StartCoroutine(CheckTargets());
    }

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (_target)
        {
            transform.LookAt(_target.transform);
        }
    }

    private IEnumerator CheckTargets()
    {
        while (true)
        {
            if (!_target)
                TryFindTarget();
            else
                CheckIfTargetInRadius();

            yield return _checkInterval;
        }
    }

    private void TryFindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);
        List<Enemy> targets = new List<Enemy>();
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Enemy enemy))
                targets.Add(enemy);
        }

        if (targets.Count == 1)
            _target = targets[0];
        else if (targets.Count > 1)
            _target = GetClosestEnemy(targets.ToArray());

        _shooting.SetTarget(_target);
    }

    private Enemy GetClosestEnemy(Enemy[] enemies)
    {
        Enemy tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Enemy t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    private void CheckIfTargetInRadius()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) > _radius)
        {
            _target = null;
        }
    }
}
