using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_PFX_CinemachinePostProcessing_Field :ICameraMovementControlField<Cinemachine.PostFX.CinemachinePostProcessing>
    {
       public  Type AttachControlField => typeof(Cinemachine.PostFX.CinemachinePostProcessing);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_PFX_CinemachinePostProcessing_Config source = (CameraMovement.Control_C_PFX_CinemachinePostProcessing_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_PFX_CinemachinePostProcessing_Config source = (CameraMovement.Control_C_PFX_CinemachinePostProcessing_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.PostFX.CinemachinePostProcessing target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
