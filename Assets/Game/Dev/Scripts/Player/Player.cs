using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform camFirstPerson;
    [SerializeField] Transform head;
    [SerializeField] Transform hand;
    [SerializeField] CapsuleCollider col;
    [SerializeField] GameObject flashLight;
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
        Bend();
        FlashLightTurnOnOff();
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
        if (Input.GetKeyDown(KeyCode.LeftControl)) { 

            LeanTween.moveY(gameObject, transform.position.y - 1, 0.2f); 
            col.height = 1;
            col.center = new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) { 

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

    void FlashLightTurnOnOff()
    { 
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashLight.activeSelf)
            {
                LeanTween.moveLocalY(hand.gameObject, -1, 0.2f).setOnComplete(()=> { flashLight.SetActive(false); });
            }
            else
            {
                flashLight.SetActive(true);
                LeanTween.moveLocalY(hand.gameObject, -0.5f, 0.2f);
            }
        }
    }
}
