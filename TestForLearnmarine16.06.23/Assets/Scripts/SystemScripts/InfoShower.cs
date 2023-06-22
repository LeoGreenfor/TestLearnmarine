using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoShower : MonoBehaviour
{
    [Header("Info boxes")]
    [SerializeField]
    private Image infoImage;

    private BarrelShowInfo _barrelShowInfo;

    private void Start()
    {
        _barrelShowInfo = FindObjectOfType<BarrelShowInfo>();
    }

    /// <summary>
    /// Turn on and of info box about tank when mouse was clicked.
    /// </summary>
    private void OnMouseDown()
    {
        _barrelShowInfo.ShowInfo(infoImage);
    }
}
