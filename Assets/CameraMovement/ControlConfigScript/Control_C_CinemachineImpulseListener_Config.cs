using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineImpulseListener")]
    public class Control_C_CinemachineImpulseListener_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineImpulseListener);

       [UnityEngine.TooltipAttribute("When to apply the impulse reaction.  Default is after the Noise stage.  Modify this if necessary to influence the ordering of extension effects")]
            public ConfigItem <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("Impulse events on channels not included in the mask will be ignored.")]
            public ConfigItem <System.Int32> m_ChannelMask;
       [UnityEngine.TooltipAttribute("Gain to apply to the Impulse signal.  1 is normal strength.  Setting this to 0 completely mutes the signal.")]
            public ConfigItem <System.Single> m_Gain;
       [UnityEngine.TooltipAttribute("Enable this to perform distance calculation in 2D (ignore Z)")]
            public ConfigItem <System.Boolean> m_Use2DDistance;
       [UnityEngine.TooltipAttribute("Enable this to process all impulse signals in camera space")]
            public ConfigItem <System.Boolean> m_UseCameraSpace;
       [UnityEngine.TooltipAttribute("This controls the secondary reaction of the listener to the incoming impulse.  The impulse might be for example a sharp shock, and the secondary reaction could be a vibration whose amplitude and duration is controlled by the size of the original impulse.  This allows different listeners to respond in different ways to the same impulse signal.")]
        public Control_C_CIL_ImpulseReaction_Config m_ReactionSettings;
    }
}
