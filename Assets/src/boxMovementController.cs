using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovementController : MonoBehaviour
{
   private bool isFloating = true;
   private float boxFloatingSpeed = 3f;
   private int id = 0;


    void Start(){
        boxFloatingSpeed = Random.Range(2,7);
        StartCoroutine(timeRemainToDestroy(60));
    }
    void Update(){
             if(isFloating)transform.position = Vector3.MoveTowards(transform.position,new Vector3(0,transform.position.y,0),Time.deltaTime * boxFloatingSpeed);
     }
      void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player"){
            isFloating = false;
        }
    }
    
    IEnumerator timeRemainToDestroy(int seconds){

        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
    public void setId(int _id){
       /*
        * -> This is used to set unique 
        */
        id = _id;
    }
}
