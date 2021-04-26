using System;
using System.Collections;
using _StarJump.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sInstance;

    [SerializeField] private PlayerController _player;
    [SerializeField] private PauseAnimationController _pausePanel;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Animator _transitionAnimator;

    [SerializeField] private float _transitionTime = 1f;
    private float _currentHighScore;

    private const string STARTLEVEL_ANIMATION_NAME = "Start";

    private void Awake()
    {
        SaveSystemManager.LoadScoreData();
        
        if (sInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            sInstance = this;
        }
    }

    private void Start()
    { 
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _uiManager.ShowMainMenuPanel();
        }

        if (SaveSystemManager.LoadScoreData().highScore <= 2)
        {
            _uiManager.ShowWelcomeMessage();
            Time.timeScale = 0f;
        }
    }

    private void Update()
    {
        if (_uiManager.GetScore() >= SaveSystemManager.Data.highScore)
        {
            _uiManager.ActivateTrophyIcon();
        }
    }

    public void GameOver()
    {
        _currentHighScore = _uiManager.GetScore();

        if (_currentHighScore >= SaveSystemManager.Data.highScore)
        {
            _uiManager.ShowHighScoreTextOnGameOver();
            SaveSystemManager.Data.highScore = _currentHighScore;
            SaveSystemManager.SaveGame();
        }
        
        _uiManager.ShowGameOverPanel();
    }

    public void StartGame()
    {
        _audioManager.MusicTransition(_transitionTime);
        StartCoroutine(LoadLevel(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        _audioManager.MusicTransition(_transitionTime);
        StartCoroutine(LoadLevel(0));
    }

    public void RestartGame()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.PlayPauseAnimation();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pausePanel.PlayClosePauseAnimation();
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        _transitionAnimator.SetTrigger(STARTLEVEL_ANIMATION_NAME);
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    
    public PlayerController Player => _player;
    public AudioManager AudioManager => _audioManager;
    public UIManager UIManager => _uiManager;
}
