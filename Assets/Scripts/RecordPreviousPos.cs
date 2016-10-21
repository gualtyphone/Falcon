using UnityEngine;
using System.Collections;

public class RecordPreviousPos : MonoBehaviour {

    public GameObject[] positions = new GameObject[100];
    public int count = 0;
    public GameObject RefObj;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0))
        {
            if (count == 0)
            {
                positions[count] = Instantiate(RefObj);
                positions[count].transform.position = transform.position;
                count++;
            }
            else if (positions[count-1].transform.position != transform.position && count < 100)
            {
                positions[count] = Instantiate(RefObj);
                positions[count].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                positions[count].transform.position = transform.position;
                count++;
            }
            
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Destroy(positions[i]);
            }
            count = 0;
        }
	}
}
