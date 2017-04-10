using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Char_Movement : MonoBehaviour
{
    // How fast to move
    public float speed = 7.0F;
    // CharacterController script
    private CharacterController controller;
    // GvrViewer Script
    private GvrViewer gvrViewer;
    // VR Head
    private Transform vrHead;

    float firstTime;

    public GameObject hand;


    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;

        firstTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPos;
        float touchX, touchY;

        // In the Google VR button press
        if (GvrController.IsTouching)
        {
            Ray myRay = new Ray(hand.transform.position, hand.transform.forward);
            RaycastHit rayHit;
            if (Physics.Raycast(myRay, out rayHit, Mathf.Infinity))
            {
                if (rayHit.collider.CompareTag("HallwayTileFloorTag") || rayHit.collider.CompareTag("LibraryTag"))
                {
                    Vector3 forward = hand.transform.forward;
                    Vector3 right = hand.transform.right;
                    controller.SimpleMove(forward * speed);
                    controller.SimpleMove(right * speed * 0.5f);
                }
            }

            /* touchPos = GvrController.TouchPos;
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            Vector3 right = vrHead.TransformDirection(Vector3.right);

            touchX = touchPos.x - 0.5F;
            touchY = touchPos.y - 0.5F;

            controller.SimpleMove(forward * speed * touchY * -1);
            controller.SimpleMove(right * speed * touchX * 0.5f);
            */

            if (Time.time >= firstTime + 0.5)
            {
                GetComponent<AudioSource>().Play();
                firstTime = Time.time;
            }
        }
    }
}