using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWindow : MonoBehaviour
{
    [SerializeField] private MainMenuSystem menuSystem;

    public void GetKnife()
    {
        menuSystem.ShowKnifessMenu();
        gameObject.SetActive(false);
    }
}
