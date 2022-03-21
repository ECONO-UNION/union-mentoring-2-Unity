using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput
{
    private Vector3 mousePosition;

    private float axisX;

    private float axisY;
    public Vector3 MousePosition => mousePosition;
    public float AxisX => axisX;
    public float AxisY => axisY;
    public void Update()
    {
        mousePosition = Input.mousePosition;

        axisX = Input.GetAxis("Mouse X");
        axisY = Input.GetAxis("Mouse Y");
    }

}
