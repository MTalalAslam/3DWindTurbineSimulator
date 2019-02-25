using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateturbine : MonoBehaviour {
    canvasLook ParentCanvasLook;

    // Use this for initialization
    void Start () {
        ParentCanvasLook = this.GetComponentInParent<canvasLook>();
      //  FromPreviousScene = GameObject.Find("ButtonScript").GetComponent<InputsAndButtons>();
      //  this.transform.localScale = new Vector3(1f, FromPreviousScene.Radius, FromPreviousScene.Radius);
      //  this.transform.localScale = new Vector3(1f, FromPreviousScene.Radius, FromPreviousScene.Radius);
      //  this.transform.localScale = new Vector3(1f, FromPreviousScene.Radius, FromPreviousScene.Radius);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(ParentCanvasLook.WindSpeed,0f, 0f);
       // this.transform.r
	}
}
