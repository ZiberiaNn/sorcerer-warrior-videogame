using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animatorPlayer;
    public Rigidbody rb;

    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    #region Move and Jump
    public void RunAnim()
    {
        animatorPlayer.SetBool("isRunning", true);
    }

    public void StopRun()
    {
        animatorPlayer.SetBool("isRunning", false);
    }

    public void JumpAnim()
    {
        animatorPlayer.SetBool("Jump", true);
    }

    public void ResetJump()
    {
        animatorPlayer.SetBool("Jump", false);
    }

    #endregion

    #region Animation Attack
    public void CastAnimation()
    {
        isRunning = true;
        animatorPlayer.SetBool("isRunning", false);
        animatorPlayer.SetBool("CastAttack", true);
    }

    public void FinishCast()
    {
        animatorPlayer.SetBool("CastAttack", false);
        isRunning = false;
    }

    public void DeniedAttack()
    {
        
    }
    #endregion

    #region Constraints Control

    public void CasttoRun()
    {
        animatorPlayer.SetBool("CastAttack", false);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        isRunning = false;
        animatorPlayer.SetBool("isRunning", true);
    }
    #endregion
}