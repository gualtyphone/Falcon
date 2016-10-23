using UnityEngine;
using System.Collections;

public class scoreControl : MonoBehaviour {
	
	public BallControl ball;

	void OnTriggerEnter (Collider col) {
		if (col.transform.tag == "WallBoxes") {
			ball.score += 100;
			Destroy(col.transform.gameObject);
		}
	}
	
}
