using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMethod : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
