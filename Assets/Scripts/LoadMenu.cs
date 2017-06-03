using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    public Canvas startmenu;
    public Button startButton;
    public RaycastHit hit;
    public float dist;
    private GvrViewer gvrViewer;
    // VR Head
    private Transform vrHead;
    Vector3 forward;

    // Use this for initialization
    void Start() {
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;


        startButton = startButton.GetComponent<Button>();
        //optionButton = exitButton.GetComponent<Button>();
        //aboutButton = aboutButton.GetComponent<Button>();
        // exitButton = exitButton.GetComponent<Button>();


    }
    void update()
    {
        Vector3 forward = vrHead.TransformDirection(Vector3.forward) * 100;
        if (Physics.Raycast(transform.position, forward, out hit))
            {
            dist = hit.distance;
            if (hit.collider.gameObject.name.Equals("start"))
                StartButtonPress();

        }

    }

    //Start Button
    public void StartButtonPress()
    {

        SceneManager.LoadScene("Hallway_10");

    }
}