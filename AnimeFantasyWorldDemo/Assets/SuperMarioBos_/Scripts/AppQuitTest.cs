using System;
using UnityEngine;
using TMPro;

public class AppQuitTest : MonoBehaviour
{

    [SerializeField] private TextMeshPro showBatteryLevel;
   // [SerializeField] private TextMeshPro showBatteryStatus;
   public void type1()
   {
       showBatteryLevel.text = SystemInfo.operatingSystem;
   }
   public void type2()
   {
       showBatteryLevel.text = SystemInfo.operatingSystemFamily.ToString();
   }   
   public void type3()
   {
       showBatteryLevel.text = SystemInfo.processorCount.ToString();
   }   
   public void type4()
   {
       showBatteryLevel.text = SystemInfo.processorType;
   }   
   public void type5()
   {
       showBatteryLevel.text = SystemInfo.renderingThreadingMode.ToString();
   }   
   public void type6()
   {
       showBatteryLevel.text = SystemInfo.supportedRenderTargetCount.ToString();
   }   
   public void type7()
   {
       showBatteryLevel.text = SystemInfo.supportsAsyncCompute.ToString();
   }   
   public void type8()
   {
       showBatteryLevel.text = SystemInfo.supportsAudio.ToString();
   }   
   public void type9()
   {
       showBatteryLevel.text = SystemInfo.supportsComputeShaders.ToString();
   }   
   public void type10()
   {
       showBatteryLevel.text = SystemInfo.supportsGeometryShaders.ToString();
   }   
   public void type11()
   {
       showBatteryLevel.text = SystemInfo.supportsComputeShaders.ToString();
   }   
}
