using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CBS_CustomBlend_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlenderSettings.CustomBlend);

       [UnityEngine.TooltipAttribute("When blending from this camera")]
            public DataMixer <System.String> m_From;
       [UnityEngine.TooltipAttribute("When blending to this camera")]
            public DataMixer <System.String> m_To;
       [UnityEngine.TooltipAttribute("Blend curve definition")]
        public Control_C_CinemachineBlendDefinition_Field m_Blend;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CBS_CustomBlend_Config source = (CameraMovement.Control_C_CBS_CustomBlend_Config)sourceConfig;
            if(source.m_From.IsUse) m_From.Add(new MixItem<System.String>(id, priority, source.m_From.Value));
            if(source.m_To.IsUse) m_To.Add(new MixItem<System.String>(id, priority, source.m_To.Value));
            m_Blend.AddByConfig(source.m_Blend, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CBS_CustomBlend_Config source = (CameraMovement.Control_C_CBS_CustomBlend_Config)sourceConfig;
            if(source.m_From.IsUse) m_From.Remove(new MixItem<System.String>(id, priority, source.m_From.Value));
            if(source.m_To.IsUse) m_To.Remove(new MixItem<System.String>(id, priority, source.m_To.Value));
            m_Blend.RemoveByConfig(source.m_Blend, id, priority);
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineBlenderSettings.CustomBlend)targetObj;
            target.m_From = m_From.Value;
            target.m_To = m_To.Value;
            // 处理字段 m_Blend
            // 生成递归代码
            m_Blend.ControlCinemachine(target.m_Blend, templateDict);
        }
    }
}
