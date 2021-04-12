using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sInstance;

    [SerializeField] private PlayerController _player;
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private UIManager _uiManager;

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
    }

    private void Update()
    {
        if (_uiManager.GetScore() >= PlayerPrefs.GetFloat("HighScore", 0))
        {
            Debug.Log("TABO TABO");
            _uiManager.ActivateTrophyIcon();
        }
    }

    public void GameOver()
    {
        _currentHighScore = _uiManager.GetScore();
        if (_uiManager.GetScore() >= PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", _currentHighScore);
        }
        //Show game over panel
        _uiManager.ShowGameOverPanel();
    }

    public void StartGame()
    {
        
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        
    }
    
    public PlayerController Player => _player;
    public AnimationManager AnimationManager => _animationManager;
    public AudioManager AudioManager => _audioManager;
    public UIManager UIManager => _uiManager;
}
