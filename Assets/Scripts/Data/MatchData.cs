﻿using UnityEngine;
using UniRx;

[CreateAssetMenu(menuName = "Data/MatchData")]
public class MatchData : ScriptableObject
{
    public LocalizationData localizationData;
    public int appleSpawnChance;    
    public int level;
    public int stage;
    public int numberOffKnifes;
    public int tryCount;
    public bool isGift;
    public Sprite ringSprite;
    public Sprite bossSprite;
    public MoneyData moneyData;
    public CustomsDataContainer CustomDataContainer;
    public enum State
    {
        MainMenu,
        ClosingMainMenu,
        Initializing,
        StartAnimation,
        ShowQuestion,
        Question,
        EnemyQuestion,
        WaitForResult,
        Result,
        Fight,
        SetHealth,
        Movement,
        CheckHealth,
        EndGame,
        Observer,
        Finish,
        PlayerDeath,
    }
    public ReactiveProperty<State> state = new ReactiveProperty<State>(State.MainMenu);
}
