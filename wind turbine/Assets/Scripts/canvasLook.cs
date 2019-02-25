using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasLook : MonoBehaviour
{
    [SerializeField] Canvas thiscanvas;
    InputsAndButtons FromPreviousScene;

    GameObject WindSpeedInputFromCanvas;
    [SerializeField]
    Text WindSpeedOutputText;
    [SerializeField]
    Text PowerGeneratedText;
    [SerializeField]
    Text XPosition;
    [SerializeField]
    Text YPosition;
    [SerializeField]
    Text Height;
    [SerializeField]
    Text WindInput;
    [SerializeField]
    Text ThrustCoefficientText;

    public GameObject[] Turbines;
    GameObject Slider;

    public int TurbineColoumn = 0;
    public int TurbineNo;
    public int TurbineRow;
    float ValueOfK = 2f;
    float[] balance = new float[8];

    public float WindSpeed;
    float WingSize;
    float ThrustCoefficient;
    float WindSpeedInput;
    float WindSpeedOutput;
    float Neww;
    Quaternion newRotation;
    RaycastHit TurbineHit;
    bool firstTurbine;
    PopulateGrid Obj = null;
    public int NoOfTurbines;
    bool isfirst = false; 
    // Use this for initialization
    public void OnDestroy()
    {
        if (Application.isEditor)
        {
           
        }
    }
    void Start()
    {
       
        
       
    }

    public void Update()
    {
        FromPreviousScene = GameObject.Find("ButtonScript").GetComponent<InputsAndButtons>();
        Slider = GameObject.Find("Slider") as GameObject;
        Obj = GameObject.Find("Content").GetComponent<PopulateGrid>();
        WindSpeedInputFromCanvas = GameObject.Find("InputFieldWindSpeed");
        if (FromPreviousScene == null || Slider == null || WindSpeedInputFromCanvas==null || Obj==null)
        {
        }
        else
        {
            if (isfirst==false)
            {
                isfirst = true;
                Slider.GetComponent<Slider>().value = 90;
                Obj.GeneratedPowerSet[TurbineRow, 3]++;
                for (int i = 0; i < NoOfTurbines; i++)
                {
                    Turbines[i] = Obj.Turbines[i];
                }
                WingSize = FromPreviousScene.Radius;
                WindSpeed = FromPreviousScene.WindSpeed;

                int n = TurbineNo;
                while ((n / 10) >= 1)
                {
                    TurbineColoumn++;
                    n = n / 10;
                }




               
                NoOfTurbines = Obj.numberToCreate;
                //Debug.Log(NoOfTurbines);
                Turbines = new GameObject[NoOfTurbines];


                XPosition.text = "XPosition:" + this.transform.position.x;
                YPosition.text = "YPosition:" + this.transform.position.z;
                Height.text = "Height:" +Obj.getTrubineHeight(TurbineRow);
                ValueOfK = FromPreviousScene.ValuefK;
            }



            

            //if (this.gameObject.activeSelf)
            Ray myray = new Ray(this.transform.position, -Vector3.forward);
            // Ray myray  = Physics.Raycast(this.transform.position, -Vector3.forward, 500f);
            Debug.DrawRay(this.transform.position, -this.transform.right, Color.blue);
            //   if (Physics.Raycast(new Vector3(this.transform.position.x,this.transform.position.y+5,this.transform.position.z), this.transform.right, out TurbineHit, 5000f))
            {
                // Debug.Log("reached");
                // Debug.Log(TurbineHit.collider.gameObject.name);
                //    WindSpeedInput = TurbineHit.collider.gameObject.GetComponentInParent<canvasLook>().WindSpeedOutput;
            }
            //else
            {
                WindSpeedInput = WindSpeed;
                //  Debug.Log("not reached");
            }
            if (WindSpeedInputFromCanvas.GetComponent<InputField>().text != null)
            {
                float.TryParse(WindSpeedInputFromCanvas.GetComponent<InputField>().text, out WindSpeed);
            }
            {
                newRotation = Quaternion.Euler(0f, Slider.GetComponent<Slider>().value, 0f);
                this.transform.rotation = newRotation;
                Neww = WindSpeed;
                thiscanvas.transform.LookAt(Camera.main.transform);
                thiscanvas.transform.Rotate(0, 180, 0);
                ThrustCoefficient = PopulateGrid.ThrustCoefficient;
                //  ThrustCoefficient = WindSpeed / (0.5f * 1.23f * (3.14f * (WingSize*this.transform.localScale.x) * (WingSize*this.transform.localScale.x)) * (WindSpeed * WindSpeed));
                /*
                if (TurbineRow == 1)
                {
                    WindSpeedInput = WindSpeed;
                }
                //Debug.Log("running");
                //Debug.Log("Turbine Row No" + TurbineRow);
                //Debug.Log(Turbines.Length);

                for (int i = TurbineRow - 1; i > 0; i--)
                {
                    //Debug.Log("inn tht");
                    //Debug.Log("Turbine no " + (TurbineNo -(i * (FromPreviousScene.Width / FromPreviousScene.TurbineSize))));

                    if (Turbines[TurbineNo - (i * (FromPreviousScene.Width / FromPreviousScene.TurbineSize))].gameObject.activeSelf == true)
                    {
                        //Debug.Log(TurbineNo - (i * (FromPreviousScene.Width / FromPreviousScene.TurbineSize)));

                        Neww = Turbines[TurbineNo - (i * (FromPreviousScene.Width / FromPreviousScene.TurbineSize))].GetComponent<canvasLook>().WindSpeedOutput;
                      //  Debug.Log("Wind speed input" + WindSpeedInput);
                       // firstTurbine =  false;
                    }
                    else 
                    {
                        WindSpeedInput = Neww;
                    }

                    //Debug.Log("Wind speed input" + WindSpeedInput);
                }
                WindSpeedInput = Neww;


                */
                float turbineHeight =Obj.getTrubineHeight(TurbineRow);
                if (FromPreviousScene.IsSameHeight == false)
                {
                    WindSpeedInput = WindSpeedCalculator.CalculateWindSpeed(turbineHeight, WindSpeedInput);
                }
                Obj.GeneratedPowerSet[TurbineRow, 4] = WindSpeedInput;
                float radius = Obj.GetTurbineRadius(TurbineRow);
                float Diameter = 2 * (radius);
                float alpha = 0.5f / (Mathf.Log(turbineHeight / 0.0024f));
                float dx = Diameter + (2 * ValueOfK * Mathf.Sin(alpha));
                //    balance[(int)(this.transform.localScale.x)] = dx; 
                if ((int)(TurbineRow) == 1)
                {
                    // WindSpeedOutput = (1 - Mathf.Sqrt(1 - ThrustCoefficient)) / (1);
                    WindSpeedOutput = balance[0] = 0;
                    Obj.TurbineOutput[1] = WindSpeedInput;
                }
                else
                {

                    // WindSpeedInput = balance[(int)(this.transform.localScale.x)];
                    if (FromPreviousScene.IsGrid)
                    {
                        WindSpeedOutput = balance[(int)(TurbineRow - 1)] = (1 - Mathf.Sqrt(1 - ThrustCoefficient)) / (Mathf.Pow(1 + (ValueOfK * (((Obj.getTrubineHeight((int)(TurbineRow - 1)) / 1.5f) * 2) * PopulateGrid.XDiaValue)) / (GetPreviousTurbineRadius(TurbineRow - 1)), 2f));
                    }
                    else
                    {
                        if (TurbineRow % 2 == 0)
                        {
                            WindSpeedOutput =  (1 - Mathf.Sqrt(1 - ThrustCoefficient)) / (Mathf.Pow(1 + (ValueOfK * (((Obj.getTrubineHeight((int)(TurbineRow - 1)) / 1.5f) * 2) *(PopulateGrid.YDiaValue))) / (GetPreviousTurbineRadius(TurbineRow - 1)), 2f));
                        }
                        else
                        {
                            WindSpeedOutput  = (1 - Mathf.Sqrt(1 - ThrustCoefficient)) / (Mathf.Pow(1 + (ValueOfK * ((Obj.getTrubineHeight((int)(TurbineRow - 1)) / 1.5f) * 2) * (PopulateGrid.YDiaValue)) / (GetPreviousTurbineRadius(TurbineRow - 1)), 2f));
                        }
                    }

                    if (FromPreviousScene.IsSameHeight)
                    {
                        //   if (Obj.TurbineOutput[TurbineRow] == 0.0f)
                        {
                            Obj.TurbineOutput[TurbineRow] = Obj.TurbineOutput[TurbineRow - 1] - WindSpeedOutput;
                        }
                        WindSpeedInput = Obj.TurbineOutput[TurbineRow];
                    }
                    else
                    {
                        WindSpeedInput = WindSpeedInput - WindSpeedOutput;
                    }

                }


                //if (this.transform.localScale.x == 8)
                //{
                //    WindSpeedOutput = WindSpeedInput * ((1 - (1 - Mathf.Sqrt(1 - ThrustCoefficient))) * (((WingSize * this.transform.localScale.x) * (WingSize * this.transform.localScale.x)) / ( ( ( (WingSize * this.transform.localScale.x) * (WingSize * this.transform.localScale.x)) + 2f * 0.05f * TurbineRow))) );
                //}
                //else
                //{e
                //    WindSpeedOutput = WindSpeed;
                //}

                ThrustCoefficientText.text = ("ThrustCoefficient " + ThrustCoefficient);
                //  WindSpeedOutputText.text = ( "Wind Speed Output "+ (WindSpeedInput * ((1 - (1 - Mathf.Sqrt(1 - ThrustCoefficient))) * ((WingSize * WingSize) / ((WingSize * WingSize) + 2f * 0.05f * TurbineRow)))).ToString());
                WindSpeedOutputText.text = ("velocity Deficit " + WindSpeedOutput);
                float GeneratedPower = (0.5f * 1.23f * (3.14f * (radius) * (radius)) * (WindSpeedInput * WindSpeedInput * WindSpeedInput) * PopulateGrid.PowerCoefficient) / 1000000;
                PowerGeneratedText.text = ("Power Generated " + GeneratedPower.ToString());
                WindInput.text = ("WI:" + WindSpeedInput.ToString());

                Obj.GeneratedPower[this.GetComponent<canvasLook>().TurbineNo] = GeneratedPower;
                Obj.GeneratedPowerSet[TurbineRow, 0] = TurbineRow;
                Obj.GeneratedPowerSet[TurbineRow, 1] = GeneratedPower;
                Obj.GeneratedPowerSet[TurbineRow, 2] = WindSpeedInput;

            }
        }

    }
    
    int GetPreviousTurbineRadius(int RowNumber)
    {
        return (int)((Obj.getTrubineHeight(RowNumber) - 10.0f) / 1.5f);
    }
}
