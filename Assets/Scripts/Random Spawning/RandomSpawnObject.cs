using UnityEngine;

[CreateAssetMenu(fileName = "RandomSpawnObject", menuName = "NimamoŠe/Random Spawn Object", order = 1)]
public class RandomSpawnObject : ScriptableObject
{
    public GameObject prefab;
    [Header("Position")]
    public Vector3 spawnPosition;
    public bool randomX;
    public bool randomY;
    public bool randomZ;
    [Header("Rotation")]
    public Vector3 spawnRotation;
    public bool randomRotationX;
    public bool randomRotationY;
    public bool randomRotationZ;


}