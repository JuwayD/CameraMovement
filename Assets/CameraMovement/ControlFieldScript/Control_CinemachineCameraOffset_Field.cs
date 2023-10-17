using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_CinemachineCameraOffset_Field :ICameraMovementControlField<CinemachineCameraOffset>
    {
       public  Type AttachControlField => typeof(CinemachineCameraOffset);

       [UnityEngine.TooltipAttribute("Offset the camera's position by this much (camera space)")]
            public DataMixer <UnityEngine.Vector3> m_Offset;
       [UnityEngine.TooltipAttribute("When to apply the offset")]
            public DataMixer <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("If applying offset after aim, re-adjust the aim to preserve the screen position of the LookAt target as much as possible")]
            public DataMixer <System.Boolean> m_PreserveComposition;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref CinemachineCameraOffset target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_CinemachineCameraOffset_Config source = (CameraMovement.Control_CinemachineCameraOffset_Config)sourceConfig;
            if(source.m_Offset.IsUse)
            {
                m_Offset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_Offset.CalculatorExpression, source.m_Offset.Value, source.m_Offset.IsUse));
            }
            if(source.m_ApplyAfter.IsUse)
            {
                m_ApplyAfter.Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value, source.m_ApplyAfter.IsUse));
            }
            if(source.m_PreserveComposition.IsUse)
            {
                m_PreserveComposition.Add(new MixItem<System.Boolean>(id, priority, source.m_PreserveComposition.CalculatorExpression, source.m_PreserveComposition.Value, source.m_PreserveComposition.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref CinemachineCameraOffset target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_CinemachineCameraOffset_Config source = (CameraMovement.Control_CinemachineCameraOffset_Config)sourceConfig;
            if(source.m_Offset.IsUse)
            {
                m_Offset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_Offset.CalculatorExpression, source.m_Offset.Value, source.m_Offset.IsUse));
            }
            if(source.m_ApplyAfter.IsUse)
            {
                m_ApplyAfter.Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value, source.m_ApplyAfter.IsUse));
            }
            if(source.m_PreserveComposition.IsUse)
            {
                m_PreserveComposition.Remove(new MixItem<System.Boolean>(id, priority, source.m_PreserveComposition.CalculatorExpression, source.m_PreserveComposition.Value, source.m_PreserveComposition.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_Offset.RemoveAll();
            m_ApplyAfter.RemoveAll();
            m_PreserveComposition.RemoveAll();
        }
        public void ControlCinemachine(ref CinemachineCameraOffset target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_ApplyAfter.IsUse) target.m_ApplyAfter = m_ApplyAfter.IsExpression ? (Cinemachine.CinemachineCore.Stage)m_ApplyAfter.Value :m_ApplyAfter.PrimitiveValue;
            if (m_PreserveComposition.IsUse) target.m_PreserveComposition = m_PreserveComposition.IsExpression ? !Mathf.Approximately(m_PreserveComposition.Value, 0) : m_PreserveComposition.PrimitiveValue;
        }
    }
}
