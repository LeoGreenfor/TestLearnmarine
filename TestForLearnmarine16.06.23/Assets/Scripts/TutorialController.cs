using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [Header("Tutorial messages")]
    [SerializeField]
    private GameObject[] AboutMesagges;
    
    [SerializeField]
    private int _numberOfCurrentMessage = 0;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CloseCurrentMessage();
            _numberOfCurrentMessage++;
            OpenNextMessage();
        }
    }

    private void CloseCurrentMessage()
    {
        AboutMesagges[_numberOfCurrentMessage].SetActive(false);
    }

    private void OpenNextMessage()
    {
        bool isLastMessage = _numberOfCurrentMessage == AboutMesagges.Length;
        if (isLastMessage)
        {
            gameObject.SetActive(false);
        }
        else
        {
            AboutMesagges[_numberOfCurrentMessage].SetActive(true);
        }
    }
}
