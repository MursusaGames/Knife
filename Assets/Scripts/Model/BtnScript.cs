using UnityEngine;
using UnityEngine.UI;

public class BtnScript : MonoBehaviour
{
    public int parentId;
    public int id;
    private GetForAppleSystem getForAppleSystem;
    private GetForVideoSystem getForVideoSystem;
    public Image knifeImg;
    private void Awake()
    {
        getForAppleSystem = FindObjectOfType<GetForAppleSystem>();
        getForVideoSystem = FindObjectOfType<GetForVideoSystem>();
    }

    public void ClickBtn()
    {
        if(parentId < 3)
        {
            if (knifeImg.color != Color.white) getForAppleSystem.SetKnife(this);
            else
            {
                getForAppleSystem.data.currentKnife = knifeImg.sprite;
                getForAppleSystem.knifesMenu.UpgradeKnifeImage();
                getForAppleSystem.mainMenu.knifeImg.sprite = knifeImg.sprite;
            }
                
        }
            
        if (parentId > 2 && parentId < 5)
        {
            if(knifeImg.color != Color.white) getForVideoSystem.SetKnife(this);
            else getForAppleSystem.data.currentKnife = knifeImg.sprite;
        }
    }
}
