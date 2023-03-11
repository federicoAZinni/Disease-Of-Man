using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform camFirstPerson;
    [Header("Move")]
    [SerializeField] float speedMov;
    [SerializeField] float speedRot;
    float movY;
    float movX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rot();
    }

    void Move()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical")) * speedMov;
    }

    void Rot()
    {
        movY += Input.GetAxis("Mouse X");
        movX -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, movY * speedRot, transform.rotation.z));
        camFirstPerson.rotation = Quaternion.Euler(new Vector3(movX * speedRot, movY * speedRot, transform.rotation.z));
    }
}
