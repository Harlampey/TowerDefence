using UnityEngine;

public class Crystal : MonoBehaviour, IDamageable
{
    [SerializeField] private int _healpoints;
    [SerializeField] private Healthbar _healthbar;

    private void Start()
    {
        _healthbar.SetupSlider(_healpoints);
    }
    public void ApplyDamage(int damage)
    {
        _healpoints -= damage;

        if (_healpoints == 0)
        {
            DestroyCrystal();
            return;
        }

        _healthbar.SetValue(_healpoints);
    }

    public void DestroyCrystal()
    {
        Level.LooseGame();
        Destroy(gameObject);
    }
}
