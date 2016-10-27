using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]

public class meshModifier : MonoBehaviour
{
    public GameObject handleBase;
    Mesh mesh;
    Vector3[] verts;
    Vector3 vertPos;
    GameObject[] handles;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh;
        verts = mesh.vertices;
        foreach (Vector3 vert in verts)
        {
            vertPos = transform.TransformPoint(vert);
            GameObject handle = Instantiate(handleBase);
            handle.transform.position = vertPos;
            handle.transform.parent = transform;
            handle.tag = "handle";
            //handle.AddComponent<Gizmo_Sphere>();
            print(vertPos);
        }
    }

	void OnApplicationQuit()
    {
		Debug.Log("deleting everything");
        GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");
		Debug.Log(handles.Length);
		for (int i = 0; i < handles.Length; i++)
		{
			Debug.Log("destroyed object" + i);
			Destroy(handles[i]);
		}
    }

    void Update()
    {
        handles = GameObject.FindGameObjectsWithTag("handle");
        for (int i = 0; i < verts.Length; i++)
        {
            verts[i] = handles[i].transform.localPosition;
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
