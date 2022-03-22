using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class MouseInput
    {
        private Vector3 mousePosition;

        private float axisX;

        private float axisY;

        public Vector3 MousePosition => mousePosition;

        public float GetAxisX => axisX;

        public float GetAxisY => axisY;

        public void Update()
        {
            mousePosition = Input.mousePosition;

            axisX = Input.GetAxis("Mouse X");
            axisY = Input.GetAxis("Mouse Y");
        }


    }
}
