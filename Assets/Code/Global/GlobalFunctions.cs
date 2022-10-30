using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFunctions : MonoBehaviour
{
    public static float Sigmoid(float x, float numerator,
		float xMultiplier, float xShift, float yShift) {
		float ePower = xMultiplier * (x - xShift);
		float denominator = 1f + Mathf.Exp(ePower);
		float y = (numerator / denominator) + yShift;
		return y;
	}
}