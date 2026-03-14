using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{

    private bool baseCamera = true;
    private Animator animator;
    [SerializeField] private Canvas baseCanvas;
    [SerializeField] private Canvas leftCanvas;
    [SerializeField] private Canvas rightCanvas;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchLeft()
    {
        if (baseCamera)
        {
            animator.Play("LeftCamera");
            baseCanvas.enabled = false;
            leftCanvas.enabled = true;
        }
        else
        {
            animator.Play("BaseCamera");
            baseCanvas.enabled = true;
            leftCanvas.enabled = false;
        }
        baseCamera = !baseCamera;
    }

    public void SwitchRight()
    {
        if (baseCamera)
        {
            animator.Play("RightCamera");
            baseCanvas.enabled = false;
            rightCanvas.enabled = true;
        }
        else
        {
            animator.Play("BaseCamera");
            baseCanvas.enabled = true;
            rightCanvas.enabled = false;
        }
        baseCamera = !baseCamera;
    }

    void Update()
    {
        
    }
}
