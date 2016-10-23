using UnityEngine;
using System.Collections;

public class Tank_Control : MonoBehaviour {

	public GameObject falcon;
	public GameObject turret;
	public GameObject turretAim;
	public GameObject bullet;
	public Rigidbody rigid;
	public float speed = 10;
	public float turnSpeed = 10;
	public float reloadTime = 1;
	public int ammo = 5;
	public bool ammoLoaded = true;
	public int health = 20;
	public float distance;
	public Vector3 centerPos;
	public float fireDelay = 0;
	public float reloadTimeDone = 0;
	public bool canFire = true;
	public bool canReload = true;
	public float shotSpeed = 1;
	public float shotLife = 1;
	public Vector3 posDis;
	public Vector3 posDisOffset;
	public SphereManipulator falconManip;
	public bool work = false;
	public Vector3 rot;
	public float waitTime = 0;
	public Vector2 aimMaxMin;

	// Use this for initialization
	void Start () {
		FalconUnity.getGodPosition(0,out posDis);
		FalconUnity.applyForce (0, -posDis * 30, Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {

		if (waitTime <= 0) {
			FalconUnity.getGodPosition(0,out posDis);
			FalconUnity.applyForce (0, (-posDis + posDisOffset) * 25, Time.deltaTime);
		} else if (waitTime > 0){
			waitTime -= Time.deltaTime;
		}

		if (reloadTimeDone > 0) {
			reloadTimeDone -= Time.deltaTime;
			if (posDis.z < -0.2F) {
			}
			canFire = false;
		} else if (canReload == true && ammoLoaded == false) {
			canFire = true;
			ammoLoaded = true;
		}

		if (fireDelay <= 0) {
			if (posDis.x > 0.3F) {
				rot = transform.rotation.eulerAngles;
				rot.y += turnSpeed * Time.deltaTime;
				transform.rotation = Quaternion.Euler(rot);
			} else if (posDis.x < -0.3F) {
				rot = transform.rotation.eulerAngles;
				rot.y -= turnSpeed * Time.deltaTime;
				transform.rotation = Quaternion.Euler(rot);
			}

			if (posDis.z > 0.3F) {
				transform.position -= transform.forward * Time.deltaTime * speed;
			} else if (posDis.z < -0.1F) {
				transform.position += transform.forward * Time.deltaTime * speed;
			}

			if (falconManip.button_states[2] == true && canFire == true) {
				FalconUnity.applyForce (0, new Vector3 (0,0,-2000), Time.deltaTime);
				canFire = false;
				ammoLoaded = false;
				reloadTimeDone = reloadTime;
				GameObject tempBullet = (GameObject)Instantiate(bullet,turret.transform.position,transform.rotation);
				tempBullet.transform.LookAt(turretAim.transform.position);
				tempBullet.GetComponent<bullet_control>().speed = shotSpeed;
				tempBullet.GetComponent<bullet_control>().time = shotLife;
				tempBullet.GetComponent<bullet_control>().parent = gameObject;
				waitTime = 0.2F;
				transform.position += transform.forward * speed/10;
			}
		
		} else {
			FalconUnity.applyForce (0, new Vector3(0,0,-20), Time.deltaTime);
			fireDelay -= Time.deltaTime;
		}



	}
}
