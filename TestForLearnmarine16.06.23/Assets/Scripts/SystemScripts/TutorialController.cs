using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class using for show a tutorial messages, like
/// "about application", "about respective buttons" ets.
/// </summary>
public class TutorialController : MonoBehaviour
{
    [Header("Tutorial messages")]
    [SerializeField]
    private GameObject[] AboutMesagges;
    
    private int _numberOfCurrentMessage = 0;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CloseCurrentMessage();
            _numberOfCurrentMessage++;
            OpenNextMessage();
        }
    }

    /// <summary>
    /// Close current tutorial message
    /// </summary>
    private void CloseCurrentMessage()
    {
        AboutMesagges[_numberOfCurrentMessage].SetActive(false);
    }

    /// <summary>
    /// Shows next tutorial message. If program already show all messages, 
    /// close tutorial in a nutshell
    /// </summary>
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
