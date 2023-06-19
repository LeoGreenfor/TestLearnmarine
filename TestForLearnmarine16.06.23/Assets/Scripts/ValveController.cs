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

    private bool _isValveOpen = false;

    public void CloseValve()
    {
        //call for change water level
        ChangeSprite();
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
