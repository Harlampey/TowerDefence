using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);     
    }

    public void SetupSlider(int maxHealpoints)
    {
        _slider.maxValue = maxHealpoints;
        _slider.value = maxHealpoints;
    }

    public void SetValue(int healpoints)
    {
        gameObject.SetActive(true);
        _slider.value = Mathf.Clamp(healpoints, 0, _slider.maxValue);
    }
}
