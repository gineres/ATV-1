using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bbObject;
    public Transform bbPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bb = Instantiate(bbObject, bbPosition.position, Quaternion.identity) as GameObject;
            BBScript script = bb.GetComponent<BBScript>();
            script.InitialForce();
        }
    }
}