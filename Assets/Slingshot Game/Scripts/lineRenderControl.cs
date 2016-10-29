using UnityEngine;
using System.Collections;

public class lineRenderControl : MonoBehaviour {

	public GameObject other;
	public Vector3 offset;
	public LineRenderer line;
	public Vector3 scale;

	void Start () {
		line = GetComponent<LineRenderer> ();
		line.SetPosition (0, transform.position);
	}

	// Update is called once per frame
	void Update () {
		line.SetPosition (1, other.transform.position - offset);
	}
}
