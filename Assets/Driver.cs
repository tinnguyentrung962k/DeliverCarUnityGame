using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{   
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 25f;

    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 35f;
    [SerializeField] float destroyDelay = 0;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);

        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpeedUp"))
        {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
    }

    
}
