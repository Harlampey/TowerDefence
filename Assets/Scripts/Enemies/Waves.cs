using UnityEngine;

public class Waves : MonoBehaviour
{
    public static Waves Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private Wave[] _waves;
    [SerializeField] private TMPro.TMP_Text _waveText;

    public static Wave[] GetWaves() => Instance._waves;
    public static TMPro.TMP_Text GetWaveText() => Instance._waveText;
}
