using UnityEngine;
using System.Collections;

public class ContainmentSphere : MonoBehaviour {

    public Material SphereMat;
    public GameObject FalconTip;
    public Color Normal;
    public Color Red;
    


    // Use this for initialization
    void Start () {
        SphereMat = GetComponent<MeshRenderer>().material;
        Normal = new Color(0.0f, 1.0f, 0.0f, 0.0f);
        Red = new Color(1.0f, 0.0f, 0.0f, 0.01f);

    }

    // Update is called once per frame
    void Update () {
        float distanceFromCenter = Vector3.Distance(FalconTip.transform.position, transform.position);
        if (distanceFromCenter > 0)
        {
            Red = new Color(1.0f, 0.0f, 0.0f, (distanceFromCenter)/3.0f);
            SphereMat.SetColor("_Color", Red);
        }
        else
        {
            SphereMat.SetColor("_Color", Normal);
        }
        /*if (distanceFromCenter < 3)
        {
            SphereMat.SetColor("_Color", Green);
        }
        if (distanceFromCenter > 3 && distanceFromCenter < 4)
        {
            SphereMat.SetColor("_Color", Yellow);
        }
        if (distanceFromCenter > 4 )
        {
            SphereMat.SetColor("_Color", Red);
        }*/
    }
}
