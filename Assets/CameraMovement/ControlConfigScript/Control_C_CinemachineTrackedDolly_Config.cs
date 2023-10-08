using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineTrackedDolly")]
    public class Control_C_CinemachineTrackedDolly_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineTrackedDolly);

       [UnityEngine.TooltipAttribute("The position along the path at which the camera will be placed.  This can be animated directly, or set automatically by the Auto-Dolly feature to get as close as possible to the Follow target.  The value is interpreted according to the Position Units setting.")]
            public ConfigItem <System.Single> m_PathPosition;
       [UnityEngine.TooltipAttribute("How to interpret Path Position.  If set to Path Units, values are as follows: 0 represents the first waypoint on the path, 1 is the second, and so on.  Values in-between are points on the path in between the waypoints.  If set to Distance, then Path Position represents distance along the path.")]
            public ConfigItem <Cinemachine.CinemachinePathBase.PositionUnits> m_PositionUnits;
       [UnityEngine.TooltipAttribute("Where to put the camera relative to the path position.  X is perpendicular to the path, Y is up, and Z is parallel to the path.  This allows the camera to be offset from the path itself (as if on a tripod, for example).")]
            public ConfigItem <UnityEngine.Vector3> m_PathOffset;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in a direction perpendicular to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_XDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in the path-local up direction.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_YDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in a direction parallel to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_ZDamping;
       [UnityEngine.TooltipAttribute("How to set the virtual camera's Up vector.  This will affect the screen composition, because the camera Aim behaviours will always try to respect the Up direction.")]
            public ConfigItem <Cinemachine.CinemachineTrackedDolly.CameraUpMode> m_CameraUp;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_PitchDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_YawDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public ConfigItem <System.Single> m_RollDamping;
       [UnityEngine.TooltipAttribute("Controls how automatic dollying occurs.  A Follow target is necessary to use this feature.")]
        public Control_C_CTD_AutoDolly_Config m_AutoDolly;
    }
}
