using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public float killForceAmt = 30;
    public float jumpForce;
    private Animator anim;
    private Rigidbody rb;
    private boxController boxControllerClass;

    private bool isJumping = false;
    private bool IsGameRunning = true;
    void Start(){
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        boxControllerClass = GetComponent<boxController>();
    }
    void Update(){
        if(IsGameRunning){
        if(Input.GetKeyUp(KeyCode.Space) & !isJumping ){
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isJumping = true;
        }
        }
    }
    public void jumpBtn(){
         if(!isJumping && IsGameRunning){
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isJumping = true;
        }
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "rightCollider"){
            youDeadForce(false);
            Debug.Log("Right Collider");

        }
         if(other.gameObject.tag == "leftCollider"){
            youDeadForce(true);
            Debug.Log("Left Collider");
            
        }
         if(other.gameObject.tag == "baseCollider"){
            if(IsGameRunning)boxControllerClass.addObject();
            Debug.Log("safe Collider");
            isJumping = false;
        }
    }
    void youDeadForce(bool isLeftForce){
        boxControllerClass.youLost();
        if(isLeftForce) rb.AddForce(Vector3.left * killForceAmt,ForceMode.Impulse);
        else rb.AddForce(Vector3.right * killForceAmt,ForceMode.Impulse);
        IsGameRunning = false;
    }
}
