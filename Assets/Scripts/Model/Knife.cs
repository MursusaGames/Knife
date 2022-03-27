using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private TouchScreenSystem touchScreenSystem;
    public bool isGo;
    bool stopLine;
    private Rigidbody2D rg;
    
    [SerializeField] float speed = 0.1f;
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
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
            rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            if (stopLine)
            {
                isGo = false;
                rg.velocity = Vector2.zero;
                //rg.simulated = false;
                touchScreenSystem.SetKnifeParent(this);
                return;
            }            
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            stopLine = true;
            touchScreenSystem.KnifeIn();
        }
        if (collision.gameObject.CompareTag("Knife"))
        {
            
        }
    }

}
