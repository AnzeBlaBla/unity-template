using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "LevelData", menuName = "NimamoŠe/Level", order = 1)]
public class LevelData : ScriptableObject
{
    public GameObject prefab;
    public Transform spawnPoint;
}