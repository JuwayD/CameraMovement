using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_CinemachineCameraOffset_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(CinemachineCameraOffset);

       [UnityEngine.TooltipAttribute("Offset the camera's position by this much (camera space)")]
            public ConfigItem <UnityEngine.Vector3> m_Offset;
       [UnityEngine.TooltipAttribute("When to apply the offset")]
            public ConfigItem <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("If applying offset after aim, re-adjust the aim to preserve the screen position of the LookAt target as much as possible")]
            public ConfigItem <System.Boolean> m_PreserveComposition;
    }
}
