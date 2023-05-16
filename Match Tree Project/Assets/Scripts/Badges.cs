using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Badges : MonoBehaviour
{
    public Achievements ach;

    public GameObject badge;

    public Image image;

    // Start is called before the first frame update
    void Start()
    { 
        int[] a = ach.GetAchieved();
        Debug.Log(a[0]);

        for(int i = 0; i < 10; i++) 
        {
            if (a[i] == 1) 
            {
                if (int.Parse(badge.tag) == i)
                {
                    //DontDestroyOnLoad(gameObject);
                    //image = badge.GetComponent<Image>();
                    //var tempColor = image.color;
                    //tempColor.a = 1f;
                    //image.color = tempColor;
                    //badge = image;

                    //badge.color = 
                }
            }
        }
    }
}
