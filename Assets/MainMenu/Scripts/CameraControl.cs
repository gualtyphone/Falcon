using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float minFov = 25f;
    public float maxFov;
    bool isLocked;
    GameObject character;

	// Use this for initialization
	void Start () {

        character = this.transform.parent.gameObject;
        SetCursorLock(true);
        maxFov = Camera.main.fieldOfView;
	}

    void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Screen.lockCursor = isLocked;
        Cursor.visible = !isLocked;
    }

	// Update is called once per frame
	void Update () {

        //Mouse look
        var mouseDetect = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDetect = Vector2.Scale(mouseDetect, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDetect.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDetect.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        //Zoom in and out
        if(Input.GetMouseButtonDown(0)) {

            Debug.Log("Pressed Left Click");
            if(Camera.main.fieldOfView != minFov) {
                
                Camera.main.fieldOfView--;
            }
        }

        if(Input.GetMouseButtonDown(1)) {

            Debug.Log("Pressed Right Click");
            if (Camera.main.fieldOfView != maxFov) {
                
                Camera.main.fieldOfView++;
            }    
        }
    }
}
