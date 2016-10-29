using UnityEngine;
using System.Collections;

public class moevMeshHandle : MonoBehaviour {

    public bool[] buttons;
    public bool objSelected;
    public bool justPressed;
    public GameObject canvas;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");
		buttons = this.GetComponentInParent<SphereManipulator>().button_states;
        if (!objSelected)
        {
            foreach (GameObject handle in handles)
            {
                if (GetComponent<Collider>().bounds.Contains(handle.transform.position) && buttons[0])
                {
                    handle.GetComponent<selectedHandle>().selected = true ;
                    justPressed = true;
                    objSelected = true;
                }
            }
        }

        if (objSelected)
        {
            foreach (GameObject handle in handles)
            {
                if (handle.GetComponent<selectedHandle>().selected == true)
                {
                    handle.transform.position = transform.position;
                }
            }
            //Don't try this because the falcon fucks up tremendously
            //canvas.GetComponent<FalconRigidBody>().refreshShape();
        }
        
        if (objSelected && buttons[0] && !justPressed)
        {
            objSelected = false;
            foreach (GameObject handle in handles)
            {
                handle.GetComponent<selectedHandle>().selected = false;
            }
            justPressed = true;
            //canvas.GetComponent<FalconRigidBody>().refreshShape();
        }

        if (!buttons[0]  && justPressed)
        {
            justPressed = false;
        }
        if (buttons[1])
        {
            canvas.GetComponent<FalconRigidBody>().disableShape();
        }
        if (buttons[2])
        {
            canvas.GetComponent<FalconRigidBody>().refreshShape();
        }
    }
}
