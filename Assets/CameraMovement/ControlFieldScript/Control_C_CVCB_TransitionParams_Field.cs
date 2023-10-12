using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CVCB_TransitionParams_Field :ICameraMovementControlField<Cinemachine.CinemachineVirtualCameraBase.TransitionParams>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineVirtualCameraBase.TransitionParams);

       [UnityEngine.TooltipAttribute("Hint for blending positions to and from this virtual camera")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.BlendHint> m_BlendHint;
       [UnityEngine.TooltipAttribute("When this virtual camera goes Live, attempt to force the position to be the same as the current position of the Unity Camera")]
            public DataMixer <System.Boolean> m_InheritPosition;
       [UnityEngine.TooltipAttribute("This event fires when the virtual camera goes Live")]
        public Control_C_CB_VcamActivatedEvent_Field m_OnCameraLive;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineVirtualCameraBase.TransitionParams target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CVCB_TransitionParams_Config source = (CameraMovement.Control_C_CVCB_TransitionParams_Config)sourceConfig;
                if(source.m_BlendHint.IsUse)
                {
                    m_BlendHint.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.BlendHint>(id, priority, source.m_BlendHint.CalculatorExpression, source.m_BlendHint.Value, source.m_BlendHint.IsUse));
                }
                if(source.m_InheritPosition.IsUse)
                {
                    m_InheritPosition.Add(new MixItem<System.Boolean>(id, priority, source.m_InheritPosition.CalculatorExpression, source.m_InheritPosition.Value, source.m_InheritPosition.IsUse));
                }
                if(source.m_OnCameraLive != null && m_OnCameraLive == null) m_OnCameraLive = new Control_C_CB_VcamActivatedEvent_Field();
            m_OnCameraLive?.AddByConfig(source.m_OnCameraLive, id, priority, ref target.m_OnCameraLive);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineVirtualCameraBase.TransitionParams target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CVCB_TransitionParams_Config source = (CameraMovement.Control_C_CVCB_TransitionParams_Config)sourceConfig;
                if(source.m_BlendHint.IsUse)
                {
                    m_BlendHint.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.BlendHint>(id, priority, source.m_BlendHint.CalculatorExpression, source.m_BlendHint.Value, source.m_BlendHint.IsUse));
                }
                if(source.m_InheritPosition.IsUse)
                {
                    m_InheritPosition.Remove(new MixItem<System.Boolean>(id, priority, source.m_InheritPosition.CalculatorExpression, source.m_InheritPosition.Value, source.m_InheritPosition.IsUse));
                }
            m_OnCameraLive?.RemoveByConfig(source.m_OnCameraLive, id, priority, ref target.m_OnCameraLive);
        }
        public void RemoveAll()
        {
            m_BlendHint.RemoveAll();
            m_InheritPosition.RemoveAll();
            m_OnCameraLive?.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineVirtualCameraBase.TransitionParams target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_BlendHint.IsUse) target.m_BlendHint = m_BlendHint.IsExpression ? (Cinemachine.CinemachineVirtualCameraBase.BlendHint)m_BlendHint.Value :m_BlendHint.PrimitiveValue;
            if (m_InheritPosition.IsUse) target.m_InheritPosition = m_InheritPosition.IsExpression ? !Mathf.Approximately(m_InheritPosition.Value, 0) : m_InheritPosition.PrimitiveValue;
            // 处理字段 m_OnCameraLive
            // 生成递归代码
            m_OnCameraLive?.ControlCinemachine(ref target.m_OnCameraLive, templateDict);
        }
    }
}
