using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sInstance;

    [SerializeField] private PlayerController _player;
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private AudioManager _audioManager;

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

    public void GameOver(GameObject player)
    {
        player.SetActive(false);
        //Show game over panel
    }

    public void StartGame()
    {
        
    }
    
    public void ExitGame()
    {
        
    }

    public void PauseGame()
    {
        
    }
    
    public PlayerController Player => _player;
    public AnimationManager AnimationManager => _animationManager;
    public AudioManager AudioManager => _audioManager;
}
