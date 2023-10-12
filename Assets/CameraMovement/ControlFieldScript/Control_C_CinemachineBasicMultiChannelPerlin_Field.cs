using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineBasicMultiChannelPerlin_Field :ICameraMovementControlField<Cinemachine.CinemachineBasicMultiChannelPerlin>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBasicMultiChannelPerlin);

       [UnityEngine.TooltipAttribute("When rotating the camera, offset the camera's pivot position by this much (camera space)")]
            public DataMixer <UnityEngine.Vector3> m_PivotOffset;
       [UnityEngine.TooltipAttribute("Gain to apply to the amplitudes defined in the NoiseSettings asset.  1 is normal.  Setting this to 0 completely mutes the noise.")]
            public DataMixer <System.Single> m_AmplitudeGain;
        public float m_AmplitudeGainAlertInit;
       [UnityEngine.TooltipAttribute("Scale factor to apply to the frequencies defined in the NoiseSettings asset.  1 is normal.  Larger magnitudes will make the noise shake more rapidly.")]
            public DataMixer <System.Single> m_FrequencyGain;
        public float m_FrequencyGainAlertInit;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBasicMultiChannelPerlin target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config source = (CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config)sourceConfig;
                if(source.m_PivotOffset.IsUse)
                {
                    m_PivotOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PivotOffset.CalculatorExpression, source.m_PivotOffset.Value, source.m_PivotOffset.IsUse));
                }
                if(source.m_AmplitudeGain.IsUse)
                {
                    m_AmplitudeGain.Add(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.CalculatorExpression, source.m_AmplitudeGain.Value, source.m_AmplitudeGain.IsUse));
                   var targetValue = (m_AmplitudeGain.IsExpression ? m_AmplitudeGain.Value : m_AmplitudeGain.PrimitiveValue);
                   m_AmplitudeGainAlertInit = target.m_AmplitudeGain - templateDict[m_AmplitudeGain.Id].Config.alertCurve.Evaluate(templateDict[m_AmplitudeGain.Id].CostTime / templateDict[m_AmplitudeGain.Id].Config.duration) * (targetValue - m_AmplitudeGainAlertInit);
                }
                if(source.m_FrequencyGain.IsUse)
                {
                    m_FrequencyGain.Add(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.CalculatorExpression, source.m_FrequencyGain.Value, source.m_FrequencyGain.IsUse));
                   var targetValue = (m_FrequencyGain.IsExpression ? m_FrequencyGain.Value : m_FrequencyGain.PrimitiveValue);
                   m_FrequencyGainAlertInit = target.m_FrequencyGain - templateDict[m_FrequencyGain.Id].Config.alertCurve.Evaluate(templateDict[m_FrequencyGain.Id].CostTime / templateDict[m_FrequencyGain.Id].Config.duration) * (targetValue - m_FrequencyGainAlertInit);
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBasicMultiChannelPerlin target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config source = (CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config)sourceConfig;
                if(source.m_PivotOffset.IsUse)
                {
                    m_PivotOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PivotOffset.CalculatorExpression, source.m_PivotOffset.Value, source.m_PivotOffset.IsUse));
                }
                if(source.m_AmplitudeGain.IsUse)
                {
                   var targetValue = (m_AmplitudeGain.IsExpression ? m_AmplitudeGain.Value : m_AmplitudeGain.PrimitiveValue);
                   m_AmplitudeGainAlertInit = target.m_AmplitudeGain - templateDict[m_AmplitudeGain.Id].Config.alertCurve.Evaluate(templateDict[m_AmplitudeGain.Id].CostTime / templateDict[m_AmplitudeGain.Id].Config.duration) * (targetValue - m_AmplitudeGainAlertInit);
                    m_AmplitudeGain.Remove(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.CalculatorExpression, source.m_AmplitudeGain.Value, source.m_AmplitudeGain.IsUse));
                }
                if(source.m_FrequencyGain.IsUse)
                {
                   var targetValue = (m_FrequencyGain.IsExpression ? m_FrequencyGain.Value : m_FrequencyGain.PrimitiveValue);
                   m_FrequencyGainAlertInit = target.m_FrequencyGain - templateDict[m_FrequencyGain.Id].Config.alertCurve.Evaluate(templateDict[m_FrequencyGain.Id].CostTime / templateDict[m_FrequencyGain.Id].Config.duration) * (targetValue - m_FrequencyGainAlertInit);
                    m_FrequencyGain.Remove(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.CalculatorExpression, source.m_FrequencyGain.Value, source.m_FrequencyGain.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_PivotOffset.RemoveAll();
            m_AmplitudeGain.RemoveAll();
            m_FrequencyGain.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBasicMultiChannelPerlin target, Dictionary<int, RuntimeTemplate> templateDict)
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
        }
    }
}
