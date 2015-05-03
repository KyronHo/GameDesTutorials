using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = -1;
	public float speed2 = 0;
	private Transform spawnPoint;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed2);
		spawnPoint = GameObject.Find("SpawnPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName != "CongaScene") {
			EnforceBounds();
		}
	}

	void OnBecameInvisible()
	{
		// This line added to remove error displayed by Unity when you stop playing the scene
		if (Camera.main == null)
			return;

		float yMax = Camera.main.orthographicSize - 0.5f;
		transform.position = new Vector3( spawnPoint.position.x, 
		                                 Random.Range(-yMax, yMax), 
		                                 transform.position.z );
	}
	
	private void EnforceBounds()
	{
		// 1
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;

		// 2
		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist;
		float xMin = cameraPosition.x - xDist;
		
		// 3
		float yMax = mainCamera.orthographicSize;
		
		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( newPosition.y, -yMax, yMax );
			speed2 = -speed2;
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed2);
		}

		// 4
		transform.position = newPosition;
	}

}
