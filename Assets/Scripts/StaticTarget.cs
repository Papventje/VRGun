using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTarget : MonoBehaviour {

    void Start ()
    {
        Quaternion.Euler(0, 270, 0);
    }

	void Update () {
        Quaternion.Euler(0, 270, 0);
        Destroy(gameObject, 3f);
    }
}
