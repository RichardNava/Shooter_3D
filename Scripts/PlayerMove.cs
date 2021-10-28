using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 150;

    private float x, z;

    public Animator anim;

    public Rigidbody rb;
    public float jumpForce = 5;

    public Transform groundCheck;
    public LayerMask groundMask;

    bool isGrounded = false;

    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal"); // -1 (Izquierda) / 0 (Centro) / 1 (Derecha)
        z = Input.GetAxis("Vertical"); // -1 (Adelante) / 0 (Centro) / 1 (Atras)

        this.transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        this.transform.Translate(0, 0, z * Time.deltaTime * speed);
        anim.SetFloat("ValueX", x);
        anim.SetFloat("ValueZ", z);
    }

    void Update()
    {
        Jumping();
        OtherAnims();
    }
    public void Jumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        anim.SetBool("isGrounded", isGrounded);

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            anim.Play("JumpingUp");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    public void OtherAnims()
    {
        if (Input.GetKey(KeyCode.T) && isGrounded)
        {
            anim.SetBool("StopAnim", false);
            anim.Play("Taunt");
        }
        if (Input.GetKey(KeyCode.Y) && isGrounded)
        {
            anim.SetBool("StopAnim", false);
            anim.Play("Dance");
        }
        if (x != 0 || z != 0) // == es para comprobar igualdad / != es para comprobar que sea distinto
        {
            anim.SetBool("StopAnim", true);
        }
    }

}
