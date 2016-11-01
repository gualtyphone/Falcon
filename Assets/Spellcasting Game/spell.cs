using UnityEngine;
using System.Collections;

public class spell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

    }

    public bool checkSpell(GameObject[] falconPreviousPos, int count)
    {
        int objectsInside = 0, totObjects = 0;
        for (int i = 0; i < count; i++)
        {
            if (GetComponent<Collider>().bounds.Contains(falconPreviousPos[i].transform.position))
            {
                objectsInside++;
                //Debug.Log("ins" + objectsInside);
            }
            totObjects++;
            //Debug.Log("tot" + totObjects);
            
        }
        if (objectsInside == totObjects)
        {
            Debug.Log(objectsInside + " " + count);
            return true;
        }
        return false;
    }
}
