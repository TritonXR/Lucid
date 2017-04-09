using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    public Canvas startmenu;
    public Button startButton;

	// Use this for initialization
	void Start () {

        startButton = startButton.GetComponent<Button>();
        //optionButton = exitButton.GetComponent<Button>();
        //aboutButton = aboutButton.GetComponent<Button>();
       // exitButton = exitButton.GetComponent<Button>();


	}

    //Start Button
    public void StartButtonPress()
    {

        SceneManager.LoadScene("Hallway_10");
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
