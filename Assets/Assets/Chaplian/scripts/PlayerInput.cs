using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public float horizontal;
    public float vertical;
    public bool fire1;


    void FixedUpdate()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");
        this.fire1 = Input.GetButton("Fire1");
    }

}

