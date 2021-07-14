using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MarioPlayerSettings : MonoBehaviour
{
    /// <summary>
    /// Players LifePoint
    /// </summary>
    public int Life;
    /// <summary>
    /// HeadCollider
    /// </summary>
    [Header("Colliders")]
    SphereCollider col;
    /// <summary>
    /// Body Collider
    /// </summary>
    private BoxCollider boxcol;

    [Header("PlayerStatus")]
    public bool Star;
    public bool Fire;
    public bool PowerUp;
    public bool Giant;
    public bool ice;

    [Header("PlayerStatusObject")]
    [SerializeField] 
    GameObject StarSystem;
    [SerializeField]
    GameObject FireSystem;

    [SerializeField,Header("ScoreSystem")]
    int Score;

    [SerializeField] private TextMeshPro ScoreText;

    [SerializeField] AudioClip BGM;
    public bool UseBGM;
    
    public void PlayerGameSettings(float floor)
    {
        if (UseBGM)
        {
            AudioSource audio= this.gameObject.AddComponent<AudioSource>();
            audio.clip = BGM;
            
        }
        Score = 0;
        col = this.gameObject.AddComponent<SphereCollider>();
        col.center = new Vector3(0, 0, 0);
        col.radius = 0.2f; 
        
        boxcol = this.gameObject.AddComponent<BoxCollider>();
        boxcol.center = new Vector3(0, floor+0.2f,0);
        boxcol.size = new Vector3(0.1f, 0.01f, 0.1f);

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

        if (other.name == "")
        {
            
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

    public void OnPlayerStatusChange()
    {
        if (Fire&& FireSystem !=null)
        {
            FireSystem.SetActive(true);
            scoreSystem(200);
            StartCoroutine(StatusEnd(-1));
        }
        if (Star)
        {
            StartCoroutine(StatusEnd(20));
        }
      
    }

    public void Damage()
    {
        if (Life > 1)
        {
            Life--;
        }

        if (Life == 1)
        {
          GameOver();    
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }
    public void OnJump()
    {

    }

    public void scoreSystem(int i)
    {
       Score += i;
       ScoreText.text = Score.ToString();
    }
    //SetAndChangeCharactorStatus.

    IEnumerator  StatusEnd(float t)
    {
        if (t > 0)
        {
            yield return new WaitForSeconds(t);
            Star = false;
        }
        
    }
}
