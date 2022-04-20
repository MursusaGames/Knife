using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetForAppleSystem : MonoBehaviour
{
    [SerializeField] GameObject textForSmoulBtn;
    [SerializeField] GameObject textForBigBtn;
    [SerializeField] UserData data;
    [SerializeField] GameObject GetBtn;
    private BtnScript currentScript;
    private int price;
    private int lowPrice = 500;
    private int mediumPrice = 1000;
    private int hiPrice = 1500;
    void Start()
    {
        
    }

    public void SetKnife(BtnScript script)
    {
        price = script.parentId == 0 ? lowPrice : script.parentId == 1 ? mediumPrice : hiPrice;
        currentScript = script;
        GetBtn.Show();
    }

    public void TryGetKnifeForApple( )
    {
        if (data.apple < price)
        {
            var popUp = Instantiate(textForSmoulBtn, GetBtn.transform.position, Quaternion.identity, GetBtn.transform);
            Destroy(popUp, 1f);
        }
    }
}
