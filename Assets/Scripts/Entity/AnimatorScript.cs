using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    
    Animator animator;
    private string currentState;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

}
