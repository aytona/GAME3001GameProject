using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

    public Text Score;
    public Text Coins;
    public Text Health;
    public Text FirstUpgradeText;
    public Text SecondUpgradeText;
    public Text ThirdUpgradeText;
    public GameObject PauseMenu;
    public GameObject UpgradeMenu;
    public GameObject PersistantPause;

    private bool paused;

    void Update()
    {
        Score.text = "Score: " + GameData._Instance.Score.ToString();
        Coins.text = "Coins: " + GameData._Instance.Coins.ToString();
        Health.text = "Health: " + GameData._Instance.Health.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
            paused = !paused;
        if (paused)
        {
            PersistantPause.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            PersistantPause.SetActive(false);
            Time.timeScale = 1;
        }

        if (GameData._Instance.Health <= 0)
            Application.LoadLevel(0);
    }

    public void doResume()
    {
        paused = false;
    }

    public void doUpgrade()
    {
        PauseMenu.SetActive(false);
        UpgradeMenu.SetActive(true);
    }

    public void doReturn()
    {
        PauseMenu.SetActive(true);
        UpgradeMenu.SetActive(false);
    }

    public void doMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void doQuit()
    {
        Application.Quit();
    }

    public void doUpgrade1()
    {
        if (GameData._Instance.Coins >= 100)
        {
            GameData._Instance.UpgradeCount = 1;
            GameData._Instance.Coins -= 100;
            FirstUpgradeText.text = "Upgraded";
            GameObject upgradeButton = GameObject.Find("FirstUpgrade");
            upgradeButton.GetComponent<Button>().interactable = false;
        }
    }

    public void doUpgrade2()
    {
        if (GameData._Instance.Coins >= 250)
        {
            GameData._Instance.UpgradeCount = 10;
            GameData._Instance.Coins -= 250;
            SecondUpgradeText.text = "Upgraded";
            GameObject upgradeButton = GameObject.Find("SecondUpgrade");
            upgradeButton.GetComponent<Button>().interactable = false;
        }
    }

    public void doUpgrade3()
    {
        if (GameData._Instance.Coins >= 500)
        {
            GameData._Instance.UpgradeCount = 100;
            GameData._Instance.Coins -= 500;
            ThirdUpgradeText.text = "Upgraded";
            GameObject upgradeButton = GameObject.Find("ThirdUpgrade");
            upgradeButton.GetComponent<Button>().interactable = false;
        }
    }

    public void doHeal()
    {
        if (GameData._Instance.Coins >= 50)
        {
            if (GameData._Instance.Health + 25 <= 100)
            {
                GameData._Instance.Health += 25;
                GameData._Instance.Coins -= 50;
            }
            else
            {
                GameData._Instance.Health = 100;
                GameData._Instance.Coins -= 50;
            }
        }
    }
}
