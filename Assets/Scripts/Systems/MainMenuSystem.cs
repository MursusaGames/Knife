using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuSystem : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject challengeMenu;
    [SerializeField] GameObject GamePlayMenu;
    public void LoadURL()
    {
        Application.OpenURL(Constants.DEVELOPER_URL);
    }

    public void ShowSettingsMenu()
    {
        settingsMenu.Show();
    }
    public void HideSettingMenu()
    {
        settingsMenu.Hide();
    }
    public void ShowChallengeMenu()
    {
        challengeMenu.Show();
    }
    public void HideChallengeMenu()
    {
        challengeMenu.Hide();
    }
    public void ShowGamePlay()
    {
        GamePlayMenu.Show();
        mainMenu.Hide();
    }
    public void ShowMainMenu()
    {
        GamePlayMenu.Hide();
        mainMenu.Show();
    }

}
