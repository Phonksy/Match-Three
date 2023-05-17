using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverLogic : MonoBehaviour
{
    public GameObject badge;

    public TextMeshProUGUI text;

    void Start()
    {
        Debug.Log(badge.activeSelf.ToString());

        if (badge.activeSelf == false)
        {
            text.enabled = true;
        }
        else if (badge.activeSelf == true)
        {
            text.enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if (badge.activeSelf == true)
        {
            text.enabled = true;
        }
    }
}
