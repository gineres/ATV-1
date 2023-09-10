using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBScript : MonoBehaviour
{
    public Rigidbody rb;
    public float backspinDrag = 0.001f;

    Vector3 previousPos;
    Vector3 currentPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Magnitude(rb.velocity));
        previousPos = currentPos;
        currentPos = rb.position;
        Debug.DrawLine(previousPos, currentPos, Color.white, 20f);
    }

    void FixedUpdate()
    {
        Vector3 newForce = new Vector3 (0, Mathf.Sqrt(Vector3.Magnitude(rb.velocity)), 0);
        rb.AddForce(newForce);
    }

    public void InitialForce(){
        rb.AddForce(25.139f,0,0, ForceMode.Impulse);
    }
}
