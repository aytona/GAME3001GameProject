using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject HowTo;
    public GameObject Menu;
    public GameObject Credits;

    public void doStart()
    {
        Application.LoadLevel(1);
    }

    // Going from menu to how to
    public void doHowTo()
    {
        Menu.SetActive(false);
        HowTo.SetActive(true);
    }

    // Going from menu to credits
    public void doCredits()
    {
        Menu.SetActive(false);
        Credits.SetActive(true);
    }

    // Going back to main menu
    public void doMenu()
    {
        Menu.SetActive(true);
        HowTo.SetActive(false);
        Credits.SetActive(false);
    }

    public void doQuit()
    {
        Application.Quit();
    }
}
