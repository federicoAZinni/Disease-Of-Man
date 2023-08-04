using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform camFirstPerson;
    [SerializeField] Transform head;
    [SerializeField] CapsuleCollider col;
    [Header("Move")]
    [SerializeField] float speedMov;
    [SerializeField] float speedRot;

    float movY;
    float movX;
   

    // Update is called once per frame
    void Update()
    {
        Move();
        Bend();
        Rot();
    }

    void Move()
    {
        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        Vector3 mov = transform.right * movx + transform.forward * movz;

        rb.velocity = mov * speedMov * Time.deltaTime * 100;
    }

    void Bend()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            LeanTween.moveY(gameObject, transform.position.y - 1, 0.2f);
            col.height = 1;
            col.center = new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {

            LeanTween.moveY(gameObject, transform.position.y + 1, 0.2f);
            // Deberia ejecutarse esto despues de terminar la animacion (sugerencia)
            col.height = 2;
            col.center = Vector3.zero;
        }

    }

    void Rot()
    {
        movY += Input.GetAxis("Mouse X");
        movX -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, movY * speedRot, transform.rotation.z));
        camFirstPerson.rotation = Quaternion.Euler(new Vector3(movX * speedRot, movY * speedRot, transform.rotation.z));
        head.rotation = Quaternion.Euler(new Vector3(movX * speedRot, movY * speedRot, transform.rotation.z));
    }
}
