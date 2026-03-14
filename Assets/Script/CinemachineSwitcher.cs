using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{

    private bool baseCamera = true;
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchLeft()
    {
        if (baseCamera)
        {
            animator.Play("LeftCamera");
        }
        else
        {
            animator.Play("BaseCamera");
        }
        baseCamera = !baseCamera;
    }

    public void SwitchRight()
    {
        if (baseCamera)
        {
            animator.Play("RightCamera");
        }
        else
        {
            animator.Play("BaseCamera");
        }
        baseCamera = !baseCamera;
    }

    void Update()
    {
        
    }
}
