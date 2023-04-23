using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cartText : MonoBehaviour
{
    public Text ScriptTxt;
    List<Item> Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.Find("cart").GetComponent<cartTrigger>().Inventory;
    }


    // Update is called once per frame
    void Update()
    {
        ScriptTxt.text = "";
        if(Inventory.Count != 0){
            for(int i = Inventory.Count - 1; i >= 0; i--)
            {
                string item = Inventory[i].KName + " " + Inventory[i].Price+ "원\n";
                ScriptTxt.text = ScriptTxt.text + item;
            }
        }
    }

}
