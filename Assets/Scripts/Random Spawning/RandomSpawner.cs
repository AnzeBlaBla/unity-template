using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class RandomSpawner : MonoBehaviour
{
    public RandomSpawnSettings settings;

    void Start()
    {
        StartSpawning();
    }


    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }
    public void StopSpawning()
    {
        StopCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(settings.spawnDelay);
            SpawnObject();
        }
    }
    void SpawnObject()
    {
        // get a random prefab from the list
        var prefab = settings.spawnPrefabs[Random.Range(0, settings.spawnPrefabs.Length)];
        // get a random position within the bounds
        var position = new Vector3(
            Random.Range(settings.spawnBounds.min.x, settings.spawnBounds.max.x),
            0.5f,
            Random.Range(settings.spawnBounds.min.z, settings.spawnBounds.max.z));
        // get a random rotation
        var rotation = Quaternion.Euler(
            0,
            Random.Range(0, 360),
            0);
        // instantiate the prefab
        Instantiate(prefab, position, rotation);
    }

}