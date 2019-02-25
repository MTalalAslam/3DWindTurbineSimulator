using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class check : MonoBehaviour {
    System.DateTime date = new System.DateTime(2019,12,1);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int result = System.DateTime.Compare(System.DateTime.Now, date);
        if (result < 0)
        {
           
        }
        else if (result == 0)
        {
            Debug.Log("equal");
        }
        else if (result > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
