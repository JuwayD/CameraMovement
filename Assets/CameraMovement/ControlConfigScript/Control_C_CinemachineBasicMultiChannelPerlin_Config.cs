using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineBasicMultiChannelPerlin")]
    public class Control_C_CinemachineBasicMultiChannelPerlin_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBasicMultiChannelPerlin);

       [UnityEngine.TooltipAttribute("When rotating the camera, offset the camera's pivot position by this much (camera space)")]
            public ConfigItem <UnityEngine.Vector3> m_PivotOffset;
       [UnityEngine.TooltipAttribute("Gain to apply to the amplitudes defined in the NoiseSettings asset.  1 is normal.  Setting this to 0 completely mutes the noise.")]
            public ConfigItem <System.Single> m_AmplitudeGain;
       [UnityEngine.TooltipAttribute("Scale factor to apply to the frequencies defined in the NoiseSettings asset.  1 is normal.  Larger magnitudes will make the noise shake more rapidly.")]
            public ConfigItem <System.Single> m_FrequencyGain;
    }
}
