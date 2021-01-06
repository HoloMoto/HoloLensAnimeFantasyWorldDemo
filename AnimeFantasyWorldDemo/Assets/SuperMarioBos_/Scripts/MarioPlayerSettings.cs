using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerSettings : MonoBehaviour
{
    private SphereCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = this.gameObject.AddComponent<SphereCollider>();
        col.center = new Vector3(0, 0, 0);
        col.radius = 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "HatenaBox")
        {
            col.enabled = false;
            GameObject hatenaBox = other.gameObject.transform.parent.gameObject;
            hatenaBox.GetComponent<HatenaBlock>().OnActiveHatenaBlockEvent();
            StartCoroutine("RestCol");
        }
    }

    IEnumerator RestCol()
    {
        yield return new WaitForSeconds(2f);
        col.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
