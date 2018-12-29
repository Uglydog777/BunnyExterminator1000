using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float missileThrust = 1f;
    [SerializeField] float missileRotSpeed = 1f;

    [SerializeField] bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if(canMove == true)
        {
            if(Input.GetKey(KeyCode.W))
            {
                print("should be moving");
                rb.AddRelativeForce(Vector2.up *  missileThrust * Time.deltaTime);
            }
            if (!Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    rb.freezeRotation = true; // stop physics so we can rotate
                    transform.Rotate(Vector3.forward * missileRotSpeed);
                    rb.freezeRotation = false; //let physics take over again
                }
            }
            if (!Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.freezeRotation = true; // stop physics so we can rotate
                    transform.Rotate(-Vector3.forward * missileRotSpeed);
                    rb.freezeRotation = false; //let physics take over again
                }
            }
        }
    }
}
