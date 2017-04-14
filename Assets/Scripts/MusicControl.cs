using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour {
    public AudioMixerSnapshot Hallway;
    public AudioMixerSnapshot Library;
    public AudioClip[] stings;
    public AudioSource stingSource;
    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;


	// Use this for initialization
	void Start () {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote * 3;
        m_TransitionOut = m_QuarterNote * 3;
	}
	
    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("LibraryTag"))
        {
            Library.TransitionTo(m_TransitionIn);
        }
    }

	void OnTriggerExit(Collider c) {
        if (c.CompareTag("LibraryTag"))
        {
            Hallway.TransitionTo(m_TransitionOut);
        }
	}
}
