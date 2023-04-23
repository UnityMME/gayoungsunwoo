using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    public void StopButton()
    {
        SceneManager.LoadScene("main");
    }
}