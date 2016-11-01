using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_Tank_Health : MonoBehaviour {

	public int health = 10;
	public Tank_Control tank;	
	public Text text;

	void Start () {
		if (tank == null) {
			tank = gameObject.GetComponentInParent<Tank_Control>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			tank.enabled = false;
			text.text = "You have Failed! restart!";
		} else {
			text.text = "Kill all the enemies, Health: " + health.ToString();
		}

	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "bullet") {
			health -= 1;
			Vector3 posDiff = transform.position - col.GetComponent<bullet_control>().parent.transform.position;
			tank.waitTime = 0.2F;
			FalconUnity.applyForce(tank.playerNum, -posDiff * 10, 0.1F);
			FalconUnity.applyForce(tank.playerNum, posDiff * 10, 0.1F);
			Destroy(col.gameObject);
		}
	}

}
