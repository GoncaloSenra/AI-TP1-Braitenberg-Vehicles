using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	public override float GetOutput()
	{
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
