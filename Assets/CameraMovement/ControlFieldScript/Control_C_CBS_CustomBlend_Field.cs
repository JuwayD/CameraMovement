using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CBS_CustomBlend_Field :ICameraMovementControlField<Cinemachine.CinemachineBlenderSettings.CustomBlend>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlenderSettings.CustomBlend[]);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CBS_CustomBlend_Config source = (CameraMovement.Control_C_CBS_CustomBlend_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CBS_CustomBlend_Config source = (CameraMovement.Control_C_CBS_CustomBlend_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBlenderSettings.CustomBlend target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
