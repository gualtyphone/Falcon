using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {

	public GameObject parent;
	public Vector3 ballOriginOffset;
	public Vector3 originPos;
	public Vector3 originOffset;
	public float force;
	public float forceMultFar;
	public float forceMultClose;
	public Vector3 closeMidFar;
	public bool fire = true;
	bool snapped = false;
	public Vector3 currPos;
	LineRenderer[] elastic;
	public SphereManipulator falconManip;
	public Text textSpace;
    public Slider slide;
	public int score;
	public GameObject camera;
	public bool[] relativeCamera = new bool[2];
	public Vector3[] startCamera = new Vector3[2];
	public Vector3[] flightCamera = new Vector3[2];
	public Vector3 falPos;
	public Vector3 posDis;
	public Vector3 closestPoint;
	public float margin;
	public float distance;
    public float prevDistance;
    public float slideValue;
    public float shotMargin;
    public float testValue;
    public float shotWait;
    public float shotWaitTime;
    public float resetTime;
    public float reset;

	// Use this for initialization
	void Start () {
		parent = gameObject.transform.parent.gameObject;
		originPos = transform.position;
		originPos += originOffset;
		elastic = GameObject.FindObjectsOfType<LineRenderer> ();
		FalconUnity.getTipPosition (0, out falPos);
		score = 0;
        distance = Vector3.Distance(transform.position, originPos);
        prevDistance = distance;
    }
	
	// Update is called once per frame
	void Update () {
		FalconUnity.getTipPosition (0, out falPos);
		distance = Vector3.Distance(transform.position,originPos);
        if (reset > 0)
        {
            reset = resetTime;
        }
        if (shotWait > 0)
        {
            shotWait -= Time.deltaTime;
        } else
        {
            if (prevDistance - distance >= shotMargin && !falconManip.button_states[3] && fire == true && distance < closeMidFar.z)
            {
                fire = false;
                if (distance < closeMidFar.x)
                {
                    force = distance * forceMultClose;
                }
                else if (distance >= closeMidFar.x && distance < closeMidFar.y)
                {
                    force = distance * (((forceMultFar - forceMultClose) / 2) + forceMultFar);
                }
                else
                {
                    force = distance * forceMultFar;
                }
                Rigidbody rigid = gameObject.AddComponent<Rigidbody>();
                rigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rigid.AddForce(transform.forward * force);
            }
            prevDistance = distance;
            shotWait = shotWaitTime;
        }
      

        slideValue = distance / closeMidFar.z;
        slide.value = slideValue;
        if (distance > margin && fire == true) {
			posDis = closestPoint - falPos;
			FalconUnity.applyForce (0, (posDis) * distance * 90, 0.1F);
		}
		if (distance > closeMidFar.z && fire == true) {
			foreach (LineRenderer i in elastic) {
				i.enabled = false;
			}
			fire = false;
			snapped = true;
		}
		if (snapped == true) {
			textSpace.text = "Oh no! you snapped the band, click '+' to restring.";
		} else if (distance < closeMidFar.z && fire == true) {
			textSpace.text = "Score: " + score.ToString ();
		} else if (distance < closeMidFar.z && fire == false) {
			textSpace.text = "click '+' to reload";
		}

		if (falconManip.button_states[3] == true && reset <= 0) {
			parent.transform.position = originPos;
			transform.position = parent.transform.position + ballOriginOffset;
			foreach (LineRenderer i in elastic) {
				i.enabled = true;
			}
			fire = true;
			snapped = false;
			Destroy(gameObject.GetComponent<Rigidbody>());
		}
  
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (fire == true) {
			if (relativeCamera[0] == false) {
				camera.transform.position = startCamera[0];
				camera.transform.rotation = Quaternion.Euler(startCamera[1].x,startCamera[1].y,startCamera[1].z);
			} else {
				transform.LookAt(originPos);
				camera.transform.LookAt(originPos);
				camera.transform.position = transform.position - transform.forward;
			}
		} else {
			if (relativeCamera[1] == false) {
				camera.transform.position = flightCamera[0];
				camera.transform.rotation = Quaternion.Euler(flightCamera[1].x,flightCamera[1].y,flightCamera[1].z);
			} else {
				camera.transform.position = transform.position + flightCamera[0];
				camera.transform.rotation = Quaternion.Euler(transform.rotation.x + flightCamera[1].x,transform.rotation.y + flightCamera[1].y,transform.rotation.z + flightCamera[1].z);
			}
		}
	}
}