using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private Text _scoreText;
    private int _score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score}";
    }

    public void AddScore(int value)
    {
        _score += value;
        UpdateScoreText();
    }
}
