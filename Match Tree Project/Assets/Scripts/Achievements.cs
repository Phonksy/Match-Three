using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//randomkubaieilutejirpasokaprisilietus

public class Achievements : MonoBehaviour 
{
    public static int[] achieved = new int[10];
    
    //[Min(0f)]
    //[SerializeField]
    //private float moveSpeed = 2.5f;
    //private Rigidbody rb;
    
    public int[] GetAchieved() 
    {
        return achieved;
        //update
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
        
    }

    public void SetAchieved(int i, int value) 
    {
        achieved[i] = value;
        //private void OnCollisionEnter(Collision other)
        //{
            //if(other.gameObject.CompareTag("Cube"))
            //{
                //var force = other.gameObject.transform.localScale;
                //rb.AddForce(10 * force.y * Vector3.up, ForceMode.Impulse);
        //}
        //}
    }
}


