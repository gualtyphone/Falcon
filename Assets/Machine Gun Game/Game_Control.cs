using UnityEngine;
using System.Collections;

public class Game_Control : MonoBehaviour {

    public player_Survival_Health p1;
    public player_Survival_Health p2;
    public create_Enemies[] enemies;

    // Use this for initialization
    void Start () {
        enemies = FindObjectsOfType<create_Enemies>();
	}
	
	// Update is called once per frame
	void Update () {
        if (p1.health <= 0)
        {
            p1.enabled = false;
            p2.enabled = false;
            p2.text.text = "You have won! you survived for: " + p2.timeSurvived;
            p1.text.text = "You have Lost! you survived for: " + p1.timeSurvived;
            enemies[0].enabled = false;
            enemies[1].enabled = false;
        } else if (p2.health <= 0)
        {
            p2.enabled = false;
            p1.enabled = false;
            p1.text.text = "You have won! you survived for: " + p1.timeSurvived;
            p2.text.text = "You have Lost! you survived for: " + p2.timeSurvived;
            enemies[0].enabled = false;
            enemies[1].enabled = false;
        }
	}
}
