using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuSystem : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject challengeMenu;
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

}
