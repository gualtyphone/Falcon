using UnityEngine;
using System.Collections;

public class BoxCollisionFalcon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec = new Vector3();
        FalconUnity.getGodPosition(0, out vec);
        if (this.GetComponent<Collider>().bounds.Contains(vec))
        {
            Vector3 vec2 = new Vector3();
            vec2 = this.gameObject.transform.position;
            vec2 -= vec;
            FalconUnity.applyForce(0, -vec2*250, 0.001f);
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Collision!");
        Vector3 vec = new Vector3();
        vec = this.gameObject.transform.position;
        vec -= coll.gameObject.transform.position;
        FalconUnity.setForceField(coll.gameObject.GetComponent<FalconMain>().num_falcons, vec);
    }
}
