using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CSDC_Instruction_Field :ICameraMovementControlField<Cinemachine.CinemachineStateDrivenCamera.Instruction>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineStateDrivenCamera.Instruction);

       [UnityEngine.TooltipAttribute("The full hash of the animation state")]
            public DataMixer <System.Int32> m_FullHash;
       [UnityEngine.TooltipAttribute("How long to wait (in seconds) before activating the virtual camera. This filters out very short state durations")]
            public DataMixer <System.Single> m_ActivateAfter;
        public float m_ActivateAfterAlertInit;
        public float m_ActivateAfterDiff;
       [UnityEngine.TooltipAttribute("The minimum length of time (in seconds) to keep a virtual camera active")]
            public DataMixer <System.Single> m_MinDuration;
        public float m_MinDurationAlertInit;
        public float m_MinDurationDiff;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineStateDrivenCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CSDC_Instruction_Config source = (CameraMovement.Control_C_CSDC_Instruction_Config)sourceConfig;
            if(source.m_FullHash.IsUse)
            {
                m_FullHash.Add(new MixItem<System.Int32>(id, priority, source.m_FullHash.CalculatorExpression, source.m_FullHash.Value, source.m_FullHash.IsUse));
            }
            if(source.m_ActivateAfter.IsUse)
            {
                m_ActivateAfter.Add(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value, source.m_ActivateAfter.IsUse));
               var targetValue = (m_ActivateAfter.IsExpression ? m_ActivateAfter.Value : m_ActivateAfter.PrimitiveValue);
               m_ActivateAfterDiff = targetValue - target.m_ActivateAfter;
               m_ActivateAfterAlertInit = target.m_ActivateAfter - templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * (m_ActivateAfterDiff);
            }
            if(source.m_MinDuration.IsUse)
            {
                m_MinDuration.Add(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value, source.m_MinDuration.IsUse));
               var targetValue = (m_MinDuration.IsExpression ? m_MinDuration.Value : m_MinDuration.PrimitiveValue);
               m_MinDurationDiff = targetValue - target.m_MinDuration;
               m_MinDurationAlertInit = target.m_MinDuration - templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * (m_MinDurationDiff);
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineStateDrivenCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CSDC_Instruction_Config source = (CameraMovement.Control_C_CSDC_Instruction_Config)sourceConfig;
            if(source.m_FullHash.IsUse)
            {
                m_FullHash.Remove(new MixItem<System.Int32>(id, priority, source.m_FullHash.CalculatorExpression, source.m_FullHash.Value, source.m_FullHash.IsUse));
            }
            if(source.m_ActivateAfter.IsUse)
            {
                m_ActivateAfter.Remove(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value, source.m_ActivateAfter.IsUse));
               var targetValue = (m_ActivateAfter.IsExpression ? m_ActivateAfter.Value : m_ActivateAfter.PrimitiveValue);
               m_ActivateAfterDiff = targetValue - target.m_ActivateAfter;
               m_ActivateAfterAlertInit = target.m_ActivateAfter - templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * (m_ActivateAfterDiff);
            }
            if(source.m_MinDuration.IsUse)
            {
                m_MinDuration.Remove(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value, source.m_MinDuration.IsUse));
               var targetValue = (m_MinDuration.IsExpression ? m_MinDuration.Value : m_MinDuration.PrimitiveValue);
               m_MinDurationDiff = targetValue - target.m_MinDuration;
               m_MinDurationAlertInit = target.m_MinDuration - templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * (m_MinDurationDiff);
            }
        }
        public void RemoveAll()
        {
            m_FullHash.RemoveAll();
            m_ActivateAfter.RemoveAll();
            m_MinDuration.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineStateDrivenCamera.Instruction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_FullHash.IsUse) target.m_FullHash = m_FullHash.IsExpression ? (System.Int32)m_FullHash.Value :m_FullHash.PrimitiveValue;
            if (m_ActivateAfter.IsUse && templateDict.ContainsKey(m_ActivateAfter.Id))
            {
                var targetValue = (m_ActivateAfter.IsExpression ? m_ActivateAfter.Value : m_ActivateAfter.PrimitiveValue);
                target.m_ActivateAfter = Mathf.Approximately(0, templateDict[m_ActivateAfter.Id].Config.duration) ? targetValue : m_ActivateAfterAlertInit + templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * m_ActivateAfterDiff;
            }
            if (m_MinDuration.IsUse && templateDict.ContainsKey(m_MinDuration.Id))
            {
                var targetValue = (m_MinDuration.IsExpression ? m_MinDuration.Value : m_MinDuration.PrimitiveValue);
                target.m_MinDuration = Mathf.Approximately(0, templateDict[m_MinDuration.Id].Config.duration) ? targetValue : m_MinDurationAlertInit + templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * m_MinDurationDiff;
            }
        }
    }
}
