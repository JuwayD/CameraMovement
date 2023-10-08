using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineFreeLook")]
    public class Control_C_CinemachineFreeLook_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineFreeLook);

       [UnityEngine.TooltipAttribute("If enabled, this lens setting will apply to all three child rigs, otherwise the child rig lens settings will be used")]
            public ConfigItem <System.Boolean> m_CommonLens;
       [UnityEngine.TooltipAttribute("Specifies the lens properties of this Virtual Camera.  This generally mirrors the Unity Camera's lens settings, and will be used to drive the Unity camera when the vcam is active")]
        public Control_C_LensSettings_Config m_Lens;
    public Control_C_CVCB_TransitionParams_Config m_Transitions;
       [UnityEngine.HeaderAttribute("Axis Control")]
           [UnityEngine.TooltipAttribute("The Vertical axis.  Value is 0..1.  Chooses how to blend the child rigs")]
        public Control_C_AxisState_Config m_YAxis;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the Y axis is accomplished")]
        public Control_C_AS_Recentering_Config m_YAxisRecentering;
       [UnityEngine.TooltipAttribute("The Horizontal axis.  Value is -180...180.  This is passed on to the rigs' OrbitalTransposer component")]
        public Control_C_AxisState_Config m_XAxis;
       [UnityEngine.TooltipAttribute("The definition of Forward.  Camera will follow behind.")]
        public Control_C_COT_Heading_Config m_Heading;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the X axis is accomplished")]
        public Control_C_AS_Recentering_Config m_RecenterToTargetHeading;
       [UnityEngine.HeaderAttribute("Orbits")]
           [UnityEngine.TooltipAttribute("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
            public ConfigItem <Cinemachine.CinemachineTransposer.BindingMode> m_BindingMode;
       [UnityEngine.TooltipAttribute("Controls how taut is the line that connects the rigs' orbits, which determines final placement on the Y axis")]
            public ConfigItem <System.Single> m_SplineCurvature;
       [UnityEngine.TooltipAttribute("The radius and height of the three orbiting rigs.")]
        public Control_C_CFL_Orbit_Config[] m_Orbits;
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
