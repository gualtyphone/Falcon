using UnityEngine;
using System.Collections;

public class falconSetupper : MonoBehaviour {

    GameObject Falcon1Waypoint;
    GameObject Falcon1;
    GameObject Falcon2Waypoint;
    GameObject Falcon2;
    GameObject holder;

    bool holderActive;
    bool moveAroundScriptActive;
    bool falconDistanceMainMenuActive;
    bool RecordPreviousPosActive;
    bool moevMeshHandleActive;
    bool falconShapeActive;

    public bool notSet = true;

    // Use this for initialization
    void Start()
    {
        Falcon1Waypoint = GameObject.Find("Falcon1Waypoint");
        Falcon1 = GameObject.Find("Falcon 1");
        Falcon2Waypoint = GameObject.Find("Falcon2Waypoint");
        Falcon2 = GameObject.Find("Falcon 2");
        holder = GameObject.FindGameObjectWithTag("HOLDER");
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Application.loadedLevel)
        {
            case 0: //firstScene
                holderActive = false;
                moveAroundScriptActive = false;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = false;
                falconShapeActive = false;
                break;
            case 1: //Main menu
                holderActive = false;
                moveAroundScriptActive = false;
                falconDistanceMainMenuActive = true;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = false;
                falconShapeActive = false;
                break;
            case 2: //machineGun
                holderActive = false;
                moveAroundScriptActive = false;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = false;
                falconShapeActive = false;
                break;
            case 3://sculpting
                holderActive = false;
                moveAroundScriptActive = true;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = true;
                falconShapeActive = true;
                break;
            case 4://slingshot
                holderActive = true;
                moveAroundScriptActive = false;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = false;
                falconShapeActive = false;
                break;
            case 5://spellcasting
                holderActive = false;
                moveAroundScriptActive = true;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = true;
                moevMeshHandleActive = false;
                falconShapeActive = true;
                break;
            case 6://tank game
                holderActive = false;
                moveAroundScriptActive = false;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = false;
                falconShapeActive = false;
                break;
            case 7:// blind maze
                holderActive = false;
                moveAroundScriptActive = false;
                falconDistanceMainMenuActive = false;
                RecordPreviousPosActive = false;
                moevMeshHandleActive = false;
                falconShapeActive = false;
                break;
        }
        Falcon1Waypoint = GameObject.Find("Falcon1Waypoint");
        Falcon1 = GameObject.Find("Falcon 1");
        Falcon2Waypoint = GameObject.Find("Falcon2Waypoint");
        Falcon2 = GameObject.Find("Falcon 2");

       
        if (Application.loadedLevel == 7 && notSet)
        {
            Vector3 pos;
            FalconUnity.getGodPosition(0, out pos);
            Vector3 pos2 = GameObject.Find("Falcon1GOWaypoint").transform.position - pos;
            float distanceSqr = (pos - GameObject.Find("Falcon1GOWaypoint").transform.position).sqrMagnitude;
            if (distanceSqr > 0.1)
            {
                GameObject[] walls = GameObject.FindGameObjectsWithTag("MazeWalls");
                foreach (GameObject wall in walls)
                {
                    wall.GetComponent<FalconRigidBody>().disableShape();
                }
                FalconUnity.applyForce(0, pos2 * 10.0f, 1.0f);

            }
            else
            {
                notSet = false;
                GameObject[] walls = GameObject.FindGameObjectsWithTag("MazeWalls");
                foreach (GameObject wall in walls)
                {
                    wall.GetComponent<FalconRigidBody>().refreshShape();
                }
            }
        }

        holder.SetActive(false);
        if (holderActive)
        {
            foreach (Transform child in Falcon1.transform)
            {
                if (child.gameObject.name == "GodObject")
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        else
        {
            foreach (Transform child in Falcon1.transform)
            {
                if (child.gameObject.name == "GodObject")
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        Falcon1.transform.position = Falcon1Waypoint.transform.position;

        Falcon1.GetComponent<moveAround>().enabled = moveAroundScriptActive;
        Falcon1.GetComponent<FalconDistanceMainMenu>().enabled = falconDistanceMainMenuActive;
        Falcon1.GetComponentInChildren<RecordPreviousPos>().enabled = RecordPreviousPosActive;
        Falcon1.GetComponentInChildren<moevMeshHandle>().enabled = moevMeshHandleActive;
        foreach (Transform child in Falcon1.transform)
        {
            if (child.gameObject.name == "FalconShape")
            {
                child.GetComponent<MeshRenderer>().enabled = falconShapeActive;
            }
        }

        Falcon2.transform.position = Falcon2Waypoint.transform.position;

        Falcon2.GetComponent<moveAround>().enabled = false;
        Falcon2.GetComponent<FalconDistanceMainMenu>().enabled = falconDistanceMainMenuActive;
        Falcon2.GetComponentInChildren<RecordPreviousPos>().enabled = RecordPreviousPosActive;
        Falcon2.GetComponentInChildren<moevMeshHandle>().enabled = moevMeshHandleActive;
        foreach (Transform child in Falcon2.transform)
        {
            if (child.gameObject.name == "FalconShape")
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
