using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class AxisInput
    {
        private InputInfo _negative;
        private InputInfo _positive;

        public bool IsEmpty => _negative == null || _positive == null; 

        public AxisInput()
        {
  
        }

        public AxisInput(InputInfo negative, InputInfo positive)
        {
            _negative = negative;
            _positive = positive;
        }

        public void SetNegative(InputInfo negative)
        {
            _negative = negative;
        }

        public void SetPositive(InputInfo positive)
        {
            _positive = positive;
        }

        public float GetAxis()
        {
            if (IsEmpty) return 0;

            if (_negative.IsHolding && !_positive.IsHolding)
                return -1;
            else if (!_negative.IsHolding && !_positive.IsHolding)
                return 0;
            else if (_negative.IsHolding && _positive.IsHolding)
                return 0;
            else if (!_negative.IsHolding && _positive.IsHolding)
                return 1;  
            else
                return 0;
        }
    }

}