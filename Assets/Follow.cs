using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
public RectTransform rectransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 player3DPosition = Camera.main.WorldToScreenPoint (transform.position);
		rectransform.position = player3DPosition;
	}
}
