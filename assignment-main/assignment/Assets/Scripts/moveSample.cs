using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSample : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Camera fpsCam;

    float MoveSpeed;
    float rotSpeed;
    float currentRot;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 2.0f;
        rotSpeed = 3.0f;
        currentRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(GameObject.Find("Stop")!=null){
            if(GameObject.Find("Stop").GetComponent<StopGame>().state == 0){
            PlayerMove();
            RotCtrl();
            }
        }
    
    }

    void PlayerMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        float xSpeed = xInput * MoveSpeed;
        float zSpeed = zInput * MoveSpeed;
        transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);

    }

    void RotCtrl()
    {   float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        // 마우스 반전
        currentRot -= rotX;

        // 마우스가 특정 각도를 넘어가지 않게 예외처리
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);      

        if (!Input.GetMouseButton(0)){
            float rotY = Input.GetAxis("Mouse X") * rotSpeed;
            // Camera는 Player의 자식이므로 플레이어의 Y축 회전은 Camera에게도 똑같이 적용됨
            this.transform.localRotation *= Quaternion.Euler(0, rotY, 0); 
        }
        

        // Camera의 transform 컴포넌트의 로컬로테이션의 오일러각에 
        // 현재X축 로테이션을 나타내는 오일러각을 할당해준다.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}