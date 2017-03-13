using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class LucidTeleportation : MonoBehaviour
{
    private CharacterController controller;// CharacterController script
    private GvrViewer gvrViewer;// GvrViewer Script
    private Transform vrHead;// VR Head
    public GameObject hand;

    void Start()
	{
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;
     
    }

    void Update()
    {
        //Create a ray starting at the left hand and going forward
        Ray myRay = new Ray(hand.transform.position, hand.transform.right);
        RaycastHit rayHit;

        //If raycast hits the floor
        if (Physics.Raycast(myRay, out rayHit, Mathf.Infinity))
        {
            Debug.Log("Teleport Hit Something");
            if (rayHit.collider.tag == "HallwayTileFloorTag")
            {
                Debug.Log("Pointing at the floor");
                //Teleports by pointing controller laser at ground and pressing touchpad button 
                if (GvrController.AppButtonUp)
                {
                    //Teleport to the intersection of the raycast and the ground
                    transform.position = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z);
                }
            }
        }
    }
}
