using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_AS_Recentering_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.AxisState.Recentering);

       [UnityEngine.TooltipAttribute("If checked, will enable automatic recentering of the axis. If unchecked, recenting is disabled.")]
            public DataMixer <System.Boolean> m_enabled;
       [UnityEngine.TooltipAttribute("If no user input has been detected on the axis, the axis will wait this long in seconds before recentering.")]
            public DataMixer <System.Single> m_WaitTime;
       [UnityEngine.TooltipAttribute("How long it takes to reach destination once recentering has started.")]
            public DataMixer <System.Single> m_RecenteringTime;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_AS_Recentering_Config source = (CameraMovement.Control_C_AS_Recentering_Config)sourceConfig;
            if(source.m_enabled.IsUse) m_enabled.Add(new MixItem<System.Boolean>(id, priority, source.m_enabled.CalculatorExpression, source.m_enabled.Value));
            if(source.m_WaitTime.IsUse) m_WaitTime.Add(new MixItem<System.Single>(id, priority, source.m_WaitTime.CalculatorExpression, source.m_WaitTime.Value));
            if(source.m_RecenteringTime.IsUse) m_RecenteringTime.Add(new MixItem<System.Single>(id, priority, source.m_RecenteringTime.CalculatorExpression, source.m_RecenteringTime.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_AS_Recentering_Config source = (CameraMovement.Control_C_AS_Recentering_Config)sourceConfig;
            if(source.m_enabled.IsUse) m_enabled.Remove(new MixItem<System.Boolean>(id, priority, source.m_enabled.CalculatorExpression, source.m_enabled.Value));
            if(source.m_WaitTime.IsUse) m_WaitTime.Remove(new MixItem<System.Single>(id, priority, source.m_WaitTime.CalculatorExpression, source.m_WaitTime.Value));
            if(source.m_RecenteringTime.IsUse) m_RecenteringTime.Remove(new MixItem<System.Single>(id, priority, source.m_RecenteringTime.CalculatorExpression, source.m_RecenteringTime.Value));
        }
        public void RemoveAll()
        {
            m_enabled.RemoveAll();
            m_WaitTime.RemoveAll();
            m_RecenteringTime.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.AxisState.Recentering)targetObj;
            target.m_enabled = !Mathf.Approximately(m_enabled.Value, 0);
            if (templateDict.ContainsKey(m_WaitTime.Id))
                target.m_WaitTime = templateDict[m_WaitTime.Id].Config.alertCurve.Evaluate(templateDict[m_WaitTime.Id].CostTime / templateDict[m_WaitTime.Id].Config.duration) * m_WaitTime.Value;
            target.m_WaitTime = (System.Single)m_WaitTime.Value;
            if (templateDict.ContainsKey(m_RecenteringTime.Id))
                target.m_RecenteringTime = templateDict[m_RecenteringTime.Id].Config.alertCurve.Evaluate(templateDict[m_RecenteringTime.Id].CostTime / templateDict[m_RecenteringTime.Id].Config.duration) * m_RecenteringTime.Value;
            target.m_RecenteringTime = (System.Single)m_RecenteringTime.Value;
        }
    }
}
