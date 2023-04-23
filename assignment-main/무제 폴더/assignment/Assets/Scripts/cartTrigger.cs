using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

[System.Serializable]
public class Item{
    public GameObject obj;
    public string No, Name, Price, KName;
    public bool Special = false;
    public Item(string _No, string _Name, string _Price, string _KName){
        No = _No;
        Name = _Name;
        Price = _Price;
        KName = _KName;
    }
    public Item(Item copy){
        No = copy.No;
        Name = copy.Name;
        Price = copy.Price;
        KName = copy.KName;
    }
    public void addGameObject(GameObject addObj){
        obj = addObj;
    }
}


public class cartTrigger : MonoBehaviour
{

    public TextAsset itemPrice;
    public string No, Name, Price;

    public Text ScriptTxtName;
    public Text ScriptTxtPrice;
    public List<Item> itemList;
    public List<Item> Inventory = new List<Item>();
    public Item newItem;
    
    void Start(){
    
        string[] line = itemPrice.text.Substring(0, itemPrice.text.Length - 1).Split('\n');
        //print(line.Length);
        //print(line[2]);
        for(int i =0; i< line.Length; i++){
            string [] row = line[i].Split('\t');

            itemList.Add(new Item(row[0], row[1], row[2], row[3]));
        }
        //print(itemList[1].Price);
    }

    private void printItem()
    {
        ScriptTxtName.text="";
        ScriptTxtPrice.text="";

        if(Inventory.Count != 0){
            for(int i = Inventory.Count - 1; i >= 0; i--)
            {
                string itemName;
                if(Inventory[i].Special){
                    itemName ="특별한" +Inventory[i].KName+"\n";
                }
                else{
                    itemName = Inventory[i].KName +"\n";
                }
                ScriptTxtName.text = ScriptTxtName.text + itemName;

                string itemPrice = Inventory[i].Price + "원\n";
                if(itemName.Length > 8){
                    itemPrice = itemPrice+"\n";
                }
                ScriptTxtPrice.text = ScriptTxtPrice.text + itemPrice;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("goal")){
            SceneManager.LoadScene("GameEnd");
        }
        
        if(other.gameObject.CompareTag("item")||other.gameObject.CompareTag("itemSpecial")){
            string str = other.gameObject.name; 

            string[] words = str.Split(' ');
            string[] item = words[0].Split('(');
            for(int i = itemList.Count - 1; i >= 0; i--){
                if(string.Equals(item[0],itemList[i].Name)){
                    newItem = new Item(itemList[i]);
                    newItem.obj = other.gameObject;
                    Inventory.Add(newItem);
                    if(other.gameObject.CompareTag("itemSpecial"))
                    {
                        Inventory[Inventory.Count - 1].Price = "10000";
                        Inventory[Inventory.Count - 1].Special = true;
                    }
                    break;
                }
            }
            printItem();
        }

        if(other.gameObject.CompareTag("goal")){
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        string str = other.gameObject.name;
        string[] words = str.Split(' ');
        string[] item = words[0].Split('(');
        for(int i = Inventory.Count - 1; i >= 0; i--)
        { 
	        if(Inventory[i].Name == item[0]){
                if(other.gameObject.tag == "itemSpecial"){
                    if(Inventory[i].Special){
                        Inventory.Remove(Inventory[i]);
                        break;
                    }
                }
                else{
                    Inventory.Remove(Inventory[i]);
                    break;
                }
            }
        }
        printItem();
    }

}