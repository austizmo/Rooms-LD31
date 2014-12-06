using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	Text resolutionText;

	// Use this for initialization
	void Start () {
		resolutionText = GameObject.Find ("ResolutionText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		resolutionText.text = Screen.width + " x " + Screen.height;
	}
}
