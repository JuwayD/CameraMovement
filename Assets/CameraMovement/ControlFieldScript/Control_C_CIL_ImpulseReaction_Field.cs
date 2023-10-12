using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CIL_ImpulseReaction_Field :ICameraMovementControlField<Cinemachine.CinemachineImpulseListener.ImpulseReaction>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineImpulseListener.ImpulseReaction);

       [UnityEngine.TooltipAttribute("Gain to apply to the amplitudes defined in the signal source.  1 is normal.  Setting this to 0 completely mutes the signal.")]
            public DataMixer <System.Single> m_AmplitudeGain;
        public float m_AmplitudeGainAlertInit;
       [UnityEngine.TooltipAttribute("Scale factor to apply to the time axis.  1 is normal.  Larger magnitudes will make the signal progress more rapidly.")]
            public DataMixer <System.Single> m_FrequencyGain;
        public float m_FrequencyGainAlertInit;
       [UnityEngine.TooltipAttribute("How long the secondary reaction lasts.")]
            public DataMixer <System.Single> m_Duration;
        public float m_DurationAlertInit;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineImpulseListener.ImpulseReaction target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CIL_ImpulseReaction_Config source = (CameraMovement.Control_C_CIL_ImpulseReaction_Config)sourceConfig;
                if(source.m_AmplitudeGain.IsUse)
                {
                    m_AmplitudeGainAlertInit = target.m_AmplitudeGain;
                    m_AmplitudeGain.Add(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.CalculatorExpression, source.m_AmplitudeGain.Value, source.m_AmplitudeGain.IsUse));
                }
                if(source.m_FrequencyGain.IsUse)
                {
                    m_FrequencyGainAlertInit = target.m_FrequencyGain;
                    m_FrequencyGain.Add(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.CalculatorExpression, source.m_FrequencyGain.Value, source.m_FrequencyGain.IsUse));
                }
                if(source.m_Duration.IsUse)
                {
                    m_DurationAlertInit = target.m_Duration;
                    m_Duration.Add(new MixItem<System.Single>(id, priority, source.m_Duration.CalculatorExpression, source.m_Duration.Value, source.m_Duration.IsUse));
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineImpulseListener.ImpulseReaction target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CIL_ImpulseReaction_Config source = (CameraMovement.Control_C_CIL_ImpulseReaction_Config)sourceConfig;
                if(source.m_AmplitudeGain.IsUse)
                {
                    m_AmplitudeGainAlertInit = target.m_AmplitudeGain;
                    m_AmplitudeGain.Remove(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.CalculatorExpression, source.m_AmplitudeGain.Value, source.m_AmplitudeGain.IsUse));
                }
                if(source.m_FrequencyGain.IsUse)
                {
                    m_FrequencyGainAlertInit = target.m_FrequencyGain;
                    m_FrequencyGain.Remove(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.CalculatorExpression, source.m_FrequencyGain.Value, source.m_FrequencyGain.IsUse));
                }
                if(source.m_Duration.IsUse)
                {
                    m_DurationAlertInit = target.m_Duration;
                    m_Duration.Remove(new MixItem<System.Single>(id, priority, source.m_Duration.CalculatorExpression, source.m_Duration.Value, source.m_Duration.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_AmplitudeGain.RemoveAll();
            m_FrequencyGain.RemoveAll();
            m_Duration.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineImpulseListener.ImpulseReaction target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_AmplitudeGain.IsUse && templateDict.ContainsKey(m_AmplitudeGain.Id))
            {
                var targetValue = (m_AmplitudeGain.IsExpression ? m_AmplitudeGain.Value : m_AmplitudeGain.PrimitiveValue);
                target.m_AmplitudeGain = Mathf.Approximately(0, templateDict[m_AmplitudeGain.Id].Config.duration) ? targetValue : m_AmplitudeGainAlertInit + templateDict[m_AmplitudeGain.Id].Config.alertCurve.Evaluate(templateDict[m_AmplitudeGain.Id].CostTime / templateDict[m_AmplitudeGain.Id].Config.duration) * (targetValue - m_AmplitudeGainAlertInit);
            }
            if (m_FrequencyGain.IsUse && templateDict.ContainsKey(m_FrequencyGain.Id))
            {
                var targetValue = (m_FrequencyGain.IsExpression ? m_FrequencyGain.Value : m_FrequencyGain.PrimitiveValue);
                target.m_FrequencyGain = Mathf.Approximately(0, templateDict[m_FrequencyGain.Id].Config.duration) ? targetValue : m_FrequencyGainAlertInit + templateDict[m_FrequencyGain.Id].Config.alertCurve.Evaluate(templateDict[m_FrequencyGain.Id].CostTime / templateDict[m_FrequencyGain.Id].Config.duration) * (targetValue - m_FrequencyGainAlertInit);
            }
            if (m_Duration.IsUse && templateDict.ContainsKey(m_Duration.Id))
            {
                var targetValue = (m_Duration.IsExpression ? m_Duration.Value : m_Duration.PrimitiveValue);
                target.m_Duration = Mathf.Approximately(0, templateDict[m_Duration.Id].Config.duration) ? targetValue : m_DurationAlertInit + templateDict[m_Duration.Id].Config.alertCurve.Evaluate(templateDict[m_Duration.Id].CostTime / templateDict[m_Duration.Id].Config.duration) * (targetValue - m_DurationAlertInit);
            }
        }
    }
}
