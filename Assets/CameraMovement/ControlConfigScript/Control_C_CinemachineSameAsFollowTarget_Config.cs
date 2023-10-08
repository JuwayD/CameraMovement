using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineSameAsFollowTarget")]
    public class Control_C_CinemachineSameAsFollowTarget_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineSameAsFollowTarget);

       [UnityEngine.TooltipAttribute("How much time it takes for the aim to catch up to the target's rotation")]
            public ConfigItem <System.Single> m_Damping;
    }
}
