using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class RaiseAwareExite : MonoBehaviour {

    public float awareness;
    public float excitement;
	public float awarenessRate = 0.1f;
	public float excitementRate = 1.01f;
	public float blurRate = 0.01f;

    GameObject mainCamera;

	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");
        awareness = 0f;
        excitement = 0.1f;
	}
	
	void Update () {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000))
        {
            AwarenessObj p = hit.collider.GetComponent<AwarenessObj>();
            if(p != null) {
				awareness = awareness + awarenessRate;
				excitement = excitement * excitementRate;
            }
        }
        if(awareness >= 20f)
        {
            mainCamera.GetComponent<DepthOfField>().aperture -= blurRate;
        }
	}
}
