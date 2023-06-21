using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class using for control UI elements, like buttons or tutorial.
/// It`s turn on of off some of UI elements, when it`s need.
/// </summary>
public class UIController : MonoBehaviour
{
    private static PipeLiftingController PipeLiftingController;
    private static WaterLevelManager WaterLevelManager;

    private void Awake()
    {
        PipeLiftingController = gameObject.GetComponentInChildren<PipeLiftingController>();
        WaterLevelManager = gameObject.GetComponentInChildren<WaterLevelManager>();
    }

    public static void SetEnableForLiftingButtons(bool enableState)
    {
        PipeLiftingController.ChangeInteractible(enableState);
    }
}
