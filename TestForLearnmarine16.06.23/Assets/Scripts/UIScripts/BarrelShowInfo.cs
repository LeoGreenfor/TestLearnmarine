using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class show actual info about each tank.
/// </summary>
public class BarrelShowInfo : MonoBehaviour
{
    [Header("Water tank colliders")]
    [SerializeField]
    private BoxCollider tankA;
    [SerializeField]
    private BoxCollider tankB;
    [Header("Info boxes")]
    [SerializeField]
    private Image tankAInfo;
    [SerializeField]
    private Image tankBInfo;
    [Header("Global info")]
    [SerializeField]
    private float maximumWaterLevel;

    private bool _isMouseOnTankA = false;
    private bool _isMouseOnTankB = false;

    private void FixedUpdate()
    {
        CheckWhichCollider();
        UpdateInfo();
        tankAInfo.gameObject.SetActive(_isMouseOnTankA);
        tankBInfo.gameObject.SetActive(_isMouseOnTankB);
    }

    /// <summary>
    /// Checking, if mouse pointer is on one of tank. If yes - remember on witch tank.
    /// </summary>
    private void CheckWhichCollider()
    {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out hit))
         {
             Collider collider = hit.collider;

             if (collider.Equals(tankA))
             {
                 _isMouseOnTankA = true;
                 _isMouseOnTankB = false;
             }
             else if (collider.Equals(tankB))
             {
                 _isMouseOnTankB = true;
                 _isMouseOnTankA = false;
             }
         }
         else
         {
             _isMouseOnTankA = false;
             _isMouseOnTankB = false;
         }
    }

    /// <summary>
    /// Updating info about tanks.
    /// </summary>
    private void UpdateInfo()
    {
        string template = "Fullness of the barrel ";
        tankAInfo.GetComponentInChildren<TMP_Text>().text = template + CalculatePercent("WaterA");

        tankBInfo.GetComponentInChildren<TMP_Text>().text = template + CalculatePercent("WaterB");
    }

    /// <summary>
    /// Ñounts how much a certain tank is filled with water.
    /// </summary>
    /// <param name="tankName"></param>
    /// <returns>Occupancy percentage</returns>
    private string CalculatePercent(string tankName)
    {
        GameObject tank = GameObject.Find(tankName);
        float result = (tank.transform.localScale.y * 100) / maximumWaterLevel;
        return (int)result + "%";
    }
}
