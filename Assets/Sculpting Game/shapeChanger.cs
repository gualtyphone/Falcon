using UnityEngine;
using System.Collections;

public class shapeChanger : MonoBehaviour
{

    public GameObject[] Shapes;
    GameObject falcon;
    int currentShape;

    // Use this for initialization
    void Start()
    {
        Shapes = GameObject.FindGameObjectsWithTag("Shape");
        falcon = GameObject.Find("GodObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentShape++;
            if (currentShape > Shapes.Length - 1)
            {
                currentShape = 0;
            }
        }
        foreach (GameObject obj in Shapes)
        {
            obj.GetComponent<FalconRigidBody>().disableShape();
            obj.GetComponent<FalconRigidBody>().enabled = false;
            obj.SetActive(false);
        }
        Shapes[currentShape].SetActive(true);
        Shapes[currentShape].GetComponent<FalconRigidBody>().enabled = true;
        falcon.GetComponent<moevMeshHandle>().canvas = Shapes[currentShape];
    }
}