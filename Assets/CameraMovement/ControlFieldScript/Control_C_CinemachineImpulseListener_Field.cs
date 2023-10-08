using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineImpulseListener_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineImpulseListener);

       [UnityEngine.TooltipAttribute("When to apply the impulse reaction.  Default is after the Noise stage.  Modify this if necessary to influence the ordering of extension effects")]
            public DataMixer <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("Impulse events on channels not included in the mask will be ignored.")]
            public DataMixer <System.Int32> m_ChannelMask;
       [UnityEngine.TooltipAttribute("Gain to apply to the Impulse signal.  1 is normal strength.  Setting this to 0 completely mutes the signal.")]
            public DataMixer <System.Single> m_Gain;
       [UnityEngine.TooltipAttribute("Enable this to perform distance calculation in 2D (ignore Z)")]
            public DataMixer <System.Boolean> m_Use2DDistance;
       [UnityEngine.TooltipAttribute("Enable this to process all impulse signals in camera space")]
            public DataMixer <System.Boolean> m_UseCameraSpace;
       [UnityEngine.TooltipAttribute("This controls the secondary reaction of the listener to the incoming impulse.  The impulse might be for example a sharp shock, and the secondary reaction could be a vibration whose amplitude and duration is controlled by the size of the original impulse.  This allows different listeners to respond in different ways to the same impulse signal.")]
        public Control_C_CIL_ImpulseReaction_Field m_ReactionSettings;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineImpulseListener_Config source = (CameraMovement.Control_C_CinemachineImpulseListener_Config)sourceConfig;
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.Value));
            if(source.m_ChannelMask.IsUse) m_ChannelMask.Add(new MixItem<System.Int32>(id, priority, source.m_ChannelMask.Value));
            if(source.m_Gain.IsUse) m_Gain.Add(new MixItem<System.Single>(id, priority, source.m_Gain.Value));
            if(source.m_Use2DDistance.IsUse) m_Use2DDistance.Add(new MixItem<System.Boolean>(id, priority, source.m_Use2DDistance.Value));
            if(source.m_UseCameraSpace.IsUse) m_UseCameraSpace.Add(new MixItem<System.Boolean>(id, priority, source.m_UseCameraSpace.Value));
            m_ReactionSettings.AddByConfig(source.m_ReactionSettings, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineImpulseListener_Config source = (CameraMovement.Control_C_CinemachineImpulseListener_Config)sourceConfig;
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.Value));
            if(source.m_ChannelMask.IsUse) m_ChannelMask.Remove(new MixItem<System.Int32>(id, priority, source.m_ChannelMask.Value));
            if(source.m_Gain.IsUse) m_Gain.Remove(new MixItem<System.Single>(id, priority, source.m_Gain.Value));
            if(source.m_Use2DDistance.IsUse) m_Use2DDistance.Remove(new MixItem<System.Boolean>(id, priority, source.m_Use2DDistance.Value));
            if(source.m_UseCameraSpace.IsUse) m_UseCameraSpace.Remove(new MixItem<System.Boolean>(id, priority, source.m_UseCameraSpace.Value));
            m_ReactionSettings.RemoveByConfig(source.m_ReactionSettings, id, priority);
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineImpulseListener)targetObj;
            target.m_ApplyAfter = m_ApplyAfter.Value;
            target.m_ChannelMask = m_ChannelMask.Value;
            if (templateDict.ContainsKey(m_Gain.Id))
                target.m_Gain = templateDict[m_Gain.Id].Config.alertCurve.Evaluate(templateDict[m_Gain.Id].CostTime / templateDict[m_Gain.Id].Config.duration);
            target.m_Gain = m_Gain.Value;
            target.m_Use2DDistance = m_Use2DDistance.Value;
            target.m_UseCameraSpace = m_UseCameraSpace.Value;
            // 处理字段 m_ReactionSettings
            // 生成递归代码
            m_ReactionSettings.ControlCinemachine(target.m_ReactionSettings, templateDict);
        }
    }
}
