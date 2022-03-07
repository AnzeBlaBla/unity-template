using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class RandomSpawner : MonoBehaviour
{
    public RandomSpawnObject[] spawnObjects;
    public float spawnDelay = 1.0f;

    public GameObject spawnBoundsObject;
    private Bounds spawnBounds;

    void Awake()
    {
        spawnBounds = spawnBoundsObject.GetComponent<Collider>().bounds;
    }
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
            yield return new WaitForSeconds(spawnDelay);
            SpawnObject();
        }
    }
    void SpawnObject()
    {
        // get a random prefab from the list
        var toSpawn = spawnObjects[Random.Range(0, spawnObjects.Length)];

        // get a random position within the bounds
        var position = new Vector3(
            toSpawn.randomX ? Random.Range(spawnBounds.min.x, spawnBounds.max.x) : toSpawn.spawnPosition.x,
            toSpawn.randomY ? Random.Range(spawnBounds.min.y, spawnBounds.max.y) : toSpawn.spawnPosition.y,
            toSpawn.randomZ ? Random.Range(spawnBounds.min.z, spawnBounds.max.z) : toSpawn.spawnPosition.z
        );

        // get a random rotation
        var rotation = Quaternion.Euler(
            toSpawn.randomRotationX ? Random.Range(0, 360) : toSpawn.spawnRotation.x,
            toSpawn.randomRotationY ? Random.Range(0, 360) : toSpawn.spawnRotation.y,
            toSpawn.randomRotationZ ? Random.Range(0, 360) : toSpawn.spawnRotation.z
            );



        // instantiate the prefab
        Instantiate(toSpawn.prefab, position, rotation);
    }

}