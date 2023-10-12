using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineSameAsFollowTarget_Field :ICameraMovementControlField<Cinemachine.CinemachineSameAsFollowTarget>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineSameAsFollowTarget);

       [UnityEngine.TooltipAttribute("How much time it takes for the aim to catch up to the target's rotation")]
            public DataMixer <System.Single> m_Damping;
        public float m_DampingAlertInit;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineSameAsFollowTarget target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config source = (CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config)sourceConfig;
                if(source.m_Damping.IsUse)
                {
                    m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
                   var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                   m_DampingAlertInit = target.m_Damping - templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (targetValue - m_DampingAlertInit);
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineSameAsFollowTarget target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config source = (CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config)sourceConfig;
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
        public void ControlCinemachine(ref Cinemachine.CinemachineSameAsFollowTarget target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Damping.IsUse && templateDict.ContainsKey(m_Damping.Id))
            {
                var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                target.m_Damping = Mathf.Approximately(0, templateDict[m_Damping.Id].Config.duration) ? targetValue : m_DampingAlertInit + templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (targetValue - m_DampingAlertInit);
            }
        }
    }
}
