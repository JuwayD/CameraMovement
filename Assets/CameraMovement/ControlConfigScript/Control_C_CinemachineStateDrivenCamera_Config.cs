using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineStateDrivenCamera_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineStateDrivenCamera);

       [UnityEngine.TooltipAttribute("Which layer in the target state machine to observe")]
            public ConfigItem <System.Int32> m_LayerIndex;
       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public ConfigItem <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("The set of instructions associating virtual cameras with states.  These instructions are used to choose the live child at any given moment")]
        public Control_C_CSDC_Instruction_Config[] m_Instructions;
       [UnityEngine.TooltipAttribute("The blend which is used if you don't explicitly define a blend between two Virtual Camera children")]
        public Control_C_CinemachineBlendDefinition_Config m_DefaultBlend;
       [UnityEngine.TooltipAttribute("This is the asset which contains custom settings for specific child blends")]
        public Control_C_CinemachineBlenderSettings_Config m_CustomBlends;
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
