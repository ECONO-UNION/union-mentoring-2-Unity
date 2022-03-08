using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisInput
{
    private InputInfo _negative;
    private InputInfo _possitive;
    float _axis;

    public AxisInput(InputInfo negative, InputInfo possitive)
    {
        _negative = negative;
        _possitive = possitive;
        _axis = 0;
    }

    public float GetAxis()
    {
        if (_negative.IsHolding && !_possitive.IsHolding)
        {
            _axis -= Time.deltaTime;
            _axis = _axis <= -1 ? -1 : _axis;
        }
        else if (!_negative.IsHolding && !_possitive.IsHolding)
            _axis = 0;
        else if (_negative.IsHolding && _possitive.IsHolding)
            _axis = 0;
        else if (!_negative.IsHolding && _possitive.IsHolding)
        {
            _axis += Time.deltaTime;
            _axis = _axis >= 1 ? 1 : _axis;
        }
        return _axis;
    }
}
