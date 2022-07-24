using UnityEngine;

[CreateAssetMenu(menuName = "Data/StageInfo")]
public class StageInfo : ScriptableObject
{
    public int appleSpawnChance;    
    public int stage;
    public int tryCount;
    public Sprite ring;
    public Sprite prizKnife;
    public Sprite bossSprite;
    public int speed;
    public bool changeRotate;
}
