using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]  Handedness handType;
   
    [SerializeField, Range(0.0f, 90.0f)] float flatHandThreshold = 45.0f;

    [SerializeField, Range(0.0f, 90f)] float facingThreshold = 80.0f;
    [SerializeField]  UnityEvent DetectedEvent;
    [SerializeField]  UnityEvent LostEvent;

    [SerializeField] TextMeshPro debugtext;


    // Update is called once per frame
    void Update()
    {
        if (CheckHandSgin())
        {
            //Event
           DetectedEvent.Invoke();
        }
        else
        {
            //LostEvent
            LostEvent.Invoke();
        }
    }
    private bool CheckHandSgin()
    {
        //detectHand
        var jointedHand = HandJointUtils.FindHand(handType);
        
        if (jointedHand.TryGetJoint(TrackedHandJoint.Palm, out MixedRealityPose palmPose))
        {
            MixedRealityPose thumbTipPose, indexTipPose, middleTipPose, ringTipPose, pinkyTipPose;
            if (jointedHand.TryGetJoint(TrackedHandJoint.IndexTip, out indexTipPose) && jointedHand.TryGetJoint(TrackedHandJoint.PinkyTip, out pinkyTipPose))
            {
                var handNormal = Vector3.Cross(indexTipPose.Position - palmPose.Position, pinkyTipPose.Position - indexTipPose.Position).normalized;
                handNormal *= (jointedHand.ControllerHandedness == handType) ? 1.0f : -1.0f;
                if (Vector3.Angle(palmPose.Up, handNormal) > flatHandThreshold)
                {
                    return false;
                }
            }
            // 中指と薬指の情報を取得
            if (jointedHand.TryGetJoint(TrackedHandJoint.MiddleTip, out middleTipPose) && jointedHand.TryGetJoint(TrackedHandJoint.RingTip, out ringTipPose))
            {
                var handNormal = Vector3.Cross(middleTipPose.Position - palmPose.Position, ringTipPose.Position - indexTipPose.Position).normalized;
                handNormal *= (jointedHand.ControllerHandedness == Handedness.Right) ? 1.0f : -1.0f;
                if (Vector3.Angle(palmPose.Up, handNormal) < flatHandThreshold)
                {
                    return false;
                }
            }
        }
        // 手のひらを向けているか確認
        return Vector3.Angle(palmPose.Up, CameraCache.Main.transform.forward) < facingThreshold;
    }

    /// <summary>
    /// 人差し指の検知。　Bool型
    /// </summary>
    /// <returns></returns>
    private bool? CheckThumb()
    {
        var jointedHand = HandJointUtils.FindHand(handType);
        if (jointedHand.TryGetJoint(TrackedHandJoint.Palm, out MixedRealityPose palmPose))
        {
            MixedRealityPose thumbTipPose, indexTipPose, middleTipPose, ringTipPose, pinkyTipPose;
            //親指が検知できているか？
            if (jointedHand.TryGetJoint(TrackedHandJoint.ThumbTip,out thumbTipPose))
            {
                var HandNormal = (thumbTipPose.Position - palmPose.Position).normalized;
                debugtext.text = HandNormal.ToString();
            }
        }
        Debug.Log("hoge");
        return false;
    }
}

