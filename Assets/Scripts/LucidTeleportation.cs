using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class LucidTeleportation : MonoBehaviour
{
    private CharacterController controller;// CharacterController script
    private GvrViewer gvrViewer;// GvrViewer Script
    public GameObject hand;
    public GameObject teleIndicator;

    void Start()
	{
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
     
    }

    void Update()
    {
        //Create a ray starting at the left hand and going forward
        Ray myRay = new Ray(hand.transform.position, hand.transform.forward);
        RaycastHit rayHit;

        //If raycast hits the floor
        if (Physics.Raycast(myRay, out rayHit, Mathf.Infinity))
        {
            if (rayHit.collider.CompareTag("HallwayTileFloorTag") || rayHit.collider.CompareTag("LibraryTag"))
            {
                teleIndicator.SetActive(true);
                teleIndicator.transform.position = new Vector3(rayHit.point.x, teleIndicator.transform.position.y, rayHit.point.z);
                //Teleports by pointing controller laser at ground and pressing touchpad button 
                if (GvrController.ClickButtonDown)
                {
                    //Teleport to the intersection of the raycast and the ground
                    transform.position = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z);
                }
                
            }
            else teleIndicator.SetActive(false);
        }
    }
}
