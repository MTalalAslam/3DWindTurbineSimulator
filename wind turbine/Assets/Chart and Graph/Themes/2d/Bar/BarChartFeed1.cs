using UnityEngine;
using System.Collections;
using ChartAndGraph;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class BarChartFeed1 : MonoBehaviour {
    public GameObject barChartObj;
    BarChart barChart;
    public GameObject Content;
    public GameObject GraphClose; 
    public ChartDynamicMaterial[] MaterialList;
    GameObject BarChatSetts;
	void Start () {
        Content = GameObject.Find("Content");
        BarChatSetts = GameObject.Find("BarChatSetts(Clone)");
        GraphClose = GameObject.Find("GraphClose");
        barChart = barChartObj.GetComponent<BarChart>();
        PopulateGrid populate = Content.GetComponent<PopulateGrid>();
        CanvasBarChart canvasBarChart = barChart.GetComponent<CanvasBarChart>();
        canvasBarChart.DataSource.ClearCategories();

        GraphClose.GetComponent<Button>().onClick.AddListener(() => CloseGraph());

        string TurbineHeight = "";
        barChart.DataSource.StartBatch();
        if (barChart != null)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < populate.GeneratedPowerSet.Length/5; i++)
            {
                if (populate.GeneratedPowerSet[i, 1] != 0)
                {

                    list.Add(  "Power of Turbine Height " + TurbineHeight + "- Row " + populate.GeneratedPowerSet[i, 0] +" : "+ populate.GeneratedPowerSet[i, 1]+" | WindInput of "+ "Turbine Height " + TurbineHeight + "- Row " + populate.GeneratedPowerSet[i, 0]+" : "+ populate.GeneratedPowerSet[i, 2]);
                    TurbineHeight = populate.getTrubineHeight(Convert.ToInt32(populate.GeneratedPowerSet[i, 0])).ToString();
                    canvasBarChart.DataSource.AddCategory("T" + TurbineHeight+"-"+ populate.GeneratedPowerSet[i, 0], MaterialList[UnityEngine.Random.Range(0, MaterialList.Length)]);
                    
                    barChart.DataSource.SetValue("T" + TurbineHeight + "-" + populate.GeneratedPowerSet[i, 0], "Power", populate.GeneratedPowerSet[i, 1]);
                    barChart.DataSource.SetValue("T" + TurbineHeight + "-" + populate.GeneratedPowerSet[i, 0], "WInput", populate.GeneratedPowerSet[i, 2]);
                }
            }
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"D:\\PowerOutPutAndWindInput.txt"))
            {
                foreach (string line in list)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.               
                    file.WriteLine(line);
                }
            }
        }
        barChart.DataSource.EndBatch();
    }
    private void Update()
    {
    }
    public void CloseGraph()
    {
        Debug.Log("Close Graph Called");
        Destroy(BarChatSetts);
    }
}
