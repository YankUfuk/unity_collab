using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public float speed;
    public int i;
    public int j;

    // Update is called once per frame
    void FixedUpdate()
    {
       while (true){

        for( i=0; i<3;i++){
        transform.position += Vector3.left * speed * Time.deltaTime;

        }
        i=0;
         for(j=0; j<3;j++){
        transform.position += Vector3.right * speed * Time.deltaTime;

        }
        j=0;

       }
       }
       
    }

