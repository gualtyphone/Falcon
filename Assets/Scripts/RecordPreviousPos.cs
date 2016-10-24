using UnityEngine;
using System.Collections;

public class RecordPreviousPos : MonoBehaviour {

    public GameObject[] positions;
    public int count = 0;
    public GameObject RefObj;
	// Use this for initialization
	void Start () {
        positions = new GameObject[1024];
        
    }
	
	// Update is called once per frame
	void Update () {
        bool[] buttons;
        FalconUnity.getFalconButtonStates(0, out buttons);
        if (buttons[0])
        {
            if (count == 0)
            {
                positions[count] = Instantiate(RefObj);
                Vector3 pos;
                FalconUnity.getGodPosition(0, out pos);
                positions[count].transform.position = pos;
                positions[count].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                count++;
            }
            else if (positions[count-1].transform.position != transform.position && count < 1024)
            {
                positions[count] = Instantiate(RefObj);
                Vector3 pos;
                FalconUnity.getGodPosition(0, out pos);
                positions[count].transform.position = pos;
                positions[count].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                
                count++;
            }
            
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
               // Destroy(positions[i]);
                //positions[i].GetComponent<FalconRigidBody>().enabled = true;
            }
            count = 0;
        }
	}
}
