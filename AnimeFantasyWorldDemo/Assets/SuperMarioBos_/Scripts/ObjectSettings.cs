using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


/// <summary>
/// This Class managed StageObject
/// </summary>
public class ObjectSettings : MonoBehaviour
{
    [SerializeField] private MarioPlayerSettings player;
    [SerializeField]
    ObjectType objectType;

    [SerializeField]  Animator animation;
    
    enum ObjectType
    {
        Hole,
        Pipes,
        Cloud,
        Goal
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (objectType)
        {
            case ObjectType.Hole:
                           
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (objectType == ObjectType.Hole)
        {
            Collider otherCol = other.collider;
            otherCol.enabled = false;
        }
    }
/*
    private void OnCollisionEnter(Collision other)
    {
        if (objectType == ObjectType.Hole)
        {
            Collider otherCol = other.collider;
            otherCol.enabled=false;
                
        }
    }
*/
    IEnumerator ColliderRestart(float t,Collider col)
    {
        yield return new WaitForSeconds(t);
        col.enabled = true;
    }

    public void Goal()
    {
        
        animation.enabled = true;
        //Goal
        player.scoreSystem(2000);
        
        //debug 使用時はifを外す
        if (this == null)
        {
            StartCoroutine("GameEnd");
        }
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(10);
        //applicationQuite.
        Application.Quit();
        
    }
}
