﻿using UnityEngine;
using System.Collections;

public class FalconDistanceMainMenu : MonoBehaviour {

	public Vector3 posDis;
	public Vector3 posDisOffset;
	public int forceMult = 1;
	//x,y,z
	//.x = min, .y = max
	public Vector2[] distanceMaxMins = new Vector2[3];
	public bool enableReposition = true;
    public bool enableRepoTime = true;
    public float maxRepoTime = 1;
	public float falconForceTime;
	public bool enableMaxMin = true;
	public bool Left = false;
	public bool Right = false;
	public bool Up = false;
	public bool Down = false;
	public bool In = false;
	public bool Out = false;

	// Update is called once per frame
	void Update () {
		FalconUnity.getGodPosition(0,out posDis);
		if (enableReposition == true) {
			if (falconForceTime == 0) {
				FalconUnity.applyForce (0, (-posDis + posDisOffset) * forceMult, Time.deltaTime);
			} else {
				FalconUnity.applyForce (0, (-posDis + posDisOffset) * forceMult, falconForceTime);
			}
		}

        if (enableRepoTime)
        {

            if (maxRepoTime > 0)
            {

                maxRepoTime -= Time.deltaTime;

            }
            else
            {

                enableReposition = false;

            }

        }

		if (enableMaxMin == true) {
			if (posDis.x < distanceMaxMins[0].x) {
				 Left = true;
			} else {
				 Left = false;
			}
			if (posDis.x > distanceMaxMins[0].y) {
				Right = true;
			} else {
				Right = false;
			}
			if (posDis.y < distanceMaxMins[1].x) {
				Down = true;
			} else {
				Down = false;
			}
			if (posDis.y > distanceMaxMins[1].y) {
				Up = true;
			} else {
				Up = false;
			}
			if (posDis.z < distanceMaxMins[2].x) {
				Out = true;
			} else {
				Out = false;
			}
			if (posDis.z > distanceMaxMins[2].y) {
				In = true;
			} else {
				In = false;
			}
		}
	}
}
