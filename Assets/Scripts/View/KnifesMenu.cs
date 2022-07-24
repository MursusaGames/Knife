using UnityEngine;
using UnityEngine.UI;

public class KnifesMenu : MonoBehaviour
{
    [SerializeField] private Image knifeImg;
    [SerializeField] private UserData data;

    public void UpgradeKnifeImage()
    {
        knifeImg.sprite = data.currentKnife;
    }
}
