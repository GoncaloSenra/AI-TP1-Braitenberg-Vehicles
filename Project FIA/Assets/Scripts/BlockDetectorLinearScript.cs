using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetectorLinearScript : BlockDetectorScript
{

    public override float GetOutput()
    {

        //YOUR CODE HERE

        if (ApplyThresholds)
        {
            if (output > MaxX)
                return MinY;
            else if (output < MinX)
                return MinY;
        }

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
