using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class controll the valve.
/// </summary>
public class ValveController : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private WaterLevelManager waterManager;

    private bool _isValveOpen = false;

    /// <summary>
    /// Twisting valve. If valve opening than start to transfusion water.
    /// </summary>
    public void TwistValve()
    {
        ChangeSprite();
        waterManager.IsValveOpenSet(_isValveOpen);
        if (_isValveOpen)
        {
            waterManager.ChangeWaterLevel(pipe.transform);
        }
    }

    /// <summary>
    /// Close the valve.
    /// </summary>
    public void CloseValve()
    {
        Sprite currentSprite;
        currentSprite = sprites[0];

        _isValveOpen = false;
        GetComponentInChildren<Image>().sprite = currentSprite;
    }

    /// <summary>
    /// Change state of valve to next state.
    /// </summary>
    private void ChangeSprite()
    {
        Sprite currentSprite;
        if (_isValveOpen)
        {
            currentSprite = sprites[0];
        }
        else
        {
            currentSprite = sprites[1];
        }

        _isValveOpen = !_isValveOpen;
        GetComponentInChildren<Image>().sprite = currentSprite;
    }
}
