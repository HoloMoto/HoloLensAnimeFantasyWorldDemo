using System.Collections;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using TMPro;

public class StageSettings : MonoBehaviour
{
    [SerializeField] 
     float Floor ;


     
     [SerializeField] 
     GameObject floorGeter;

     [SerializeField, Tooltip("After measuring the floor, we will still use SpatialMesh.")] 
     bool usePersistentSpatialMesh = false;     
     [SerializeField] 
     GameObject stagetextRoot;
     [SerializeField] 
     TextMeshPro Stagetext;
     [SerializeField] 
     GameObject FloorAnchor;

     [SerializeField]
     GameObject StageObject;

     [SerializeField] 
     MarioPlayerSettings marioSettings;

     [SerializeField, Tooltip("Status Check Text(Debug)")]
     TextMeshPro DebugText;
     // Start is called before the first frame update
    void Start()
    {
        
        InitializeFloorSetting(7);
    }

    
    public void InitializeFloorSetting(float sec)
    {
        floorGeter.SetActive(false);
        StageObject.SetActive(false);
        StartCoroutine("FloorSetting",sec);
    }

    IEnumerator FloorSetting(float sec)
    {
        TapToPlace ttp = floorGeter.transform.Find("Cube").gameObject.GetComponent<TapToPlace>();
       yield return new WaitForSeconds(sec);
        floorGeter.SetActive(true);
        yield return new WaitForSeconds(2);
        ttp.enabled = false;
    }
    public void setFloor()
    {
           
        Floor = FloorAnchor.transform.position.y;
        floorGeter.SetActive(false);
        
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0,Floor,0);
        plane.transform.localScale = new Vector3(10f,1f,100f);
        plane.GetComponent<Renderer>().enabled = false;
    }

    public void stageSet()
    {
        StageObject.transform.position = new Vector3(0, Floor, 0);
        StageObject.SetActive(true);
        marioSettings.PlayerGameSettings(Floor);
        if (!usePersistentSpatialMesh)
        {
            var access = CoreServices.SpatialAwarenessSystem as IMixedRealityDataProviderAccess;
            var observer = access.GetDataProvider<IMixedRealitySpatialAwarenessMeshObserver>(); 
            // Change the VisivleMaterial to new material.
            observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
           
           
            //dalete SpatialMeshCollider
            //GameObject.Find("SpatialAwareness").SetActive(false);
            Destroy(GameObject.Find("Spatial Awareness System"));
            observer.Suspend();
        }
        
    }  
    
}