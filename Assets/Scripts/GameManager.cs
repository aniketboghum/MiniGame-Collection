using System;
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
        WhackAMole = 2
    }

    public static GameManager Instance { get; private set; }
    public static Scenes CurrentScene { get; private set; }
    [SerializeField] private GameObject _uIElements;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _scoreText;
    public int PlayerScore { private set; get; } = 0;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        DontDestroyOnLoad(Instance);

        _backButton.onClick.AddListener(OnBackButtonClicked);
        _pauseButton.onClick.AddListener(PauseGame);
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

    public void OpenScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        CurrentScene = (Scenes) SceneIndex;
    }

    public void ShowGameOverPanel()
    {
        var gameOverPanel = Instantiate(_gameOverPanel);
        gameOverPanel.GetComponent<GameOverPanel>().SetHighScore();
    }

    private void OnBackButtonClicked()
    {
        OpenScene((int) Scenes.HomeScene);
    }

    public void PauseGame()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    public void ReserPlayerScore()
    {
        if (PlayerPrefs.GetInt(CurrentScene.ToString() + "HighScore", 0) < PlayerScore) 
        {
            PlayerPrefs.SetInt(CurrentScene.ToString() + "HighScore", PlayerScore);
        }

        _scoreText.text = PlayerScore.ToString();
        PlayerScore = 0;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(CurrentScene.ToString() + "HighScore");
    }
}
