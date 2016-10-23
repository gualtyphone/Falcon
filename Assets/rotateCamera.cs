using UnityEngine;
using System.Collections;

public class rotateCamera : MonoBehaviour {
    public int falcon_num;
    public GameObject FalconOrigin;
    public bool pressed = false;
    public bool cameraMode = false;
    Vector3 rot;
    int turnSpeed = 100;
    // Use this for initialization
    void Start () {
        falcon_num = GetComponentInParent<GameObject>().GetComponentInParent<SphereManipulator>().falcon_num;
        
    }

    // Update is called once per frame
    void Update()
    {

       /* bool[] buttons;
        FalconUnity.getFalconButtonStates(falcon_num, out buttons);

        if (buttons[0] && !pressed)
        {
            cameraMode = !cameraMode;
            pressed = true;
            Vector3 godPos;
            FalconUnity.getGodPosition(falcon_num, out godPos);
            FalconUnity.applyForce(falcon_num, (-godPos + FalconOrigin.transform.position) * 25, Time.deltaTime);
        }
        if (!buttons[0] && pressed)
        {
            pressed = false;
        }
        if (buttons[0])
        {
            Vector3 godPos;
            FalconUnity.getGodPosition(falcon_num, out godPos);
            //FalconUnity.applyForce(falcon_num, (-godPos + FalconOrigin.transform.position) * 25, Time.deltaTime);
            if ((-godPos + FalconOrigin.transform.position).x > 0.3F)
            {
                rot = transform.rotation.eulerAngles;
                rot.y += turnSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(rot);
            }
            if ((-godPos + FalconOrigin.transform.position).x < -0.3F)
            {
                rot = transform.rotation.eulerAngles;
                rot.y -= turnSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(rot);
            }
            if ((-godPos + FalconOrigin.transform.position).y > 0.3F)
            {
                rot = transform.rotation.eulerAngles;
                rot.x += turnSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(rot);
            }
            if ((-godPos + FalconOrigin.transform.position).y < -0.3F)
            {
                rot = transform.rotation.eulerAngles;
                rot.x -= turnSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(rot);
            }

        }*/
    }
}
