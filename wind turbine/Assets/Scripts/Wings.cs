using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour {
    InputsAndButtons FromPreviousScene;
    // Use this for initialization
    void Start () {
        FromPreviousScene = GameObject.Find("ButtonScript").GetComponent<InputsAndButtons>();
        this.transform.localScale = new Vector3(this.transform.localScale.x, FromPreviousScene.Radius, FromPreviousScene.WingSpan);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
