using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGPrefabScript : MonoBehaviour
{
    public List<Image> buttonsImg;
    public int id;
    private int _id;
    void Start()
    {
        if(id <3)
        {
            foreach(var img in buttonsImg)
            {
                img.color = Color.green;
            }
        }
        else if(id > 2 && id < 5)
        {
            foreach (var img in buttonsImg)
            {
                img.color = Color.blue;
            }
        }
        else if (id > 4 && id < 7)
        {
            foreach (var img in buttonsImg)
            {
                img.color = Color.red;
            }
        }
        else if (id > 6 && id < 9)
        {
            foreach (var img in buttonsImg)
            {
                img.color = Color.cyan;
            }
        }
        else if (id > 8)
        {
            foreach (var img in buttonsImg)
            {
                img.color = Color.gray;
            }
        }

        foreach (var img in buttonsImg)
        {
            img.gameObject.GetComponent<BtnScript>().parentId = id;
            img.gameObject.GetComponent<BtnScript>().id = _id;
            _id++;
        }

    }
    
}
