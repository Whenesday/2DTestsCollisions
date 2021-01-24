using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerExposer : MonoBehaviour
{
    // Start is called before the first frame update
    public string SortingLayerName = "Default";
    public int SortingOrder = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        gameObject.GetComponent <MeshRenderer> ().sortingLayerName = SortingLayerName;
        gameObject.GetComponent <MeshRenderer> ().sortingOrder = SortingOrder;
    }
}
