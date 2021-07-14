using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySystem : MonoBehaviour
{
    [SerializeField] private MarioPlayerSettings platerSyesem;
    
    [SerializeField] 
    EnemyName name;

    [SerializeField] 
    int GetScore;
    
    
    public enum EnemyName
    {
        Kuribo,
        Kuppa,
        PiranhaPlant,
        KuppaTurtle,
        PataPata
    }
    public int Life;

    [SerializeField] 
    AudioClip audio;
    
    [SerializeField] 
    UnityEvent DeadEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        switch (name)
        {
            case EnemyName.Kuribo :
                Life = 1;
                GetScore = 100;
                break;
            case EnemyName.KuppaTurtle :
                GetScore = 150;
                Life = 1;
                break;
            case EnemyName.PataPata:
                GetScore =150;
                Life = 2;
                break;
            case EnemyName.Kuppa :
                Life = 10;
                GetScore = 1000;
                break;
            case EnemyName.PiranhaPlant :
                Life = 1;
                break;
        }
    }



    public void DamegeEvent()
    {
        Life--;
        platerSyesem.scoreSystem(GetScore);
        if (Life == 0)
        {
            DeadEvent.Invoke();
            StartCoroutine("dead");
        }
    }
    
    IEnumerator dead()
    {
        switch (name)
        {
            case EnemyName.Kuribo :
               KuriboDead();  
                break;
            case EnemyName.KuppaTurtle :
                
                break;
            case EnemyName.PataPata:
                
                break;
            case EnemyName.Kuppa :
               
                break;
            case EnemyName.PiranhaPlant :
               
                break;
        }
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    private void KuriboDead()
    {
        Debug.Log("クリボーが死んだ！");
    }
}

