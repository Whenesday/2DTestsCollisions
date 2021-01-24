using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text collisionValue;
    public Text triggerValue;
    public GameSceneScript gameSceneScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collisionValue.text = GameSceneScript.GetDestroyedPickupAmt().ToString();
        triggerValue.text = GameSceneScript.GetTriggerCount().ToString();
    }
}
