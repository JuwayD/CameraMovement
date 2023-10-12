using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineFollowZoom_Field :ICameraMovementControlField<Cinemachine.CinemachineFollowZoom>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFollowZoom);

       [UnityEngine.TooltipAttribute("The shot width to maintain, in world units, at target distance.")]
            public DataMixer <System.Single> m_Width;
        public float m_WidthAlertInit;
       [UnityEngine.TooltipAttribute("Increase this value to soften the aggressiveness of the follow-zoom.  Small numbers are more responsive, larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_Damping;
        public float m_DampingAlertInit;
       [UnityEngine.TooltipAttribute("Lower limit for the FOV that this behaviour will generate.")]
            public DataMixer <System.Single> m_MinFOV;
        public float m_MinFOVAlertInit;
       [UnityEngine.TooltipAttribute("Upper limit for the FOV that this behaviour will generate.")]
            public DataMixer <System.Single> m_MaxFOV;
        public float m_MaxFOVAlertInit;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFollowZoom target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFollowZoom_Config source = (CameraMovement.Control_C_CinemachineFollowZoom_Config)sourceConfig;
                if(source.m_Width.IsUse)
                {
                    m_WidthAlertInit = target.m_Width;
                    m_Width.Add(new MixItem<System.Single>(id, priority, source.m_Width.CalculatorExpression, source.m_Width.Value, source.m_Width.IsUse));
                }
                if(source.m_Damping.IsUse)
                {
                    m_DampingAlertInit = target.m_Damping;
                    m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
                }
                if(source.m_MinFOV.IsUse)
                {
                    m_MinFOVAlertInit = target.m_MinFOV;
                    m_MinFOV.Add(new MixItem<System.Single>(id, priority, source.m_MinFOV.CalculatorExpression, source.m_MinFOV.Value, source.m_MinFOV.IsUse));
                }
                if(source.m_MaxFOV.IsUse)
                {
                    m_MaxFOVAlertInit = target.m_MaxFOV;
                    m_MaxFOV.Add(new MixItem<System.Single>(id, priority, source.m_MaxFOV.CalculatorExpression, source.m_MaxFOV.Value, source.m_MaxFOV.IsUse));
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFollowZoom target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFollowZoom_Config source = (CameraMovement.Control_C_CinemachineFollowZoom_Config)sourceConfig;
                if(source.m_Width.IsUse)
                {
                    m_WidthAlertInit = target.m_Width;
                    m_Width.Remove(new MixItem<System.Single>(id, priority, source.m_Width.CalculatorExpression, source.m_Width.Value, source.m_Width.IsUse));
                }
                if(source.m_Damping.IsUse)
                {
                    m_DampingAlertInit = target.m_Damping;
                    m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
                }
                if(source.m_MinFOV.IsUse)
                {
                    m_MinFOVAlertInit = target.m_MinFOV;
                    m_MinFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MinFOV.CalculatorExpression, source.m_MinFOV.Value, source.m_MinFOV.IsUse));
                }
                if(source.m_MaxFOV.IsUse)
                {
                    m_MaxFOVAlertInit = target.m_MaxFOV;
                    m_MaxFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MaxFOV.CalculatorExpression, source.m_MaxFOV.Value, source.m_MaxFOV.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_Width.RemoveAll();
            m_Damping.RemoveAll();
            m_MinFOV.RemoveAll();
            m_MaxFOV.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineFollowZoom target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Width.IsUse && templateDict.ContainsKey(m_Width.Id))
            {
                var targetValue = (m_Width.IsExpression ? m_Width.Value : m_Width.PrimitiveValue);
                target.m_Width = Mathf.Approximately(0, templateDict[m_Width.Id].Config.duration) ? targetValue : m_WidthAlertInit + templateDict[m_Width.Id].Config.alertCurve.Evaluate(templateDict[m_Width.Id].CostTime / templateDict[m_Width.Id].Config.duration) * (targetValue - m_WidthAlertInit);
            }
            if (m_Damping.IsUse && templateDict.ContainsKey(m_Damping.Id))
            {
                var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                target.m_Damping = Mathf.Approximately(0, templateDict[m_Damping.Id].Config.duration) ? targetValue : m_DampingAlertInit + templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (targetValue - m_DampingAlertInit);
            }
            if (m_MinFOV.IsUse && templateDict.ContainsKey(m_MinFOV.Id))
            {
                var targetValue = (m_MinFOV.IsExpression ? m_MinFOV.Value : m_MinFOV.PrimitiveValue);
                target.m_MinFOV = Mathf.Approximately(0, templateDict[m_MinFOV.Id].Config.duration) ? targetValue : m_MinFOVAlertInit + templateDict[m_MinFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinFOV.Id].CostTime / templateDict[m_MinFOV.Id].Config.duration) * (targetValue - m_MinFOVAlertInit);
            }
            if (m_MaxFOV.IsUse && templateDict.ContainsKey(m_MaxFOV.Id))
            {
                var targetValue = (m_MaxFOV.IsExpression ? m_MaxFOV.Value : m_MaxFOV.PrimitiveValue);
                target.m_MaxFOV = Mathf.Approximately(0, templateDict[m_MaxFOV.Id].Config.duration) ? targetValue : m_MaxFOVAlertInit + templateDict[m_MaxFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaxFOV.Id].CostTime / templateDict[m_MaxFOV.Id].Config.duration) * (targetValue - m_MaxFOVAlertInit);
            }
        }
    }
}
