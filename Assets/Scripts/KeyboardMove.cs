using UnityEngine;
using System.Collections;

public class KeyboardMove : MonoBehaviour {

	//movement
	public float forward_Speed = 5.0f;
	public float sideways_Speed = 1.0f;

	//camera
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	GameObject mainCamera;

	void Start () {
		//movement
		Cursor.lockState = CursorLockMode.Locked;
		//camera
		mainCamera = GameObject.FindWithTag("MainCamera");
	}

	void Update () {

		//movement
		float translation = Input.GetAxis ("Vertical") * forward_Speed;
		float straffe = Input.GetAxis ("Horizontal") * sideways_Speed;
		translation *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);

		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
	
		//camera
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;
		mainCamera.transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		this.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, this.transform.up);

	}
}
