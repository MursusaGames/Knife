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
    public List<Rigidbody2D> knifeRG = new List<Rigidbody2D>();
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
            knifeRG.Add(_knife.GetComponent<Rigidbody2D>());
        }
            
    }
    public void DeletKnifesInGame()
    {
        foreach(var knife in knifesInGame)
        {
            Destroy(knife);
        }
        knifesInGame.Clear();
        knifeRG.Clear();
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
