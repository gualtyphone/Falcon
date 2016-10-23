using UnityEngine;
using System.Collections;

public class bullet_control : MonoBehaviour {

	public float speed;
	public float time;
	public GameObject parent;

	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;
		if (time <= 0) {
			Destroy (gameObject);
		} else {
			time -= Time.deltaTime;
		}
	}
}
