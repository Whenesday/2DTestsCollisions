using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject ufoModel;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(ufoModel,gameObject.transform);
    }
    //new Vector3 (0,0,0)

    // Update is called once per frame
    void Update()
    {
        
    }
}
