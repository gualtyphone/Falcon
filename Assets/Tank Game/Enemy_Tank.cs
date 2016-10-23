using UnityEngine;
using System.Collections;

public class Enemy_Tank : MonoBehaviour {

	public GameObject bullet;
	public GameObject turret;
	public GameObject turretAim;
	public float shotSpeed = 1;
	public float shotLife = 5;
	public float reloadTimeDone;
	public float reloadTime;
	public int health = 5;
	public GameObject player;
	public int viewRange = 5;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) < viewRange) {
			transform.parent.transform.LookAt(player.transform.position);

			if (reloadTimeDone <= 0) {
				reloadTimeDone = reloadTime;
				GameObject tempBullet = (GameObject)Instantiate(bullet,turret.transform.position,transform.rotation);
				tempBullet.transform.LookAt(turretAim.transform.position);
				tempBullet.GetComponent<bullet_control>().speed = shotSpeed;
				tempBullet.GetComponent<bullet_control>().time = shotLife;
				tempBullet.GetComponent<bullet_control>().parent = gameObject;
			}

		}
		if (health <= 0) {
			Destroy(this.gameObject);
		}

		if (reloadTimeDone > 0) {
			reloadTimeDone -= Time.deltaTime;
		}

	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "bullet") {
			health -= 1;
			Destroy(col.gameObject);
		}
	}
}
