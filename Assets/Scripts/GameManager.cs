using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sInstance;

    [SerializeField] private PlayerController _player;
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Animator _transitionAnimator;

    private float _transitionTime = 1f;
    private float _currentHighScore;

    private void Awake()
    {
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
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.GetFloat("HighScore", 0);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _uiManager.ShowMainMenuPanel();
        }

        if (PlayerPrefs.GetFloat("HighScore", 0) <= 2)
        {
            _uiManager.ShowWelcomeMessage();
            Time.timeScale = 0f;
        }
    }

    private void Update()
    {
        if (_uiManager.GetScore() >= PlayerPrefs.GetFloat("HighScore", 0))
        {
            _uiManager.ActivateTrophyIcon();
        }
    }

    public void GameOver()
    {
        _currentHighScore = _uiManager.GetScore();
        if (_uiManager.GetScore() >= PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", _currentHighScore);
            _uiManager.ShowHighScoreTextOnGameOver();
        }
        //Show game over panel
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
        //open pause panel ui
        _animationManager.PlayPauseAnimation();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        //close pause panel ui
        _animationManager.PlayClosePauseAnimation();
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        _transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    
    public PlayerController Player => _player;
    public AnimationManager AnimationManager => _animationManager;
    public AudioManager AudioManager => _audioManager;
    public UIManager UIManager => _uiManager;
}
