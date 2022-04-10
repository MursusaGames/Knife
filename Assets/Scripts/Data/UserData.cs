using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/UserData")]
public class UserData : ScriptableObject
{
    public int score;    
    public int apple;
    public Sprite currentKnife;
}
