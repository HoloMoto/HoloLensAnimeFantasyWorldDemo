using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour
{
 public class Practice
 {
  public delegate void Dele();

  public void Method(Dele deleMethod)
  {
   
    deleMethod();
  }
 }
}
