using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private TouchScreenSystem touchScreenSystem;
    bool isGo;
    float stopPoint = -12f;
    [SerializeField] float speed = 0.1f;
    void Awake()
    {
        touchScreenSystem = FindObjectOfType<TouchScreenSystem>();
        touchScreenSystem.GetKnife(this);
    }

    public void KnifeGo()
    {
        if(!isGo) isGo = true;
    }
    void FixedUpdate()
    {
        if (isGo)
        {
            Vector3 pos = transform.position;
            pos.y += speed;
            if(pos.y >= stopPoint)
            {
                isGo = false;
                touchScreenSystem.SetKnifeParent(this);
                return;
            }
            transform.position = pos;
        }
    }
}
