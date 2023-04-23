using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHint : MonoBehaviour
{
    public GameObject Hint;
    public Button btnHint;

    void Start()
    {
        Hint.SetActive(false);
        btnHint.onClick.AddListener(ShowHint);
    }

    void ShowHint(){
        Hint.SetActive(true);
        Invoke("HideHint", 5);
    }

    void HideHint(){
        Hint.SetActive(false);
    }
}
