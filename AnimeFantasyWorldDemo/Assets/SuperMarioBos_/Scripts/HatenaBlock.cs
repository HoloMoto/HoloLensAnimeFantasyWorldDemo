using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HatenaBlock : MonoBehaviour
{
    [SerializeField]
    AudioSource audio;

    [SerializeField]
    UnityEvent BlockActiveEvents;


    [SerializeField]
    int BlockLife;

    [SerializeField]
    UnityEvent EndBlockEvents;
    [SerializeField,Tooltip("")]
    UnityEvent DeactiveBlockEvents;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnActiveHatenaBlockEvent()
    {
        if (BlockLife>0)
        {
            BlockActiveEvents.Invoke();

            BlockLife -= 1;
            if (BlockLife == 0)
            {
                EndBlockLifeEvent();
            }
        }
        else
        {
            DeactiveBlockEvents.Invoke();
        }
    }

    private void EndBlockLifeEvent()
    {
        EndBlockEvents.Invoke();    
    }
}
