using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class MeleeAnimController : MonoBehaviour, IEnemyAnimController
{
    public Animator enemyAnim;
    private MeleeEnemyNavMesh enemyNavMesh;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyNavMesh = GetComponent<MeleeEnemyNavMesh>();
        enemyNavMesh.canMove = false;

    }

    private void Update()
    {

    }

    public void WalkBack()
    {
        //enemyAnim.SetBool("isWalkingBack", true);
    }
    public void WalkAnim()
    {
        enemyAnim.SetBool("isWalking", true);
    }

    public void Idle()
    {
        enemyAnim.SetTrigger("Idle");
        enemyAnim.SetBool("isWalking", false);
    }

    public void AttackAnim()
    {
        enemyAnim.SetBool("isAttacking", true);
        enemyAnim.SetBool("isWalking", false);
        //enemyAnim.SetBool("isWalkingBack", false);
        enemyNavMesh.canMove = false;
    }

    public void EndAttackAnim()
    {
        enemyAnim.SetBool("isAttacking", false);
        enemyNavMesh.canMove = true;
    }

    public void SummonAnim()
    {
        //enemyAnim.SetBool("isSummoning", true);
        enemyAnim.SetBool("isWalking", false);
        //enemyAnim.SetBool("isWalkingBack", false);
        enemyNavMesh.canMove = false;
    }
    public void EndSummonAnim()
    {
        //enemyAnim.SetBool("isSummoning", false);
        //enemyNavMesh.canMove = true;
    }


    public void GetHitAnim()
    {
        FindObjectOfType<SoundManager>().Play("HitEnemy");
        enemyAnim.SetTrigger("GetHit");
        enemyAnim.SetBool("isWalking", false);
        //enemyAnim.SetBool("isWalkingBack", false);
        enemyAnim.SetBool("isAttacking", false);
        //enemyAnim.SetBool("isSummoning", false);
        enemyNavMesh.canMove = false;

    }

    public void EndGetHitAnim()
    {      
        enemyNavMesh.canMove = true;
    }
    public void DieAnim()
    {
        FindObjectOfType<SoundManager>().Play("DeadEnemy");
        enemyAnim.SetTrigger("Die");
        enemyNavMesh.isDead=true;
    }

    public void ActivateMove()
    {
        enemyNavMesh.canMove = true;
    }
}


