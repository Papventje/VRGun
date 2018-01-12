using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour {

    public GameObject laserPrefab;
    public Transform muzzle;

    private float range = 100f;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    private void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, range))
        {
            hitPoint = hit.point;
            ShowLaser(hit);
        }
        else
        {
            laser.SetActive(false);
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(muzzle.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);

        
    }
}
