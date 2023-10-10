using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CVCB_TransitionParams_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineVirtualCameraBase.TransitionParams);

       [UnityEngine.TooltipAttribute("Hint for blending positions to and from this virtual camera")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.BlendHint> m_BlendHint;
       [UnityEngine.TooltipAttribute("When this virtual camera goes Live, attempt to force the position to be the same as the current position of the Unity Camera")]
            public DataMixer <System.Boolean> m_InheritPosition;
       [UnityEngine.TooltipAttribute("This event fires when the virtual camera goes Live")]
        public Control_C_CB_VcamActivatedEvent_Field m_OnCameraLive;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CVCB_TransitionParams_Config source = (CameraMovement.Control_C_CVCB_TransitionParams_Config)sourceConfig;
            if(source.m_BlendHint.IsUse) m_BlendHint.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.BlendHint>(id, priority, source.m_BlendHint.CalculatorExpression, source.m_BlendHint.Value));
            if(source.m_InheritPosition.IsUse) m_InheritPosition.Add(new MixItem<System.Boolean>(id, priority, source.m_InheritPosition.CalculatorExpression, source.m_InheritPosition.Value));
            m_OnCameraLive.AddByConfig(source.m_OnCameraLive, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CVCB_TransitionParams_Config source = (CameraMovement.Control_C_CVCB_TransitionParams_Config)sourceConfig;
            if(source.m_BlendHint.IsUse) m_BlendHint.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.BlendHint>(id, priority, source.m_BlendHint.CalculatorExpression, source.m_BlendHint.Value));
            if(source.m_InheritPosition.IsUse) m_InheritPosition.Remove(new MixItem<System.Boolean>(id, priority, source.m_InheritPosition.CalculatorExpression, source.m_InheritPosition.Value));
            m_OnCameraLive.RemoveByConfig(source.m_OnCameraLive, id, priority);
        }
        public void RemoveAll()
        {
            m_BlendHint.RemoveAll();
            m_InheritPosition.RemoveAll();
            m_OnCameraLive.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineVirtualCameraBase.TransitionParams)targetObj;
            target.m_BlendHint = (Cinemachine.CinemachineVirtualCameraBase.BlendHint)m_BlendHint.Value;
            target.m_InheritPosition = !Mathf.Approximately(m_InheritPosition.Value, 0);
            // 处理字段 m_OnCameraLive
            // 生成递归代码
            m_OnCameraLive.ControlCinemachine(target.m_OnCameraLive, templateDict);
        }
    }
}
