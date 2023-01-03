using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Controls the state of our player for animations and other effects?*/
public class PlayerTorsoAndLegsAnimator : MonoBehaviour
{
    public Animator animator;
    public bool IsWalking // were offloading this state to the animator
    {
        get { return animator.GetBool("IsWalking"); }
        set { animator.SetBool("IsWalking", value); }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
