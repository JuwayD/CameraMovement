using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineConfiner_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineConfiner);

       [UnityEngine.TooltipAttribute("The confiner can operate using a 2D bounding shape or a 3D bounding volume")]
            public ConfigItem <Cinemachine.CinemachineConfiner.Mode> m_ConfineMode;
       [UnityEngine.TooltipAttribute("If camera is orthographic, screen edges will be confined to the volume.  If not checked, then only the camera center will be confined")]
            public ConfigItem <System.Boolean> m_ConfineScreenEdges;
       [UnityEngine.TooltipAttribute("How gradually to return the camera to the bounding volume if it goes beyond the borders.  Higher numbers are more gradual.")]
            public ConfigItem <System.Single> m_Damping;
    }
}
