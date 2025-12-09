using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public Transform[] goals;
    int currentIndex = -1;


    // Start is called before the first frame update
    public Transform NextGoal()
    {
        currentIndex = (currentIndex + 1) % goals.Length;
        return goals[currentIndex];

    }
}
