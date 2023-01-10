using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameController : MonoBehaviour
{
    private AudioSource jumpAudio;
    public TMP_Text gameScore;
    public float killForceAmt = 30;
    public float jumpForce;
    // private Animator anim;
    private Rigidbody rb;
    private boxController boxControllerClass;
    public GameObject youLostCanvas;
    
    private int currentScore = 0;

    private bool isJumping = false;
    private bool IsGameRunning = true;
    void Start(){
        jumpAudio = GetComponent<AudioSource>();
        youLostCanvas.SetActive(false);
        rb = GetComponent<Rigidbody>();
        // anim = GetComponent<Animator>();
        boxControllerClass = GetComponent<boxController>();
        Application.targetFrameRate = 60;
    }
    void Update(){
        if(IsGameRunning){
        if(Input.GetKeyUp(KeyCode.Space) & !isJumping ){
            // anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isJumping = true;
        }
        }
    }
    public void jumpBtn(){
         if(!isJumping && IsGameRunning){
            // anim.SetTrigger("jump");
            jumpAudio.Play();
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
            currentScore = boxControllerClass.getCount();
            gameScore.SetText(currentScore.ToString());
        //    if (GUI.Button(new Rect(0, 10, 100, 32), "Vibrate!"))
        }
    }
    void youDeadForce(bool isLeftForce){
        boxControllerClass.youLost();
            Handheld.Vibrate();

        // if(isLeftForce) rb.AddForce(Vector3.left * killForceAmt,ForceMode.Impulse);
        // else rb.AddForce(Vector3.right * killForceAmt,ForceMode.Impulse);
        IsGameRunning = false;
        youLostCanvas.SetActive(true);

    }
    public void ReplayGame(){
        SceneManager.LoadScene("Level 1");
    }
}
