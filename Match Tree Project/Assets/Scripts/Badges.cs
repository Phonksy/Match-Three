using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//kapsuleeinaperkoridoriusurandomkliutim

public class Badges : MonoBehaviour
{
    public Achievements ach;

    public GameObject badge;

    public TextMeshProUGUI text;

    public TextMeshProUGUI question;

    public int level;
    
    //capsuleController
    //public Transform goal;
    //void Start()
    //{
    //    NavMeshAgent agent = GetComponent<NavMeshAgent>();
    //    agent.destination = goal.position;
    //}

    void Start()
    {
        int[] a = ach.GetAchieved();

        if (a[level] == 1)
        {
            badge.SetActive(true);
            question.enabled = false;
        }
        else if (a[level] == 0) 
        {
            badge.SetActive(false);
            question.enabled = true;
        }
        
        //startmetodekreipiamasiisita
        //private void CreateObstacles()
        //{
        //    for (var i = 0; i < count; i++)
        //    {
        //        foreach(var obstacle in obstacles)
        //        {  
        //            Instantiate(obstacle, GetRandomPosition(), 
        //                obstacle.transform.rotation, gameObject.transform);
        //        }
        //    }
        //}

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(
                Random.Range(0, size.x),
                Random.Range(0, size.y),
                Random.Range(0, size.z)
            );
        return transform.position + volumePosition - size / 2;
    }

        if (badge.activeSelf) 
        {
            text.enabled = false;
        }
        else if(!badge.activeSelf) 
        {
            text.enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (badge.activeSelf) 
        {
            text.enabled = true;
        }
        
        //darvienasmetodas
        //private void OnDrawGizmos()
        //{
        //    Gizmos.DrawWireCube(transform.position, size);
        //}
    }

    private void OnMouseExit()
    {
        text.enabled = false;
    }
}
