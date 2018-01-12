using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycast : MonoBehaviour {

    [SerializeField] Transform muzzle;

    public static float magazineBulletsLeft = 8f;

    public GameObject controllerRight;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController controller;

    private TargetSript targetScript;

    private void Start()
    {
        targetScript = GameObject.Find("Targets").GetComponent<TargetSript>();
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
    }

    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        if(magazineBulletsLeft > 0)
        {
            ShootWeapon();
        }
    }

    public void ShootWeapon()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);

        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, 100))
        {
            if(hit.transform.tag == "target")
            {
                targetScript.targetIsShot(hit.transform.gameObject);
            }
        }
        magazineBulletsLeft -= 1;
    }
}
