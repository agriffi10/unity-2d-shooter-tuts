using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensures the required component is attached to where this script is also attached
[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    protected Animator agentAnimator;

    private void Awake()
    {
        // Gets our required component and sets it to the variable as a reference
        agentAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnimation(bool val)
    {
        agentAnimator.SetBool("Walk", val);
    }

    public void AnimatePlayer(float velocity)
    {
        SetWalkAnimation(velocity > 0);
    }
}
