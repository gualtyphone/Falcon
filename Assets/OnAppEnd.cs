using UnityEngine;
using System.Collections;

public class OnAppEnd : MonoBehaviour {

	void OnApplicationQuit()
	{
		Destroy(gameObject);
	}
}
