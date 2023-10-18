using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CFL_Orbit_Field :ICameraMovementControlField<Cinemachine.CinemachineFreeLook.Orbit>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFreeLook.Orbit);

        public DataMixer <System.Single> m_Height;
        public float m_HeightAlertInit;
        public float m_HeightDiff;
        public DataMixer <System.Single> m_Radius;
        public float m_RadiusAlertInit;
        public float m_RadiusDiff;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFreeLook.Orbit target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CFL_Orbit_Config source = (CameraMovement.Control_C_CFL_Orbit_Config)sourceConfig;
            if(source.m_Height.IsUse)
            {
                m_Height.Add(new MixItem<System.Single>(id, priority, source.m_Height.CalculatorExpression, source.m_Height.Value, source.m_Height.IsUse));
               var targetValue = (m_Height.IsExpression ? m_Height.Value : m_Height.PrimitiveValue);
               m_HeightDiff = targetValue - target.m_Height;
               if(templateDict[m_Height.Id].Config.alertCurve != null) m_HeightAlertInit = target.m_Height - templateDict[m_Height.Id].Config.alertCurve.Evaluate(templateDict[m_Height.Id].CostTime / templateDict[m_Height.Id].Config.duration) * (m_HeightDiff);
            }
            if(source.m_Radius.IsUse)
            {
                m_Radius.Add(new MixItem<System.Single>(id, priority, source.m_Radius.CalculatorExpression, source.m_Radius.Value, source.m_Radius.IsUse));
               var targetValue = (m_Radius.IsExpression ? m_Radius.Value : m_Radius.PrimitiveValue);
               m_RadiusDiff = targetValue - target.m_Radius;
               if(templateDict[m_Radius.Id].Config.alertCurve != null) m_RadiusAlertInit = target.m_Radius - templateDict[m_Radius.Id].Config.alertCurve.Evaluate(templateDict[m_Radius.Id].CostTime / templateDict[m_Radius.Id].Config.duration) * (m_RadiusDiff);
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFreeLook.Orbit target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CFL_Orbit_Config source = (CameraMovement.Control_C_CFL_Orbit_Config)sourceConfig;
            if(source.m_Height.IsUse)
            {
                m_Height.Remove(new MixItem<System.Single>(id, priority, source.m_Height.CalculatorExpression, source.m_Height.Value, source.m_Height.IsUse));
               var targetValue = (m_Height.IsExpression ? m_Height.Value : m_Height.PrimitiveValue);
               m_HeightDiff = targetValue - target.m_Height;
               if(templateDict[m_Height.Id].Config.alertCurve != null) m_HeightAlertInit = target.m_Height - templateDict[m_Height.Id].Config.alertCurve.Evaluate(templateDict[m_Height.Id].CostTime / templateDict[m_Height.Id].Config.duration) * (m_HeightDiff);
            }
            if(source.m_Radius.IsUse)
            {
                m_Radius.Remove(new MixItem<System.Single>(id, priority, source.m_Radius.CalculatorExpression, source.m_Radius.Value, source.m_Radius.IsUse));
               var targetValue = (m_Radius.IsExpression ? m_Radius.Value : m_Radius.PrimitiveValue);
               m_RadiusDiff = targetValue - target.m_Radius;
               if(templateDict[m_Radius.Id].Config.alertCurve != null) m_RadiusAlertInit = target.m_Radius - templateDict[m_Radius.Id].Config.alertCurve.Evaluate(templateDict[m_Radius.Id].CostTime / templateDict[m_Radius.Id].Config.duration) * (m_RadiusDiff);
            }
        }
        public void RemoveAll()
        {
            m_Height.RemoveAll();
            m_Radius.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineFreeLook.Orbit target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Height.IsUse && templateDict.ContainsKey(m_Height.Id))
            {
                var targetValue = (m_Height.IsExpression ? m_Height.Value : m_Height.PrimitiveValue);
                target.m_Height = Mathf.Approximately(0, templateDict[m_Height.Id].Config.duration) ? targetValue : m_HeightAlertInit + templateDict[m_Height.Id].Config.alertCurve.Evaluate(templateDict[m_Height.Id].CostTime / templateDict[m_Height.Id].Config.duration) * m_HeightDiff;
            }
            if (m_Radius.IsUse && templateDict.ContainsKey(m_Radius.Id))
            {
                var targetValue = (m_Radius.IsExpression ? m_Radius.Value : m_Radius.PrimitiveValue);
                target.m_Radius = Mathf.Approximately(0, templateDict[m_Radius.Id].Config.duration) ? targetValue : m_RadiusAlertInit + templateDict[m_Radius.Id].Config.alertCurve.Evaluate(templateDict[m_Radius.Id].CostTime / templateDict[m_Radius.Id].Config.duration) * m_RadiusDiff;
            }
        }
    }
}
