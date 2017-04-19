using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

using System.IO;

public class GazePlotToFile : MonoBehaviour {

	private GazePoint       _lastGazePoint = GazePoint.Invalid;

	private bool            _useFilter = false;

	public string uniqueId = "";
	string fileName = "";
	private StreamWriter sr;

	public bool UseFilter
	{
		get { return _useFilter; }
		set { _useFilter = value; }
	}

	// Use this for initialization
	void Start () {
		uniqueId = SessionController.id;
		fileName = "Assets/" + uniqueId + "/" + UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name;
		string filepath = fileName + ".txt";
		try {
			if (!File.Exists (filepath)) {
				sr = File.CreateText (filepath);
			} else {
				GetComponent<FileToGazePlot> ().enabled = true;
				this.enabled = false;
			}
		}
		catch(IOException e) {
			Debug.Log (e.StackTrace);
		}

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

	public void CloseStreamReader() {
		sr.Close ();
	}
}
