using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineBlendDefinition_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlendDefinition);

       [UnityEngine.TooltipAttribute("Shape of the blend curve")]
            public DataMixer <Cinemachine.CinemachineBlendDefinition.Style> m_Style;
       [UnityEngine.TooltipAttribute("Duration of the blend, in seconds")]
            public DataMixer <System.Single> m_Time;
        public DataMixer <UnityEngine.AnimationCurve> m_CustomCurve;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendDefinition_Config source = (CameraMovement.Control_C_CinemachineBlendDefinition_Config)sourceConfig;
            if(source.m_Style.IsUse) m_Style.Add(new MixItem<Cinemachine.CinemachineBlendDefinition.Style>(id, priority, source.m_Style.Value));
            if(source.m_Time.IsUse) m_Time.Add(new MixItem<System.Single>(id, priority, source.m_Time.Value));
            if(source.m_CustomCurve.IsUse) m_CustomCurve.Add(new MixItem<UnityEngine.AnimationCurve>(id, priority, source.m_CustomCurve.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendDefinition_Config source = (CameraMovement.Control_C_CinemachineBlendDefinition_Config)sourceConfig;
            if(source.m_Style.IsUse) m_Style.Remove(new MixItem<Cinemachine.CinemachineBlendDefinition.Style>(id, priority, source.m_Style.Value));
            if(source.m_Time.IsUse) m_Time.Remove(new MixItem<System.Single>(id, priority, source.m_Time.Value));
            if(source.m_CustomCurve.IsUse) m_CustomCurve.Remove(new MixItem<UnityEngine.AnimationCurve>(id, priority, source.m_CustomCurve.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineBlendDefinition)targetObj;
            target.m_Style = m_Style.Value;
            if (templateDict.ContainsKey(m_Time.Id))
                target.m_Time = templateDict[m_Time.Id].Config.alertCurve.Evaluate(templateDict[m_Time.Id].CostTime / templateDict[m_Time.Id].Config.duration);
            target.m_Time = m_Time.Value;
        }
    }
}
