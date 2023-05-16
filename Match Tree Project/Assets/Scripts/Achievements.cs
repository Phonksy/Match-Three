using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour 
{
    public static int[] achieved = new int[10];

    public int[] GetAchieved() 
    {
        return achieved;
    }

    public void SetAchieved(int i, int value) 
    {
        achieved[i] = value;
    }
}
