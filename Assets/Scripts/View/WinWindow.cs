using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI numberOfKnifesText;
    [SerializeField] private MatchData matchData;
    // Start is called before the first frame update
    void OnEnable()
    {
        stageText.text = "Stage " + matchData.stage.ToString();
        numberOfKnifesText.text = matchData.numberOffKnifes.ToString();
        
    }
}
