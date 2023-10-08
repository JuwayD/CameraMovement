using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineMixingCamera")]
    public class Control_C_CinemachineMixingCamera_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineMixingCamera);

       [UnityEngine.TooltipAttribute("The weight of the first tracked camera")]
            public ConfigItem <System.Single> m_Weight0;
       [UnityEngine.TooltipAttribute("The weight of the second tracked camera")]
            public ConfigItem <System.Single> m_Weight1;
       [UnityEngine.TooltipAttribute("The weight of the third tracked camera")]
            public ConfigItem <System.Single> m_Weight2;
       [UnityEngine.TooltipAttribute("The weight of the fourth tracked camera")]
            public ConfigItem <System.Single> m_Weight3;
       [UnityEngine.TooltipAttribute("The weight of the fifth tracked camera")]
            public ConfigItem <System.Single> m_Weight4;
       [UnityEngine.TooltipAttribute("The weight of the sixth tracked camera")]
            public ConfigItem <System.Single> m_Weight5;
       [UnityEngine.TooltipAttribute("The weight of the seventh tracked camera")]
            public ConfigItem <System.Single> m_Weight6;
       [UnityEngine.TooltipAttribute("The weight of the eighth tracked camera")]
            public ConfigItem <System.Single> m_Weight7;
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
