using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreValue;
    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI soundButtonText;

    private int highscore = 0;
    private int coins = 0;

    public GameObject mainMenuPanel;
    public GameObject upgradesStorePanel;

    public TextMeshProUGUI magnetLevelText;
    public TextMeshProUGUI magnetButtonText;

    public TextMeshProUGUI immortalityLevelText;
    public TextMeshProUGUI immortalityButtonText;

    public Powerup magnet;
    public Powerup immortality;


    void Start()
    {
        if (PlayerPrefs.HasKey("HighscoreValue"))
        {
            highscore = PlayerPrefs.GetInt("HighscoreValue");
        }

        if (PlayerPrefs.HasKey("CoinsValue"))
        {
            coins = PlayerPrefs.GetInt("CoinsValue");
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        highscoreValue.text = highscore.ToString();
        coinsValue.text = coins.ToString();

        if (SoundManager.instance.GetMuted())
        {
            soundButtonText.text = "Music ON";
        }
        else
        {
            soundButtonText.text = "Music OFF";
        }
    }
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    public void SoundButtonClicked()
    {
        SoundManager.instance.ToggleMuted();
        UpdateUI();
    }


    void Update()
    {
        
    }
}
