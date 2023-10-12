using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CB_VcamActivatedEvent_Field :ICameraMovementControlField<Cinemachine.CinemachineBrain.VcamActivatedEvent>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBrain.VcamActivatedEvent);

        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBrain.VcamActivatedEvent target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CB_VcamActivatedEvent_Config source = (CameraMovement.Control_C_CB_VcamActivatedEvent_Config)sourceConfig;
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBrain.VcamActivatedEvent target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CB_VcamActivatedEvent_Config source = (CameraMovement.Control_C_CB_VcamActivatedEvent_Config)sourceConfig;
        }
        public void RemoveAll()
        {
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBrain.VcamActivatedEvent target, Dictionary<int, RuntimeTemplate> templateDict)
        {
        }
    }
}
