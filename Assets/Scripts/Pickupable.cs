﻿using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {

    bool holding;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(GvrController.AppButtonUp)
        {
            if(holding)
            {
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
	}

    void OnTriggerStay(Collider c)
    {
        if (c.CompareTag("Hand"))
        {
            if(GvrController.AppButton)
            {
                transform.SetParent(c.gameObject.transform);
                GetComponent<Rigidbody>().useGravity = false;
                holding = true;
            }
        }
    }
}
