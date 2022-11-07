using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    [SerializeField] private GameObject _gamePanel, _victoryPanel, _gameoverPanel;

    public static void LooseGame()
    {
        Time.timeScale = 0f;
        Instance._gamePanel.SetActive(false);
        Instance._gameoverPanel.SetActive(true);
    }

    public static void WinGame()
    {
        Time.timeScale = 0f;
        Instance._gamePanel.SetActive(false);
        Instance._victoryPanel.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
