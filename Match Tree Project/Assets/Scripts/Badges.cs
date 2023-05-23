using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Badges : MonoBehaviour
{
    public Achievements ach;

    public GameObject badge;

    public TextMeshProUGUI text;

    public TextMeshProUGUI question;

    public int level;

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
    }

    private void OnMouseExit()
    {
        text.enabled = false;
    }
}
