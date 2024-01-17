using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public TextMeshProUGUI CurrentScore;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        CurrentScore.text = score.ToString();
    }
}
