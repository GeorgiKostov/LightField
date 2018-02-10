using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class Utilities
{
	#region Math helper
	public static Vector3 RandomCircle(Vector3 theCenter, float theRadius)
	{ 
		float anAngle = Random.value * 360; 
		Vector3 aPosOnCircle = new Vector3(
			theCenter.x + theRadius * Mathf.Sin(anAngle * Mathf.Deg2Rad),
			theCenter.y + theRadius * Mathf.Cos(anAngle * Mathf.Deg2Rad),
			theCenter.z
			);
		return aPosOnCircle; 
	}

	public static float GetLowerVal(float value1, float value2)
	{
		return Mathf.Min(value1, value2);
	}
	public static float GetHigherVal(float value1, float value2)
	{
		return Mathf.Max(value1, value2);
	}
	public static int GetHighestVal(int value1, int value2, int value3)
	{
		return Math.Max(value1, Math.Max(value2, value3));
	}
	public static int GetLowestVal(int value1, int value2, int value3)
	{
		return Math.Min(value1, Math.Min(value2, value3));
	}
	public static void RotateX(this Vector3 v, float angle)
	{
		float sin = Mathf.Sin(angle);
		float cos = Mathf.Cos(angle);

		float ty = v.y;
		float tz = v.z;
		v.y = (cos * ty) - (sin * tz);
		v.z = (cos * tz) + (sin * ty);
	}

	public static void RotateY(this Vector3 v, float angle)
	{
		float sin = Mathf.Sin(angle);
		float cos = Mathf.Cos(angle);

		float tx = v.x;
		float tz = v.z;
		v.x = (cos * tx) + (sin * tz);
		v.z = (cos * tz) - (sin * tx);
	}

	public static void RotateZ(this Vector3 v, float angle)
	{
		float sin = Mathf.Sin(angle);
		float cos = Mathf.Cos(angle);

		float tx = v.x;
		float ty = v.y;
		v.x = (cos * tx) - (sin * ty);
		v.y = (cos * ty) + (sin * tx);
	}
	public static float GetPitch(this Vector3 v)
	{
		float len = Mathf.Sqrt((v.x * v.x) + (v.z * v.z));    // Length on xz plane.
		return (-Mathf.Atan2(v.y, len));
	}

	public static float GetYaw(this Vector3 v)
	{
		return (Mathf.Atan2(v.x, v.z));
	}
	#endregion

	#region extension methods for: Color
	public static Color SetAlpha(this Color theColor, float theAlpha)
	{
		theColor.a = theAlpha;
		return theColor;
	}
	#endregion

	#region extension methods for: IList
	public static void RemoveNulls<T>(this IList<T> collection) where T : class
	{
		for (var i = collection.Count-1; i >= 0 ; i--)
		{
			if (collection[i] == null)
				collection.RemoveAt(i);
		}
	}
	#endregion

	#region calculate time
	public static string DisplayTime(float theTime)
	{
		int minutes = (int)Mathf.Floor(theTime / 60f);
		int seconds = (int)theTime - (minutes * 60);
		string minutesString = (minutes < 10) ? string.Format("0{0}", minutes) : minutes.ToString();
		string secondsString = (seconds < 10) ? string.Format("0{0}", seconds) : seconds.ToString();

		return string.Format("{0}:{1}", minutesString, secondsString);
	}
	#endregion

	#region RandomNumbers
	public static int RandomInt(int a, int b)
	{
		int i = Random.Range(a, b);
		return i;
	}

	public static float RandomFloat(float a, float b)
	{
		float i = Random.Range(a, b);
		return i;
	}
	#endregion

	#region RemapValue
	public static float Remap(this float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
	#endregion

    public static Color GetRandomColor()
    {
        int randomColor =  RandomInt(0, 7);
        Color newColor = new Color();
        switch (randomColor)
        {
            case 0:
                newColor= Color.red;
                break;
            case 1:
                newColor = Color.blue;
                break;
            case 2:
                newColor = Color.cyan;
                break;
            case 3:
                newColor = Color.magenta;
                break;
            case 4:
                newColor = Color.green;
                break;
            case 5:
                newColor = Color.yellow;
                break;
            case 6:
                newColor = Color.white;
                break;
        }
        return newColor;
    }
}