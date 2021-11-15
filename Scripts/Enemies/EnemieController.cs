using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    public int hp = 10;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerKnock")
        {
            anim.SetTrigger("Hit");
            hp -= PlayerMove.punchDamage;
        }
        if (hp <= 0)
        {
            anim.SetBool("Death",true);
        }
    }

    public void Defeated()
    {
        Destroy(gameObject);
    }
}
