using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValveController : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private WaterLevelManager waterManager;

    private bool _isValveOpen = false;

    public void TwistValve()
    {
        ChangeSprite();
        waterManager.IsValveOpenSet(_isValveOpen);
        if (_isValveOpen)
        {
            waterManager.ChangeWaterLevel(pipe.transform);
        }
    }

    public void CloseValve()
    {
        Sprite currentSprite;
        currentSprite = sprites[0];

        _isValveOpen = false;
        GetComponentInChildren<Image>().sprite = currentSprite;
    }

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
