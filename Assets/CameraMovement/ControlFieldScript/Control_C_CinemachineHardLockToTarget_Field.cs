using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineHardLockToTarget_Field :ICameraMovementControlField<Cinemachine.CinemachineHardLockToTarget>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineHardLockToTarget);

       [UnityEngine.TooltipAttribute("How much time it takes for the position to catch up to the target's position")]
            public DataMixer <System.Single> m_Damping;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineHardLockToTarget_Config source = (CameraMovement.Control_C_CinemachineHardLockToTarget_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineHardLockToTarget_Config source = (CameraMovement.Control_C_CinemachineHardLockToTarget_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
        }
        public void RemoveAll()
        {
            m_Damping.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineHardLockToTarget target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Damping.IsUse && templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = Mathf.Approximately(0, templateDict[m_Damping.Id].Config.duration) ? (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue) : templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
        }
    }
}
