using UnityEngine;
using System.Collections;

public class survival_Enemy : MonoBehaviour {

	public int health;
	public float speed;

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "bullet") {
			health -= 1;
			Destroy(col.gameObject);
		}
	}
}
