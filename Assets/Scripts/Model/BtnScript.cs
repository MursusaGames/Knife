using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public int parentId;
    public int id;
    private GetForAppleSystem getForAppleSystem;
    private GetForVideoSystem getForVideoSystem;

    private void Start()
    {
        getForAppleSystem = FindObjectOfType<GetForAppleSystem>();
        getForVideoSystem = FindObjectOfType<GetForVideoSystem>();
    }

    public void ClickBtn()
    {
        if(parentId < 3) getForAppleSystem.SetKnife(this);
        if (parentId > 2 && parentId < 5) getForVideoSystem.SetKnife(this);

    }
}
