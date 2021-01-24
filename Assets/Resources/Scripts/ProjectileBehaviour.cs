using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private float fireballXValue;
    public float fireballSpeed;
    private Rigidbody2D fireballBody;
    // Start is called before the first frame update
    void Start()
    {
        fireballBody = GetComponent<Rigidbody2D>();
        // fireballBody.velocity = new Vector2(fireballSpeed, 0);
        fireballBody.AddForce(new Vector2(fireballSpeed, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdjustCollision2DSize(Vector2 size)
    {

    }
}
