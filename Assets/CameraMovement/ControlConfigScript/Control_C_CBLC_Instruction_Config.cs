using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CBLC_Instruction_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBlendListCamera.Instruction);

       [UnityEngine.TooltipAttribute("How long to wait (in seconds) before activating the next virtual camera in the list (if any)")]
            public ConfigItem <System.Single> m_Hold;
       [UnityEngine.TooltipAttribute("How to blend to the next virtual camera in the list (if any)")]
        public Control_C_CinemachineBlendDefinition_Config m_Blend;
    }
}
