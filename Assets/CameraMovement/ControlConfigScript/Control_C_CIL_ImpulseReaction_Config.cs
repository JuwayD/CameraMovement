using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CIL_ImpulseReaction_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineImpulseListener.ImpulseReaction);

       [UnityEngine.TooltipAttribute("Gain to apply to the amplitudes defined in the signal source.  1 is normal.  Setting this to 0 completely mutes the signal.")]
            public ConfigItem <System.Single> m_AmplitudeGain;
       [UnityEngine.TooltipAttribute("Scale factor to apply to the time axis.  1 is normal.  Larger magnitudes will make the signal progress more rapidly.")]
            public ConfigItem <System.Single> m_FrequencyGain;
       [UnityEngine.TooltipAttribute("How long the secondary reaction lasts.")]
            public ConfigItem <System.Single> m_Duration;
    }
}
