using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineComposer")]
    public class Control_C_CinemachineComposer_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineComposer);

       [UnityEngine.TooltipAttribute("Target offset from the target object's center in target-local space. Use this to fine-tune the tracking target position when the desired area is not the tracked object's center.")]
            public ConfigItem <UnityEngine.Vector3> m_TrackedObjectOffset;
       [UnityEngine.TooltipAttribute("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
            public ConfigItem <System.Single> m_LookaheadTime;
       [UnityEngine.TooltipAttribute("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
            public ConfigItem <System.Single> m_LookaheadSmoothing;
       [UnityEngine.TooltipAttribute("If checked, movement along the Y axis will be ignored for lookahead calculations")]
            public ConfigItem <System.Boolean> m_LookaheadIgnoreY;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-horizontal direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_HorizontalDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-vertical direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public ConfigItem <System.Single> m_VerticalDamping;
       [UnityEngine.TooltipAttribute("Horizontal screen position for target. The camera will rotate to position the tracked object here.")]
            public ConfigItem <System.Single> m_ScreenX;
       [UnityEngine.TooltipAttribute("Vertical screen position for target, The camera will rotate to position the tracked object here.")]
            public ConfigItem <System.Single> m_ScreenY;
       [UnityEngine.TooltipAttribute("Camera will not rotate horizontally if the target is within this range of the position.")]
            public ConfigItem <System.Single> m_DeadZoneWidth;
       [UnityEngine.TooltipAttribute("Camera will not rotate vertically if the target is within this range of the position.")]
            public ConfigItem <System.Single> m_DeadZoneHeight;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate horizontally to re-align towards the desired position, depending on the damping speed.")]
            public ConfigItem <System.Single> m_SoftZoneWidth;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate vertically to re-align towards the desired position, depending on the damping speed.")]
            public ConfigItem <System.Single> m_SoftZoneHeight;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
            public ConfigItem <System.Single> m_BiasX;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
            public ConfigItem <System.Single> m_BiasY;
       [UnityEngine.TooltipAttribute("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
            public ConfigItem <System.Boolean> m_CenterOnActivate;
    }
}
