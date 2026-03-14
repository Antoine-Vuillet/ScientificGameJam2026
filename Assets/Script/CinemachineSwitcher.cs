using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{

    private bool baseCamera = true;
    private Animator animator;
    [SerializeField] private Canvas baseCanvas;
    [SerializeField] private Canvas phoneCanvas;
    [SerializeField] private Canvas laptopCanvas;
    [SerializeField] private Canvas screen1Canvas;
    [SerializeField] private Canvas screen2Canvas;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchPhone()
    {
        if (baseCamera)
        {
            animator.Play("PhoneCamera");
            baseCanvas.enabled = false;
            phoneCanvas.enabled = true;
        }
        else
        {
            animator.Play("BaseCamera");
            baseCanvas.enabled = true;
            phoneCanvas.enabled = false;
        }
        baseCamera = !baseCamera;
    }

    public void SwitchLaptop()
    {
        if (baseCamera)
        {
            animator.Play("LaptopCamera");
            baseCanvas.enabled = false;
            laptopCanvas.enabled = true;
        }
        else
        {
            animator.Play("BaseCamera");
            baseCanvas.enabled = true;
            laptopCanvas.enabled = false;
        }
        baseCamera = !baseCamera;
    }
    
    public void SwitchScreen1()
    {
        if (baseCamera)
        {
            animator.Play("Screen1Camera");
            baseCanvas.enabled = false;
            screen1Canvas.enabled = true;
        }
        else
        {
            animator.Play("BaseCamera");
            baseCanvas.enabled = true;
            screen1Canvas.enabled = false;
        }
        baseCamera = !baseCamera;
    }
    
    public void SwitchScreen2()
    {
        if (baseCamera)
        {
            animator.Play("Screen2Camera");
            baseCanvas.enabled = false;
            screen2Canvas.enabled = true;
        }
        else
        {
            animator.Play("BaseCamera");
            baseCanvas.enabled = true;
            screen2Canvas.enabled = false;
        }
        baseCamera = !baseCamera;
    }
}
