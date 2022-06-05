using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlaySystem : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] Transform knifeParent;
    [SerializeField] Transform startPoint;
    [SerializeField] StageControllerSystem stageController;
    public MatchData matchData;
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] GameObject gamePlayWindow;
    List<GameObject> knifesInGame = new List<GameObject>();
    public List<Rigidbody2D> knifeRG = new List<Rigidbody2D>();
    List<BoxCollider2D> knifeCol = new List<BoxCollider2D>();
    int tryCount = 0;
    bool stopSpawn;
    void Start()
    {
        CreateKnife();
        matchData.numberOffKnifes = 0;
    }

    public void CreateKnife()
    {
        if (!stopSpawn)
        {
            var _knife = Instantiate(knife, startPoint.position, Quaternion.identity, knifeParent);
            knifesInGame.Add(_knife);
            knifeRG.Add(_knife.GetComponent<Rigidbody2D>());
            knifeCol.Add(_knife.GetComponent<BoxCollider2D>());
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
        knifeCol.Clear();
        stopSpawn = false;
        tryCount = 0;
    }
    public void ResetCollaiders()
    {
        foreach (var knife in knifeCol)
        {
            knife.enabled = false;
        }
    }
    
    public void KnifeIsGo()
    {
        stageController.TrueTry();
        tryCount++;
        if (tryCount >= matchData.tryCount)
        {
            stopSpawn = true;
            ResetCollaiders();
        }
            
    }

    public void GameOver()
    {
        Invoke(nameof(Delay), 1f);
    }

    private void Delay()
    {
        gameOverWindow.Show();
    }

    public void ReloadGame()
    {
        gamePlayWindow.Hide();
        gameOverWindow.Hide();
        SceneManager.LoadScene(0);
    }
}
