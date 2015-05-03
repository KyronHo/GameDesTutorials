using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

	// Use this for initialization
	private Text score;
	private GlobalScript manager;
	
	void Start () {
		score = GetComponent<Text>();
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript>();
		manager.uiupdater = this;
	}

	// Update is called once per frame
	void Update () {
		score.text = "Score: " + manager.zombiecontroller.getScore();
	}
}
