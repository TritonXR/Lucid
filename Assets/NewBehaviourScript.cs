using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public float Hp;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = new Vector3 ((-(1-(Hp/100))*150)/1000,0.0f,0.0f);
		this.transform.localScale = new Vector3 (Hp/100, 1, 1);
	}
}
