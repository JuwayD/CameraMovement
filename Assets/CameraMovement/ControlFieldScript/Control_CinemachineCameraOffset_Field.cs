using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_CinemachineCameraOffset_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(CinemachineCameraOffset);

       [UnityEngine.TooltipAttribute("Offset the camera's position by this much (camera space)")]
            public DataMixer <UnityEngine.Vector3> m_Offset;
       [UnityEngine.TooltipAttribute("When to apply the offset")]
            public DataMixer <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("If applying offset after aim, re-adjust the aim to preserve the screen position of the LookAt target as much as possible")]
            public DataMixer <System.Boolean> m_PreserveComposition;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_CinemachineCameraOffset_Config source = (CameraMovement.Control_CinemachineCameraOffset_Config)sourceConfig;
            if(source.m_Offset.IsUse) m_Offset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_Offset.CalculatorExpression, source.m_Offset.Value));
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value));
            if(source.m_PreserveComposition.IsUse) m_PreserveComposition.Add(new MixItem<System.Boolean>(id, priority, source.m_PreserveComposition.CalculatorExpression, source.m_PreserveComposition.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_CinemachineCameraOffset_Config source = (CameraMovement.Control_CinemachineCameraOffset_Config)sourceConfig;
            if(source.m_Offset.IsUse) m_Offset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_Offset.CalculatorExpression, source.m_Offset.Value));
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value));
            if(source.m_PreserveComposition.IsUse) m_PreserveComposition.Remove(new MixItem<System.Boolean>(id, priority, source.m_PreserveComposition.CalculatorExpression, source.m_PreserveComposition.Value));
        }
        public void RemoveAll()
        {
            m_Offset.RemoveAll();
            m_ApplyAfter.RemoveAll();
            m_PreserveComposition.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (CinemachineCameraOffset)targetObj;
            target.m_ApplyAfter = (Cinemachine.CinemachineCore.Stage)m_ApplyAfter.Value;
            target.m_PreserveComposition = !Mathf.Approximately(m_PreserveComposition.Value, 0);
        }
    }
}
