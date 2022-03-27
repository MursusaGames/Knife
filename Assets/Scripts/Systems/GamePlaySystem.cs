using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySystem : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] Transform knifeParent;
    [SerializeField] Transform startPoint;
    [SerializeField] StageControllerSystem stageController;
    [SerializeField] MatchData matchData;
    List<GameObject> knifesInGame = new List<GameObject>();
    int tryCount = 0;
    bool stopSpawn;
    void Start()
    {
        CreateKnife();
    }

    public void CreateKnife()
    {
        if (!stopSpawn)
        {
            var _knife = Instantiate(knife, startPoint.position, Quaternion.identity, knifeParent);
            knifesInGame.Add(_knife);
        }
            
    }
    public void DeletKnifesInGame()
    {
        foreach(var knife in knifesInGame)
        {
            Destroy(knife, 1f);
        }
        stopSpawn = false;
        tryCount = 0;
    }
    
    public void KnifeIsGo()
    {
        stageController.TrueTry();
        tryCount++;
        if (tryCount >= matchData.tryCount) stopSpawn = true;
    }
}
