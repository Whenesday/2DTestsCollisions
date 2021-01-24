using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameScene;
    void Start()
    {
        Instantiate<GameObject>(gameScene, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
