using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovementController : MonoBehaviour
{
   private bool isFloating = true;
   private float boxFloatingSpeed = 3f;
   private int id = 0;
   public Renderer baseNode;

    private int colorX;
    private int colorY;
    private int colorZ;

    private int colorCode;
    void Start(){
        boxFloatingSpeed = Random.Range(2,7); // -> Decide the speed of the box at spawn point
        StartCoroutine(timeRemainToDestroy(60)); // -> Destry this after 60sec
        int code = Random.Range(0,6);
        colorCode = code;
        setBoxColor(code);
    }
    void Update(){
             if(isFloating)transform.position = Vector3.MoveTowards(transform.position,new Vector3(0,transform.position.y,0),Time.deltaTime * boxFloatingSpeed);

            if(transform.position.x == 0 && isFloating){
                StartCoroutine(blink());
                isFloating = false;
            }  
    
     }
      void OnTriggerEnter(Collider other)
    {
        // Debug.Log("boxMovementController - trigger activate");
        /* This trigger is use to stop the base at current postion  */
        if(other.gameObject.tag == "player"){
            isFloating = false;
        // Debug.Log("boxMovementController - inside trigger player");

        }
    }
    
    IEnumerator timeRemainToDestroy(int seconds){
        /* This function is use to destroy the base object in <seconds> intervel of time */
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
    public void setId(int _id){
       /* This is used to set unique */
        id = _id;
    }
    public int getId(){
        /* To get the id of the perticular object */
        return id;
    }
    private void setBoxColor(int code){
        /* This function is use to color the box node at spawn point */
        string switch_on = code.ToString();
        // Color baseColor = baseNode.GetComponent.color;
        
        switch (switch_on)
        {   
            case "0":
                baseNode.material.SetColor("_Color",Color.red);
            break;
             case "1":
                baseNode.material.SetColor("_Color",Color.gray);
            break;
             case "2":
                baseNode.material.SetColor("_Color",Color.green);
            break;
             case "3":
                baseNode.material.SetColor("_Color",Color.blue);
            break;
             case "4":
                baseNode.material.SetColor("_Color",Color.black);
            break;
             case "5":
                baseNode.material.SetColor("_Color",Color.cyan);
            break;
             case "6":
                baseNode.material.SetColor("_Color",Color.yellow);
            break;
            default:
                baseNode.material.SetColor("_Color",Color.white);
            break;
        }
    }
   IEnumerator blink()
    {
        setBoxColor(-1);
        yield return new WaitForSeconds(0.05f);
        setBoxColor(colorCode);
    }
   
  
}
