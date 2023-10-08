using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CTD_AutoDolly")]
    public class Control_C_CTD_AutoDolly_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineTrackedDolly.AutoDolly);

       [UnityEngine.TooltipAttribute("If checked, will enable automatic dolly, which chooses a path position that is as close as possible to the Follow target.  Note: this can have significant performance impact")]
            public ConfigItem <System.Boolean> m_Enabled;
       [UnityEngine.TooltipAttribute("Offset, in current position units, from the closest point on the path to the follow target")]
            public ConfigItem <System.Single> m_PositionOffset;
       [UnityEngine.TooltipAttribute("Search up to this many waypoints on either side of the current position.  Use 0 for Entire path.")]
            public ConfigItem <System.Int32> m_SearchRadius;
       [UnityEngine.TooltipAttribute("We search between waypoints by dividing the segment into this many straight pieces.  he higher the number, the more accurate the result, but performance is proportionally slower for higher numbers")]
            public ConfigItem <System.Int32> m_SearchResolution;
    }
}
