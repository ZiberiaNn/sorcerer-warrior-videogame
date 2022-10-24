using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    public Transform atkPoint;
    public float meleeDamage;

    private Animator enemyAnim;

    private Animator playerAnim;

    private float cycleTime = 0;
    public float spellCooldown = 2f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CooldownTime()
    {
        if (cycleTime - Time.time > 0)
        {
            return cycleTime - Time.time;
        }
        else
        {
            return 0;
        }
    }

    public float CooldownPercentage()
    {
        return 1 - (CooldownTime() / spellCooldown);
    }

    public void Attack()
    {
        //if (CooldownTime() <= 0)
        //{
            playerAnim.SetTrigger("Melee");
        //}
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Esto es una prueba");   
        if (collision.transform.CompareTag("Enemy"))
        {
            enemyAnim=GetComponent<Animator>();
            EnemyHealthSystem enemyHealth = collision.gameObject.GetComponent<EnemyHealthSystem>();
            if (enemyHealth != null)
            {
                enemyHealth.UpdateHealth(-meleeDamage);
            }
        }
    }

}
