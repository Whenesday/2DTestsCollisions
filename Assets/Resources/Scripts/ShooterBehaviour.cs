using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : MonoBehaviour
{
    public int mode = 0;
    public GameObject fireball;    // Start is called before the first frame update
    public GameObject rocket;

    void Start()
    {
        mode = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // instantiate the fireball object
            if (mode == 0)
            {
                Instantiate(fireball,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0),
                new Quaternion(0, 0, 0, 0));
            } else if (mode == 1)
            {
                Instantiate(rocket,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0),
                new Quaternion(0, 0, 0, 0));
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mode++;
            if(mode > 1)
            {
                mode = 0;
            }
        }
    }
}
