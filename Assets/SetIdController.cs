using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetIdController : MonoBehaviour {

	public InputField name_field;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetUniqueID() {
		SessionController.id = name_field.text;
	}
}
