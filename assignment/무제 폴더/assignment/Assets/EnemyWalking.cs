using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

using Debug = UnityEngine.Debug;


public class EnemyWalking : MonoBehaviour
{
    Vector3 position;
    int recent;
    int mode; //enum
    Vector3 Target;
    Animator animator;
    bool bump;
    //Vector3 TargetUp = new Vector3(12.96f, 0.0359f, 90);
    //Vector3 TargetDown = new Vector3(12.96f, 0.0359f, 70);
    Vector3 velo = Vector3.zero;
    /*ai
    public Transform target;
    Rigidbody rigid;
    BoxCollider boxCollider;
    Animator anim;
    NavMeshAgent nav;
    */
    [SerializeField] GameObject Player;
    [SerializeField] Collider[] cols;
    [SerializeField] LayerMask layer;
    [SerializeField] float radius;


    void Awake()
    {
        animator = GetComponent<Animator>();
        /*ai
        rigid = GetComponent<Rigidbody>();
       boxCollider = GetComponent<BoxCollider>();
       // mat = GetComponentInChildren<Material>();
      nav= GetComponent<NavMeshAgent>();
       // anim = GetComponent<Animator>();
        */

        bump = false;

    }


    void Start()
    {
        Debug.Log("start");
        position = transform.position;
        mode=1;
        transform.forward = new Vector3(0, 0, -1);


        //Target = new Vector3(12.96f, 0.0359f, 70);
        //position =transform.position;
        //StartCoroutine(MoveObject());
    }

    // Update is called once per frame
    void Update()
    {
        if (mode==1)
        {
            transform.forward = new Vector3(0, 0, -1);
            position.z -= 0.4f * Time.deltaTime;
            transform.position = position;
        }
        if (mode==2)
        {
            transform.forward = new Vector3(0, 0, 1);
            position.z += 0.4f * Time.deltaTime;
            transform.position = position;

        }
        if (mode == 0)
        {
            //position.z += 0.4f * Time.deltaTime;
            transform.position = position;

        }

        //transform.position = Vector3.SmoothDamp(transform.position, Target, ref velo, 0.0000000000001f);

        //nav.SetDestination(target.position);
        /*
        if (down)
        {
            position.z -= 1 * Time.deltaTime;
        }
        if (!down)
        
            position.z += 1 * Time.deltaTime;
        }
        //float dir1 = Random.Range(-1f, 1f);
        //float dir2= Random.Range(-1f, 1f);
        destination = position;
        transform.position = destination;
        
        transform.position = Vector3.MoveTowards(transform.position, destination, 1*Time.deltaTime);

          */
        if (bump)
        {
            InvokeRepeating("cartAround", 0,0.2f);
        }

    }
    private void cartAround()//check when cart finish bumping
    {
        cols = Physics.OverlapSphere(transform.position, radius,layer); //player.transform.position?
        //if (cols.Exists(Player)) { bump = true; }
        if (cols == null) { 
            bump = false;
            animator.SetBool("isWalking", true);
            mode = recent; 
            Debug.Log("bump Á¾·á");
        }
    }

    /*
    IEnumerator MoveObject()
    {
        
        Debug.Log("coroutine");
        position.x+= 1 * Time.deltaTime;
        //float dir1 = Random.Range(-1f, 1f);
        //float dir2= Random.Range(-1f, 1f);
        transform.position = position;
        yield return new WaitForSeconds(2);
        

    }
    */

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().gameObject.CompareTag("Wall1"))
        {
            Debug.Log("walkingEnemy and wall1 bump");
            mode = 2;
            //transform.Rotate(Vector3.right * 1* Time.deltaTime);
            //Target = new Vector3(12.96f, 0.0359f, 90);
            //RotateGameObject(new Vector3(0f, (Mathf.Cos(timer) * 0.5f * 0.5f) * 180f, 0f));
            


        }
        if (other.GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            animator.SetBool("isWalking", false);
            Debug.Log("BUMP cart enemy");
            bump = true;
            recent = mode;
            mode = 0;
            //Target = new Vector3(12.96f, 0.0359f, 90);


        }
        /*
        if (other.collider.gameObject.CompareTag("Wall2"))
        //if (other.collider.tag == "Wall1")
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            down = false;

        }
       // Time.timeScale = 1;
        
        */

    }
    
    /*
    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            Debug.Log("BUMP STOPPED");
            mode = recent;
            animator.SetBool("isWalking", true);
            
            //Target = new Vector3(12.96f, 0.0359f, 90);


        }

    }
    */
   
}
     
