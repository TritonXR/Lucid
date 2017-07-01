using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GaiusTutorial : MonoBehaviour {
    public int beckonNumber = 0;
    int isPlaying;
    private float t;
    public AudioSource[] audio;
    public bool library;
    bool tutorial;
    bool tutorial1;
    bool tutorial2;
    public float delay;
    public GameObject text;
    string[] dialog;
    public GameObject canvas;
    public Button button;
    bool continueDialog;

    // Use this for initialization
    void Start () {
        t = Time.time;
        audio = GetComponents<AudioSource>();
        library = false;
        tutorial = false;
        dialog = new string[]{ "In here, young Dreamer.  Come on in here.","Come to the library, the first door on the left.","I have urgent things to tell you!","Over here by the fireplace.","Come on over!  Learn the Art of Dreaming!","Welcome young Dreamer!  Welcome to Dreamland!  Where you’ll learn of controlling one's dreams with a dive deep into that grey matter you call a brain, and pierce the veil into the collective subconsciousness.","You have just broken through the barrier into Dreamland.  I have summoned you here to The School of Dreamancy to make sure you are properly trained before venturing off!"};
        continueDialog = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!tutorial && Time.time > t + 4.5f)
            canvas.SetActive(false);
        if (!library)
        {
            if (Time.time > t + delay)  // beckon every 18 seconds
            {
                audio[beckonNumber].Play();
                canvas.SetActive(true);
                text.GetComponent<Text>().text = dialog[beckonNumber];
                t = Time.time;

                if (beckonNumber < 2)
                    beckonNumber++;
                else beckonNumber = 0;
            }
        } else if(!tutorial)
        {
            if (Time.time > t + delay)  // beckon every 18 seconds
            {
                audio[beckonNumber].Play();
                canvas.SetActive(true);
                text.GetComponent<Text>().text = dialog[beckonNumber];
                isPlaying = beckonNumber;
                t = Time.time;
                if (beckonNumber < 4)
                    beckonNumber++;
                else beckonNumber = 2;
            }
        } else if(tutorial && !audio[isPlaying].isPlaying)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("MainCharacter").transform); // turns Gaius to look at the player
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // prevent Gaius from falling over!
            if (tutorial1)
            {
                audio[5].Play();
                canvas.SetActive(true);
                text.GetComponent<Text>().text = dialog[5];
                tutorial1 = false;
                t = Time.time;

            }
            if (!audio[5].isPlaying)
            {
                button.gameObject.SetActive(true);
                if (continueDialog)
                {
                    tutorial2 = true;
                }
            }
            if(tutorial2)
            {
                audio[6].Play();
                canvas.SetActive(true);
                text.GetComponent<Text>().text = dialog[6];
                if (!audio[6].isPlaying)
                {
                    canvas.SetActive(false);
                    button.gameObject.SetActive(false);
                }
                this.enabled = false;
            }

            
        }

	}

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("MainCharacter"))
        {
            if (!tutorial)
            {
                tutorial = true;
                tutorial1 = true;
            }
        }
    }

    public void contDial()
    {
        continueDialog = true;
    }

}
