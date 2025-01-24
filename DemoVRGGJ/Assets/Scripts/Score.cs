using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    private int _currentScore;

    private void Start()
    {
        score = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        AddScore();
    }

    private void AddScore()
    {
        _currentScore = int.Parse(score.text);
        _currentScore++;
        score.text = _currentScore.ToString();
    }
}
