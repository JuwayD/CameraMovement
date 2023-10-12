using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineConfiner_Field :ICameraMovementControlField<Cinemachine.CinemachineConfiner>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineConfiner);

       [UnityEngine.TooltipAttribute("The confiner can operate using a 2D bounding shape or a 3D bounding volume")]
            public DataMixer <Cinemachine.CinemachineConfiner.Mode> m_ConfineMode;
       [UnityEngine.TooltipAttribute("If camera is orthographic, screen edges will be confined to the volume.  If not checked, then only the camera center will be confined")]
            public DataMixer <System.Boolean> m_ConfineScreenEdges;
       [UnityEngine.TooltipAttribute("How gradually to return the camera to the bounding volume if it goes beyond the borders.  Higher numbers are more gradual.")]
            public DataMixer <System.Single> m_Damping;
        public float m_DampingAlertInit;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineConfiner target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineConfiner2D_Config source = (CameraMovement.Control_C_CinemachineConfiner2D_Config)sourceConfig;
                if(source.m_Damping.IsUse)
                {
                    m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
                   var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                   m_DampingAlertInit = target.m_Damping - templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (targetValue - m_DampingAlertInit);
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineConfiner target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineConfiner2D_Config source = (CameraMovement.Control_C_CinemachineConfiner2D_Config)sourceConfig;
                if(source.m_Damping.IsUse)
                {
                   var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                   m_DampingAlertInit = target.m_Damping - templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (targetValue - m_DampingAlertInit);
                    m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_Damping.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineConfiner target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_ConfineMode.IsUse) target.m_ConfineMode = m_ConfineMode.IsExpression ? (Cinemachine.CinemachineConfiner.Mode)m_ConfineMode.Value :m_ConfineMode.PrimitiveValue;
            if (m_ConfineScreenEdges.IsUse) target.m_ConfineScreenEdges = m_ConfineScreenEdges.IsExpression ? !Mathf.Approximately(m_ConfineScreenEdges.Value, 0) : m_ConfineScreenEdges.PrimitiveValue;
            if (m_Damping.IsUse && templateDict.ContainsKey(m_Damping.Id))
            {
                var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                target.m_Damping = Mathf.Approximately(0, templateDict[m_Damping.Id].Config.duration) ? targetValue : m_DampingAlertInit + templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (targetValue - m_DampingAlertInit);
            }
        }
    }
}
