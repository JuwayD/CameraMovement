using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CVCB_TransitionParams")]
    public class Control_C_CVCB_TransitionParams_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineVirtualCameraBase.TransitionParams);

       [UnityEngine.TooltipAttribute("Hint for blending positions to and from this virtual camera")]
            public ConfigItem <Cinemachine.CinemachineVirtualCameraBase.BlendHint> m_BlendHint;
       [UnityEngine.TooltipAttribute("When this virtual camera goes Live, attempt to force the position to be the same as the current position of the Unity Camera")]
            public ConfigItem <System.Boolean> m_InheritPosition;
       [UnityEngine.TooltipAttribute("This event fires when the virtual camera goes Live")]
        public Control_C_CB_VcamActivatedEvent_Config m_OnCameraLive;
    }
}
