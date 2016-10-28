using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_Survival_Health : MonoBehaviour {

	public int health = 10;
	public turret_Controls turret;	
	public Text text;
	public float timeSurvived = 0;
	
	void Start () {
		if (turret == null) {
			turret = gameObject.GetComponentInParent<turret_Controls>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			turret.enabled = false;
			text.text = "You have Failed! restart!, you survived for: " + timeSurvived.ToString();
		} else {
			timeSurvived += Time.deltaTime;
			text.text = "Survive as long as you can, Health: " + health.ToString();
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "enemy") {
			health -= 1;
			Destroy(col.gameObject);
		}
	}
}
