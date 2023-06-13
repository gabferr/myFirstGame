using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{   
    public Animator animator;
    public string triggerAttack = "Attack";

    public int damage = 10;
    public HealthBase healthBase;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.damage(damage);
            PlayAtatckAnimation();
        }
    }

   private void PlayAtatckAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    public void Damage(int amout)
    {
        healthBase.damage(amout);
    }
}
