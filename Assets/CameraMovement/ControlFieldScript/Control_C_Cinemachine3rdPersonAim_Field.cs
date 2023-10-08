using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_Cinemachine3rdPersonAim_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.Cinemachine3rdPersonAim);

       [UnityEngine.TooltipAttribute("Objects with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public DataMixer <System.String> IgnoreTag;
       [UnityEngine.TooltipAttribute("How far to project the object detection ray")]
            public DataMixer <System.Single> AimDistance;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonAim_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonAim_Config)sourceConfig;
            if(source.IgnoreTag.IsUse) IgnoreTag.Add(new MixItem<System.String>(id, priority, source.IgnoreTag.Value));
            if(source.AimDistance.IsUse) AimDistance.Add(new MixItem<System.Single>(id, priority, source.AimDistance.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonAim_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonAim_Config)sourceConfig;
            if(source.IgnoreTag.IsUse) IgnoreTag.Remove(new MixItem<System.String>(id, priority, source.IgnoreTag.Value));
            if(source.AimDistance.IsUse) AimDistance.Remove(new MixItem<System.Single>(id, priority, source.AimDistance.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.Cinemachine3rdPersonAim)targetObj;
        }
    }
}
