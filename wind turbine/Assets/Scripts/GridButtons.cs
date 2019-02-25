using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class GridButtons : MonoBehaviour
{
    int name;
    int i = 0;
    public int NoOfTurbines;
    public GameObject[] Turbines;
    PopulateGrid Obj=null;
    bool firstTime = true;
    float ThrustCoefficient;
    public void Start () {
        //Obj = GameObject.Find("Content").GetComponent<PopulateGrid>();

        //if (Obj != null)
        //{

        //    Debug.Log(Obj.name);
        //}
        //NoOfTurbines = Obj.numberToCreate;
        //Debug.Log(NoOfTurbines);
        //Turbines = new GameObject[NoOfTurbines];

        //for (int i = 0; i < NoOfTurbines; i++)
        //{
        //    Turbines[i] = Obj.Turbines[i];
        //    //  Turbines[i].GetComponentInChildren<Text>().text = i.ToString();
        //    Turbines[i].SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Turbines.Length);

    }

    public void OnclickButton()
    {

      if (firstTime)
        {
            Obj = GameObject.Find("Content").GetComponent<PopulateGrid>();

            if (Obj != null)
            {

               // Debug.Log(Obj.name);
            }
            NoOfTurbines = Obj.numberToCreate;
            //Debug.Log(NoOfTurbines);
            Turbines = new GameObject[NoOfTurbines];

            for (int i = 0; i < NoOfTurbines; i++)
            {
                Turbines[i] = Obj.Turbines[i];
                Turbines[i].SetActive(false);
            }
            firstTime = false;
        }
        int.TryParse(EventSystem.current.currentSelectedGameObject.name, out name);

        if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color != Color.green)
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color(194f,194f,194f);
        }
        //Debug.Log(name.ToString());
       // Debug.Log("No of turbines " + Turbines.Length);
        //for (int i=0;i<Turbines.Length;i++) 
        //{
        //    Debug.Log(Turbines[i].gameObject.name);
        //}
        if (Turbines[name].activeInHierarchy == true)
        {
            Turbines[name].SetActive(false);
        }
        else
        {
            Turbines[name].SetActive(true);
        }
    }

}
