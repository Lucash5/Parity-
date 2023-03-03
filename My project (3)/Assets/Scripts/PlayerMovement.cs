using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Pelaajan nopeus
    public float speed = 350;
    public float jumpForce = 350;
    public AudioClip jumpsound;
    AudioSource AS;

    Rigidbody rb;
    Animator anim;
    Vector3 playerInput; // pelaajan syötteen tallennukseen

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        playerInput = transform.forward * Input.GetAxis("Vertical") * speed;
        playerInput += transform.right * Input.GetAxis("Horizontal") * speed;
        playerInput.y = rb.velocity.y;


        if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
                AS.PlayOneShot(jumpsound, 0.5f);
            }
        }
        anim.SetFloat("velocity", playerInput.magnitude);
    }

    private void FixedUpdate()
    {
        rb.velocity = playerInput;
    }
}

