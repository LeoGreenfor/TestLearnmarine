using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelManager : MonoBehaviour
{
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

    public void ChangeWaterLevel(Transform pipe)
    {
        _step = step;
        if (IsWaterLevelCanChange(pipe))
        {
            StartCoroutine(Culldown(pipe));
        }
    }

    public void IsValveOpenSet(bool valveState)
    {
        _isValveOpen = valveState;
    }

    private bool IsWaterLevelCanChange(Transform pipe)
    {
        float actualLevelOfPipe = pipe.position.y - pipe.GetComponent<CapsuleCollider>().radius * 0.15f;

        if ((waterInTankA.localScale.y > actualLevelOfPipe || 
            waterInTankB.localScale.y > actualLevelOfPipe) && 
            (waterInTankA.localScale.y > waterInTankB.localScale.y))
        {
            _isWaterInTankAHigher = true;
            _isWaterInTankBHigher = false;
            return true;
        } else if ((waterInTankA.localScale.y > actualLevelOfPipe ||
            waterInTankB.localScale.y > actualLevelOfPipe) &&
            (waterInTankA.localScale.y < waterInTankB.localScale.y))
          {
            _isWaterInTankBHigher = true;
            _isWaterInTankAHigher = false;
            return true;
          }
        return false;
    }

    private IEnumerator Culldown(Transform pipe)
    {
        yield return new WaitForSeconds(speed);
        WaterTransfusion();
        if (IsWaterLevelCanChange(pipe) && _isValveOpen)
        {
            StartCoroutine(Culldown(pipe));
        }
    }

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
