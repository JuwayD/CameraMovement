using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineVirtualCamera")]
    public class Control_C_CinemachineVirtualCamera_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineVirtualCamera);

       [UnityEngine.TooltipAttribute("Specifies the lens properties of this Virtual Camera.  This generally mirrors the Unity Camera's lens settings, and will be used to drive the Unity camera when the vcam is active.")]
        public Control_C_LensSettings_Config m_Lens;
    public Control_C_CVCB_TransitionParams_Config m_Transitions;
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
