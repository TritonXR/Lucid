using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class GaiusTutorial : MonoBehaviour {
    public string playerLocation { get; private set; }
    public int beckonNumber = 1;
    private float t;
    public AudioClip[] stings;
    public AudioSource audio;
    public AudioClip beckon1;
    public AudioClip beckon2;
    public AudioClip beckon3;

    // Use this for initialization
    void Start () {
        playerLocation = "hallway";
        t = Time.time;
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > t + 18f)  // beckon every 18 seconds
        {
            switch (beckonNumber)
            {
                case 1:
                    audio.clip = beckon1;
                    break;

                case 2:
                    audio.clip = beckon2;
                    break;
                case 3:
                    audio.clip = beckon3;
                    beckonNumber = 0;  // reset to start
                    break;
            }
            audio.Play();
            t = Time.time;
            beckonNumber++;
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("LibraryTag"))
        {
            playerLocation = "library";
        }
    }
}
