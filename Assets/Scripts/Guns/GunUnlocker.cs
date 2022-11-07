using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunUnlocker : MonoBehaviour
{
    [SerializeField] private Button _buttonToUnlock;
    [SerializeField] private GameObject _lockedPanel;
    [SerializeField] private TMP_Text _price_text;
    [SerializeField] private int _unlockPrice;

    private void Start()
    {
        _price_text.text = _unlockPrice.ToString() + "<sprite index=\"22\">";
        _buttonToUnlock.interactable = false;
    }
    public void UnlockGun()
    {
        if (Balance.TrySpendMoney(_unlockPrice))
        {
            _buttonToUnlock.interactable = true;
            _lockedPanel.SetActive(false);
        }
    }
}
