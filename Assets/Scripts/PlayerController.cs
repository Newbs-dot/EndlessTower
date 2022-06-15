using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 rotationPoint = new Vector3(0,0,0);
    public float playerSpeed = 0.5f;
    public float jumpHeight = 1.0f;
    Rigidbody rb;
    bool isGrounded = true;
    bool isStarting = true;
    bool isSuperJump = false;
    Animator animator;
    bool goingRight = true;
    public GameObject playerModel;
    public ParticleSystem particle;
    public float TurnSpeed = 250f;
    
    
    void Start(){
       rb = gameObject.GetComponent<Rigidbody>();
       
       animator = playerModel.GetComponent<Animator>();
    }
    void Update()
    {
        
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }
            else if(Input.GetKeyDown(KeyCode.W)){
                SuperJump();
                isSuperJump = true;
            }
           
        }
        
        if(!isSuperJump){
            float horizontalMovement = playerSpeed * -Input.GetAxis("Horizontal");
            if(horizontalMovement!= 0 )
            {
                animator.SetBool("IsMoving",true);
            }
            else{
                animator.SetBool("IsMoving",false);
            }
            
            
            if(Input.GetAxis("Horizontal") > 0){
                playerModel.transform.localRotation = Quaternion.RotateTowards(playerModel.transform.localRotation, Quaternion.Euler(0,90,0), TurnSpeed * Time.deltaTime);
            }   
            else if (Input.GetAxis("Horizontal")<0){
                playerModel.transform.localRotation = Quaternion.RotateTowards(playerModel.transform.localRotation, Quaternion.Euler(0,-90,0), TurnSpeed * Time.deltaTime);
            }
            
           
            // Костыль
            Vector3 costil = transform.position;
            costil.x = 0;
            costil.z = 0;
            transform.position = costil;

            Quaternion costilrot = transform.rotation;
            costilrot.x = 0;
            costilrot.z = 0;
            
            transform.rotation = costilrot;
            
            //конец костыля
            
            transform.Rotate(0,horizontalMovement * Time.deltaTime,0);
            
        }
        
        
    }
    void OnCollisionEnter(Collision col){
        if(col.collider.tag == "Ground"){
           isGrounded = true;
           isSuperJump = false;
           animator.SetBool("OnGround",true);
        }
        
        else if(col.collider.tag == "Destroyable" && isSuperJump){
            Destroy(col.gameObject);
            Instantiate(particle,col.transform.position,Quaternion.identity);
        }
    
    }
    void OnCollisionExit(Collision col){
        if(col.collider.tag == "Ground"){
            isGrounded = false;
        }
    }
    void Jump(){
        rb.AddForce(new Vector3(0,200,0) * jumpHeight,ForceMode.Acceleration);
        animator.SetBool("OnGround",false);
    }
    void SuperJump(){
        rb.AddForce(new Vector3(0,300,0) * jumpHeight,ForceMode.Acceleration);
        animator.SetBool("OnGround",false);
    }
   
      
    

}

