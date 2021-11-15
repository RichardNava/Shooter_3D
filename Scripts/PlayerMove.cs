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


    // Variables para el ataque
    public bool isAttacking, stepAdvance;
    public float impulsePunch = 200f;
    public static int punchDamage = 2;
    public BoxCollider punchCollider;



    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal"); // -1 (Izquierda) / 0 (Centro) / 1 (Derecha)
        z = Input.GetAxis("Vertical"); // -1 (Adelante) / 0 (Centro) / 1 (Atras)

        if (!isAttacking)
        {
            this.transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            this.transform.Translate(0, 0, z * Time.deltaTime * speed);
            anim.SetFloat("ValueX", x);
            anim.SetFloat("ValueZ", z);
        }
        if (stepAdvance)
        {
            rb.velocity = transform.forward * impulsePunch * Time.deltaTime;
        }

    }

    void Update()
    {
        Jumping();
        OtherAnims();
        Punch();
    }

    public void Punch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded && !isAttacking)
        {
            anim.SetTrigger("Punch");
            isAttacking = true;
        }
    }
    public void Jumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        anim.SetBool("isGrounded", isGrounded);

        if (isGrounded && Input.GetKey(KeyCode.Space) && !isAttacking)
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
    public void NotAttack()
    {
        isAttacking = false;
    }
    public void AdvanceStep()
    {
        stepAdvance = true;
    }
    public void NotAdvanceStep()
    {
        stepAdvance = false;
    }
    public void EnablePunchCollider()
    {
        punchCollider.enabled = true;
    }
    public void DisablePunchCollider()
    {
        punchCollider.enabled = false;
    }
}
