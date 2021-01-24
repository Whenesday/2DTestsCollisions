using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int spawnLimit;
    public float spawnTimer = 5.0f;
    private float elaspedTime = 0.0f;
    public Vector3 minSpawnAreaLoc;
    public Vector3 maxSpawnAreaLoc;
    private List<GameObject> gameObjects;
    private Vector3 offset;
    void Start()
    {
        gameObjects = new List<GameObject>();
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        elaspedTime += Time.deltaTime;
        if ((gameObjects.Count < spawnLimit) && (elaspedTime > spawnTimer)) {
            elaspedTime = 0;
            SpawnObject();
        }
        ReviewSpawnList();


    }
    public Vector3 Random2DVector(Vector3 min, Vector3 max)
    {
        return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), 0);
    }
    private void SpawnObject()
    {
        offset = Random2DVector(minSpawnAreaLoc, maxSpawnAreaLoc);
        gameObjects.Add(Instantiate<GameObject>(objectToSpawn, gameObject.transform.position + offset, new Quaternion(0, 0, 0, 0)));
    }

    private void ReviewSpawnList()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i] == null)
            {
                Debug.Log("Detected item destoryed in spawn manager");
                gameObjects.RemoveAt(i);
                i -= 1;
            }
        }
    }
}
