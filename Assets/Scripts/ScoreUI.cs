using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public PlayerScore playerScore;
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = "Player 1: " + playerScore.score;
    }
}