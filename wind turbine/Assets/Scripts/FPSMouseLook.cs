using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class FPSMouseLook : MonoBehaviour {

    public enum RotationAxis { MouseX,MouseY}
    public RotationAxis axes = RotationAxis.MouseY;

    private float SensivityX = 3f;
    private float SensivityY = 1.5f;

    private float RotationX, RotationY;

    private float MinimumX = -360f;
    private float MaximumX = 360f;

    private float MinimumY = -360f;
    private float MaximumY = 360f;

    private Quaternion OriginalRotation;
    private float MosueSensivity = 1.7f;

    bool esc;
    // Use this for initialization
    void Start () {
        OriginalRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (esc)
            {
                esc = false;
            }
            else
            {
                esc = true;
            }
        }
    }
    void LateUpdate()
    {
        
            HandleRotation();
        
    }
    void HandleRotation()
    {
        if (axes==RotationAxis.MouseY && esc)
        {
            RotationY -= Input.GetAxis("Mouse Y") * SensivityY;
            RotationY = ClampAngle(RotationY, MinimumY, MaximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(RotationY, Vector3.right);
            this.transform.localRotation = OriginalRotation * yQuaternion;
        }
        if (axes == RotationAxis.MouseX && esc )
        {
            RotationX += Input.GetAxis("Mouse X") * SensivityX;
            RotationX = ClampAngle(RotationX, MinimumX, MaximumX);
            Quaternion XQuaternion = Quaternion.AngleAxis(RotationX, Vector3.up);
            this.transform.localRotation = OriginalRotation * XQuaternion;

        }
    }



    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360 || angle > 360)
        {
            angle = 0;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
