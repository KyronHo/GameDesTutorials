using UnityEngine;
using System.Collections;

public class Life1Control : MonoBehaviour {

	private GlobalScript manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript>();
		manager.life1control = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.zombiecontroller.getLives() == 2) 
		{
			DestroyObject (gameObject);
		}
	}
}
