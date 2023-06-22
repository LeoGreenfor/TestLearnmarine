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
    private GameObject _waterInTank;

    private void Start()
    {
        _barrelShowInfo = FindObjectOfType<BarrelShowInfo>();
        _waterInTank = transform.GetChild(0).gameObject;
    }

    private void OnMouseDown()
    {
        _barrelShowInfo.ShowInfo(infoImage, _waterInTank.name);
    }
}
