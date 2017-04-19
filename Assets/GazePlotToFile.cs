using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

using System.IO;

public class GazePlotToFile : MonoBehaviour {

	private GazePoint       _lastGazePoint = GazePoint.Invalid;

	private bool            _useFilter = false;

	public string fileName = "Assets/emil_fgt.txt";
	private StreamWriter sr;

	public bool UseFilter
	{
		get { return _useFilter; }
		set { _useFilter = value; }
	}

	// Use this for initialization
	void Start () {
		sr = File.CreateText (fileName);
	}
	
	// Update is called once per frame
	void Update () {
		GazePoint gazePoint = EyeTracking.GetGazePoint();

		if (gazePoint.SequentialId > _lastGazePoint.SequentialId &&
			gazePoint.IsWithinScreenBounds)
		{

			StoreGazePoint (gazePoint);

			_lastGazePoint = gazePoint;
		}
	}

	void StoreGazePoint(GazePoint gazePoint) {
		string data = gazePoint.Timestamp + "|" + gazePoint.Screen;
		sr.WriteLine (data);
	}

	void OnApplicationQuit() {
		sr.Close ();
	}
}
