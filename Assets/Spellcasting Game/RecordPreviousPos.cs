using UnityEngine;
using System.Collections;

public class RecordPreviousPos : MonoBehaviour {

    public GameObject[] positions;
    public bool[] buttons;
    public int count = 0;
    public GameObject RefObj;
    public bool spellCast = false;
    public string spellName;
    public Material normalMaterial;
    public Material fireMaterial;
    public Material iceMaterial;
    public GameObject IceCube, FireBall;
    public int iceCubes, fireballs;

    // Use this for initialization
    void Start () {
        positions = new GameObject[1024];
    }
	
	// Update is called once per frame
	void Update () {
       
        if (!spellCast)
        {
            createSpell();
        }
        else
        {
            //Debug.Log("case1");
            castSpell();
        }
        
	}

    void castSpell()
    {
        FalconUnity.getFalconButtonStates(0, out buttons);
        switch (spellName)
        {
            case "Fire":
                GetComponent<Renderer>().material = fireMaterial;
                FireSpell();
                break;
            case "Ice":
                GetComponent<Renderer>().material = iceMaterial;
                IceSpell();
                break;
            default:
                GetComponent<Renderer>().material = normalMaterial;
                spellCast = false;
                spellName = null;
                break;
        }
        for (int i = 0; i < count; i++)
        {
            positions[i].transform.position = Vector3.Lerp(positions[i].transform.position, transform.position, 0.5f*Time.deltaTime);
            if (positions[i].transform.position == transform.position)
            {
                Destroy(positions[i]);
            }
        }
    }

    void IceSpell()
    {
        if (buttons[0])
        {
            Vector3 pos;
            FalconUnity.getGodPosition(0, out pos);
            Instantiate(IceCube, pos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            iceCubes--;
        }
        if(iceCubes <= 0)
        {
            spellName = "Finished";
        }
    }

    void FireSpell()
    {
        //Debug.Log("FIRE");
        if (buttons[0])
        {

            Vector3 pos;
            FalconUnity.getGodPosition(0, out pos);
            Instantiate(FireBall, pos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            fireballs--;
        }
        if (fireballs <= 0)
        {
            spellName = "Finished";
        }
    }

    void createSpell()
    {
        //bool[] buttons;
        //buttons = new bool[3];
        //buttons[0] = Input.GetMouseButton(0);
        FalconUnity.getFalconButtonStates(0, out buttons);
        if (buttons[0])
        {
            if (count == 0)
            {
                positions[count] = Instantiate(RefObj);
                Vector3 pos;
                FalconUnity.getGodPosition(0, out pos);
                //pos = transform.position;
                positions[count].transform.position = pos;
                positions[count].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                count++;
            }
            else if (positions[count - 1].transform.position != transform.position && count < 1024)
            {
                positions[count] = Instantiate(RefObj);
                Vector3 pos;
                //pos = transform.position;
                FalconUnity.getGodPosition(0, out pos);
                positions[count].transform.position = pos;
                positions[count].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                count++;
            }

        }
        else
        {

            GameObject[] spells = GameObject.FindGameObjectsWithTag("Spell");

            if (count > 20)
            {

                foreach (GameObject go in spells)
                {
                    if (!spellCast)
                    {
                        spellCast = go.GetComponent<spell>().checkSpell(positions, count);
                        if (spellCast)
                        {
                            spellName = go.name;
                            fireballs = 20;
                            iceCubes = 20;
                        }
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                Destroy(positions[i]);
                //positions[i].GetComponent<FalconRigidBody>().enabled = true;
            }
            count = 0;
        }
        
    
    }
}
