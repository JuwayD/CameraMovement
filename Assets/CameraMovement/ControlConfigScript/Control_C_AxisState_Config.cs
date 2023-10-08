using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_AxisState")]
    public class Control_C_AxisState_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.AxisState);

       [UnityEngine.TooltipAttribute("The current value of the axis.")]
            public ConfigItem <System.Single> Value;
       [UnityEngine.TooltipAttribute("How to interpret the Max Speed setting: in units/second, or as a direct input value multiplier")]
            public ConfigItem <Cinemachine.AxisState.SpeedMode> m_SpeedMode;
       [UnityEngine.TooltipAttribute("The maximum speed of this axis in units/second, or the input value multiplier, depending on the Speed Mode")]
            public ConfigItem <System.Single> m_MaxSpeed;
       [UnityEngine.TooltipAttribute("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value")]
            public ConfigItem <System.Single> m_AccelTime;
       [UnityEngine.TooltipAttribute("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position")]
            public ConfigItem <System.Single> m_DecelTime;
       [UnityEngine.TooltipAttribute("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
            public ConfigItem <System.String> m_InputAxisName;
       [UnityEngine.TooltipAttribute("The value of the input axis.  A value of 0 means no input.  You can drive this directly from a custom input system, or you can set the Axis Name and have the value driven by the internal Input Manager")]
            public ConfigItem <System.Single> m_InputAxisValue;
       [UnityEngine.TooltipAttribute("If checked, then the raw value of the input axis will be inverted before it is used")]
            public ConfigItem <System.Boolean> m_InvertInput;
       [UnityEngine.TooltipAttribute("The minimum value for the axis")]
            public ConfigItem <System.Single> m_MinValue;
       [UnityEngine.TooltipAttribute("The maximum value for the axis")]
            public ConfigItem <System.Single> m_MaxValue;
       [UnityEngine.TooltipAttribute("If checked, then the axis will wrap around at the min/max values, forming a loop")]
            public ConfigItem <System.Boolean> m_Wrap;
       [UnityEngine.TooltipAttribute("Automatic recentering to at-rest position")]
        public Control_C_AS_Recentering_Config m_Recentering;
    }
}
