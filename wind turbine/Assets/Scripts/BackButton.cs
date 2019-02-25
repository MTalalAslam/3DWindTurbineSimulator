using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {
    public GameObject BarGraph;
    public GameObject InputBarGraph;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickBackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickGraphButton()
    {
        Instantiate(BarGraph);
    }
    public void OnClickInputGraphButton()
    {
        Instantiate(InputBarGraph);
    }
}
