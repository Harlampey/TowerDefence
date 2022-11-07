using UnityEngine;
using TMPro;

public class PriceSetter : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    private void Start()
    {
        GetComponent<TMP_Text>().text = _gun.Price.ToString() + "<sprite index=\"22\">";
    }
}
