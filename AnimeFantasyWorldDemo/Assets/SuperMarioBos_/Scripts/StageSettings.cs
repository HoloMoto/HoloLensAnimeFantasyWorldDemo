using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;

public class StageSettings : MonoBehaviour
{
    [SerializeField] 
     float Floor ;

     [SerializeField] 
     GameObject floorGeter;

     [SerializeField] 
     GameObject stagetextRoot;
     [SerializeField] 
     TextMeshPro Stagetext;
     [SerializeField] 
     GameObject FloorAnchor;
    // Start is called before the first frame update
    void Start()
    {
        InitializeFloorSetting();
       
    }


    void InitializeFloorSetting()
    {
        floorGeter.SetActive(false);
        StartCoroutine("FloorSetting");
    }

    IEnumerator FloorSetting()
    {
        yield return new WaitForSeconds(7);
        floorGeter.SetActive(true);
    }
    public void setFloor()
    {
           
        Floor = FloorAnchor.transform.position.y;
        floorGeter.SetActive(false);
        
#if UNITY_EDITOR
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0,Floor,0);
#endif

    }
    
}