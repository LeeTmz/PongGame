using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
   [SerializeField] private int timeToDestroy;


    public void OnDestroy()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
