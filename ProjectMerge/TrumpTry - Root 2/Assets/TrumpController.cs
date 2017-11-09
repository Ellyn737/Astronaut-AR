using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TrumpController : MonoBehaviour {

    private Rigidbody rb;
    private Animation anim;

    public float speed = 0.1f;
    public float jumpVelocity;
  
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
	}

    // Update is called once per frame
    void Update() {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        bool z =  CrossPlatformInputManager.GetButtonDown("Jump");
         
        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * speed;

        // rotate character in movement direction
        if (x != 0 && y != 0) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if (x != 0 || y != 0) {
            anim.Play("walk");
        } else {
            anim.Play("idle");
        }
         
        if (z)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            Debug.Log(z);
        }

    }
}
