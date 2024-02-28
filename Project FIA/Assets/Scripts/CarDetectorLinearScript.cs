using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorLinearScript : CarDetectorScript {

	public bool inverse = false;
	// Get gaussian output value

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
