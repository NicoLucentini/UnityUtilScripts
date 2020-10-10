using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper 
{
    public static float Map(float value, float min, float max, float mapMin, float mapMax)
    {
        if (value < min) return mapMin;
        else if (value > max) return mapMax;
        else
        {
            float coef = value / max;
            return mapMin + (mapMax - mapMin) * coef;
        }

    }   
}
