using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineClearShot_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineClearShot);

       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public ConfigItem <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("Wait this many seconds before activating a new child camera")]
            public ConfigItem <System.Single> m_ActivateAfter;
       [UnityEngine.TooltipAttribute("An active camera must be active for at least this many seconds")]
            public ConfigItem <System.Single> m_MinDuration;
       [UnityEngine.TooltipAttribute("If checked, camera choice will be randomized if multiple cameras are equally desirable.  Otherwise, child list order and child camera priority will be used.")]
            public ConfigItem <System.Boolean> m_RandomizeChoice;
       [UnityEngine.TooltipAttribute("The blend which is used if you don't explicitly define a blend between two Virtual Cameras")]
        public Control_C_CinemachineBlendDefinition_Config m_DefaultBlend;
       [UnityEngine.HideInInspector]
        public Control_C_CinemachineBlenderSettings_Config m_CustomBlends;
       [UnityEngine.HideInInspector]
        public Control_S_String_Config[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
        public Control_C_CC_Stage_Config[] m_LockStageInInspector;
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
