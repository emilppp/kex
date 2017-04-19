using UnityEngine;
using UnityEngine.UI;
using Tobii.EyeTracking;

/// <summary>
/// Writes the position of the eye gaze point into a UI Text view
/// </summary>
/// <remarks>
/// Referenced by the Data View in the Eye Tracking Data example scene.
/// </remarks>
public class MoveWithGaze : MonoBehaviour
{

	void Update()
	{
		Vector2 gazePosition = EyeTracking.GetGazePoint ().Screen;

		if (EyeTracking.GetGazePoint().IsValid)
		{
			Vector2 roundedSampleInput = new Vector2(Mathf.RoundToInt(gazePosition.x), Mathf.RoundToInt(gazePosition.y));

			Vector3 newPos = Camera.main.WorldToViewportPoint(new Vector3 (roundedSampleInput.x, roundedSampleInput.y, 0f) - new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2, 0f));

			transform.position = newPos;
		}
	}
}
