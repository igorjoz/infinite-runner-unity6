using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float worldScrollingSpeed = 0.2f;

    private float score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        score += worldScrollingSpeed * 20 * Time.fixedDeltaTime;
        //worldScrollingSpeed += 0.001f;
        UpdateOnScreenScore();
    }

    void UpdateOnScreenScore()
    {
        scoreText.text = score.ToString("0");
    }
}
