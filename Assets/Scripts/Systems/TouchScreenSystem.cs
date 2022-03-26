using System;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchScreenSystem : MonoBehaviour 
{
    [SerializeField] RectTransform knifeParent;
    [SerializeField] public Transform collisionLine;
    [SerializeField] GamePlaySystem playSystem;
    private Knife _knife;   

    public void GetKnife(Knife knife)
    {
        _knife = knife;        
    }
    public void SetKnifeParent(Knife knife)
    {
        knife.gameObject.transform.SetParent(knifeParent);
    }

    

    public void Go()
    {
        _knife.KnifeGo();
        Invoke(nameof(NewKnife), 0.3f);
    }  
    
    private void NewKnife()
    {
        playSystem.CreateKnife();
    }

}
