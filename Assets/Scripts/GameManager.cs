using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Scenes
    {
        HomeScene = 0,
        FlappyBird = 1,
    }

    public static GameManager Instance { get; private set; }
    public static Scenes CurrentScene { get; private set; }
    [SerializeField] private GameObject _uIElements;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Canvas _gameOverPanel;
    [SerializeField] private Text _scoreText;
    private int _timeScale = 1;
    public int PlayerScore { private set; get; } = 0;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        DontDestroyOnLoad(Instance);

        _backButton.onClick.AddListener(OnBackButtonClicked);
        _pauseButton.onClick.AddListener(onPauseButtonClicked);
    }

    void Start()
    {
        PlayerScore = 0;
    }

    void Update()
    {
        if ((int) CurrentScene > 0) _uIElements.SetActive(true);
        else _uIElements.SetActive(false);
    }

    public void IncrementPlayerScore(int scoreToAdd)
    {
        PlayerScore += scoreToAdd;
        _scoreText.text = PlayerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        CurrentScene = (Scenes) SceneIndex;
    }

    public void ShowGameOverPanel()
    {
        Instantiate(_gameOverPanel);
    }

    private void OnBackButtonClicked()
    {
        OpenScene((int) Scenes.HomeScene);
    }

    private void onPauseButtonClicked()
    {
        _timeScale = _timeScale == 0 ? 1 : 0;
        Time.timeScale = _timeScale;
    }
}
