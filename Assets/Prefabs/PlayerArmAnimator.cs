using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void punch()
    {
        animator.SetTrigger("Punch");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
