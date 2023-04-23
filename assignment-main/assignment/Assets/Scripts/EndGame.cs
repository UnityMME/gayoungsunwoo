using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public List<Item> Inventory;
    public GameObject[] objList;
    public Vector3 StartPos;
    public GameObject Restart, Menu;
    public AudioSource audioSource;

    public Text ScriptTxtName;
    public Text ScriptTxtPrice;
    public Text ScriptTotal;
    public Text ScriptTotalName;

    int i, c;

    // Start is called before the first frame update
    
    void Start()
    {
        Restart.SetActive(false);
        Menu.SetActive(false);
        objList = GameObject.FindGameObjectsWithTag("item");
        
        i=0;
        print(">>>>>"+objList.Length);
        /*i= 0;
        for(int j = 0 ; j<Inventory.Count; j++){
            print("j "+ j +Inventory[j].obj.name);
        }
        c = Inventory.Count;
        print(Inventory.Count);
        InvokeRepeating("Drop", 1f, 2f);
        */
    }

    // Update is called once per frame
    float currTime;
    int total = 0;
    void Update(){
        // 시간이 흐르게 만들어준다.
        currTime += Time.deltaTime;
        // 오브젝트를 몇초마다 생성할 것인지 조건문으로 만든다. 여기서는 10초로 했다.
        if (currTime > 2)
        {
            if(i < objList.Length)
            {
                print(objList.Length+":"+i+":"+objList[i].name);
                objList[i].transform.position = StartPos;

                int p = int.Parse(objList[i].GetComponent<Object>().Price);
                total += p;
                audioSource.playOnAwake = true;
                ScriptTxtName.text += objList[i].GetComponent<Object>().KName + "\n";
                ScriptTxtPrice.text += objList[i].GetComponent<Object>().Price + "\n";

                i++;

            }
            else{
                ScriptTotalName.text = "합계 :";
                ScriptTotal.text = total.ToString();
                Restart.SetActive(true);
                Menu.SetActive(true);
            }
            currTime = 0;
        }    
    }
    
}


