using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CC_Stage_Field :ICameraMovementControlField<Cinemachine.CinemachineCore.Stage>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineCore.Stage[]);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineCore.Stage target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CC_Stage_Config source = (CameraMovement.Control_C_CC_Stage_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineCore.Stage target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CC_Stage_Config source = (CameraMovement.Control_C_CC_Stage_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineCore.Stage target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
