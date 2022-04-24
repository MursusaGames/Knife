using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GiftSystem : MonoBehaviour
{
    [SerializeField] TimerSystem timerSystem;
    [SerializeField] GameObject giftWindow;
    [SerializeField] MatchData data;
    [SerializeField] GameObject blockerWindow;
    [SerializeField] TextMeshProUGUI blockerText;
    [SerializeField] Image giftBtnImg;
    public void StartGiftMode()
    {
        if (!data.isGift)
        {
            blockerWindow.Show();
            blockerText.text =  timerSystem.GetTime();
            Invoke(nameof(HideBlockerWindow), 1.3f);
            return;
        }
        giftWindow.Show();
    }
    public void StopGiftMode()
    {
        data.isGift = false;
        giftWindow.Hide();
        timerSystem.StartTimer();
        giftBtnImg.color = Color.cyan;
    }
    
    void HideBlockerWindow()
    {
        blockerWindow.Hide();
    }
}
