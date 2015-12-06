using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject HowTo;
    public GameObject Menu;

    public void doStart()
    {
        Application.LoadLevel(1);
    }

    public void doHowTo()
    {
        Menu.SetActive(false);
        HowTo.SetActive(true);
    }

    public void doMenu()
    {
        Menu.SetActive(true);
        HowTo.SetActive(false);
    }

    public void doQuit()
    {
        Application.Quit();
    }
}
