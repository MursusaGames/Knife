using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleSpawnSystem : MonoBehaviour
{
    [SerializeField] MatchData matchData;
    [SerializeField] StagePrefab stagePrefab;
    int apples;
    int knifes;
    int bossStage = 4;
    private Sprite ring;
    
    private void Start()
    {
        InitData();
    }
    private void OnEnable()
    {
        stagePrefab.GameStart += InitStage;
    }
    private void InitData()
    {
        
        ring = matchData.ringSprite;
        if (matchData.level < bossStage)
        {
            knifes = matchData.level;
            if (GetAppleCount())
            {
                apples = matchData.level;
            }
        }
        else
        {
            knifes = 0;
            apples = 0;
            ring = matchData.bossSprite;
        }
    } 
    public void ReloadLevel()
    {
        InitData();
        //InitStage();
    }
    void OnDisable()
    {
        stagePrefab.GameStart -= InitStage;
    }

    private bool GetAppleCount()
    {
        bool isApple = false;
        int rand = Random.Range(0, 100);        //100%
        if (rand < matchData.appleSpawnChance) isApple = true;        
        return isApple;
    }
    private void InitStage()
    {
        Debug.Log("InitStage"+ apples);
        stagePrefab.InitStage(knifes, apples, ring);
    }    
}
