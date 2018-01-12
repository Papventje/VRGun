using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReloadPistol : MonoBehaviour
{
    public GameObject controllerRight;
    [SerializeField] GameObject magazineInPistol;


    private SteamVR_TrackedController controller;

    [SerializeField]
    private bool magLoaded = true;


    private void Start()
    {
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.Gripped += releaseTag;
    }

    private void releaseTag(object sender, ClickedEventArgs e)
    {
        if (magLoaded)
        {
            magLoaded = false;
            ShootWithRaycast.magazineBulletsLeft = 0;
            Instantiate(magazineInPistol, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!magLoaded && other.gameObject.tag == "Magazine")
        {
            Destroy(other.gameObject);
            ShootWithRaycast.magazineBulletsLeft = 8;
            magLoaded = true;
        }
    }
}
