using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    [SerializeField] 
    MarioPlayerSettings player;

    [SerializeField] 
    AudioSource audio;

    [SerializeField] 
    ItemType itemtype;
    public  enum ItemType
    {
        coin,
        Mush
    }
    
    [SerializeField] 
    AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
       player = Camera.main.gameObject.GetComponent<MarioPlayerSettings>();
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

    public void GetCoin()
    { 
        audio.PlayOneShot(audioClip);
        StartCoroutine("GetCoins");
        player.scoreSystem(100);
    }
    
    IEnumerator GetCoins()
    {
        Collider col = this.GetComponent<Collider>();
        col.enabled = false;
        Renderer rend = this.gameObject.GetComponent<Renderer>();
        rend.enabled = false;
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);  
    }
    
    //FireFlower/Star/PowerUpMush etc...
    public void PlayerPowerUpItem()
    {
        player.Fire = true;
        player.OnPlayerStatusChange();
        audio.PlayOneShot(audioClip);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (itemtype)
        {
            case ItemType.coin:
                GetCoin();
                break;
        }
    }
}
