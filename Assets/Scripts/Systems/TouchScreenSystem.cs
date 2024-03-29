﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchScreenSystem : MonoBehaviour 
{
    RectTransform knifeParent;    
    [SerializeField] GamePlaySystem playSystem;
    [SerializeField] private GamePlayMenu playMenu;
    private Knife _knife;
    
    public void GetKnifeParent(RectTransform _knifeParent)
    {
        knifeParent = _knifeParent;
    }
    public void GetKnife(Knife knife)
    {
        _knife = knife;        
    }
    public void SetKnifeParent(Knife knife)
    {
        knife.gameObject.transform.SetParent(knifeParent);
        
    }
    public void GameOver()
    {
        playSystem.GameOver();
    }
    public void KnifeIn()
    {
        playSystem.matchData.numberOffKnifes++;
        playMenu.UpdateScore();
        playSystem.KnifeIsGo();
        Invoke(nameof(NewKnife), 0.01f);
    }

    public void Go()
    {
        _knife.KnifeGo();
    }  
    
    private void NewKnife()
    {
        playSystem.CreateKnife();        
    }

}
