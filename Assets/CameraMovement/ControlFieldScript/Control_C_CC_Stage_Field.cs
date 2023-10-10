using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CC_Stage_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineCore.Stage);

        public DataMixer <System.Int32> value__;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CC_Stage_Config source = (CameraMovement.Control_C_CC_Stage_Config)sourceConfig;
            if(source.value__.IsUse) value__.Add(new MixItem<System.Int32>(id, priority, source.value__.CalculatorExpression, source.value__.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CC_Stage_Config source = (CameraMovement.Control_C_CC_Stage_Config)sourceConfig;
            if(source.value__.IsUse) value__.Remove(new MixItem<System.Int32>(id, priority, source.value__.CalculatorExpression, source.value__.Value));
        }
        public void RemoveAll()
        {
            value__.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineCore.Stage)targetObj;
        }
    }
}
