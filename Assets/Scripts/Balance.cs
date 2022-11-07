using UnityEngine;
using TMPro;
using System.Text;

public class Balance : MonoBehaviour {
    #region Singlton
    public static Balance Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Balance is Singlton!");
        }
            
    }
    #endregion

    private int _money;
    public int Money
    {
        get
        {
            return _money;
        }
        private set
        {
            _money = value;

            StringBuilder sb = new StringBuilder(_money.ToString());
            sb.Append("<sprite index=\"22\">");

            _moneyText.text = sb.ToString();

        }
    }

    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private int _startMoney;

    private void Start()
    {
        Money = _startMoney;
        _moneyText.text = $"{_startMoney}<sprite index=\"22\">";
    }

    public static void AddMoney(int amount)
    {
        Instance.Money += amount; 
    }

    public static bool TrySpendMoney(int amount)
    {
        if (Instance.Money >= amount)
        {
            Instance.Money -= amount;
            return true;
        }

        return false;
    }
}
