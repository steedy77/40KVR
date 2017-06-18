using UnityEngine;
using System.Collections;

public class TriggerZoom : MonoBehaviour
{

    Animator anim;
    Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent< ****ENEMY NEEDS TO GO HERE****    >())
            anim.SetBool("CameraZoom", true);
    }
}

