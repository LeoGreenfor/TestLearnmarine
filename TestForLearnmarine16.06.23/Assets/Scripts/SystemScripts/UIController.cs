using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class using for control UI elements, like buttons or tutorial.
/// It`s turn on or off some of UI elements, when it`s need.
/// </summary>
public class UIController : MonoBehaviour
{
    private static PipeLiftingController PipeLiftingController;

    /// <summary>
    /// Gets the necessary cortrollers from the scene
    /// </summary>
    private void Awake()
    {
        PipeLiftingController = gameObject.GetComponentInChildren<PipeLiftingController>();
    }

    /// <summary>
    /// Set interactible value for pipe lifting buttons
    /// </summary>
    /// <param name="enableState"></param>
    public static void SetEnableForLiftingButtons(bool enableState)
    {
        PipeLiftingController.ChangeInteractible(enableState);
    }
}
