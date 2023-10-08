using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineOrbitalTransposer")]
    public class Control_C_CinemachineOrbitalTransposer_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineOrbitalTransposer);

       [UnityEngine.TooltipAttribute("The definition of Forward.  Camera will follow behind.")]
        public Control_C_COT_Heading_Config m_Heading;
       [UnityEngine.TooltipAttribute("Automatic heading recentering.  The settings here defines how the camera will reposition itself in the absence of player input.")]
        public Control_C_AS_Recentering_Config m_RecenterToTargetHeading;
       [UnityEngine.TooltipAttribute("Heading Control.  The settings here control the behaviour of the camera in response to the player's input.")]
        public Control_C_AxisState_Config m_XAxis;
       [UnityEngine.HideInInspector]
            public ConfigItem <System.Boolean> m_HeadingIsSlave;
       [UnityEngine.TooltipAttribute("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
            public ConfigItem <Cinemachine.CinemachineTransposer.BindingMode> m_BindingMode;
       [UnityEngine.TooltipAttribute("The distance vector that the transposer will attempt to maintain from the Follow target")]
            public ConfigItem <UnityEngine.Vector3> m_FollowOffset;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_XDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_YDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_ZDamping;
        public ConfigItem <Cinemachine.CinemachineTransposer.AngularDampingMode> m_AngularDampingMode;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_PitchDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_YawDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_RollDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target's orientation.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_AngularDamping;
    }
}
