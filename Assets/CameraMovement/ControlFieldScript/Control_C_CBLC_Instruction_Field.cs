using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CBLC_Instruction_Field :ICameraMovementControlField<Cinemachine.CinemachineBlendListCamera.Instruction>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlendListCamera.Instruction[]);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CBLC_Instruction_Config source = (CameraMovement.Control_C_CBLC_Instruction_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CBLC_Instruction_Config source = (CameraMovement.Control_C_CBLC_Instruction_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBlendListCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
