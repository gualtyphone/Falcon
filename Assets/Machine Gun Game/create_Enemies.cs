using UnityEngine;
using System.Collections;

public class create_Enemies : MonoBehaviour {

	public Vector3 startPos;
	public Vector3 endPos;
	public GameObject enemy;
	public float respawnTime = 5;
	public float timeDecrease = 0.01F;
	float respawnTimeCurrent = 0;
	float waitTime = 2;
	
	// Update is called once per frame
	void Update () {
		if (waitTime <= 0) {
			if (respawnTimeCurrent <= 0) {
				Vector3 tempPos;
				tempPos.x = Random.Range(startPos.x,endPos.x);
				tempPos.y = Random.Range(startPos.y,endPos.y);
				tempPos.z = Random.Range(startPos.z,endPos.z);
				GameObject tempObj = (GameObject)Instantiate(enemy,tempPos,transform.rotation);
				respawnTimeCurrent = respawnTime;
				respawnTime -= timeDecrease;
			} else {
				respawnTimeCurrent -= Time.deltaTime;
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
