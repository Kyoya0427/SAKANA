using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedSensor : MonoBehaviour
{
    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }

    public bool GetGrounded()
    {
        return grounded;
    }
}
