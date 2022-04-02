using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/MatchData")]
public class MatchData : ScriptableObject
{
    public int appleSpawnChance;    
    public int level;
    public int stage;
    public int tryCount;
    public Sprite ringSprite;
    public Sprite bossSprite;
}
