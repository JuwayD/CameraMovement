using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CBS_CustomBlend")]
    public class Control_C_CBS_CustomBlend_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBlenderSettings.CustomBlend);

       [UnityEngine.TooltipAttribute("When blending from this camera")]
            public ConfigItem <System.String> m_From;
       [UnityEngine.TooltipAttribute("When blending to this camera")]
            public ConfigItem <System.String> m_To;
       [UnityEngine.TooltipAttribute("Blend curve definition")]
        public Control_C_CinemachineBlendDefinition_Config m_Blend;
    }
}
