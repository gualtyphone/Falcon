using UnityEngine;
using System.Collections;

public class moevMeshHandle : MonoBehaviour {

    public bool[] buttons;
    public bool objSelected;
    public bool justPressed;
    public GameObject selectedObj;
    public GameObject canvas;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");
        FalconUnity.getFalconButtonStates(0, out buttons);
        if (!objSelected)
        {
            foreach (GameObject handle in handles)
            {
                

                if (GetComponent<Collider>().bounds.Contains(handle.transform.position) && buttons[0] && !objSelected)
                {
                    selectedObj = handle;
                    objSelected = true;
                    justPressed = true;
                }

            }
        }

        if (objSelected)
        {
            selectedObj.transform.position = transform.position;
            //Don't try this because the falcon fucks up tremendously
            //canvas.GetComponent<FalconRigidBody>().refreshShape();
        }
        
        if (objSelected && buttons[1] && !justPressed)
        {
            objSelected = false;
            selectedObj = null;
            //canvas.GetComponent<FalconRigidBody>().refreshShape();
        }

        if (objSelected && !buttons[0]  && justPressed)
        {
            justPressed = false;
        }
        if (buttons[2])
        {
            canvas.GetComponent<FalconRigidBody>().disableShape();
        }
        if (buttons[3])
        {
            canvas.GetComponent<FalconRigidBody>().refreshShape();
        }
    }
}
