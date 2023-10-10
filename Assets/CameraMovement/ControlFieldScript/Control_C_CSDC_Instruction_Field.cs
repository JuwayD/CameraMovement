using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CSDC_Instruction_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineStateDrivenCamera.Instruction);

       [UnityEngine.TooltipAttribute("The full hash of the animation state")]
            public DataMixer <System.Int32> m_FullHash;
       [UnityEngine.TooltipAttribute("How long to wait (in seconds) before activating the virtual camera. This filters out very short state durations")]
            public DataMixer <System.Single> m_ActivateAfter;
       [UnityEngine.TooltipAttribute("The minimum length of time (in seconds) to keep a virtual camera active")]
            public DataMixer <System.Single> m_MinDuration;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CSDC_Instruction_Config source = (CameraMovement.Control_C_CSDC_Instruction_Config)sourceConfig;
            if(source.m_FullHash.IsUse) m_FullHash.Add(new MixItem<System.Int32>(id, priority, source.m_FullHash.CalculatorExpression, source.m_FullHash.Value));
            if(source.m_ActivateAfter.IsUse) m_ActivateAfter.Add(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value));
            if(source.m_MinDuration.IsUse) m_MinDuration.Add(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CSDC_Instruction_Config source = (CameraMovement.Control_C_CSDC_Instruction_Config)sourceConfig;
            if(source.m_FullHash.IsUse) m_FullHash.Remove(new MixItem<System.Int32>(id, priority, source.m_FullHash.CalculatorExpression, source.m_FullHash.Value));
            if(source.m_ActivateAfter.IsUse) m_ActivateAfter.Remove(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value));
            if(source.m_MinDuration.IsUse) m_MinDuration.Remove(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value));
        }
        public void RemoveAll()
        {
            m_FullHash.RemoveAll();
            m_ActivateAfter.RemoveAll();
            m_MinDuration.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineStateDrivenCamera.Instruction)targetObj;
            target.m_FullHash = (System.Int32)m_FullHash.Value;
            if (templateDict.ContainsKey(m_ActivateAfter.Id))
                target.m_ActivateAfter = templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * m_ActivateAfter.Value;
            target.m_ActivateAfter = (System.Single)m_ActivateAfter.Value;
            if (templateDict.ContainsKey(m_MinDuration.Id))
                target.m_MinDuration = templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * m_MinDuration.Value;
            target.m_MinDuration = (System.Single)m_MinDuration.Value;
        }
    }
}
