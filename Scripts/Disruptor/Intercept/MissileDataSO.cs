using UnityEngine;

[CreateAssetMenu(fileName = "MissileDataSO", menuName = "ScriptableObjects/MissileDataSO", order = 1)]
public class MissileDataSO : ScriptableObject
{
    [SerializeField] public string missileName;
    [SerializeField] public string missileDescription;
    [SerializeField] public string targetLayerstring;
    [SerializeField] public float range;
    [SerializeField] public float speed;
}