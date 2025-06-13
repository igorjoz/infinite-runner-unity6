using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float worldScrollingSpeed = 0.2f;

    private float score;
    public TextMeshProUGUI scoreText;

    public bool inGame;
    public GameObject resetButton;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        InitializeGame();
    }

    void InitializeGame()
    {
        inGame = true;
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.inGame)
        {
            return;
        }

        score += worldScrollingSpeed * 20 * Time.fixedDeltaTime;
        //worldScrollingSpeed += 0.001f;
        UpdateOnScreenScore();
    }

    void UpdateOnScreenScore()
    {
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        inGame = false;
        resetButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
