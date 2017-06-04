using UnityEngine;
using System.Collections;

public class RealityCheck : MonoBehaviour
{

    // Use this for initialization
    Animator anim;
    public GameObject lefthand;
    public GameObject righthand;
    int Point = Animator.StringToHash("Point");
    int Idle = Animator.StringToHash("Idle");

    public static float awareness;
    public float excitement;
    public float awarenessRate = 0.1f;
    public float excitementRate = 1.01f;
    public float blurRate = 0.01f;
    public GameObject awarenessBlur;
    GameObject mainCamera;

    void Start()
    {
        anim = righthand.GetComponent<Animator>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        awareness = 0f;
        excitement = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gyr = GvrController.Gyro;
        Vector3 ori = GvrController.Orientation.eulerAngles;
        if (((ori.x - 360) < 0) && ((ori.y - 360) > -130 && (ori.y - 360) < 0) && ((ori.z - 360) > -340 && (ori.z - 360) < -240) && righthand.activeSelf == true)
        {
            lefthand.SetActive(true);
            anim.SetTrigger(Point);
            awareness = awareness + awarenessRate;
            Debug.Log("x " + (ori.x - 360) + "y " + (ori.y - 360) + "z " + (ori.z - 360));
            
        }
        else
        {
            lefthand.SetActive(false);
            anim.SetTrigger(Idle);
        }
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
        for (int i = 0; i < hits.Length; i++)
        {
            AwarenessObj p = hits[i].collider.GetComponent<AwarenessObj>();
            if (p != null)
            {
                awareness = awareness + awarenessRate;
                excitement = excitement * excitementRate;
            }
        }
        if (awareness >= 20f)
        {
            if (awarenessBlur.transform.localScale.x < 2000)
            {
                awarenessBlur.transform.localScale = awarenessBlur.transform.localScale * 1.03f;
            }
        }
    }
}