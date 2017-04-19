using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using Tobii.EyeTracking;
public class FileToGazePlot : MonoBehaviour {

	public Sprite PointSprite;
	StreamReader sr;

	public string path = "";

	// Use this for initialization
	void Start () {

		string uniqueId = SessionController.id;
		string fileName = "Assets/" + uniqueId + "/" + UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name;
		path = fileName + ".txt";
		
		try {
			sr = File.OpenText(path);

			string line = sr.ReadLine();

			int index = 0;

			while(line != null) {
				
				string[] tokens = line.Split("|"[0]);
				string timestamp = tokens[0];

				string vector = tokens[1].Replace("(", "");
				vector = vector.Replace(")", "");
				string[] xAndY = vector.Trim().Split(", "[0]);

				float x = float.Parse(xAndY[0]);
				float y = float.Parse(xAndY[1]);

				Vector2 v2 = new Vector2(x, y);

				PlotVector(timestamp, v2, index);

				line = sr.ReadLine();
				index ++;
			}
			sr.Close();
		}
		catch (IOException e) {
			Debug.Log (e.StackTrace);
		}
	}

	void PlotVector(string timestamp, Vector2 position, int index) {
		Vector3 gazePoint = ProjectToPlaneInWorld (position);

		var pointCloudSprite = new GameObject("PointCloudSprite fuck" + index);
		//pointCloudSprite.transform.localScale *= 0.3f;

		pointCloudSprite.transform.position = gazePoint;

		var spriteRenderer = pointCloudSprite.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = PointSprite;

		//Set the alpha of the sprite
		Color c = pointCloudSprite.GetComponent<SpriteRenderer> ().color;
		c.a = 0.2f;
		pointCloudSprite.GetComponent<SpriteRenderer> ().color = c;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Vector3 ProjectToPlaneInWorld(Vector2 gazePoint)
	{
		Vector3 gazeOnScreen = (transform.forward * 10f) + (Vector3)gazePoint;
		return Camera.main.ScreenToWorldPoint(gazeOnScreen);
	}
}
