using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam1;
    public float camSens = 100f;
    float xRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        CameraRotation();   
    }

    void CameraRotation()
    {
        Vector3 axis = new Vector3(0, Input.GetAxis("Mouse X") * camSens * Time.deltaTime, 0);
        transform.Rotate(axis);

        float mouseY = Input.GetAxis("Mouse Y") * camSens *Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        cam1.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
