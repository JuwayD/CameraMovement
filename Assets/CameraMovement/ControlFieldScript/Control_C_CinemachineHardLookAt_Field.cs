using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineHardLookAt_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineHardLookAt);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineHardLookAt_Config source = (CameraMovement.Control_C_CinemachineHardLookAt_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineHardLookAt_Config source = (CameraMovement.Control_C_CinemachineHardLookAt_Config)sourceConfig;
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineHardLookAt)targetObj;
        }
    }
}
