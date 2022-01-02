using UnityEngine;

[CreateAssetMenu(fileName ="StaticData", menuName ="Game/Player")]
public class StaticData : ScriptableObject
{
    public GameObject PlayerPrefab;
    public float PlayerSpeed;
}
