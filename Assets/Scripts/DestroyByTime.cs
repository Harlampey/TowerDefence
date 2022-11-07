using System.Collections;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private float _time = 3f;

    private void Start()
    {
        StartCoroutine(Destroying());
    }
    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
}
