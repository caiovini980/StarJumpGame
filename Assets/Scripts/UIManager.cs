using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _welcomePanel;
    [SerializeField] private GameObject _trophyIcon;
    [SerializeField] private GameObject _highScoreGameOverIcons; 
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _quitButton;

    [SerializeField] private RectTransform _gameOverPanel;
    [SerializeField] private RectTransform _mainMenuPanel;
    [SerializeField] private RectTransform _title;
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private float _scoreAmount;

    private AnimationManager _animationManager;

    private GameObject _highScoreTextGameObject;
    
    private Color _darkScreenColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "" + 00;
        _animationManager = GameManager.sInstance.AnimationManager;
        _highScoreTextGameObject = _highScoreText.gameObject;
        
        _trophyIcon.SetActive(false);
    }

    public void UpdateScore(float score)
    {
        _scoreAmount += score;
        _scoreText.text = "" + Mathf.Round(_scoreAmount / 10);
    }

    public void ShowGameOverPanel()
    {
        LeanTween.move(_gameOverPanel, Vector3.zero, 0.5f).setOnComplete(ShowHighScore);
    }

    public void ShowWelcomeMessage()
    {
        _welcomePanel.SetActive(true);
    }

    public void HideWelcomeMessage()
    {
        Time.timeScale = 1f;
        _welcomePanel.SetActive(false);
    }

    public void ShowHighScoreTextOnGameOver()
    {
        _highScoreGameOverIcons.SetActive(true);
    }

    public void ActivateTrophyIcon()
    {
        _trophyIcon.SetActive(true);
    }

    public void ShowMainMenuPanel()
    {
        LeanTween.move(_mainMenuPanel, Vector3.zero, 1f).setOnComplete(ShowTitle);
    }

    private void ShowTitle()
    {
        LeanTween.moveY(_title, -200, 1.5f).setEaseOutBounce();
        StartCoroutine(WaitToShowTitleParticles(0.6f));
    }

    private void ShowHighScore()
    {
        _highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        LeanTween.scale(_highScoreTextGameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.5f).setOnComplete(ReturnUIAnimationToNormal);
    }

    private void ReturnUIAnimationToNormal()
    {
        LeanTween.scale(_highScoreTextGameObject, new Vector3(1f, 1f, 1f), 0.5f).setOnComplete(AnimationRestartButton);
    }

    private void AnimationRestartButton()
    {
        LeanTween.scale(_restartButton, new Vector3(1f, 1f, 1f), 0.3f).setOnComplete(AnimationReturnToMenuButton);
    }
    
    private void AnimationReturnToMenuButton()
    {
        LeanTween.scale(_quitButton, new Vector3(1f, 1f, 1f), 0.3f);
    }

    public float GetScore()
    {
        return Int32.Parse(_scoreText.text);
    }

    private IEnumerator WaitToShowTitleParticles(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animationManager.PlayTitleParticles();
    }
}
