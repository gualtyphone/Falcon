using UnityEngine;
using System.Collections;

public class StayOnLoad : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
