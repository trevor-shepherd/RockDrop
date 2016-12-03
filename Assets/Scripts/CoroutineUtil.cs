using UnityEngine;
using System.Collections;

public static class CoroutineUtil {

	// This allows you to create a delay based on the time since the game was started instead of using the current timescale. The main reason for this is for WashAway() in GameManager.
	public static IEnumerator WaitForRealSeconds(float time)
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}
}
