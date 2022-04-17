using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class AxisInput
    {
        private KeyState negative;

        private KeyState positive;

        public AxisInput()
        {

        }

        public AxisInput(KeyState negative, KeyState positive)
        {
            this.negative = negative;
            this.positive = positive;
        }

        public void SetNegative(KeyState negative)
        {
            this.negative = negative;
        }

        public void SetPositive(KeyState positive)
        {
            this.positive = positive;
        }

        public int GetAxis()
        {
            if (negative == null || positive == null) return 0;
           
            if (negative.GetKey && !positive.GetKey) return -1;
            if (!negative.GetKey && positive.GetKey) return 1;

            else return 0;
        }

    }
}
