using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputsAndButtons : MonoBehaviour {
    [SerializeField] InputField InputFieldWidth;
    [SerializeField]
    InputField InputFieldLength;
    [SerializeField]
    InputField InputFieldTurbineSize;
    [SerializeField]
    InputField InputFieldWingSpan;
    [SerializeField]
    InputField ValueofKText;
    [SerializeField]
    InputField InputFieldWindSpeed;
    [SerializeField]
    InputField MinimumTurbineHeightInput;
    [SerializeField]
    InputField ThrustCoefficient;
    [SerializeField]
    InputField PowerCoefficient;

    [SerializeField]
    InputField InputFieldXDValues;
    [SerializeField]
    InputField InputFieldYDValues;
    [SerializeField]
    Toggle SameHeightToggle;
    [SerializeField]
    Toggle IsGridToggle;
    bool onClickNextButton = false;
    public int Width;
    public int Length;
    public int TurbineSize;
    public int Radius;
    public int WingSpan;
    public int WindSpeed;
    public bool IsSameHeight=false;
    public bool IsGrid = false;
    public float ValuefK = 0.0f; 
    PopulateGrid Obj = null;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        //Obj = GameObject.Find("Content").GetComponent<PopulateGrid>();
        //if (Obj== null)
        //{
        //    Debug.Log(" Content NOt Found");
        //}
    }
	
	// Update is called once per frame
	void Update () {
        if (!onClickNextButton)
        {
            int.TryParse(InputFieldWidth.GetComponent<InputField>().text, out Length);
            int.TryParse(InputFieldWidth.GetComponent<InputField>().text, out Width);
           // int.TryParse(InputFieldTurbineSize.GetComponent<InputField>().text, out TurbineSize);
            float.TryParse(ValueofKText.GetComponent<InputField>().text, out ValuefK);
            
            // int.TryParse(InputFieldWingSpan.GetComponent<InputField>().text, out WingSpan);
            int.TryParse(InputFieldWindSpeed.GetComponent<InputField>().text, out WindSpeed);
            
            // Debug.Log("radius" + Radius);

            if (Radius == 0)
            {
                Radius = 45;               
            }

            if (WingSpan == 0)
            {
                WingSpan = Radius;
            }
            
            if (Width == 0)
            {
                Width = 10000;
                Length = 10000;
            }
            else
            {
               // Debug.Log(Width);
                Length = Width;
            }
            if (TurbineSize==0)
            {
                TurbineSize = (Radius*2)* PopulateGrid.XDiaValue;
            }
            if (WindSpeed == 0)
            {
                WindSpeed = 12;
            }
        }
    }
    
    public void OnClickNextButton()
    {
        int.TryParse(InputFieldXDValues.GetComponent<InputField>().text, out PopulateGrid.XDiaValue);
        int.TryParse(InputFieldYDValues.GetComponent<InputField>().text, out PopulateGrid.YDiaValue);
        int.TryParse(MinimumTurbineHeightInput.GetComponent<InputField>().text, out PopulateGrid.MinimumTurbineHeight);
        float.TryParse(ThrustCoefficient.GetComponent<InputField>().text, out PopulateGrid.ThrustCoefficient);
        float.TryParse(PowerCoefficient.GetComponent<InputField>().text, out PopulateGrid.PowerCoefficient);
        IsSameHeight =  SameHeightToggle.isOn;
        IsGrid = IsGridToggle.isOn;
        if (IsGrid)
        {
            IsSameHeight = true;
            PopulateGrid.YDiaValue = PopulateGrid.XDiaValue;
        }
        SceneManager.LoadScene(1);
        onClickNextButton = true;
    }
}
