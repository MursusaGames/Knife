using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchScreenSystem : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] RectTransform knifeParent;
    private Knife _knife;   

    public void GetKnife(Knife knife)
    {
        _knife = knife;
        Debug.Log("GetKnife");
    }
    public void SetKnifeParent(Knife knife)
    {
        knife.gameObject.transform.SetParent(knifeParent);
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointerUp");
        _knife.KnifeGo();
    }    

}
