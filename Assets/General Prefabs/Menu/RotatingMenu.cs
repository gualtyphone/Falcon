using UnityEngine;
using System.Collections;

public class RotatingMenu : MonoBehaviour
{

    public GameObject GodObject;
    public GameObject mainMenuButton;
    public GameObject cancelButton;
    bool MenuIsOpen =false;
    public string LevelToLoadName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MenuIsOpen)
        {
            mainMenuButton.transform.Rotate(new Vector3(0.0f, 0.5f, 0.0f));
            cancelButton.transform.Rotate(new Vector3(0.0f, 0.5f, 0.0f));
        }


        bool[] buttons;
        buttons = new bool[4];
        //FalconUnity.getFalconButtonStates(this.GetComponentInParent<SphereManipulator>().falcon_num, out buttons);
        //Testing purposes only
        buttons[3] = Input.GetKeyDown(KeyCode.Q);
        buttons[0] = Input.GetMouseButtonDown(0);
        //end of testing
        if (buttons[3])
        {
            mainMenuButton.GetComponent<MeshRenderer>().enabled = !mainMenuButton.GetComponent<MeshRenderer>().enabled;
            cancelButton.GetComponent<MeshRenderer>().enabled = !cancelButton.GetComponent<MeshRenderer>().enabled;
            MenuIsOpen = !MenuIsOpen;
        }


        if (MenuIsOpen && buttons[0])
        {
            if (mainMenuButton.GetComponent<Collider>().bounds.Contains(GodObject.transform.position))
            {
                Application.LoadLevel(LevelToLoadName);
            }
            else if (cancelButton.GetComponent<Collider>().bounds.Contains(GodObject.transform.position))
            {
                MenuIsOpen = false;
                mainMenuButton.GetComponent<MeshRenderer>().enabled = false;
                cancelButton.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
