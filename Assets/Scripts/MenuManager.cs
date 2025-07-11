using UnityEngine;
using TMPro;                     // <-- Dodaj tê liniê
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI highScoreValue;  // <-- Zmieniono typ
    public TextMeshProUGUI coinsValue;      // <-- Zmieniono typ
    public TextMeshProUGUI soundBtnText;    // <-- Zmieniono typ

    private int hs = 0;
    private int coins = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScoreValue"))
            hs = PlayerPrefs.GetInt("HighScoreValue");

        if (PlayerPrefs.HasKey("Coins"))
            coins = PlayerPrefs.GetInt("Coins");

        UpdateUI();
    }

    public void UpdateUI()
    {
        highScoreValue.text = hs.ToString();
        coinsValue.text = coins.ToString();

        if (SoundManager.instance.GetMuted())
            soundBtnText.text = "Music ON";
        else
            soundBtnText.text = "Music OFF";
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void SoundButton()
    {
        SoundManager.instance.ToggleMuted();
        UpdateUI();
    }
}
