using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_S_String_Field :ICameraMovementControlField<System.String>
    {
       public  Type AttachControlField => typeof(System.String[]);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref System.String target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_S_String_Config source = (CameraMovement.Control_S_String_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref System.String target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_S_String_Config source = (CameraMovement.Control_S_String_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref System.String target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
