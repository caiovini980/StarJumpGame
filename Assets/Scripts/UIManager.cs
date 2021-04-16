using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _welcomePanel;
    [SerializeField] private GameObject _trophyIcon;
    [SerializeField] private GameObject _highScoreGameOverIcons; 
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private GameObject _comboAreaObject;
    
    [SerializeField] private RectTransform _maxComboHeader;
    [SerializeField] private RectTransform _gameOverPanel;
    [SerializeField] private RectTransform _mainMenuPanel;
    [SerializeField] private RectTransform _title;
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI _maxComboText;

    private AnimationManager _animationManager;
    
    private PlayerController _player;

    private GameObject _highScoreTextGameObject;
    
    private Color _darkScreenColor;

    private Vector3 _playerPosition;

    private float _scoreAmount;
    private float _tempCombo = 0;
    
    private int _comboScore;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "" + 0;
        _comboText.text = "+ " + 1;
        _maxComboText.text = "" + 0;
        _animationManager = GameManager.sInstance.AnimationManager;
        _player = GameManager.sInstance.Player;
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

    public void ShowComboMultiplier(int value)
    {
        _comboScore += value;
        _comboText.text = _comboScore.ToString();
        
        Debug.Log(_tempCombo);
        
        if (_comboScore >= 4)
        {
            LeanTween.scaleY(_comboAreaObject, 1, 0.3f);
     
            PlayerPrefs.SetFloat("ComboScore", _comboScore);
        }
    }

    public void ResetCombo()
    {
        if (PlayerPrefs.GetFloat("ComboScore", defaultValue: 0) > _tempCombo)
        {
            _tempCombo = PlayerPrefs.GetFloat("ComboScore", defaultValue: 0);
            //play animation
            LeanTween.moveY(_maxComboHeader, 37f, 0.2f);
            _maxComboText.text = _tempCombo.ToString();
        }
        
        _comboScore = 0;
        _comboText.text = _comboScore.ToString();
        
        LeanTween.scaleY(_comboAreaObject, 0, 0.1f);
    }

    private void ShowTitle()
    {
        LeanTween.moveY(_title, -200, 1.5f).setEaseOutBounce().setOnComplete(AnimationReturnToMenuButton);
        StartCoroutine(WaitToShowTitleParticles(0.6f));
    }

    private void ShowHighScore()
    {
        _highScoreText.text = (PlayerPrefs.GetFloat("HighScore", 0) + _tempCombo).ToString();
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
