using UnityEngine;
using TMPro;

public class KilledEnemiesCounter : MonoBehaviour
{
    public static KilledEnemiesCounter Instance { get; private set; }
    [SerializeField] private TMP_Text _counter;
    private void Awake()
    {
        Instance = this;
    }
    private int _kills;
    public static void AddKill()
    {
        Instance._kills++;
        Instance._counter.text = Instance._kills.ToString();
    }
}
