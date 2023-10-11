using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_COT_Heading_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineOrbitalTransposer.Heading);

       [UnityEngine.TooltipAttribute("How 'forward' is defined.  The camera will be placed by default behind the target.  PositionDelta will consider 'forward' to be the direction in which the target is moving.")]
            public ConfigItem <Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition> m_Definition;
       [UnityEngine.TooltipAttribute("Size of the velocity sampling window for target heading filter.  This filters out irregularities in the target's movement.  Used only if deriving heading from target's movement (PositionDelta or Velocity)")]
            public ConfigItem <System.Int32> m_VelocityFilterStrength;
       [UnityEngine.TooltipAttribute("Where the camera is placed when the X-axis value is zero.  This is a rotation in degrees around the Y axis.  When this value is 0, the camera will be placed behind the target.  Nonzero offsets will rotate the zero position around the target.")]
            public ConfigItem <System.Single> m_Bias;
    }
}
