using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CBLC_Instruction_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlendListCamera.Instruction);

       [UnityEngine.TooltipAttribute("How long to wait (in seconds) before activating the next virtual camera in the list (if any)")]
            public DataMixer <System.Single> m_Hold;
       [UnityEngine.TooltipAttribute("How to blend to the next virtual camera in the list (if any)")]
        public Control_C_CinemachineBlendDefinition_Field m_Blend;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CBLC_Instruction_Config source = (CameraMovement.Control_C_CBLC_Instruction_Config)sourceConfig;
            if(source.m_Hold.IsUse) m_Hold.Add(new MixItem<System.Single>(id, priority, source.m_Hold.Value));
            m_Blend.AddByConfig(source.m_Blend, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CBLC_Instruction_Config source = (CameraMovement.Control_C_CBLC_Instruction_Config)sourceConfig;
            if(source.m_Hold.IsUse) m_Hold.Remove(new MixItem<System.Single>(id, priority, source.m_Hold.Value));
            m_Blend.RemoveByConfig(source.m_Blend, id, priority);
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineBlendListCamera.Instruction)targetObj;
            if (templateDict.ContainsKey(m_Hold.Id))
                target.m_Hold = templateDict[m_Hold.Id].Config.alertCurve.Evaluate(templateDict[m_Hold.Id].CostTime / templateDict[m_Hold.Id].Config.duration);
            target.m_Hold = m_Hold.Value;
            // 处理字段 m_Blend
            // 生成递归代码
            m_Blend.ControlCinemachine(target.m_Blend, templateDict);
        }
    }
}
