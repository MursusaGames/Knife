using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleSystem : MonoBehaviour
{
    [SerializeField] Image sound;
    [SerializeField] GameObject soundCheckmark;
    [SerializeField] Image music;
    [SerializeField] GameObject musicCheckmark;
    [SerializeField] Image vibration;
    [SerializeField] GameObject vibrationCheckmark;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey(Constants.SOUND))
        {
            PlayerPrefs.SetInt(Constants.SOUND, 1);
            sound.color = Color.green;
            soundCheckmark.Show();
        }
        if (!PlayerPrefs.HasKey(Constants.MUSIC))
        {
            PlayerPrefs.SetInt(Constants.MUSIC, 1);
            music.color = Color.green;
            musicCheckmark.Show();
        }
        if (!PlayerPrefs.HasKey(Constants.VIBRO))
        {
            PlayerPrefs.SetInt(Constants.VIBRO, 1);
            vibration.color = Color.green;
            vibrationCheckmark.Show();
        }
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(Constants.SOUND) == 1)
        {
            sound.color = Color.green;
            soundCheckmark.Show();
        }
        else
        {
            sound.color = Color.red;
            soundCheckmark.Hide();
        }

        if (PlayerPrefs.GetInt(Constants.MUSIC) == 1)
        {
            music.color = Color.green;
            musicCheckmark.Show();
        }
        else
        {
            music.color = Color.red;
            musicCheckmark.Hide();
        }

        if (PlayerPrefs.GetInt(Constants.VIBRO) == 1)
        {
            vibration.color = Color.green;
            vibrationCheckmark.Show();
        }
        else
        {
            vibration.color = Color.red;
            vibrationCheckmark.Hide();
        }
    }
    public void ChangeSound()
    {
        if(PlayerPrefs.GetInt(Constants.SOUND) == 0)
        {
            PlayerPrefs.SetInt(Constants.SOUND, 1);
            sound.color = Color.green;
            soundCheckmark.Show();
            return;
        }
        else
        {
            PlayerPrefs.SetInt(Constants.SOUND, 0);
            sound.color = Color.red;
            soundCheckmark.Hide();
        }        
    }
    public void ChangeMusic()
    {
        if (PlayerPrefs.GetInt(Constants.MUSIC) == 0)
        {
            PlayerPrefs.SetInt(Constants.MUSIC, 1);
            music.color = Color.green;
            musicCheckmark.Show();
            return;
        }
        else
        {
            PlayerPrefs.SetInt(Constants.MUSIC, 0);
            music.color = Color.red;
            musicCheckmark.Hide();
        }
    }
    public void ChangeVibration()
    {
        if (PlayerPrefs.GetInt(Constants.VIBRO) == 0)
        {
            PlayerPrefs.SetInt(Constants.VIBRO, 1);
            vibration.color = Color.green;
            vibrationCheckmark.Show();
            return;
        }
        else
        {
            PlayerPrefs.SetInt(Constants.VIBRO, 0);
            vibration.color = Color.red;
            vibrationCheckmark.Hide();
        }
    }
}
