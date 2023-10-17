using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_SphereCastCollider_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.SphereCastCollider);

       [UnityEngine.TooltipAttribute("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public ConfigItem <System.String> m_IgnoreTag;
       [UnityEngine.TooltipAttribute("Obstacles closer to the target than this will be ignored")]
            public ConfigItem <System.Single> m_MinimumDistanceFromTarget;
       [UnityEngine.TooltipAttribute("When enabled, will attempt to resolve situations where the line of sight to the target is blocked by an obstacle")]
            public ConfigItem <System.Boolean> m_AvoidObstacles;
       [UnityEngine.TooltipAttribute("The maximum raycast distance when checking if the line of sight to this camera's target is clear.  If the setting is 0 or less, the current actual distance to target will be used.")]
            public ConfigItem <System.Single> m_DistanceLimit;
       [UnityEngine.TooltipAttribute("Don't take action unless occlusion has lasted at least this long.")]
            public ConfigItem <System.Single> m_MinimumOcclusionTime;
       [UnityEngine.TooltipAttribute("Camera will try to maintain this distance from any obstacle.  Try to keep this value small.  Increase it if you are seeing inside obstacles due to a large FOV on the camera.")]
            public ConfigItem <System.Single> m_CameraRadius;
       [UnityEngine.TooltipAttribute("The way in which the Collider will attempt to preserve sight of the target.")]
            public ConfigItem <Cinemachine.SphereCastCollider.ResolutionStrategy> m_Strategy;
       [UnityEngine.TooltipAttribute("Upper limit on how many obstacle hits to process.  Higher numbers may impact performance.  In most environments, 4 is enough.")]
            public ConfigItem <System.Int32> m_MaximumEffort;
       [UnityEngine.TooltipAttribute("Smoothing to apply to obstruction resolution.  Nearest camera point is held for at least this long")]
            public ConfigItem <System.Single> m_SmoothingTime;
       [UnityEngine.TooltipAttribute("How gradually the camera returns to its normal position after having been corrected.  Higher numbers will move the camera more gradually back to normal.")]
            public ConfigItem <System.Single> m_Damping;
       [UnityEngine.TooltipAttribute("How gradually the camera moves to resolve an occlusion.  Higher numbers will move the camera more gradually.")]
            public ConfigItem <System.Single> m_DampingWhenOccluded;
       [UnityEngine.HeaderAttribute("Shot Evaluation")]
           [UnityEngine.TooltipAttribute("If greater than zero, a higher score will be given to shots when the target is closer to this distance.  Set this to zero to disable this feature.")]
            public ConfigItem <System.Single> m_OptimalTargetDistance;
    }
}
