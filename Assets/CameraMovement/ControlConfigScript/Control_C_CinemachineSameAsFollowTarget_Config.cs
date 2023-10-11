using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineSameAsFollowTarget_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineSameAsFollowTarget);

       [UnityEngine.TooltipAttribute("How much time it takes for the aim to catch up to the target's rotation")]
            public ConfigItem <System.Single> m_Damping;
    }
}
