using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image darkScreenUI;
    public GameObject trophyIcon;

    [SerializeField] private RectTransform _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _quitButton;

    private float _scoreAmount;

    private AnimationManager _animationManager;

    private GameObject _highScoreTextGameObject;
    
    private Color _darkScreenColor;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 00;
        _animationManager = GameManager.sInstance.AnimationManager;
        _highScoreTextGameObject = _highScoreText.gameObject;
        trophyIcon.SetActive(false);
    }

    public void UpdateScore(float score)
    {
        _scoreAmount += score;
        scoreText.text = "" + Mathf.Round(_scoreAmount / 10);
    }

    public void ShowGameOverPanel()
    {
        LeanTween.move(_gameOverPanel, Vector3.zero, 1f).setOnComplete(ShowHighScore);
    }

    public void ActivateTrophyIcon()
    {
        trophyIcon.SetActive(true);
    }
    
    public void MakeDarkerScreen()
    {
        _darkScreenColor = darkScreenUI.color;
        _animationManager.PlayDarkScreenAnimation();
        darkScreenUI.color = _darkScreenColor;
    }
    
    public void MakeScreenNormal()
    {
        _darkScreenColor = darkScreenUI.color;
        _darkScreenColor.a = 0.0f;
        
        //add more stuff if needed
        darkScreenUI.color = _darkScreenColor;
    }

    private void ShowHighScore()
    {
        _highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        LeanTween.scale(_highScoreTextGameObject, new Vector3(2f, 2f, 2f), 1f).setOnComplete(ReturnUIAnimationToNormal);
    }

    private void ReturnUIAnimationToNormal()
    {
        LeanTween.scale(_highScoreTextGameObject, new Vector3(1f, 1f, 1f), 0.5f).setOnComplete(AnimationRestartButton);
    }

    private void AnimationRestartButton()
    {
        LeanTween.scale(_restartButton, new Vector3(1f, 1f, 1f), 0.7f).setOnComplete(AnimationQuitButton);
    }
    
    private void AnimationQuitButton()
    {
        LeanTween.scale(_quitButton, new Vector3(1f, 1f, 1f), 0.7f);
    }

    public float GetScore()
    {
        return Int32.Parse(scoreText.text);
    }

    
}
