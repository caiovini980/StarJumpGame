using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private float _scoreAmount;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 00;
    }

    public void UpdateScore(float score)
    {
        _scoreAmount += score;
        scoreText.text = "" + Mathf.Round(_scoreAmount / 10);
    }

    public float GetScore()
    {
        return Int32.Parse(scoreText.text);
    }
}
