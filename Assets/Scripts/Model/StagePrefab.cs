using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePrefab : MonoBehaviour
{
    public event Action GameStart;
    [SerializeField] List<GameObject> knifes;
    [SerializeField] List<GameObject> apples;
    [SerializeField] Sprite _ring;

    public void OnEnable()
    {
        GameStart?.Invoke();
    }
    public void DeletLevel()
    {
        for(int i = 0; i < knifes.Count; i++)
        {
            knifes[i].Hide();
        }
        for (int i = 0; i < apples.Count; i++)
        {
            apples[i].Hide();
        }
    }

    public void InitStage(int knifeCount, int appleCount, Sprite ring)
    {
        _ring = ring;
        if(knifeCount > 0)
        {
            int rand = UnityEngine.Random.Range(1, 3);
            for(int i = 0; i< knifeCount; i++)
            {
                knifes[i + rand].Show();
            }
        }
        if(appleCount > 0)
        {
            for (int i = 0; i < appleCount; i++)
            {
                apples[i].Show();
            }
        }
    }
    
}
