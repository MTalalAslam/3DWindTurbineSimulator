using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpeedCalculator : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static float CalculateWindSpeed(float height, float RefSpeed)
    {
        float[] theRLength = { 0.0002f, 0.0024f, 0.03f, 0.055f, 0.1f, 0.4f, 1.6f };
        float[] theHeight = { 100f, 90f, 80f, 70f, 60f, 50f, 40f, 30f, 20f, 10f };
        var theRefSpeed = RefSpeed;
        theRefSpeed = RefSpeed;
        int j = 0; 
        for (;j<theHeight.Length;j++)
        {
            if (Convert.ToInt32( theHeight[j])== PopulateGrid.MinimumTurbineHeight)
            {
                break; 
            }
        }

        for (var i = 0; i < 10; i++)
        {
            var theRes = WSpeed(theHeight[i], theRLength[1], theHeight[j], theRefSpeed, theRLength[1]);
            theRes = 0.01f * Mathf.Round(100 * theRes);
            if (theHeight[i] == height)
            {
                return theRes;
            }
        }
        return 0;
    }
    static float WSpeed(float height, float roughness, float refHeight, float refSpeed, float refRoughness)
    {
        return (refSpeed * Mathf.Log(height / roughness) / Mathf.Log(refHeight / refRoughness));
    }
}
