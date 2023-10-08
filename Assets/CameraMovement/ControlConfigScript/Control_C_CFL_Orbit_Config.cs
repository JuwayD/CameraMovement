using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CFL_Orbit")]
    public class Control_C_CFL_Orbit_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineFreeLook.Orbit);

        public ConfigItem <System.Single> m_Height;
        public ConfigItem <System.Single> m_Radius;
    }
}
