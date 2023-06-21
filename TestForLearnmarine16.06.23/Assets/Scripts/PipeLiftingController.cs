using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeLiftingController : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;

    [Header("Limits for pipe")]
    [SerializeField]
    private float maximumLevelOfPipe;
    [SerializeField]
    private float minimumLevelOfPipe;

    [SerializeField]
    private float step;

    public void LiftPipe(bool state)
    {
        OnLifting();
        ChangeLevel(state);
    }

    public void ChangeInteractible(bool state)
    {
        Button[] buttons = gameObject.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }
    }

    /// <summary>
    /// Change level of pipe. If "operation" equal true, then level increase. 
    /// Else if "operation" equal false, level of pipe decrease.
    /// </summary>
    /// <param name="operation"></param>
    private void ChangeLevel(bool operation)
    {
        float koef = 0;

        if (operation && pipe.transform.position.y < maximumLevelOfPipe)
        {
            koef = 1;
        }
        else if (!operation && pipe.transform.position.y > minimumLevelOfPipe)
        {
            koef = -1;
        }

        float newScaleY = pipe.transform.position.y + (step * koef);
        float clampedY = Mathf.Clamp(newScaleY, minimumLevelOfPipe, maximumLevelOfPipe);
        Vector3 newTransform = pipe.transform.position;
        newTransform = new Vector3(newTransform.x, clampedY, newTransform.z);
        pipe.transform.position = newTransform;
    }

    private void OnLifting()
    {
        FindObjectOfType<ValveController>().CloseValve();
    }
}
