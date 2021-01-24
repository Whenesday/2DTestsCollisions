using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeToLive = 4f;
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}
