using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMenu : MonoBehaviour {

    public Text Score;
    public Text Coins;
    public Text Health;
    public GameObject PauseMenu;
    public GameObject UpgradeMenu;
    public GameObject PersistantPause;

    private bool paused;

    void Update()
    {
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
}
