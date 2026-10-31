using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Vector3 spawnposition;

    void Start()
    {
        Instantiate(objectToSpawn, spawnposition, transform.rotation);
    }


    void Update()
    {
        
    }
}
