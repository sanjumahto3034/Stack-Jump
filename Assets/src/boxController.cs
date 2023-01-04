using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    public float offsetXAmt = 10;
    public GameObject box;
    private GameObject lastElement;
    bool isLeft = false;
    [HideInInspector]public bool IsGameRunning = true;
    void Start()
    {
        GameObject obj = Instantiate(box, new Vector3(0, 1.4f, 0), Quaternion.identity);
        lastElement = obj;
    }

    void FixedUpdate()
    {
        if(IsGameRunning){

        if (lastElement.transform.position.x != 0 && !isLeft)
        {
            if (lastElement.transform.position.x > 0)
            {
                lastElement.transform.position = lastElement.transform.position - new Vector3(5, 0, 0) * Time.deltaTime;
            }
            else if (lastElement.transform.position.x <= 0)
            {
                addObject();
            }
        }

        if (lastElement.transform.position.x != 0 && isLeft)
        {
            if (lastElement.transform.position.x < 0)
            {
                lastElement.transform.position = lastElement.transform.position + new Vector3(5, 0, 0) * Time.deltaTime;
            }
            else if (lastElement.transform.position.x >= 0)
            {
                addObject();
            }
        }
        }
    }
    public void addObject()
    {
        int spawnRange = Random.Range(0, 20);
        float offsetX = spawnRange % 2 == 0 ? offsetXAmt: offsetXAmt * -1;
        isLeft = (offsetX < 0) ? true : false;
        var transfrm = new Vector3(offsetX,lastElement.transform.position.y + 1.4f,0);


        GameObject boxObject = Instantiate(box, transfrm, Quaternion.identity);
        lastElement = boxObject;
    }
    public void youLost(){
        IsGameRunning = false;
    }
}