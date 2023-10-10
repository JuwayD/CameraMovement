using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineBasicMultiChannelPerlin_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBasicMultiChannelPerlin);

       [UnityEngine.TooltipAttribute("When rotating the camera, offset the camera's pivot position by this much (camera space)")]
            public DataMixer <UnityEngine.Vector3> m_PivotOffset;
       [UnityEngine.TooltipAttribute("Gain to apply to the amplitudes defined in the NoiseSettings asset.  1 is normal.  Setting this to 0 completely mutes the noise.")]
            public DataMixer <System.Single> m_AmplitudeGain;
       [UnityEngine.TooltipAttribute("Scale factor to apply to the frequencies defined in the NoiseSettings asset.  1 is normal.  Larger magnitudes will make the noise shake more rapidly.")]
            public DataMixer <System.Single> m_FrequencyGain;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config source = (CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config)sourceConfig;
            if(source.m_PivotOffset.IsUse) m_PivotOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PivotOffset.CalculatorExpression, source.m_PivotOffset.Value));
            if(source.m_AmplitudeGain.IsUse) m_AmplitudeGain.Add(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.CalculatorExpression, source.m_AmplitudeGain.Value));
            if(source.m_FrequencyGain.IsUse) m_FrequencyGain.Add(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.CalculatorExpression, source.m_FrequencyGain.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config source = (CameraMovement.Control_C_CinemachineBasicMultiChannelPerlin_Config)sourceConfig;
            if(source.m_PivotOffset.IsUse) m_PivotOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PivotOffset.CalculatorExpression, source.m_PivotOffset.Value));
            if(source.m_AmplitudeGain.IsUse) m_AmplitudeGain.Remove(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.CalculatorExpression, source.m_AmplitudeGain.Value));
            if(source.m_FrequencyGain.IsUse) m_FrequencyGain.Remove(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.CalculatorExpression, source.m_FrequencyGain.Value));
        }
        public void RemoveAll()
        {
            m_PivotOffset.RemoveAll();
            m_AmplitudeGain.RemoveAll();
            m_FrequencyGain.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineBasicMultiChannelPerlin)targetObj;
            if (templateDict.ContainsKey(m_AmplitudeGain.Id))
                target.m_AmplitudeGain = templateDict[m_AmplitudeGain.Id].Config.alertCurve.Evaluate(templateDict[m_AmplitudeGain.Id].CostTime / templateDict[m_AmplitudeGain.Id].Config.duration) * m_AmplitudeGain.Value;
            target.m_AmplitudeGain = (System.Single)m_AmplitudeGain.Value;
            if (templateDict.ContainsKey(m_FrequencyGain.Id))
                target.m_FrequencyGain = templateDict[m_FrequencyGain.Id].Config.alertCurve.Evaluate(templateDict[m_FrequencyGain.Id].CostTime / templateDict[m_FrequencyGain.Id].Config.duration) * m_FrequencyGain.Value;
            target.m_FrequencyGain = (System.Single)m_FrequencyGain.Value;
        }
    }
}
