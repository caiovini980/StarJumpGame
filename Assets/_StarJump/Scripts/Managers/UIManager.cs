using System;
using System.Collections;
using System.IO;
using _StarJump.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _welcomePanel;
    [SerializeField] private GameObject _trophyIcon;
    [SerializeField] private GameObject _highScoreGameOverIcons;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private GameObject _comboAreaObject;
    [SerializeField] private GameObject _settingsPanel;

    [SerializeField] private RectTransform _maxComboHeader;
    [SerializeField] private RectTransform _gameOverPanel;
    [SerializeField] private RectTransform _mainMenuPanel;
    [SerializeField] private RectTransform _title;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI _maxComboText;

    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sFXVolumeSlider;

    private PlayerController _player;

    private GameObject _highScoreTextGameObject;

    private Color _darkScreenColor;

    private Vector3 _playerPosition;

    private float _scoreAmount;
    private float _tempCombo = 0;

    private int _comboScore;

    private string _json;

    private SaveSystemManager.SaveData _saveData;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "" + 0;
        _comboText.text = "+ " + 1;
        _maxComboText.text = "" + 0;
        SaveSystemManager.Data.comboScore = 0f;
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

    public void ShowSettingPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void ShowMainMenuPanel()
    {
        LeanTween.move(_mainMenuPanel, Vector3.zero, 1f).setOnComplete(ShowTitle);
    }

    public void ShowComboMultiplier(int value)
    {
        _comboScore += value;
        _comboText.text = _comboScore.ToString();

        if (_comboScore >= 4)
        {
            LeanTween.scaleY(_comboAreaObject, 1, 0.3f);
            SaveSystemManager.Data.comboScore = _comboScore;
        }
    }

    public void ResetCombo()
    {
        if (SaveSystemManager.Data.comboScore > _tempCombo)
        {
            _tempCombo = SaveSystemManager.Data.comboScore;
            LeanTween.moveY(_maxComboHeader, 37f, 0.2f);
            _maxComboText.text = _tempCombo.ToString();
        }
        
        _comboText.text = _comboScore.ToString();

        _comboScore = 0;
        LeanTween.scaleY(_comboAreaObject, 0, 0.1f);
    }

    private void ShowTitle()
    {
        LeanTween.moveY(_title, -200, 1.5f).setEaseOutBounce().setOnComplete(AnimationReturnToMenuButton);
    }

    private void ShowHighScore()
    {
        SaveSystemManager.LoadScoreData();
        _highScoreText.text = SaveSystemManager.Data.highScore.ToString();

        if (_scoreAmount >= SaveSystemManager.Data.highScore)
        {
            if (_tempCombo == 0)
            {
                _tempCombo = _comboScore;
            }
            
            SaveSystemManager.Data.highScore = SaveSystemManager.Data.highScore + _tempCombo;
            _highScoreText.text = SaveSystemManager.Data.highScore.ToString();
            
            SaveSystemManager.SaveGame();
        }

        LeanTween.scale(_highScoreTextGameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.5f)
            .setOnComplete(ReturnUIAnimationToNormal);
    }

    public void ReturnToMainMenuFromSettings()
    {
        _settingsPanel.SetActive(false);
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

    public void SetSlidersPositionTo(float musicSlider, float sfxSlider)
    {
        _musicVolumeSlider.value = musicSlider;
        _sFXVolumeSlider.value = sfxSlider;
    }

    public float GetScore()
    {
        return Int32.Parse(_scoreText.text);
    }
}
