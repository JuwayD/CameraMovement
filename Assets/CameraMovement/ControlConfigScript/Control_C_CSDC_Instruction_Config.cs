using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CSDC_Instruction_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineStateDrivenCamera.Instruction);

       [UnityEngine.TooltipAttribute("The full hash of the animation state")]
            public ConfigItem <System.Int32> m_FullHash;
       [UnityEngine.TooltipAttribute("How long to wait (in seconds) before activating the virtual camera. This filters out very short state durations")]
            public ConfigItem <System.Single> m_ActivateAfter;
       [UnityEngine.TooltipAttribute("The minimum length of time (in seconds) to keep a virtual camera active")]
            public ConfigItem <System.Single> m_MinDuration;
    }
}
