using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objectSpecial : MonoBehaviour
{
    Material objSpecial;

    Renderer renderers;
    List<Material> materialList = new List<Material>();
    // Start is called before the first frame update
    void Start()
    {

        objSpecial = new Material(Shader.Find("Unlit/objSpecial"));
        GameObject [] objList = GameObject.FindGameObjectsWithTag("item");
        print(objList.Length);
        int size = 40;
        int [] numList = new int[size];

        for (int i = 0; i<size; i++){
            numList[i] = Random.Range(0, objList.Length);
            if(i>0){
                for(int j = 0; j<i; j++){
                    while(numList[j] == numList[i]){
                        numList[i] =Random.Range(0, objList.Length);
                    }
                }
            }

        }

        for (int i = 0; i<size; i++){
            print(objList[numList[i]].name);
            objList[numList[i]].tag = "itemSpecial";

            renderers = objList[numList[i]].GetComponent<Renderer>();
            materialList.Clear();
            materialList.AddRange(renderers.sharedMaterials);
            materialList.Add(objSpecial);

            renderers.materials = materialList.ToArray();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}