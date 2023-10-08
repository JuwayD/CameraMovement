using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachinePOV")]
    public class Control_C_CinemachinePOV_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachinePOV);

        public ConfigItem <Cinemachine.CinemachinePOV.RecenterTargetMode> m_RecenterTarget;
       [UnityEngine.TooltipAttribute("The Vertical axis.  Value is -90..90. Controls the vertical orientation")]
        public Control_C_AxisState_Config m_VerticalAxis;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the Vertical axis is accomplished")]
        public Control_C_AS_Recentering_Config m_VerticalRecentering;
       [UnityEngine.TooltipAttribute("The Horizontal axis.  Value is -180..180.  Controls the horizontal orientation")]
        public Control_C_AxisState_Config m_HorizontalAxis;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the Horizontal axis is accomplished")]
        public Control_C_AS_Recentering_Config m_HorizontalRecentering;
       [UnityEngine.HideInInspector]
           [UnityEngine.TooltipAttribute("Obsolete - no longer used")]
            public ConfigItem <System.Boolean> m_ApplyBeforeBody;
    }
}
