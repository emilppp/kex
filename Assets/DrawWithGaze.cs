using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class DrawWithGaze : MonoBehaviour {

	LineRenderer lr;

	Vector3[] positions = new Vector3[500];

	//The current index of the line renderer
	int index = 0;
	int countDown = 0;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
		EyeTracking.Initialize();

		lr.numPositions = 500;
	}
	
	// Update is called once per frame
	void Update () {
		if (countDown > 30) {
			getEyePos ();
		} else {
			countDown++;
		}

	}

	void getEyePos() {
		if (index < lr.numPositions - 1) {

			Vector2 gazePosition = EyeTracking.GetGazePoint ().Screen;

			if (EyeTracking.GetGazePoint().IsValid)
			{
				Vector2 roundedSampleInput = new Vector2(Mathf.RoundToInt(gazePosition.x), Mathf.RoundToInt(gazePosition.y));

				roundedSampleInput.x /= Camera.main.pixelWidth;
				roundedSampleInput.y /= Camera.main.pixelHeight;
				Debug.Log (roundedSampleInput);
				Vector3 newPos = new Vector3 (roundedSampleInput.x, roundedSampleInput.y, 0f);

				positions [index] = newPos;
				index++;
				//Debug.Log (index);
			}

		} else if (index == lr.numPositions - 1) {
			lr.SetPositions (positions);
			index = lr.numPositions;
		}
	
	}

}
