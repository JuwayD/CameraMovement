using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CBLC_Instruction_Field :ICameraMovementControlField<Cinemachine.CinemachineBlendListCamera.Instruction>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlendListCamera.Instruction);

       [UnityEngine.TooltipAttribute("How long to wait (in seconds) before activating the next virtual camera in the list (if any)")]
            public DataMixer <System.Single> m_Hold;
        public float m_HoldAlertInit;
        public float m_HoldDiff;
       [UnityEngine.TooltipAttribute("How to blend to the next virtual camera in the list (if any)")]
        public Control_C_CinemachineBlendDefinition_Field m_Blend;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlendListCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CBLC_Instruction_Config source = (CameraMovement.Control_C_CBLC_Instruction_Config)sourceConfig;
            if(source.m_Hold.IsUse)
            {
                m_Hold.Add(new MixItem<System.Single>(id, priority, source.m_Hold.CalculatorExpression, source.m_Hold.Value, source.m_Hold.IsUse));
               var targetValue = (m_Hold.IsExpression ? m_Hold.Value : m_Hold.PrimitiveValue);
               m_HoldDiff = targetValue - target.m_Hold;
               if(templateDict[m_Hold.Id].Config.alertCurve != null) m_HoldAlertInit = target.m_Hold - templateDict[m_Hold.Id].Config.alertCurve.Evaluate(templateDict[m_Hold.Id].CostTime / templateDict[m_Hold.Id].Config.duration) * (m_HoldDiff);
            }
            if(source.m_Blend != null && m_Blend == null) m_Blend = new Control_C_CinemachineBlendDefinition_Field();
            m_Blend?.AddByConfig(source.m_Blend, id, priority, ref target.m_Blend, templateDict);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlendListCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CBLC_Instruction_Config source = (CameraMovement.Control_C_CBLC_Instruction_Config)sourceConfig;
            if(source.m_Hold.IsUse)
            {
                m_Hold.Remove(new MixItem<System.Single>(id, priority, source.m_Hold.CalculatorExpression, source.m_Hold.Value, source.m_Hold.IsUse));
               var targetValue = (m_Hold.IsExpression ? m_Hold.Value : m_Hold.PrimitiveValue);
               m_HoldDiff = targetValue - target.m_Hold;
               if(templateDict[m_Hold.Id].Config.alertCurve != null) m_HoldAlertInit = target.m_Hold - templateDict[m_Hold.Id].Config.alertCurve.Evaluate(templateDict[m_Hold.Id].CostTime / templateDict[m_Hold.Id].Config.duration) * (m_HoldDiff);
            }
            m_Blend?.RemoveByConfig(source.m_Blend, id, priority, ref target.m_Blend, templateDict);
        }
        public void RemoveAll()
        {
            m_Hold.RemoveAll();
            m_Blend.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBlendListCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Hold.IsUse && templateDict.ContainsKey(m_Hold.Id))
            {
                var targetValue = (m_Hold.IsExpression ? m_Hold.Value : m_Hold.PrimitiveValue);
                target.m_Hold = Mathf.Approximately(0, templateDict[m_Hold.Id].Config.duration) ? targetValue : m_HoldAlertInit + templateDict[m_Hold.Id].Config.alertCurve.Evaluate(templateDict[m_Hold.Id].CostTime / templateDict[m_Hold.Id].Config.duration) * m_HoldDiff;
            }
            // 处理字段 m_Blend
            // 生成递归代码
            m_Blend?.ControlCinemachine(ref target.m_Blend, templateDict);
        }
    }
}
