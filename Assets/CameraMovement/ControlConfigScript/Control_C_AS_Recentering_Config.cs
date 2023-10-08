using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_AS_Recentering")]
    public class Control_C_AS_Recentering_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.AxisState.Recentering);

       [UnityEngine.TooltipAttribute("If checked, will enable automatic recentering of the axis. If unchecked, recenting is disabled.")]
            public ConfigItem <System.Boolean> m_enabled;
       [UnityEngine.TooltipAttribute("If no user input has been detected on the axis, the axis will wait this long in seconds before recentering.")]
            public ConfigItem <System.Single> m_WaitTime;
       [UnityEngine.TooltipAttribute("How long it takes to reach destination once recentering has started.")]
            public ConfigItem <System.Single> m_RecenteringTime;
    }
}
