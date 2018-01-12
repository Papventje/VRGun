using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSript : MonoBehaviour {
    
    [SerializeField] GameObject[] targets;
    GameObject currentTarget;
    int index;

    bool targetShot = false;
    public static bool ShotOnTarget = false;
    
    [SerializeField] float speed;

    public Transform to;
    public Transform from;

    void Start()
    {
        SelectRandomTarget();
        print(currentTarget.name);
    }
    
    private void FixedUpdate()
    {
        if (targetShot == false && this.gameObject.transform.rotation == to.rotation)
        {
            LerpRotationUp();
        }
        if(targetShot == true)
        {
            LerpRotationDown();
        }
    }

    public void targetIsShot (GameObject shotObject)
    {
        if (shotObject == currentTarget)
        {
            targetShot = true;
            StartCoroutine(TargetShotDown());
        }
    }

    void LerpRotationUp()
    {
        currentTarget.transform.rotation = Quaternion.Lerp(currentTarget.transform.rotation, to.rotation, Time.deltaTime * speed);
    }

    void LerpRotationDown()
    {
        currentTarget.transform.rotation = Quaternion.Lerp(currentTarget.transform.rotation, from.rotation, Time.deltaTime * (speed * 3) );
    }

    void SelectRandomTarget()
    {
        index = Random.Range(0, targets.Length -1);
        currentTarget = targets[index];
        print(currentTarget.name);
    }

    IEnumerator TargetShotDown()
    {
        yield return new WaitForSeconds(2f);
        SelectRandomTarget();
        targetShot = false;
        ShotOnTarget = false;
        StopCoroutine(TargetShotDown());
    }

    // Zorgen dat het met raycast geactiveerd kan worden
    // Omzetten naar VR
    // FixedUpdate()
}
