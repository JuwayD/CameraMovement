using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineHardLookAt_Field :ICameraMovementControlField<Cinemachine.CinemachineHardLookAt>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineHardLookAt);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineHardLookAt target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineHardLookAt_Config source = (CameraMovement.Control_C_CinemachineHardLookAt_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineHardLookAt target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineHardLookAt_Config source = (CameraMovement.Control_C_CinemachineHardLookAt_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineHardLookAt target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
