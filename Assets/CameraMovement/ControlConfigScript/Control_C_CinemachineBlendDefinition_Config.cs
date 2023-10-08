using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineBlendDefinition")]
    public class Control_C_CinemachineBlendDefinition_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBlendDefinition);

       [UnityEngine.TooltipAttribute("Shape of the blend curve")]
            public ConfigItem <Cinemachine.CinemachineBlendDefinition.Style> m_Style;
       [UnityEngine.TooltipAttribute("Duration of the blend, in seconds")]
            public ConfigItem <System.Single> m_Time;
        public ConfigItem <UnityEngine.AnimationCurve> m_CustomCurve;
    }
}
