using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ĳ���� �ȴ� ������ �ٲߴϴ�");
        }
        transform.position = new Vector3(13, 0, 91);
    }
}
