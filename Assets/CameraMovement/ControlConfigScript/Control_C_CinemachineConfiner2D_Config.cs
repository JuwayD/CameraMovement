using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineConfiner2D")]
    public class Control_C_CinemachineConfiner2D_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineConfiner2D);

       [UnityEngine.TooltipAttribute("Damping applied around corners to avoid jumps.  Higher numbers are more gradual.")]
            public ConfigItem <System.Single> m_Damping;
       [UnityEngine.TooltipAttribute("To optimize computation and memory costs, set this to the largest view size that the camera is expected to have.  The confiner will not compute a polygon cache for frustum sizes larger than this.  This refers to the size in world units of the frustum at the confiner plane (for orthographic cameras, this is just the orthographic size).  If set to 0, then this parameter is ignored and a polygon cache will be calculated for all potential window sizes.")]
            public ConfigItem <System.Single> m_MaxWindowSize;
    }
}
