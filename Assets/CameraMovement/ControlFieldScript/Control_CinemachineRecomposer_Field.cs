using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_CinemachineRecomposer_Field :ICameraMovementControlField<CinemachineRecomposer>
    {
       public  Type AttachControlField => typeof(CinemachineRecomposer);

       [UnityEngine.TooltipAttribute("When to apply the adjustment")]
            public DataMixer <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("Tilt the camera by this much")]
            public DataMixer <System.Single> m_Tilt;
        public float m_TiltAlertInit;
       [UnityEngine.TooltipAttribute("Pan the camera by this much")]
            public DataMixer <System.Single> m_Pan;
        public float m_PanAlertInit;
       [UnityEngine.TooltipAttribute("Roll the camera by this much")]
            public DataMixer <System.Single> m_Dutch;
        public float m_DutchAlertInit;
       [UnityEngine.TooltipAttribute("Scale the zoom by this amount (normal = 1)")]
            public DataMixer <System.Single> m_ZoomScale;
        public float m_ZoomScaleAlertInit;
       [UnityEngine.TooltipAttribute("Lowering this value relaxes the camera's attention to the Follow target (normal = 1)")]
            public DataMixer <System.Single> m_FollowAttachment;
        public float m_FollowAttachmentAlertInit;
       [UnityEngine.TooltipAttribute("Lowering this value relaxes the camera's attention to the LookAt target (normal = 1)")]
            public DataMixer <System.Single> m_LookAtAttachment;
        public float m_LookAtAttachmentAlertInit;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref CinemachineRecomposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_CinemachineRecomposer_Config source = (CameraMovement.Control_CinemachineRecomposer_Config)sourceConfig;
                if(source.m_ApplyAfter.IsUse)
                {
                    m_ApplyAfter.Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value, source.m_ApplyAfter.IsUse));
                }
                if(source.m_Tilt.IsUse)
                {
                    m_Tilt.Add(new MixItem<System.Single>(id, priority, source.m_Tilt.CalculatorExpression, source.m_Tilt.Value, source.m_Tilt.IsUse));
                   var targetValue = (m_Tilt.IsExpression ? m_Tilt.Value : m_Tilt.PrimitiveValue);
                   m_TiltAlertInit = target.m_Tilt - templateDict[m_Tilt.Id].Config.alertCurve.Evaluate(templateDict[m_Tilt.Id].CostTime / templateDict[m_Tilt.Id].Config.duration) * (targetValue - m_TiltAlertInit);
                }
                if(source.m_Pan.IsUse)
                {
                    m_Pan.Add(new MixItem<System.Single>(id, priority, source.m_Pan.CalculatorExpression, source.m_Pan.Value, source.m_Pan.IsUse));
                   var targetValue = (m_Pan.IsExpression ? m_Pan.Value : m_Pan.PrimitiveValue);
                   m_PanAlertInit = target.m_Pan - templateDict[m_Pan.Id].Config.alertCurve.Evaluate(templateDict[m_Pan.Id].CostTime / templateDict[m_Pan.Id].Config.duration) * (targetValue - m_PanAlertInit);
                }
                if(source.m_Dutch.IsUse)
                {
                    m_Dutch.Add(new MixItem<System.Single>(id, priority, source.m_Dutch.CalculatorExpression, source.m_Dutch.Value, source.m_Dutch.IsUse));
                   var targetValue = (m_Dutch.IsExpression ? m_Dutch.Value : m_Dutch.PrimitiveValue);
                   m_DutchAlertInit = target.m_Dutch - templateDict[m_Dutch.Id].Config.alertCurve.Evaluate(templateDict[m_Dutch.Id].CostTime / templateDict[m_Dutch.Id].Config.duration) * (targetValue - m_DutchAlertInit);
                }
                if(source.m_ZoomScale.IsUse)
                {
                    m_ZoomScale.Add(new MixItem<System.Single>(id, priority, source.m_ZoomScale.CalculatorExpression, source.m_ZoomScale.Value, source.m_ZoomScale.IsUse));
                   var targetValue = (m_ZoomScale.IsExpression ? m_ZoomScale.Value : m_ZoomScale.PrimitiveValue);
                   m_ZoomScaleAlertInit = target.m_ZoomScale - templateDict[m_ZoomScale.Id].Config.alertCurve.Evaluate(templateDict[m_ZoomScale.Id].CostTime / templateDict[m_ZoomScale.Id].Config.duration) * (targetValue - m_ZoomScaleAlertInit);
                }
                if(source.m_FollowAttachment.IsUse)
                {
                    m_FollowAttachment.Add(new MixItem<System.Single>(id, priority, source.m_FollowAttachment.CalculatorExpression, source.m_FollowAttachment.Value, source.m_FollowAttachment.IsUse));
                   var targetValue = (m_FollowAttachment.IsExpression ? m_FollowAttachment.Value : m_FollowAttachment.PrimitiveValue);
                   m_FollowAttachmentAlertInit = target.m_FollowAttachment - templateDict[m_FollowAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_FollowAttachment.Id].CostTime / templateDict[m_FollowAttachment.Id].Config.duration) * (targetValue - m_FollowAttachmentAlertInit);
                }
                if(source.m_LookAtAttachment.IsUse)
                {
                    m_LookAtAttachment.Add(new MixItem<System.Single>(id, priority, source.m_LookAtAttachment.CalculatorExpression, source.m_LookAtAttachment.Value, source.m_LookAtAttachment.IsUse));
                   var targetValue = (m_LookAtAttachment.IsExpression ? m_LookAtAttachment.Value : m_LookAtAttachment.PrimitiveValue);
                   m_LookAtAttachmentAlertInit = target.m_LookAtAttachment - templateDict[m_LookAtAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_LookAtAttachment.Id].CostTime / templateDict[m_LookAtAttachment.Id].Config.duration) * (targetValue - m_LookAtAttachmentAlertInit);
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref CinemachineRecomposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_CinemachineRecomposer_Config source = (CameraMovement.Control_CinemachineRecomposer_Config)sourceConfig;
                if(source.m_ApplyAfter.IsUse)
                {
                    m_ApplyAfter.Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value, source.m_ApplyAfter.IsUse));
                }
                if(source.m_Tilt.IsUse)
                {
                   var targetValue = (m_Tilt.IsExpression ? m_Tilt.Value : m_Tilt.PrimitiveValue);
                   m_TiltAlertInit = target.m_Tilt - templateDict[m_Tilt.Id].Config.alertCurve.Evaluate(templateDict[m_Tilt.Id].CostTime / templateDict[m_Tilt.Id].Config.duration) * (targetValue - m_TiltAlertInit);
                    m_Tilt.Remove(new MixItem<System.Single>(id, priority, source.m_Tilt.CalculatorExpression, source.m_Tilt.Value, source.m_Tilt.IsUse));
                }
                if(source.m_Pan.IsUse)
                {
                   var targetValue = (m_Pan.IsExpression ? m_Pan.Value : m_Pan.PrimitiveValue);
                   m_PanAlertInit = target.m_Pan - templateDict[m_Pan.Id].Config.alertCurve.Evaluate(templateDict[m_Pan.Id].CostTime / templateDict[m_Pan.Id].Config.duration) * (targetValue - m_PanAlertInit);
                    m_Pan.Remove(new MixItem<System.Single>(id, priority, source.m_Pan.CalculatorExpression, source.m_Pan.Value, source.m_Pan.IsUse));
                }
                if(source.m_Dutch.IsUse)
                {
                   var targetValue = (m_Dutch.IsExpression ? m_Dutch.Value : m_Dutch.PrimitiveValue);
                   m_DutchAlertInit = target.m_Dutch - templateDict[m_Dutch.Id].Config.alertCurve.Evaluate(templateDict[m_Dutch.Id].CostTime / templateDict[m_Dutch.Id].Config.duration) * (targetValue - m_DutchAlertInit);
                    m_Dutch.Remove(new MixItem<System.Single>(id, priority, source.m_Dutch.CalculatorExpression, source.m_Dutch.Value, source.m_Dutch.IsUse));
                }
                if(source.m_ZoomScale.IsUse)
                {
                   var targetValue = (m_ZoomScale.IsExpression ? m_ZoomScale.Value : m_ZoomScale.PrimitiveValue);
                   m_ZoomScaleAlertInit = target.m_ZoomScale - templateDict[m_ZoomScale.Id].Config.alertCurve.Evaluate(templateDict[m_ZoomScale.Id].CostTime / templateDict[m_ZoomScale.Id].Config.duration) * (targetValue - m_ZoomScaleAlertInit);
                    m_ZoomScale.Remove(new MixItem<System.Single>(id, priority, source.m_ZoomScale.CalculatorExpression, source.m_ZoomScale.Value, source.m_ZoomScale.IsUse));
                }
                if(source.m_FollowAttachment.IsUse)
                {
                   var targetValue = (m_FollowAttachment.IsExpression ? m_FollowAttachment.Value : m_FollowAttachment.PrimitiveValue);
                   m_FollowAttachmentAlertInit = target.m_FollowAttachment - templateDict[m_FollowAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_FollowAttachment.Id].CostTime / templateDict[m_FollowAttachment.Id].Config.duration) * (targetValue - m_FollowAttachmentAlertInit);
                    m_FollowAttachment.Remove(new MixItem<System.Single>(id, priority, source.m_FollowAttachment.CalculatorExpression, source.m_FollowAttachment.Value, source.m_FollowAttachment.IsUse));
                }
                if(source.m_LookAtAttachment.IsUse)
                {
                   var targetValue = (m_LookAtAttachment.IsExpression ? m_LookAtAttachment.Value : m_LookAtAttachment.PrimitiveValue);
                   m_LookAtAttachmentAlertInit = target.m_LookAtAttachment - templateDict[m_LookAtAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_LookAtAttachment.Id].CostTime / templateDict[m_LookAtAttachment.Id].Config.duration) * (targetValue - m_LookAtAttachmentAlertInit);
                    m_LookAtAttachment.Remove(new MixItem<System.Single>(id, priority, source.m_LookAtAttachment.CalculatorExpression, source.m_LookAtAttachment.Value, source.m_LookAtAttachment.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_ApplyAfter.RemoveAll();
            m_Tilt.RemoveAll();
            m_Pan.RemoveAll();
            m_Dutch.RemoveAll();
            m_ZoomScale.RemoveAll();
            m_FollowAttachment.RemoveAll();
            m_LookAtAttachment.RemoveAll();
        }
        public void ControlCinemachine(ref CinemachineRecomposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_ApplyAfter.IsUse) target.m_ApplyAfter = m_ApplyAfter.IsExpression ? (Cinemachine.CinemachineCore.Stage)m_ApplyAfter.Value :m_ApplyAfter.PrimitiveValue;
            if (m_Tilt.IsUse && templateDict.ContainsKey(m_Tilt.Id))
            {
                var targetValue = (m_Tilt.IsExpression ? m_Tilt.Value : m_Tilt.PrimitiveValue);
                target.m_Tilt = Mathf.Approximately(0, templateDict[m_Tilt.Id].Config.duration) ? targetValue : m_TiltAlertInit + templateDict[m_Tilt.Id].Config.alertCurve.Evaluate(templateDict[m_Tilt.Id].CostTime / templateDict[m_Tilt.Id].Config.duration) * (targetValue - m_TiltAlertInit);
            }
            if (m_Pan.IsUse && templateDict.ContainsKey(m_Pan.Id))
            {
                var targetValue = (m_Pan.IsExpression ? m_Pan.Value : m_Pan.PrimitiveValue);
                target.m_Pan = Mathf.Approximately(0, templateDict[m_Pan.Id].Config.duration) ? targetValue : m_PanAlertInit + templateDict[m_Pan.Id].Config.alertCurve.Evaluate(templateDict[m_Pan.Id].CostTime / templateDict[m_Pan.Id].Config.duration) * (targetValue - m_PanAlertInit);
            }
            if (m_Dutch.IsUse && templateDict.ContainsKey(m_Dutch.Id))
            {
                var targetValue = (m_Dutch.IsExpression ? m_Dutch.Value : m_Dutch.PrimitiveValue);
                target.m_Dutch = Mathf.Approximately(0, templateDict[m_Dutch.Id].Config.duration) ? targetValue : m_DutchAlertInit + templateDict[m_Dutch.Id].Config.alertCurve.Evaluate(templateDict[m_Dutch.Id].CostTime / templateDict[m_Dutch.Id].Config.duration) * (targetValue - m_DutchAlertInit);
            }
            if (m_ZoomScale.IsUse && templateDict.ContainsKey(m_ZoomScale.Id))
            {
                var targetValue = (m_ZoomScale.IsExpression ? m_ZoomScale.Value : m_ZoomScale.PrimitiveValue);
                target.m_ZoomScale = Mathf.Approximately(0, templateDict[m_ZoomScale.Id].Config.duration) ? targetValue : m_ZoomScaleAlertInit + templateDict[m_ZoomScale.Id].Config.alertCurve.Evaluate(templateDict[m_ZoomScale.Id].CostTime / templateDict[m_ZoomScale.Id].Config.duration) * (targetValue - m_ZoomScaleAlertInit);
            }
            if (m_FollowAttachment.IsUse && templateDict.ContainsKey(m_FollowAttachment.Id))
            {
                var targetValue = (m_FollowAttachment.IsExpression ? m_FollowAttachment.Value : m_FollowAttachment.PrimitiveValue);
                target.m_FollowAttachment = Mathf.Approximately(0, templateDict[m_FollowAttachment.Id].Config.duration) ? targetValue : m_FollowAttachmentAlertInit + templateDict[m_FollowAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_FollowAttachment.Id].CostTime / templateDict[m_FollowAttachment.Id].Config.duration) * (targetValue - m_FollowAttachmentAlertInit);
            }
            if (m_LookAtAttachment.IsUse && templateDict.ContainsKey(m_LookAtAttachment.Id))
            {
                var targetValue = (m_LookAtAttachment.IsExpression ? m_LookAtAttachment.Value : m_LookAtAttachment.PrimitiveValue);
                target.m_LookAtAttachment = Mathf.Approximately(0, templateDict[m_LookAtAttachment.Id].Config.duration) ? targetValue : m_LookAtAttachmentAlertInit + templateDict[m_LookAtAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_LookAtAttachment.Id].CostTime / templateDict[m_LookAtAttachment.Id].Config.duration) * (targetValue - m_LookAtAttachmentAlertInit);
            }
        }
    }
}
