using UnityEngine;

[CreateAssetMenu(fileName = "RandomSpawnSettings", menuName = "NimamoŠe/RandomSpawnSettings", order = 1)]
public class RandomSpawnSettings : ScriptableObject
{
    public GameObject[] spawnPrefabs;
    public float spawnDelay = 1.0f;
    public Bounds spawnBounds; 

}