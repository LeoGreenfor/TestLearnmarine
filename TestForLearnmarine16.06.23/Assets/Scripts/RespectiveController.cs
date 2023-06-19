using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespectiveController : MonoBehaviour
{
    [Header("Water in tanks")]
    [SerializeField]
    private GameObject waterInTankA;
    [SerializeField]
    private GameObject waterInTankB;
    
    [Header("Limits for water")]
    [SerializeField]
    private float maximumLevelOfWater;
    [SerializeField]
    private float minimumLevelOfWater;

    [SerializeField]
    private float step;

    public void LeftPlus()
    {
        ChangeLevel(waterInTankA, true);
    }
    public void RightPlus()
    {
        ChangeLevel(waterInTankB, true);
    }
    public void LeftMinus()
    {
        ChangeLevel(waterInTankA, false);
    }
    public void RightMinus()
    {
        ChangeLevel(waterInTankB, false);
    }

    /// <summary>
    /// Change level of water in specific tank. If "operation" equal true, then level increase. 
    /// Else if "operation" equal false, level of water decrease.
    /// </summary>
    /// <param name="water"></param>
    /// <param name="operation"></param>
    private void ChangeLevel(GameObject water, bool operation)
    {
        float koef = 0;

        if (operation && water.transform.localScale.y < maximumLevelOfWater)
        {
            koef = 1;
        }
        else if (!operation && water.transform.localScale.y > minimumLevelOfWater) {
            koef = -1;
        }

        float newScaleY = water.transform.localScale.y + (step * koef);
        float clampedY = Mathf.Clamp(newScaleY, minimumLevelOfWater, maximumLevelOfWater);
        Vector3 newTransform = water.transform.localScale;
        newTransform = new Vector3(newTransform.x, clampedY, newTransform.z);
        water.transform.localScale = newTransform;
    }

}
