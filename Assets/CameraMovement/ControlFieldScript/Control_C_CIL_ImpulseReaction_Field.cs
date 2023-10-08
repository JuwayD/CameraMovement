using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CIL_ImpulseReaction_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineImpulseListener.ImpulseReaction);

       [UnityEngine.TooltipAttribute("Gain to apply to the amplitudes defined in the signal source.  1 is normal.  Setting this to 0 completely mutes the signal.")]
            public DataMixer <System.Single> m_AmplitudeGain;
       [UnityEngine.TooltipAttribute("Scale factor to apply to the time axis.  1 is normal.  Larger magnitudes will make the signal progress more rapidly.")]
            public DataMixer <System.Single> m_FrequencyGain;
       [UnityEngine.TooltipAttribute("How long the secondary reaction lasts.")]
            public DataMixer <System.Single> m_Duration;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CIL_ImpulseReaction_Config source = (CameraMovement.Control_C_CIL_ImpulseReaction_Config)sourceConfig;
            if(source.m_AmplitudeGain.IsUse) m_AmplitudeGain.Add(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.Value));
            if(source.m_FrequencyGain.IsUse) m_FrequencyGain.Add(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.Value));
            if(source.m_Duration.IsUse) m_Duration.Add(new MixItem<System.Single>(id, priority, source.m_Duration.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CIL_ImpulseReaction_Config source = (CameraMovement.Control_C_CIL_ImpulseReaction_Config)sourceConfig;
            if(source.m_AmplitudeGain.IsUse) m_AmplitudeGain.Remove(new MixItem<System.Single>(id, priority, source.m_AmplitudeGain.Value));
            if(source.m_FrequencyGain.IsUse) m_FrequencyGain.Remove(new MixItem<System.Single>(id, priority, source.m_FrequencyGain.Value));
            if(source.m_Duration.IsUse) m_Duration.Remove(new MixItem<System.Single>(id, priority, source.m_Duration.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineImpulseListener.ImpulseReaction)targetObj;
            if (templateDict.ContainsKey(m_AmplitudeGain.Id))
                target.m_AmplitudeGain = templateDict[m_AmplitudeGain.Id].Config.alertCurve.Evaluate(templateDict[m_AmplitudeGain.Id].CostTime / templateDict[m_AmplitudeGain.Id].Config.duration);
            target.m_AmplitudeGain = m_AmplitudeGain.Value;
            if (templateDict.ContainsKey(m_FrequencyGain.Id))
                target.m_FrequencyGain = templateDict[m_FrequencyGain.Id].Config.alertCurve.Evaluate(templateDict[m_FrequencyGain.Id].CostTime / templateDict[m_FrequencyGain.Id].Config.duration);
            target.m_FrequencyGain = m_FrequencyGain.Value;
            if (templateDict.ContainsKey(m_Duration.Id))
                target.m_Duration = templateDict[m_Duration.Id].Config.alertCurve.Evaluate(templateDict[m_Duration.Id].CostTime / templateDict[m_Duration.Id].Config.duration);
            target.m_Duration = m_Duration.Value;
        }
    }
}
