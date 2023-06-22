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
    [Header("Info boxes")]
    [SerializeField]
    private Image tankAInfo;
    [SerializeField]
    private Image tankBInfo;
    [Header("Global info")]
    [SerializeField]
    private float maximumWaterLevel;

    /// <summary>
    /// Turn on and off an info box about specific tank. 
    /// </summary>
    /// <param name="tankInfoImage">Info box of specific tank</param>
    public void ShowInfo(Image tankInfoImage)
    {
        bool activeStateOfTank = !tankInfoImage.gameObject.activeSelf;
        tankInfoImage.gameObject.SetActive(activeStateOfTank);
    }

    private void FixedUpdate()
    {
        UpdateInfo();
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
    /// <param name="tankName">Name of water object in specific tank</param>
    /// <returns>Occupancy percentage</returns>
    private string CalculatePercent(string tankName)
    {
        GameObject tank = GameObject.Find(tankName);
        float result = (tank.transform.localScale.y * 100) / maximumWaterLevel;
        return (int)result + "%";
    }
}
