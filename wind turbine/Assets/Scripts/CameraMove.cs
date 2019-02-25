using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    GameObject parentt;
    
	// Use this for initialization
	void Start () {
     //   parentt = GameObject.Find("parentt");
    }
	
	// Update is called once per frame
	void Update () {
      
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Camera.main.transform.forward * 350f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = (transform.position + (-Camera.main.transform.forward) * 350f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = (transform.position + (-Camera.main.transform.right) * 200f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = (transform.position + (Camera.main.transform.right) *200f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Translate(0f,-6f,0f);

        }
        else if (Input.GetKey(KeyCode.E))
        {
            this.transform.Translate(0f,6f, 0f);

        }
    }
}
