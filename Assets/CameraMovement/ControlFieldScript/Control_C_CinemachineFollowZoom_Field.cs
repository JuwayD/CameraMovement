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
       [UnityEngine.TooltipAttribute("Increase this value to soften the aggressiveness of the follow-zoom.  Small numbers are more responsive, larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_Damping;
       [UnityEngine.TooltipAttribute("Lower limit for the FOV that this behaviour will generate.")]
            public DataMixer <System.Single> m_MinFOV;
       [UnityEngine.TooltipAttribute("Upper limit for the FOV that this behaviour will generate.")]
            public DataMixer <System.Single> m_MaxFOV;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFollowZoom_Config source = (CameraMovement.Control_C_CinemachineFollowZoom_Config)sourceConfig;
            if(source.m_Width.IsUse) m_Width.Add(new MixItem<System.Single>(id, priority, source.m_Width.CalculatorExpression, source.m_Width.Value, source.m_Width.IsUse));
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
            if(source.m_MinFOV.IsUse) m_MinFOV.Add(new MixItem<System.Single>(id, priority, source.m_MinFOV.CalculatorExpression, source.m_MinFOV.Value, source.m_MinFOV.IsUse));
            if(source.m_MaxFOV.IsUse) m_MaxFOV.Add(new MixItem<System.Single>(id, priority, source.m_MaxFOV.CalculatorExpression, source.m_MaxFOV.Value, source.m_MaxFOV.IsUse));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFollowZoom_Config source = (CameraMovement.Control_C_CinemachineFollowZoom_Config)sourceConfig;
            if(source.m_Width.IsUse) m_Width.Remove(new MixItem<System.Single>(id, priority, source.m_Width.CalculatorExpression, source.m_Width.Value, source.m_Width.IsUse));
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
            if(source.m_MinFOV.IsUse) m_MinFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MinFOV.CalculatorExpression, source.m_MinFOV.Value, source.m_MinFOV.IsUse));
            if(source.m_MaxFOV.IsUse) m_MaxFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MaxFOV.CalculatorExpression, source.m_MaxFOV.Value, source.m_MaxFOV.IsUse));
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
                target.m_Width = Mathf.Approximately(0, templateDict[m_Width.Id].Config.duration) ? (m_Width.IsExpression ? m_Width.Value : m_Width.PrimitiveValue) : templateDict[m_Width.Id].Config.alertCurve.Evaluate(templateDict[m_Width.Id].CostTime / templateDict[m_Width.Id].Config.duration) * (m_Width.IsExpression ? m_Width.Value : m_Width.PrimitiveValue);
            if (m_Damping.IsUse && templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = Mathf.Approximately(0, templateDict[m_Damping.Id].Config.duration) ? (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue) : templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
            if (m_MinFOV.IsUse && templateDict.ContainsKey(m_MinFOV.Id))
                target.m_MinFOV = Mathf.Approximately(0, templateDict[m_MinFOV.Id].Config.duration) ? (m_MinFOV.IsExpression ? m_MinFOV.Value : m_MinFOV.PrimitiveValue) : templateDict[m_MinFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinFOV.Id].CostTime / templateDict[m_MinFOV.Id].Config.duration) * (m_MinFOV.IsExpression ? m_MinFOV.Value : m_MinFOV.PrimitiveValue);
            if (m_MaxFOV.IsUse && templateDict.ContainsKey(m_MaxFOV.Id))
                target.m_MaxFOV = Mathf.Approximately(0, templateDict[m_MaxFOV.Id].Config.duration) ? (m_MaxFOV.IsExpression ? m_MaxFOV.Value : m_MaxFOV.PrimitiveValue) : templateDict[m_MaxFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaxFOV.Id].CostTime / templateDict[m_MaxFOV.Id].Config.duration) * (m_MaxFOV.IsExpression ? m_MaxFOV.Value : m_MaxFOV.PrimitiveValue);
        }
    }
}
