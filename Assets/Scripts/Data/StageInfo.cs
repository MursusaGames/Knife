using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/StageInfo")]
public class StageInfo : ScriptableObject
{
    public int appleSpawnChance;    
    public int stage;
    public int tryCount;
    public Sprite ring;
    public Sprite bossSprite;
}
