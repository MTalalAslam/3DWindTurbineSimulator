using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour {
    public GameObject Prefab; // This is our prefab object that will be exposed in the inspector
    public GameObject Smoke;
    public int numberToCreate; // number of objects to create. Exposed in inspector
    [SerializeField]
    GameObject TurbinePrefab;
    InputsAndButtons FromPreviousScene;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Image Point;
    [SerializeField]
    Image GridLineX;
    [SerializeField]
    Image GridLineY;
    GameObject Cube;
    public GameObject[] Turbines;
    public GameObject[] AllSmokes;
    public float[] TurbineOutput = new float[150];
    public Text TotalGeneratedPowerText;
    public Text TotalTurbines;
    public float[] GeneratedPower;
    public float[,] GeneratedPowerSet;
    public static int XDiaValue = 4;
    public static int YDiaValue = 5;
    public static int MinimumTurbineHeight =30;
    public static float ThrustCoefficient = 0.8f;
    public static float PowerCoefficient= 0.4f;
    int TurbineCount = 0;
    int GridLineHorizontal=0;
    int RotateGridForFirst=0;
    int FirstPointPosition=135;
    int GridLineHeight;
    float TurbineSizeEven;
    float TurbineSizeOdd;
    float LatestTurbinePosition;
    float ZLocation=0;
    float Xlocation=0;
   // public static bool ISHeightSame = true;
    bool IsLoopFirstTime = true;
    void Start () {
        SizeFitter();
        Populate();
	}


    void Update()
    {
        if (GeneratedPower!=null)
        {
            float TotalPower = 0;
            for (int i = 0; i < numberToCreate; i++)
            {
                TotalPower += GeneratedPower[i];
            }
            TotalGeneratedPowerText.text= "Total Power  = " +TotalPower;
        }
        TotalTurbines.text = "T. Turbines="+TurbineCount;
    }



    void SizeFitter()
    {
        FromPreviousScene = GameObject.Find("ButtonScript").GetComponent<InputsAndButtons>();
        Cube = GameObject.Find("Cube");
       // Cube.transform.localScale = new Vector3((FromPreviousScene.TurbineSize)*((int)FromPreviousScene.Width/FromPreviousScene.TurbineSize),0.04f, ((FromPreviousScene.Radius * 2) *  PopulateGrid.YDiaValue) * ((int)FromPreviousScene.Length / ((FromPreviousScene.Radius * 2) * PopulateGrid.YDiaValue)));
        Cube.transform.localScale = new Vector3(FromPreviousScene.Width,0.04f,FromPreviousScene.Width);
        Cube.transform.position = new Vector3((Cube.transform.localScale.x/2.0f),0f,(Cube.transform.localScale.z/2.0f));
        if (FromPreviousScene == null)
        {
            Debug.Log("ni milya");
        }
    }

    void NumberToCreate()
    {
        this.GetComponent<GridLayoutGroup>().constraintCount=(FromPreviousScene.Width) / (FromPreviousScene.TurbineSize);
        numberToCreate =(int)((Cube.transform.localScale.x* Cube.transform.localScale.x)/(((30f/1.5f)*2)*PopulateGrid.XDiaValue)); 
      //numberToCreate = (this.GetComponent<GridLayoutGroup>().constraintCount) * (((FromPreviousScene.Length) / ((FromPreviousScene.Radius * 2) * 5)/2)) + (this.GetComponent<GridLayoutGroup>().constraintCount - 1) * (((FromPreviousScene.Length) / ((FromPreviousScene.Radius * 2) * 5) / 2));
      //numberToCreate = (((FromPreviousScene.Width) / (FromPreviousScene.TurbineSize))+((FromPreviousScene.Width) / (FromPreviousScene.TurbineSize+450))+ (FromPreviousScene.Width) / (FromPreviousScene.TurbineSize + 900)+ (FromPreviousScene.Width) / (FromPreviousScene.TurbineSize + 1350)+ (FromPreviousScene.Width) / (FromPreviousScene.TurbineSize + 1800)+ (FromPreviousScene.Width) / (FromPreviousScene.TurbineSize + 450)+ (FromPreviousScene.Width) / (FromPreviousScene.TurbineSize + 450));
        this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Cube.transform.localScale.x/10f,Cube.transform.localScale.z/10f);
        //this.GetComponent<GridLayoutGroup>().cellSize.y()
    }
    void acha()
    {
    }

    void Populate()
    {
        NumberToCreate();
        Turbines = new GameObject[numberToCreate];
        AllSmokes = new GameObject[numberToCreate];
        GameObject newObj; // Create GameObject instance
        float j = 0;
        int  k = 0;
        GridLineHorizontal = k;
        bool IsEven = true;
        float scale=0.5f;
        float lastScale = 0;
        GameObject Grid = GameObject.Find("Cube");
      float TurbineSizeY= ((FromPreviousScene.Radius * 2) * PopulateGrid.YDiaValue);
       GeneratedPower = new float[numberToCreate];
        GeneratedPowerSet = new float[100,5];
        List <string>Lines = new List<string>();
        for (int i = 0; i < numberToCreate; i++)
        {

            TurbineCount++;
            Point = Instantiate(Point, panel.transform);
            //   newObj = (GameObject)Instantiate(Prefab, transform);
            //  newObj.transform.gameObject.name = i.ToString();
            // newObj.GetComponent<Button>().onClick.AddListener( () => Grid.GetComponent<GridButtons>().OnclickButton() );
          //  AllSmokes[i] = Instantiate(Smoke) as GameObject;
            Turbines[i] = Instantiate(TurbinePrefab) as GameObject;
            //Turbines[i].transform.localScale = new Vector3(1f, 1f, 1f);
            Turbines[i].GetComponent<canvasLook>().TurbineNo = i;
           
            // Turbines[i].GetComponent<canvasLook>().Turbines =Turbines;
            if (IsEven)
            {
                if (Xlocation > (Cube.transform.localScale.x - ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue))
                {
                   // LatestTurbinePosition = Turbines[i].transform.position.z;
                    j = 0;
                    k++;
                    scale+=0.5f;
                    if (!FromPreviousScene.IsSameHeight)
                    {
                        FromPreviousScene.TurbineSize += 73;
                        //if (k <= 3)
                        //{
                        //    TurbineSizeY =(((30f / 1.5f) * 2f) * 7f);

                        //}
                        //else
                        //{
                        //    TurbineSizeY = ((((k * 10f) / 1.5f) * 2f) * 7f);
                        //}
                       // TurbineSizeEven = TurbineSizeY;
                    }
                    else
                    {
                        //TurbineSizeY = (((80f / 1.5f) * 2f) * 7f);
                        //TurbineSizeEven = TurbineSizeOdd;

                        FromPreviousScene.TurbineSize = 424;
                    }
                    

                    IsEven = false;
                   
                }
            }
            else
            {
                if (Xlocation > (Cube.transform.localScale.x- ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue))
                {
                    Debug.Log("reached");
                    //LatestTurbinePosition = Turbines[i].transform.position.z;
                    j = 0;
                    k++;
                    if (!FromPreviousScene.IsSameHeight)
                    {
                        FromPreviousScene.TurbineSize += 73;
                        //if (k <= 3)
                        //{
                        //    TurbineSizeY = (((30f / 1.5f) * 2f) * 8f);
                        //}
                        //else
                        //{
                        //    TurbineSizeY = ((((k * 10f) / 1.5f) * 2f) * 8f);
                        //}
                      //  TurbineSizeOdd = TurbineSizeY;
                    }
                    else
                    {
                        FromPreviousScene.TurbineSize = 424;
                        // TurbineSizeY = (((80f / 1.5f) * 2f) * 8f);
                        // TurbineSizeOdd = TurbineSizeY;
                    }
                    scale += 0.5f;
                    IsEven = true;
                    
                }
            }
            if (k+1 < 8 && (!FromPreviousScene.IsSameHeight))
            {
                
                Turbines[i].transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                if (FromPreviousScene.IsSameHeight)
                {
                    scale = 4;
                }
                else
                {
                    scale = 4;
                }
                Turbines[i].transform.localScale = new Vector3(scale, scale, scale);
            }
        //    Turbines[i].transform.Find("Cone").transform.localScale = new Vector3(1f,FromPreviousScene.Radius,FromPreviousScene.Radius);
        //    Turbines[i].transform.Find("Cone.2").transform.localScale = new Vector3(1f, FromPreviousScene.Radius, FromPreviousScene.Radius);
        //    Turbines[i].transform.Find("Cone.3").transform.localScale = new Vector3(1f, FromPreviousScene.Radius, FromPreviousScene.Radius);
            Turbines[i].GetComponent<canvasLook>().TurbineRow = k+1;

            if (k!= lastScale)
            {
                lastScale = k;
                if (FromPreviousScene.IsGrid)
                {
                    Xlocation = 0f;// ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue;
                    ZLocation += ((getTrubineHeight((int)(k)) / 1.5f) * 2) * PopulateGrid.XDiaValue;
                }
                else
                {
                    if ((k + 1) % 2 == 0)
                    {
                        Xlocation = 0f;
                        ZLocation += ((getTrubineHeight((int)(k)) / 1.5f) * 2) *(PopulateGrid.YDiaValue);
                    }
                    else
                    {
                        Xlocation = ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue;
                        ZLocation += ((getTrubineHeight((int)(k)) / 1.5f) * 2) * (PopulateGrid.YDiaValue);
                    }
                }
            }
            if (FromPreviousScene.IsGrid)
            {
                Xlocation += ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue;
            }
            else
            {
                if ((k + 1) % 2 != 0)
                {
                    Xlocation += ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue;
                }
                else
                {
                    Xlocation += ((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * (PopulateGrid.XDiaValue);
                }
            }
            

            if (FromPreviousScene.IsGrid)
            {
                Turbines[i].transform.position = new Vector3(Xlocation, 0f, (ZLocation));
            }
            else
            {
                if (IsEven)
                {
                   // Debug.Log("K " + k);
                    if (k == 0)
                    {
                        //  Turbines[i].transform.position = new Vector3(((j * FromPreviousScene.TurbineSize) + (FromPreviousScene.TurbineSize / 2.0f)), 0, (ZLocation));
                        Turbines[i].transform.position = new Vector3(Xlocation - ((((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue) / 2), 0, (ZLocation));
                    }
                    else
                    {
                        // Turbines[i].transform.position = new Vector3(((j * FromPreviousScene.TurbineSize) + (FromPreviousScene.TurbineSize / 2.0f)), 0, ( ZLocation));
                        Turbines[i].transform.position = new Vector3(Xlocation - ((((getTrubineHeight((int)(k + 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue) / 2), 0, (ZLocation));
                    }
                }
                else
                {
                 //   Debug.Log("K " + k);
                    //    Turbines[i].transform.position = new Vector3(((j * FromPreviousScene.TurbineSize) + (FromPreviousScene.TurbineSize)), 0f, (ZLocation));
                    Turbines[i].transform.position = new Vector3(Xlocation, 0f, (ZLocation));

                }
            }
            j++;
         //   Debug.Log(Cube.transform.localScale.x / 10);
            //  Point.transform.position = new Vector2( ((Cube.transform.localScale.x/10)) , (Turbines[i].transform.position.z/10f));
            //            Point.rectTransform.localPosition = new Vector3((Turbines[i].transform.position.x/10) - ((Cube.transform.localScale.x/10)/2), -((Turbines[i].transform.position.z / 10) - ((Cube.transform.localScale.z / 10) / 2)), 0);
            
            float pointx = (Turbines[i].transform.position.x / 10) - ((Cube.transform.localScale.x / 10) / 2);
            float pointy = -((Turbines[i].transform.position.z / 10) - ((Cube.transform.localScale.z / 10) / 2));
            Point.rectTransform.localPosition = new Vector3(pointx, pointy, 0);
            if (k == 0)
            {
                GridLineY = Instantiate(GridLineY, panel.transform);
                GridLineY.rectTransform.localPosition = new Vector3(Point.rectTransform.localPosition.x +2f, Point.rectTransform.localPosition.y);
//                GridLine.rectTransform.localScale = new Vector3(GridLine.rectTransform.localPosition.x, Cube.transform.localScale.z / 10f);
                GridLineY.rectTransform.sizeDelta = new Vector2(GridLineY.rectTransform.sizeDelta.x, Cube.transform.localScale.z / 10f);
                GridLineHeight = (int)(GridLineY.rectTransform.localPosition.y - GridLineY.rectTransform.sizeDelta.y);
                FirstPointPosition = (int)(Point.rectTransform.localPosition.y);
            }
          
            if (FirstPointPosition >= GridLineHeight)
            {
                GridLineHorizontal = k;
                GridLineX = Instantiate(GridLineX, panel.transform);
                if (RotateGridForFirst == 0)
                {
                    //GridLineX.rectTransform.Rotate(0f, 0f, 90f); 
                    RotateGridForFirst = 1;
                }
                GridLineX.rectTransform.sizeDelta = new Vector2(Cube.transform.localScale.x / 10f, GridLineX.rectTransform.sizeDelta.y);
                GridLineX.rectTransform.localPosition = new Vector3(-((Cube.transform.localScale.x / 10) / 2), FirstPointPosition);
                if (FromPreviousScene.IsSameHeight)
                {
                    FirstPointPosition =(int) -((Turbines[i].transform.position.z / 10) - ((Cube.transform.localScale.z / 10) / 2));
                }
                else
                {

                    FirstPointPosition -= (int)(((YDiaValue * getTrubineHeight((int)(1))) / 10)) + (YDiaValue * 2);
                }
                
            }
            Point.rectTransform.localPosition = new Vector3(pointx, pointy, 0);
            //if ((k % 2 == 0) && (j % 2 == 0) && i!=0)
            //{
            //    Turbines[i].SetActive(false);
            //}
            //if (((k % 2) != 0) && ((j % 2) != 0) &&i!=0)
            //{
            //    Turbines[i].SetActive(false);
            //}
            //  newObj.GetComponentInChildren<Text>().text = i.ToString();
            // newObj.GetComponent<Button>().onClick.AddListener(() => Turbines[i].GetComponent<canvasLook>().Update());
            //Transform obj = Turbines[i].transform.Find("head");

            //AllSmokes[i].transform.localPosition= new Vector3(obj.position.x, obj.position.y, obj.position.z);
            if (Turbines[i].transform.position.z > Cube.transform.localScale.z)
            {
                Destroy(Turbines[i]);
                TurbineCount--;
                //Destroy(AllSmokes[i]);
                Destroy(Point);
                GeneratedPowerSet[k+1, 3]--;
                break;
            }
            else
            {
                // Debug.Log("X:"+Xlocation+":Y:"+ZLocation);
                Lines.Add("X:" + Xlocation + ":Y:" + ZLocation);

            }
        }
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"D:\\Coordinates.txt"))
        {
            foreach (string line in Lines)
            {
                // If the line doesn't contain the word 'Second', write the line to the file.               
                    file.WriteLine(line);               
            }
        }


        //  Grid.GetComponent<GridButtons>().OnclickButton();
        // Debug.Log("reached");

        //  Debug.Log(this.transform.parent.parent.gameObject.name);
        //this.transform.parent.parent.gameObject.SetActive(false);
    }
    public  int getTrubineHeight(int RowNumber)
    {
        int TurbineHeight = MinimumTurbineHeight-10;
        for (int i = 1; i <= RowNumber; i++)
        {
            TurbineHeight += 10;
        }
        if (TurbineHeight > 100)
        {
            TurbineHeight = 100;
        }
        if (FromPreviousScene.IsSameHeight)
        {
            return 80;
        }
        else
        {
            return TurbineHeight;
        }
    }
    public float GetTurbineRadius(int RowNumber)
    {
       // float TurbineRadius = (int)((getTrubineHeight(RowNumber)) / 1.5f);
    //    Debug.Log("RowNumber = "+RowNumber+" TurbineRadius="+TurbineRadius);
        return (int)((getTrubineHeight(RowNumber)) / 1.5f);
       // return TurbineRadius;
    }
}
