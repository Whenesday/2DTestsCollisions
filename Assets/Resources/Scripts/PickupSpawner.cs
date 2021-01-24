using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupModel;
    private Vector3 offset;
    public float spawnTimer = 5.0f;
    private float elaspedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(pickupModel, gameObject.transform);
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        elaspedTime += Time.deltaTime;
        if (elaspedTime > spawnTimer)
        {
            elaspedTime = 0;
            Debug.Log("Spawning new Pickup via Update");
            SpawnPickup();
        }
    }

    public void SpawnPickup()
    {
        offset = Random2DVector(new Vector3(-3, -3, 0), new Vector3(3, 3, 0));
        //Instantiate<GameObject>(pickupModel, gameObject.transform);
        //Instantiate<GameObject>(pickupModel, gameObject.transform + offset);
        Instantiate<GameObject>(pickupModel, gameObject.transform.position+offset, new Quaternion(0,0,0,0));
    }
    public Vector3 Random2DVector(Vector3 min, Vector3 max)
    {
        return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y),0);
    }
}
