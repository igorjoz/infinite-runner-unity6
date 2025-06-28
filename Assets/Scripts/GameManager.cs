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

    private int coins;
    public TMP_Text coinsText;

    public void CoinCollected(int value = 1)
    {
        coins += value;
        PlayerPrefs.SetInt("Coins", coins);
        Debug.Log(coins);
    }

    void InitializeGame()
    {
        inGame = true;

        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            coins = 0;
            PlayerPrefs.SetInt("Coins", 0);
        }
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        InitializeGame();
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
        coinsText.text = coins.ToString("0");
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
