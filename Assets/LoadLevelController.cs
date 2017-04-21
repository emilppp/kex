using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel(string level) {
		UnityEngine.SceneManagement.SceneManager.LoadScene (level);
	}

	public void ExitApplication() {
		Debug.Log ("THank you!");
		Application.Quit ();
	}
}
