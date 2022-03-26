using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySystem : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] Transform knifeParent;
    [SerializeField] Transform startPoint;
    void Start()
    {
        CreateKnife();
    }

    public void CreateKnife()
    {
        Instantiate(knife, startPoint.position, Quaternion.identity, knifeParent);
    }    
}
