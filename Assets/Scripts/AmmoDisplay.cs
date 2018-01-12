using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {

    [SerializeField] Text ammoText;

    private void Update()
    {
        ammoText.text = ShootWithRaycast.magazineBulletsLeft + " / 8";
    }
}
