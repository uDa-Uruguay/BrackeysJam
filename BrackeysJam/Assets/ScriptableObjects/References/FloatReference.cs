using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReference
{
    public bool useConstant = false;
    public float constantValue = 0f;
    public FloatVariable variable;

    public float value
    {
        get { return useConstant ? constantValue : variable.value; }
    }
}
