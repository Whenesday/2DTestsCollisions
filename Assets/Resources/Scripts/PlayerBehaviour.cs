using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D body;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }
}
