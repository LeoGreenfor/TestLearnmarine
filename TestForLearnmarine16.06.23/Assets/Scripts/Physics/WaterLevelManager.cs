using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class change level of water in tanks by making
/// they same level.
/// </summary>
public class WaterLevelManager : MonoBehaviour
{
    public static bool IsChangingWaterLevel;

    [Header("Water in tanks")]
    [SerializeField]
    private Transform waterInTankA;
    [SerializeField]
    private Transform waterInTankB;
    [Header("Stats")]
    [SerializeField]
    private float step;
    [SerializeField]
    private float speed;

    private bool _isWaterInTankAHigher;
    private bool _isWaterInTankBHigher;
    private bool _isValveOpen;
    private float _step;

    /// <summary>
    /// Change water level, if its possible
    /// </summary>
    /// <param name="pipe"></param>
    public void ChangeWaterLevel(Transform pipe)
    {
        _step = step;
        if (IsWaterLevelCanChange(pipe))
        {
            IsChangingWaterLevel = true;
            UIController.SetEnableForLiftingButtons(false);
            StartCoroutine(Culldown(pipe));
        }
        else
        {
            IsChangingWaterLevel = false;
            UIController.SetEnableForLiftingButtons(true);
        }
    }

    /// <summary>
    /// Set the isValveOpen variable
    /// </summary>
    /// <param name="valveState"></param>
    public void IsValveOpenSet(bool valveState)
    {
        _isValveOpen = valveState;
    }

    /// <summary>
    /// Checking, if its possible to change water level in tanks by 
    /// checking level of pipe and level of water in each tank.
    /// </summary>
    /// <param name="pipe"></param>
    /// <returns>True if possible, false if not.</returns>
    private bool IsWaterLevelCanChange(Transform pipe)
    {
        float actualLevelOfPipe = pipe.position.y - pipe.GetComponent<CapsuleCollider>().radius * 0.2f;

        if ((waterInTankA.localScale.y >= actualLevelOfPipe || 
            waterInTankB.localScale.y >= actualLevelOfPipe) && 
            (waterInTankA.localScale.y > waterInTankB.localScale.y))
        {
            _isWaterInTankAHigher = true;
            _isWaterInTankBHigher = false;
            return true;
        } else if ((waterInTankA.localScale.y >= actualLevelOfPipe ||
            waterInTankB.localScale.y >= actualLevelOfPipe) &&
            (waterInTankA.localScale.y < waterInTankB.localScale.y))
          {
            _isWaterInTankBHigher = true;
            _isWaterInTankAHigher = false;
            return true;
          }

        return false;
    }

    /// <summary>
    /// Makes a smooth leveling of water levels in tanks.
    /// </summary>
    /// <param name="pipe"></param>
    /// <returns></returns>
    private IEnumerator Culldown(Transform pipe)
    {
        yield return new WaitForSeconds(speed);
        WaterTransfusion();
        if (IsWaterLevelCanChange(pipe) && _isValveOpen)
        {
            IsChangingWaterLevel = true;
            StartCoroutine(Culldown(pipe));
        }
        else
        {
            IsChangingWaterLevel = false;
            UIController.SetEnableForLiftingButtons(true);
        }
    }

    /// <summary>
    /// Transfusion water from tank with higher level of water to lower.
    /// </summary>
    private void WaterTransfusion()
    {
        float newLevelWaterA = waterInTankA.localScale.y;
        float newLevelWaterB = waterInTankB.localScale.y;


        if (Mathf.Abs(newLevelWaterA - newLevelWaterB) <= step)
        {
            _step = Mathf.Abs(newLevelWaterA - newLevelWaterB) / 2.0f;
        }
        if (_isWaterInTankAHigher)
        {
            newLevelWaterA = waterInTankA.localScale.y - _step;
            newLevelWaterB = waterInTankB.localScale.y + _step;
        }
        if (_isWaterInTankBHigher)
        {
            newLevelWaterA = waterInTankA.localScale.y + _step;
            newLevelWaterB = waterInTankB.localScale.y - _step;
        }

        waterInTankA.localScale = new Vector3(waterInTankA.localScale.x, newLevelWaterA, waterInTankA.localScale.z);
        waterInTankB.localScale = new Vector3(waterInTankB.localScale.x, newLevelWaterB, waterInTankB.localScale.z);
    }
}
