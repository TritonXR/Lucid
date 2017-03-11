using UnityEngine;
using System.Collections;

public class doorOpenClose : MonoBehaviour {

    public GameObject door;
    int isOpen;
    int afterAnim;

	void Start () {
        isOpen = 0;
        afterAnim = 0;
	}
	
	void Update () {
	    if(door.GetComponent<Animation>().IsPlaying("doorOpen"))
        {
            door.GetComponent<BoxCollider>().enabled = false;
            isOpen = 3;
        } else if(door.GetComponent<Animation>().IsPlaying("doorClose")) {
            door.GetComponent<BoxCollider>().enabled = false;
            isOpen = 3;
        } else
        {
            door.GetComponent<BoxCollider>().enabled = true;
            isOpen = afterAnim;
        }
	}

    void OnTriggerStay()
    {
        Debug.Log("entered trigger");
        if(isOpen == 0)
        {
            if(GvrController.AppButtonDown)
            {
                door.GetComponent<Animation>().Play("doorOpen");
                afterAnim = 1;
            }
        } else if(isOpen == 1)
        {
            if(GvrController.AppButtonDown)
            {
                door.GetComponent<Animation>().Play("doorClose");
                afterAnim = 0;
            }
        }
    }
}
