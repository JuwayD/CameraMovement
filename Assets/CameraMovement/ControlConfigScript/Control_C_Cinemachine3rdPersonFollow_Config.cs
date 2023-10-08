using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_Cinemachine3rdPersonFollow")]
    public class Control_C_Cinemachine3rdPersonFollow_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.Cinemachine3rdPersonFollow);

       [UnityEngine.TooltipAttribute("How responsively the camera tracks the target.  Each axis (camera-local) can have its own setting.  Value is the approximate time it takes the camera to catch up to the target's new position.  Smaller values give a more rigid effect, larger values give a squishier one")]
            public ConfigItem <UnityEngine.Vector3> Damping;
       [UnityEngine.HeaderAttribute("Rig")]
           [UnityEngine.TooltipAttribute("Position of the shoulder pivot relative to the Follow target origin.  This offset is in target-local space")]
            public ConfigItem <UnityEngine.Vector3> ShoulderOffset;
       [UnityEngine.TooltipAttribute("Vertical offset of the hand in relation to the shoulder.  Arm length will affect the follow target's screen position when the camera rotates vertically")]
            public ConfigItem <System.Single> VerticalArmLength;
       [UnityEngine.TooltipAttribute("Specifies which shoulder (left, right, or in-between) the camera is on")]
            public ConfigItem <System.Single> CameraSide;
       [UnityEngine.TooltipAttribute("How far behind the hand the camera will be placed")]
            public ConfigItem <System.Single> CameraDistance;
       [UnityEngine.TooltipAttribute("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public ConfigItem <System.String> IgnoreTag;
       [UnityEngine.TooltipAttribute("Specifies how close the camera can get to obstacles")]
            public ConfigItem <System.Single> CameraRadius;
       [UnityEngine.TooltipAttribute("How gradually the camera moves to correct for occlusions.  Higher numbers will move the camera more gradually.")]
            public ConfigItem <System.Single> DampingIntoCollision;
       [UnityEngine.TooltipAttribute("How gradually the camera returns to its normal position after having been corrected by the built-in collision resolution system.  Higher numbers will move the camera more gradually back to normal.")]
            public ConfigItem <System.Single> DampingFromCollision;
    }
}
