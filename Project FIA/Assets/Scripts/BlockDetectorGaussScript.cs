using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetectorGaussScript : BlockDetectorScript
{
    public float stdDev = 0.4f;
    public float mean = 0.8f;
    public bool inverse = false;

    public override float GetOutput()
    {

        if (ApplyThresholds)
        {
            if (output > MaxX)
                return MinY;
            else if (output < MinX)
                return MinY;
        }

        output = 1.0f / (stdDev * (float)Math.Sqrt(2 * Math.PI)) * (float)Math.Exp(-0.5f * Math.Pow(output - mean, 2) / (float)Math.Pow(stdDev, 2));

        if (inverse)
            output = (stdDev * (1.0f / (float)(Math.Sqrt(2 * Math.PI)))) - output;

        if (ApplyLimits)
        {
            if (output > MaxY)
                output = MaxY;
            else if (output < MinY)
                output = MinY;
        }
        return output;
    }
}
