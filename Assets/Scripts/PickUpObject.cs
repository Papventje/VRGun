using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObj;
    private GameObject ObjInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObj || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObj = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObj)
            return;

        collidingObj = null;
    }

    private void GrabObject()
    {
        ObjInHand = collidingObj;
        collidingObj = null;

        var joint = AddFixedJoint();
        joint.connectedBody = ObjInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            ObjInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            ObjInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        ObjInHand = null;
    }

    private void Update()
    {
        if(Controller.GetHairTriggerDown())
        {
            if (collidingObj)
            {
                GrabObject();
            }
        }
        if (Controller.GetHairTriggerUp())
        {
            if (ObjInHand)
            {
                ReleaseObject();
            }
        }
    }
}

