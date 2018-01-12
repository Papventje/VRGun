using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDispenser : MonoBehaviour {

    [SerializeField] Transform dispensePoint;
    [SerializeField] GameObject magazine;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Beer")
        {
            Instantiate(magazine, dispensePoint.transform.position, dispensePoint.transform.rotation);
        }
    }
}
