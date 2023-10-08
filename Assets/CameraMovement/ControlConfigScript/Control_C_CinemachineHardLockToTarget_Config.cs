using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineHardLockToTarget")]
    public class Control_C_CinemachineHardLockToTarget_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineHardLockToTarget);

       [UnityEngine.TooltipAttribute("How much time it takes for the position to catch up to the target's position")]
            public ConfigItem <System.Single> m_Damping;
    }
}
