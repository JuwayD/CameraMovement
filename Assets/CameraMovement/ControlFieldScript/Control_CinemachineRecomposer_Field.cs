using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_CinemachineRecomposer_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(CinemachineRecomposer);

       [UnityEngine.TooltipAttribute("When to apply the adjustment")]
            public DataMixer <Cinemachine.CinemachineCore.Stage> m_ApplyAfter;
       [UnityEngine.TooltipAttribute("Tilt the camera by this much")]
            public DataMixer <System.Single> m_Tilt;
       [UnityEngine.TooltipAttribute("Pan the camera by this much")]
            public DataMixer <System.Single> m_Pan;
       [UnityEngine.TooltipAttribute("Roll the camera by this much")]
            public DataMixer <System.Single> m_Dutch;
       [UnityEngine.TooltipAttribute("Scale the zoom by this amount (normal = 1)")]
            public DataMixer <System.Single> m_ZoomScale;
       [UnityEngine.TooltipAttribute("Lowering this value relaxes the camera's attention to the Follow target (normal = 1)")]
            public DataMixer <System.Single> m_FollowAttachment;
       [UnityEngine.TooltipAttribute("Lowering this value relaxes the camera's attention to the LookAt target (normal = 1)")]
            public DataMixer <System.Single> m_LookAtAttachment;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_CinemachineRecomposer_Config source = (CameraMovement.Control_CinemachineRecomposer_Config)sourceConfig;
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.Value));
            if(source.m_Tilt.IsUse) m_Tilt.Add(new MixItem<System.Single>(id, priority, source.m_Tilt.Value));
            if(source.m_Pan.IsUse) m_Pan.Add(new MixItem<System.Single>(id, priority, source.m_Pan.Value));
            if(source.m_Dutch.IsUse) m_Dutch.Add(new MixItem<System.Single>(id, priority, source.m_Dutch.Value));
            if(source.m_ZoomScale.IsUse) m_ZoomScale.Add(new MixItem<System.Single>(id, priority, source.m_ZoomScale.Value));
            if(source.m_FollowAttachment.IsUse) m_FollowAttachment.Add(new MixItem<System.Single>(id, priority, source.m_FollowAttachment.Value));
            if(source.m_LookAtAttachment.IsUse) m_LookAtAttachment.Add(new MixItem<System.Single>(id, priority, source.m_LookAtAttachment.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_CinemachineRecomposer_Config source = (CameraMovement.Control_CinemachineRecomposer_Config)sourceConfig;
            if(source.m_ApplyAfter.IsUse) m_ApplyAfter.Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_ApplyAfter.Value));
            if(source.m_Tilt.IsUse) m_Tilt.Remove(new MixItem<System.Single>(id, priority, source.m_Tilt.Value));
            if(source.m_Pan.IsUse) m_Pan.Remove(new MixItem<System.Single>(id, priority, source.m_Pan.Value));
            if(source.m_Dutch.IsUse) m_Dutch.Remove(new MixItem<System.Single>(id, priority, source.m_Dutch.Value));
            if(source.m_ZoomScale.IsUse) m_ZoomScale.Remove(new MixItem<System.Single>(id, priority, source.m_ZoomScale.Value));
            if(source.m_FollowAttachment.IsUse) m_FollowAttachment.Remove(new MixItem<System.Single>(id, priority, source.m_FollowAttachment.Value));
            if(source.m_LookAtAttachment.IsUse) m_LookAtAttachment.Remove(new MixItem<System.Single>(id, priority, source.m_LookAtAttachment.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (CinemachineRecomposer)targetObj;
            target.m_ApplyAfter = m_ApplyAfter.Value;
            if (templateDict.ContainsKey(m_Tilt.Id))
                target.m_Tilt = templateDict[m_Tilt.Id].Config.alertCurve.Evaluate(templateDict[m_Tilt.Id].CostTime / templateDict[m_Tilt.Id].Config.duration);
            target.m_Tilt = m_Tilt.Value;
            if (templateDict.ContainsKey(m_Pan.Id))
                target.m_Pan = templateDict[m_Pan.Id].Config.alertCurve.Evaluate(templateDict[m_Pan.Id].CostTime / templateDict[m_Pan.Id].Config.duration);
            target.m_Pan = m_Pan.Value;
            if (templateDict.ContainsKey(m_Dutch.Id))
                target.m_Dutch = templateDict[m_Dutch.Id].Config.alertCurve.Evaluate(templateDict[m_Dutch.Id].CostTime / templateDict[m_Dutch.Id].Config.duration);
            target.m_Dutch = m_Dutch.Value;
            if (templateDict.ContainsKey(m_ZoomScale.Id))
                target.m_ZoomScale = templateDict[m_ZoomScale.Id].Config.alertCurve.Evaluate(templateDict[m_ZoomScale.Id].CostTime / templateDict[m_ZoomScale.Id].Config.duration);
            target.m_ZoomScale = m_ZoomScale.Value;
            if (templateDict.ContainsKey(m_FollowAttachment.Id))
                target.m_FollowAttachment = templateDict[m_FollowAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_FollowAttachment.Id].CostTime / templateDict[m_FollowAttachment.Id].Config.duration);
            target.m_FollowAttachment = m_FollowAttachment.Value;
            if (templateDict.ContainsKey(m_LookAtAttachment.Id))
                target.m_LookAtAttachment = templateDict[m_LookAtAttachment.Id].Config.alertCurve.Evaluate(templateDict[m_LookAtAttachment.Id].CostTime / templateDict[m_LookAtAttachment.Id].Config.duration);
            target.m_LookAtAttachment = m_LookAtAttachment.Value;
        }
    }
}
