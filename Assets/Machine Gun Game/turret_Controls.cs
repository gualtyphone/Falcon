using UnityEngine;
using System.Collections;

public class turret_Controls : MonoBehaviour {

	public bool[] falcManipButtons;
    public int playerNum;
	FalconDistance falc;
	public float forceMult = 1;
	public GameObject bullet;
	public GameObject turretStart;
	public GameObject turretEnd;
	public float turnSpeed = 1;
	public float shotLife = 1;
	public float shotSpeed = 1;
	public float reloadTime = 1;
	public float RPS = 10;
	float shotTime = 0;
	public Vector2 rotHorizontalMinMax;
	float distRotated = 0;
	Vector3 rot;
	float rotAdj;
	float waitTime = 2;

	// Use this for initialization
	void Start () {
		if (falc == null) {
			falc = gameObject.GetComponent<FalconDistance>();
		}
	}
	
	// Update is called once per frame
	void Update () {
        FalconUnity.getFalconButtonStates(playerNum, out falcManipButtons);
		if (waitTime <= 0) {
			rotAdj = 0;
			if ((falc.Left && distRotated > rotHorizontalMinMax.x) || (falc.Right && distRotated < rotHorizontalMinMax.y)) {
				if (falcManipButtons[1] == true) {
					rotAdj = turnSpeed * falc.posDis.x * 2;
				} else {
					rotAdj = turnSpeed * falc.posDis.x;
				}
				distRotated += rotAdj;
			}
			transform.RotateAround(transform.position,Vector3.up,rotAdj);

			if (falcManipButtons[2]) {
				if (shotTime > 0) {
					shotTime -= Time.deltaTime;
				} else {
					GameObject tempObject = (GameObject)Instantiate(bullet,turretStart.transform.position,transform.rotation);
					bullet_control tempScript = tempObject.GetComponent<bullet_control>();
					tempScript.time = shotLife;
					tempScript.speed = shotSpeed;
					tempScript.parent = gameObject;
					tempScript.transform.LookAt(turretEnd.transform.position);
					shotTime = 1 / RPS;
					FalconUnity.applyForce(0,new Vector3(1,1,1 * forceMult),Time.deltaTime);
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
