using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CFL_Orbit_Field :ICameraMovementControlField<Cinemachine.CinemachineFreeLook.Orbit>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFreeLook.Orbit[]);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFreeLook.Orbit target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CFL_Orbit_Config source = (CameraMovement.Control_C_CFL_Orbit_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFreeLook.Orbit target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CFL_Orbit_Config source = (CameraMovement.Control_C_CFL_Orbit_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineFreeLook.Orbit target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
