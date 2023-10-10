using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_S_String_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(System.String);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_S_String_Config source = (CameraMovement.Control_S_String_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_S_String_Config source = (CameraMovement.Control_S_String_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (System.String)targetObj;
        }
    }
}
