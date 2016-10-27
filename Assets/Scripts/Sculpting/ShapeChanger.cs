using UnityEngine;
using System.Collections;

public class ShapeChanger : MonoBehaviour {

    public GameObject[] Shapes;
    int currentShape;

	// Use this for initialization
	void Start () {
        Shapes = GameObject.FindGameObjectsWithTag("Shape");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            currentShape++;
            if(currentShape > Shapes.Length-1)
            {
                currentShape = 0;
            }
        }
        foreach (GameObject obj in Shapes)
        {
            obj.SetActive(false);
        }

        Shapes[currentShape].SetActive(true);
	}
}
