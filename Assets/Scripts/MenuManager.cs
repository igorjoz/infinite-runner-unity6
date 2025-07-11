using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI highScoreValue;
    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI soundBtnText;

    private int hs = 0;
    private int coins = 0;

    public GameObject mainMenuPanel;
    public GameObject upgradeStorePanel;

    public Text magnetLevelText;
    public Text magnetButtonText;
    public Text immortalityLevelText;
    public Text immortalityButtonText;

    public Powerup magnet;
    public Powerup immortality;

    private void Start()
    {
        Screen.SetResolution(1600, 1000, false);

        if (PlayerPrefs.HasKey("HighScoreValue"))
            hs = PlayerPrefs.GetInt("HighScoreValue");

        if (PlayerPrefs.HasKey("Coins"))
            coins = PlayerPrefs.GetInt("Coins");

        mainMenuPanel.SetActive(true);
        upgradeStorePanel.SetActive(false);

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

        immortalityLevelText.text = immortality.ToString();
        immortalityButtonText.text = immortality.UpgradeCostString();
        magnetLevelText.text = magnet.ToString();
        magnetButtonText.text = magnet.UpgradeCostString();
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

    public void OpenUpgradeStore()
    {
        mainMenuPanel.SetActive(false);
        upgradeStorePanel.SetActive(true);
    }
    public void CloseUpgradeStore()
    {
        mainMenuPanel.SetActive(true);
        upgradeStorePanel.SetActive(false);
    }

    public void UpgradeImmortalityButton()
    {
        UpgradePowerup(immortality);
    }
    public void UpgradeMagnetButton()
    {
        UpgradePowerup(magnet);
    }
    private void UpgradePowerup(Powerup powerup)
    {
        if (coins >= powerup.GetNextUpgradeCost() && !powerup.IsMaxedOut())
        {
            ReduceCoinsAmount(powerup.GetNextUpgradeCost());
            powerup.Upgrade();
            UpdateUI();
        }
    }
    // wydzielenie metody odejmuj¹cej pieni¹dze jest nam na rêkê - w razie gdybyœmy w przysz³oœci chcieli zmieniæ sposób zapisywania/przechowywania iloœci pieniêdzy, wystarczy zmieniæ to w oddzielnej metodzie, bez szukania ka¿dej wzmianki w kodzie
    private void ReduceCoinsAmount(int amount)
    {
        coins -= amount;
        PlayerPrefs.SetInt("Coins", coins);
    }
}
