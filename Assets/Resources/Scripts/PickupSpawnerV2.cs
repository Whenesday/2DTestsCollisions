using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnerV2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickupModel;
    private Vector3 offset;
    public float spawnTimer = 5.0f;
    private float elaspedTime = 0.0f;
    public static bool signalOver = false;
    void Start()
    {
        signalOver = false;
        //Instantiate<GameObject>(pickupModel, gameObject.transform);
        SpawnPickupStatic(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        elaspedTime += Time.deltaTime;
        if (elaspedTime > spawnTimer)
        {
            elaspedTime = 0;
            Debug.Log("Spawning new Pickup via Update");
            SpawnPickupRandom();
        }
    }
    public void SpawnPickupRandom()
    {
        offset = Random2DVector(new Vector3(-10, -10, 0), new Vector3(10, 10, 0));
        //Instantiate<GameObject>(pickupModel, gameObject.transform);
        //Instantiate<GameObject>(pickupModel, gameObject.transform + offset);
        Instantiate<GameObject>(pickupModel, gameObject.transform.position + offset, new Quaternion(0, 0, 0, 0));
    }
    public void SpawnPickupStatic(Vector3 specifiedPos)
    {
        Instantiate<GameObject>(pickupModel, specifiedPos, new Quaternion(0, 0, 0, 0));
    }
    public Vector3 Random2DVector(Vector3 min, Vector3 max)
    {
        return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), 0);
    }
}
