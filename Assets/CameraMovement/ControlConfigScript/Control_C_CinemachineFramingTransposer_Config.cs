using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineFramingTransposer")]
    public class Control_C_CinemachineFramingTransposer_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineFramingTransposer);

       [UnityEngine.TooltipAttribute("Offset from the Follow Target object (in target-local co-ordinates).  The camera will attempt to frame the point which is the target's position plus this offset.  Use it to correct for cases when the target's origin is not the point of interest for the camera.")]
            public ConfigItem <UnityEngine.Vector3> m_TrackedObjectOffset;
       [UnityEngine.TooltipAttribute("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
            public ConfigItem <System.Single> m_LookaheadTime;
       [UnityEngine.TooltipAttribute("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
            public ConfigItem <System.Single> m_LookaheadSmoothing;
       [UnityEngine.TooltipAttribute("If checked, movement along the Y axis will be ignored for lookahead calculations")]
            public ConfigItem <System.Boolean> m_LookaheadIgnoreY;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera.  Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_XDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera.  Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_YDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera.  Using different settings per axis can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_ZDamping;
       [UnityEngine.TooltipAttribute("If set, damping will apply  only to target motion, but not to camera rotation changes.  Turn this on to get an instant response when the rotation changes.  ")]
            public ConfigItem <System.Boolean> m_TargetMovementOnly;
       [UnityEngine.TooltipAttribute("Horizontal screen position for target. The camera will move to position the tracked object here.")]
            public ConfigItem <System.Single> m_ScreenX;
       [UnityEngine.TooltipAttribute("Vertical screen position for target, The camera will move to position the tracked object here.")]
            public ConfigItem <System.Single> m_ScreenY;
       [UnityEngine.TooltipAttribute("The distance along the camera axis that will be maintained from the Follow target")]
            public ConfigItem <System.Single> m_CameraDistance;
       [UnityEngine.TooltipAttribute("Camera will not move horizontally if the target is within this range of the position.")]
            public ConfigItem <System.Single> m_DeadZoneWidth;
       [UnityEngine.TooltipAttribute("Camera will not move vertically if the target is within this range of the position.")]
            public ConfigItem <System.Single> m_DeadZoneHeight;
       [UnityEngine.TooltipAttribute("The camera will not move along its z-axis if the Follow target is within this distance of the specified camera distance")]
            public ConfigItem <System.Single> m_DeadZoneDepth;
       [UnityEngine.TooltipAttribute("If checked, then then soft zone will be unlimited in size.")]
            public ConfigItem <System.Boolean> m_UnlimitedSoftZone;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually move horizontally to re-align towards the desired position, depending on the damping speed.")]
            public ConfigItem <System.Single> m_SoftZoneWidth;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually move vertically to re-align towards the desired position, depending on the damping speed.")]
            public ConfigItem <System.Single> m_SoftZoneHeight;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
            public ConfigItem <System.Single> m_BiasX;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
            public ConfigItem <System.Single> m_BiasY;
       [UnityEngine.TooltipAttribute("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
            public ConfigItem <System.Boolean> m_CenterOnActivate;
       [UnityEngine.TooltipAttribute("What screen dimensions to consider when framing.  Can be Horizontal, Vertical, or both")]
            public ConfigItem <Cinemachine.CinemachineFramingTransposer.FramingMode> m_GroupFramingMode;
       [UnityEngine.TooltipAttribute("How to adjust the camera to get the desired framing.  You can zoom, dolly in/out, or do both.")]
            public ConfigItem <Cinemachine.CinemachineFramingTransposer.AdjustmentMode> m_AdjustmentMode;
       [UnityEngine.TooltipAttribute("The bounding box of the targets should occupy this amount of the screen space.  1 means fill the whole screen.  0.5 means fill half the screen, etc.")]
            public ConfigItem <System.Single> m_GroupFramingSize;
       [UnityEngine.TooltipAttribute("The maximum distance toward the target that this behaviour is allowed to move the camera.")]
            public ConfigItem <System.Single> m_MaxDollyIn;
       [UnityEngine.TooltipAttribute("The maximum distance away the target that this behaviour is allowed to move the camera.")]
            public ConfigItem <System.Single> m_MaxDollyOut;
       [UnityEngine.TooltipAttribute("Set this to limit how close to the target the camera can get.")]
            public ConfigItem <System.Single> m_MinimumDistance;
       [UnityEngine.TooltipAttribute("Set this to limit how far from the target the camera can get.")]
            public ConfigItem <System.Single> m_MaximumDistance;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV lower than this.")]
            public ConfigItem <System.Single> m_MinimumFOV;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV higher than this.")]
            public ConfigItem <System.Single> m_MaximumFOV;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it lower than this.")]
            public ConfigItem <System.Single> m_MinimumOrthoSize;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it higher than this.")]
            public ConfigItem <System.Single> m_MaximumOrthoSize;
    }
}
