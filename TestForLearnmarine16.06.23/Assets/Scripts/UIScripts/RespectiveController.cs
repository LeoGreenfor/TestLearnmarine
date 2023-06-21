using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows user to change level of water in tanks by press specific buttons.
/// </summary>
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

    /// <summary>
    /// Increase water level in tank A.
    /// </summary>
    public void LeftPlus()
    {
        OnWaterTransfusion();
        ChangeLevel(waterInTankA, true);
    }

    /// <summary>
    /// Increase water level in tank B.
    /// </summary>
    public void RightPlus()
    {
        OnWaterTransfusion();
        ChangeLevel(waterInTankB, true);
    }

    /// <summary>
    /// Decrease water level in tank A.
    /// </summary>
    public void LeftMinus()
    {
        OnWaterTransfusion();
        ChangeLevel(waterInTankA, false);
    }

    /// <summary>
    /// Decrease water level in tank B.
    /// </summary>
    public void RightMinus()
    {
        OnWaterTransfusion();
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

    /// <summary>
    /// Auto close valve if water transfusion is over and user 
    /// try to change water level themself.
    /// </summary>
    private void OnWaterTransfusion()
    {
        bool isOnWaterTransfusion = WaterLevelManager.IsChangingWaterLevel;
        if (!isOnWaterTransfusion)
        {
            FindObjectOfType<ValveController>().CloseValve();
        }
    }
}
