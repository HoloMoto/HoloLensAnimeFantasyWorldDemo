using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    [SerializeField] 
    MarioPlayerSettings player;

    [SerializeField] 
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("Main Camera").GetComponent<MarioPlayerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject cloneObject;
    public void InBlockCoin(Transform pos)
    {
        cloneObject = Instantiate(this.gameObject,pos.localPosition, Quaternion.identity);
        cloneObject.SetActive(true);
    }

    public void InBlockMush(Transform pos)
    {
        cloneObject = Instantiate(this.gameObject, pos.localPosition, Quaternion.identity);
        cloneObject.SetActive(true);
    }
}
