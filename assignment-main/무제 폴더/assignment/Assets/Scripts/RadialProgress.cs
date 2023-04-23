using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RadialProgress : MonoBehaviour
{
    public Image LoadingBar;
    float currentValue;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < 60){
            currentValue += speed * Time.deltaTime;
        }
        else{
            SceneManager.LoadScene("GameOver");
        }

        LoadingBar.fillAmount = (1 - currentValue / 60);
    }
}