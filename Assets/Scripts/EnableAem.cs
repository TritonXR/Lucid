using UnityEngine;
using System.Collections;

public class EnableAem : MonoBehaviour
{

    public GameObject ddcontroller;
    public GameObject handmodel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LibraryTag"))
        {
            handmodel.SetActive(true);
            ddcontroller.SetActive(false);
        }
    }
}
