using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建CinemachineRecomposer")]
    public class Control_CinemachineRecomposer_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(CinemachineRecomposer);

       [UnityEngine.TooltipAttribute("When to apply the adjustment")]
            public ConfigItem <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("Tilt the camera by this much")]
            public ConfigItem <System.Single> m_Tilt;
       [UnityEngine.TooltipAttribute("Pan the camera by this much")]
            public ConfigItem <System.Single> m_Pan;
       [UnityEngine.TooltipAttribute("Roll the camera by this much")]
            public ConfigItem <System.Single> m_Dutch;
       [UnityEngine.TooltipAttribute("Scale the zoom by this amount (normal = 1)")]
            public ConfigItem <System.Single> m_ZoomScale;
       [UnityEngine.TooltipAttribute("Lowering this value relaxes the camera's attention to the Follow target (normal = 1)")]
            public ConfigItem <System.Single> m_FollowAttachment;
       [UnityEngine.TooltipAttribute("Lowering this value relaxes the camera's attention to the LookAt target (normal = 1)")]
            public ConfigItem <System.Single> m_LookAtAttachment;
    }
}
