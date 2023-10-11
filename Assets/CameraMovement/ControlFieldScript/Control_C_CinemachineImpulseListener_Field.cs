using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineImpulseListener_Field :ICameraMovementControlField<Cinemachine.CinemachineImpulseListener>
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
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineImpulseListener_Config source = (CameraMovement.Control_C_CinemachineImpulseListener_Config)sourceConfig;
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value, source.m_ApplyAfter.IsUse));
            if(source.m_ChannelMask.IsUse) m_ChannelMask.Add(new MixItem<System.Int32>(id, priority, source.m_ChannelMask.CalculatorExpression, source.m_ChannelMask.Value, source.m_ChannelMask.IsUse));
            if(source.m_Gain.IsUse) m_Gain.Add(new MixItem<System.Single>(id, priority, source.m_Gain.CalculatorExpression, source.m_Gain.Value, source.m_Gain.IsUse));
            if(source.m_Use2DDistance.IsUse) m_Use2DDistance.Add(new MixItem<System.Boolean>(id, priority, source.m_Use2DDistance.CalculatorExpression, source.m_Use2DDistance.Value, source.m_Use2DDistance.IsUse));
            if(source.m_UseCameraSpace.IsUse) m_UseCameraSpace.Add(new MixItem<System.Boolean>(id, priority, source.m_UseCameraSpace.CalculatorExpression, source.m_UseCameraSpace.Value, source.m_UseCameraSpace.IsUse));
                if(source.m_ReactionSettings != null && m_ReactionSettings == null) m_ReactionSettings = new Control_C_CIL_ImpulseReaction_Field();
            m_ReactionSettings?.AddByConfig(source.m_ReactionSettings, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineImpulseListener_Config source = (CameraMovement.Control_C_CinemachineImpulseListener_Config)sourceConfig;
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.CalculatorExpression, source.m_ApplyAfter.Value, source.m_ApplyAfter.IsUse));
            if(source.m_ChannelMask.IsUse) m_ChannelMask.Remove(new MixItem<System.Int32>(id, priority, source.m_ChannelMask.CalculatorExpression, source.m_ChannelMask.Value, source.m_ChannelMask.IsUse));
            if(source.m_Gain.IsUse) m_Gain.Remove(new MixItem<System.Single>(id, priority, source.m_Gain.CalculatorExpression, source.m_Gain.Value, source.m_Gain.IsUse));
            if(source.m_Use2DDistance.IsUse) m_Use2DDistance.Remove(new MixItem<System.Boolean>(id, priority, source.m_Use2DDistance.CalculatorExpression, source.m_Use2DDistance.Value, source.m_Use2DDistance.IsUse));
            if(source.m_UseCameraSpace.IsUse) m_UseCameraSpace.Remove(new MixItem<System.Boolean>(id, priority, source.m_UseCameraSpace.CalculatorExpression, source.m_UseCameraSpace.Value, source.m_UseCameraSpace.IsUse));
            m_ReactionSettings?.RemoveByConfig(source.m_ReactionSettings, id, priority);
        }
        public void RemoveAll()
        {
            m_ApplyAfter.RemoveAll();
            m_ChannelMask.RemoveAll();
            m_Gain.RemoveAll();
            m_Use2DDistance.RemoveAll();
            m_UseCameraSpace.RemoveAll();
            m_ReactionSettings?.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineImpulseListener target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_ApplyAfter.IsUse) target.m_ApplyAfter = m_ApplyAfter.IsExpression ? (Cinemachine.CinemachineCore.Stage)m_ApplyAfter.Value :m_ApplyAfter.PrimitiveValue;
            if (m_ChannelMask.IsUse) target.m_ChannelMask = m_ChannelMask.IsExpression ? (System.Int32)m_ChannelMask.Value :m_ChannelMask.PrimitiveValue;
            if (m_Gain.IsUse && templateDict.ContainsKey(m_Gain.Id))
                target.m_Gain = Mathf.Approximately(0, templateDict[m_Gain.Id].Config.duration) ? (m_Gain.IsExpression ? m_Gain.Value : m_Gain.PrimitiveValue) : templateDict[m_Gain.Id].Config.alertCurve.Evaluate(templateDict[m_Gain.Id].CostTime / templateDict[m_Gain.Id].Config.duration) * (m_Gain.IsExpression ? m_Gain.Value : m_Gain.PrimitiveValue);
            if (m_Use2DDistance.IsUse) target.m_Use2DDistance = m_Use2DDistance.IsExpression ? !Mathf.Approximately(m_Use2DDistance.Value, 0) : m_Use2DDistance.PrimitiveValue;
            if (m_UseCameraSpace.IsUse) target.m_UseCameraSpace = m_UseCameraSpace.IsExpression ? !Mathf.Approximately(m_UseCameraSpace.Value, 0) : m_UseCameraSpace.PrimitiveValue;
            // 处理字段 m_ReactionSettings
            // 生成递归代码
            m_ReactionSettings?.ControlCinemachine(ref target.m_ReactionSettings, templateDict);
        }
    }
}
