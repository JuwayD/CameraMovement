using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineFollowZoom_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFollowZoom);

       [UnityEngine.TooltipAttribute("The shot width to maintain, in world units, at target distance.")]
            public DataMixer <System.Single> m_Width;
       [UnityEngine.TooltipAttribute("Increase this value to soften the aggressiveness of the follow-zoom.  Small numbers are more responsive, larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_Damping;
       [UnityEngine.TooltipAttribute("Lower limit for the FOV that this behaviour will generate.")]
            public DataMixer <System.Single> m_MinFOV;
       [UnityEngine.TooltipAttribute("Upper limit for the FOV that this behaviour will generate.")]
            public DataMixer <System.Single> m_MaxFOV;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFollowZoom_Config source = (CameraMovement.Control_C_CinemachineFollowZoom_Config)sourceConfig;
            if(source.m_Width.IsUse) m_Width.Add(new MixItem<System.Single>(id, priority, source.m_Width.Value));
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.Value));
            if(source.m_MinFOV.IsUse) m_MinFOV.Add(new MixItem<System.Single>(id, priority, source.m_MinFOV.Value));
            if(source.m_MaxFOV.IsUse) m_MaxFOV.Add(new MixItem<System.Single>(id, priority, source.m_MaxFOV.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFollowZoom_Config source = (CameraMovement.Control_C_CinemachineFollowZoom_Config)sourceConfig;
            if(source.m_Width.IsUse) m_Width.Remove(new MixItem<System.Single>(id, priority, source.m_Width.Value));
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.Value));
            if(source.m_MinFOV.IsUse) m_MinFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MinFOV.Value));
            if(source.m_MaxFOV.IsUse) m_MaxFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MaxFOV.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineFollowZoom)targetObj;
            if (templateDict.ContainsKey(m_Width.Id))
                target.m_Width = templateDict[m_Width.Id].Config.alertCurve.Evaluate(templateDict[m_Width.Id].CostTime / templateDict[m_Width.Id].Config.duration);
            target.m_Width = m_Width.Value;
            if (templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration);
            target.m_Damping = m_Damping.Value;
            if (templateDict.ContainsKey(m_MinFOV.Id))
                target.m_MinFOV = templateDict[m_MinFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinFOV.Id].CostTime / templateDict[m_MinFOV.Id].Config.duration);
            target.m_MinFOV = m_MinFOV.Value;
            if (templateDict.ContainsKey(m_MaxFOV.Id))
                target.m_MaxFOV = templateDict[m_MaxFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaxFOV.Id].CostTime / templateDict[m_MaxFOV.Id].Config.duration);
            target.m_MaxFOV = m_MaxFOV.Value;
        }
    }
}
