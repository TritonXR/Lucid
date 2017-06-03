using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

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

    // Use this for initialization
    void Start () {
        t = Time.time;
        audio = GetComponents<AudioSource>();
        library = false;
        tutorial = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!library)
        {
            if (Time.time > t + delay)  // beckon every 18 seconds
            {
                audio[beckonNumber].Play();
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
                isPlaying = beckonNumber;
                t = Time.time;
                if (beckonNumber < 4)
                    beckonNumber++;
                else beckonNumber = 2;
            }
        } else if(tutorial && !audio[isPlaying].isPlaying)
        {
            float time = Time.time;
            if (tutorial1)
            {

                audio[5].Play();
                tutorial1 = false;

            }
            if (!audio[5].isPlaying)
            {
                if (GvrController.AppButtonDown || Time.time > time + 10f)
                {
                    tutorial2 = true;
                }
            }
            if(tutorial2)
            {
                audio[6].Play();
                tutorial2 = false;
                tutorial = false;
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

}
