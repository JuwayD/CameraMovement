using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineBlendListCamera_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBlendListCamera);

       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public ConfigItem <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("When enabled, the child vcams will cycle indefinitely instead of just stopping at the last one")]
            public ConfigItem <System.Boolean> m_Loop;
       [UnityEngine.TooltipAttribute("The set of instructions for enabling child cameras.")]
        public Control_C_CBLC_Instruction_Config[] m_Instructions;
       [UnityEngine.HideInInspector]
            public ConfigItem<System.String>[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
            public ConfigItem<Cinemachine.CinemachineCore.Stage>[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public ConfigItem <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public ConfigItem <System.Single> FollowTargetAttachment;
       [System.NonSerializedAttribute]
            public ConfigItem <System.Single> LookAtTargetAttachment;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public ConfigItem <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
    }
}
