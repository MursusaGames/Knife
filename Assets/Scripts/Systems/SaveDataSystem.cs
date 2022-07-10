using UnityEngine;
using UniRx;

public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;    
    
   
    private void Start()
    {
        
        LoadPlayerData();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SavePlayerData();
    }

    private void OnApplicationQuit() => SavePlayerData();
    private void OnDestroy()
    {
        SavePlayerData();
    }
    public void SaveData() => SavePlayerData();

    #region LOADS
    private void SavePlayerData()
    {
        PlayerPrefs.SetInt(Constants.STAGE, data.stage);
        //SaveSkins();
    }

   
    #endregion

    #region LOADS
    private void LoadPlayerData()
    {
        data.stage = PlayerPrefs.GetInt(Constants.STAGE);
        
    }
   
    #endregion
}
