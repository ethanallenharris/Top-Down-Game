using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
   // public PlayerAnimation playerAnimation;
    public int attackSegments;
    public bool chainAttack;
    public int currentChain = 1;

    public void getPlayerAnimator()
    {
       // playerAnimation = FindObjectOfType<PlayerAnimation>();
    }

    public void startAttack(string animation)
    {
       // playerAnimation.ChangeAnimationState(animation + currentChain);
        //Animator.Se   get slash animation to revert back to normal
        if (chainAttack)//if player has clicked again to chain the attack
        {
            ++currentChain;
            startAttack(animation);
            return;
        } else
        {
            currentChain = 1;
        }
       // playerAnimation.ChangeAnimationState("None");
    }



}
