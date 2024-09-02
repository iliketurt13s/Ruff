using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureSpawner : MonoBehaviour
{
    public GameObject[] structures;
    float distanceFromSpawn;
    public float maxDistanceFromSpawn;
    bool spawnedRight = false;

    void Start()
    {
        spawnStructure();
    }

    void spawnStructure()
    {
        if (!spawnedRight){
            //spawns a structure and stores that structure in the spawned gameobject
            GameObject spawned = Instantiate(structures[Random.Range(0, structures.Length)], transform.position, Quaternion.identity);
            //Gets references for the spawned structure script
            Structure script = spawned.GetComponent<Structure>();
            spawned.transform.position = new Vector3(distanceFromSpawn + (script.width/2), transform.position.y + Random.Range(-1, 2), 0);
            transform.position = new Vector3(0, spawned.transform.position.y, 0); distanceFromSpawn = distanceFromSpawn + script.width;
            if (distanceFromSpawn > maxDistanceFromSpawn){
                spawnedRight = true;
                distanceFromSpawn = 0;
                transform.position = new Vector3(0, -5, 0);
            }
            spawnStructure();
        } else {
            //spawns a structure and stores that structure in the spawned gameobject
            GameObject spawned = Instantiate(structures[Random.Range(0, structures.Length)], transform.position, Quaternion.identity);
            //Gets references for the spawned structure script
            Structure script = spawned.GetComponent<Structure>();
            spawned.transform.position = new Vector3(distanceFromSpawn - (script.width/2), transform.position.y + Random.Range(-1, 2), 0);
            transform.position = new Vector3(0, spawned.transform.position.y, 0); distanceFromSpawn = distanceFromSpawn - script.width;
            if (distanceFromSpawn > -maxDistanceFromSpawn){
                spawnStructure();
            }
        }
    }
}
