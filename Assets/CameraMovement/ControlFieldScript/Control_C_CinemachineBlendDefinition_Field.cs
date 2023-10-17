using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineBlendDefinition_Field :ICameraMovementControlField<Cinemachine.CinemachineBlendDefinition>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlendDefinition);

       [UnityEngine.TooltipAttribute("Shape of the blend curve")]
            public DataMixer <Cinemachine.CinemachineBlendDefinition.Style> m_Style;
       [UnityEngine.TooltipAttribute("Duration of the blend, in seconds")]
            public DataMixer <System.Single> m_Time;
        public float m_TimeAlertInit;
        public float m_TimeDiff;
        public DataMixer <UnityEngine.AnimationCurve> m_CustomCurve;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlendDefinition target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendDefinition_Config source = (CameraMovement.Control_C_CinemachineBlendDefinition_Config)sourceConfig;
            if(source.m_Style.IsUse)
            {
                m_Style.Add(new MixItem<Cinemachine.CinemachineBlendDefinition.Style>(id, priority, source.m_Style.CalculatorExpression, source.m_Style.Value, source.m_Style.IsUse));
            }
            if(source.m_Time.IsUse)
            {
                m_Time.Add(new MixItem<System.Single>(id, priority, source.m_Time.CalculatorExpression, source.m_Time.Value, source.m_Time.IsUse));
               var targetValue = (m_Time.IsExpression ? m_Time.Value : m_Time.PrimitiveValue);
               m_TimeDiff = targetValue - target.m_Time;
               m_TimeAlertInit = target.m_Time - templateDict[m_Time.Id].Config.alertCurve.Evaluate(templateDict[m_Time.Id].CostTime / templateDict[m_Time.Id].Config.duration) * (m_TimeDiff);
            }
            if(source.m_CustomCurve.IsUse)
            {
                m_CustomCurve.Add(new MixItem<UnityEngine.AnimationCurve>(id, priority, source.m_CustomCurve.CalculatorExpression, source.m_CustomCurve.Value, source.m_CustomCurve.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlendDefinition target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendDefinition_Config source = (CameraMovement.Control_C_CinemachineBlendDefinition_Config)sourceConfig;
            if(source.m_Style.IsUse)
            {
                m_Style.Remove(new MixItem<Cinemachine.CinemachineBlendDefinition.Style>(id, priority, source.m_Style.CalculatorExpression, source.m_Style.Value, source.m_Style.IsUse));
            }
            if(source.m_Time.IsUse)
            {
                m_Time.Remove(new MixItem<System.Single>(id, priority, source.m_Time.CalculatorExpression, source.m_Time.Value, source.m_Time.IsUse));
               var targetValue = (m_Time.IsExpression ? m_Time.Value : m_Time.PrimitiveValue);
               m_TimeDiff = targetValue - target.m_Time;
               m_TimeAlertInit = target.m_Time - templateDict[m_Time.Id].Config.alertCurve.Evaluate(templateDict[m_Time.Id].CostTime / templateDict[m_Time.Id].Config.duration) * (m_TimeDiff);
            }
            if(source.m_CustomCurve.IsUse)
            {
                m_CustomCurve.Remove(new MixItem<UnityEngine.AnimationCurve>(id, priority, source.m_CustomCurve.CalculatorExpression, source.m_CustomCurve.Value, source.m_CustomCurve.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_Style.RemoveAll();
            m_Time.RemoveAll();
            m_CustomCurve.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBlendDefinition target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Style.IsUse) target.m_Style = m_Style.IsExpression ? (Cinemachine.CinemachineBlendDefinition.Style)m_Style.Value :m_Style.PrimitiveValue;
            if (m_Time.IsUse && templateDict.ContainsKey(m_Time.Id))
            {
                var targetValue = (m_Time.IsExpression ? m_Time.Value : m_Time.PrimitiveValue);
                target.m_Time = Mathf.Approximately(0, templateDict[m_Time.Id].Config.duration) ? targetValue : m_TimeAlertInit + templateDict[m_Time.Id].Config.alertCurve.Evaluate(templateDict[m_Time.Id].CostTime / templateDict[m_Time.Id].Config.duration) * m_TimeDiff;
            }
        }
    }
}
