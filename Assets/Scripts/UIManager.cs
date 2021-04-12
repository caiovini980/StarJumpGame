using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image darkScreenUI;

    private float _scoreAmount;

    private AnimationManager _animationManager;
    
    private Color _darkScreenColor;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 00;
        _animationManager = GameManager.sInstance.AnimationManager;
    }

    public void UpdateScore(float score)
    {
        _scoreAmount += score;
        scoreText.text = "" + Mathf.Round(_scoreAmount / 10);
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
    
    
    public float GetScore()
    {
        return Int32.Parse(scoreText.text);
    }

    
}
