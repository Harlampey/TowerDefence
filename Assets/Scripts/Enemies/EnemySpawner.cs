using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay, _wavesInterval = 10f;
    
    private TMP_Text _waveText;
    private Wave[] _waves;

    private int _waveNumber;

    private void Start()
    {
        _waves = Waves.GetWaves();
        _waveText = Waves.GetWaveText();
        StartCoroutine(Spawning());
    }
    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(_spawnDelay);
        foreach (Wave wave in _waves)
        {
            _waveNumber++;
            _waveText.text = "Wave " + _waveNumber.ToString();
            _waveText.transform.DOPunchScale(Vector3.one * 1.1f, 0.6f);

            foreach (MonstersArmy army in wave.Armies)
            {
                for (int i = 0; i < army.Count; i++)
                {
                    Instantiate(army.EnemyPrefab, _spawnPoint.position, Quaternion.identity);
                    yield return new WaitForSeconds(army.SpawnInterval);
                }
            }
            yield return new WaitForSeconds(_wavesInterval);
        }
    }
}
