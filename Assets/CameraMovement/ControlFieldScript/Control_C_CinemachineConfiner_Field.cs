using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineConfiner_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineConfiner);

       [UnityEngine.TooltipAttribute("The confiner can operate using a 2D bounding shape or a 3D bounding volume")]
            public DataMixer <Cinemachine.CinemachineConfiner.Mode> m_ConfineMode;
       [UnityEngine.TooltipAttribute("If camera is orthographic, screen edges will be confined to the volume.  If not checked, then only the camera center will be confined")]
            public DataMixer <System.Boolean> m_ConfineScreenEdges;
       [UnityEngine.TooltipAttribute("How gradually to return the camera to the bounding volume if it goes beyond the borders.  Higher numbers are more gradual.")]
            public DataMixer <System.Single> m_Damping;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineConfiner2D_Config source = (CameraMovement.Control_C_CinemachineConfiner2D_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineConfiner2D_Config source = (CameraMovement.Control_C_CinemachineConfiner2D_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineConfiner)targetObj;
            target.m_ConfineMode = m_ConfineMode.Value;
            target.m_ConfineScreenEdges = m_ConfineScreenEdges.Value;
            if (templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration);
            target.m_Damping = m_Damping.Value;
        }
    }
}
