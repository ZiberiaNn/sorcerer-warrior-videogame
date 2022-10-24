using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class CasterAnimController : MonoBehaviour
{
    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

    }

    private void Update()
    {

    }

    public void WalkAnim()
    {
        enemyAnim.SetBool("Walk", true);
    }

    public void AttackAnim()
    {
        enemyAnim.SetBool("Walk", true);
    }

    public void GetHitAnim()
    {
        enemyAnim.SetTrigger("GetHit");
    }

}


