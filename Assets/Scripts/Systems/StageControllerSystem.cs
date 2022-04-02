using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageControllerSystem : MonoBehaviour
{
    [SerializeField] StagePrefab stagePrefab;
    [SerializeField] GamePlaySystem playSystem;
    [SerializeField] AppleSpawnSystem spawnSystem;
    [SerializeField] List<Image> levelsIcons = new List<Image>();
    [SerializeField] List<StageInfo> stages = new List<StageInfo>();
    [SerializeField] List<Image> tryCountIcons = new List<Image>();
    [SerializeField] TextMeshProUGUI stageText;
    [SerializeField] MatchData matchData;
    [SerializeField] GameObject winWindow;
    [SerializeField] GameObject gamePlayWindow;
    int currentStage = 0;
    int tryCount = 0;
    int currentLevel = 0;
    int tryCurrentCount = 0;
    int maxLevel = 5;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(Constants.STAGE))
        {
            PlayerPrefs.SetInt(Constants.STAGE, 0);
        }
        matchData.tryCount = stages[currentStage].tryCount;
        matchData.level = 0;
    }
    
    public void TrueTry()
    {
        tryCountIcons[tryCurrentCount].color = Color.gray;
        tryCurrentCount++;
        if (tryCurrentCount >= tryCount)
        {
            Invoke(nameof(WinLevel), 1f);
        }
    }
    private void WinLevel()
    {
        tryCurrentCount = 0;
        winWindow.Show();
        matchData.level++;
        matchData.tryCount++;
        stagePrefab.DeletLevel();
        playSystem.DeletKnifesInGame();
        //spawnSystem.ReloadLevel();
        playSystem.CreateKnife();
        
    }
    public void NewLevel()
    {
        winWindow.Hide();
        spawnSystem.ReloadLevel();
        stagePrefab.OnEnable();
        levelsIcons[currentLevel].color = Color.yellow;
        currentLevel++;
        if(currentLevel == maxLevel)
        {
            currentStage++;
            PlayerPrefs.SetInt(Constants.STAGE, currentStage);            
        }
        OnEnable();
        SetStageInfo();
    }
    void OnEnable()
    {
        currentStage = PlayerPrefs.GetInt(Constants.STAGE);
        matchData.stage = currentStage;
       
        matchData.appleSpawnChance = stages[currentStage].appleSpawnChance;
        stagePrefab.GameStart += SetStageInfo;
        currentStage = PlayerPrefs.GetInt(Constants.STAGE);
        matchData.stage = currentStage;
        matchData.ringSprite = stages[currentStage].ring;
        matchData.bossSprite = stages[currentStage].bossSprite;
        
        tryCount = matchData.tryCount;
        
    }
    private void OnDisable()
    {
        stagePrefab.GameStart -= SetStageInfo;
    }

    private void SetStageInfo()
    {
        stageText.text = "STAGE" + currentStage;
        for(int i = 0; i < tryCount; i++)
        {
            tryCountIcons[i].gameObject.Show();
            tryCountIcons[i].color = Color.white;
        }
        
    }

    
}
