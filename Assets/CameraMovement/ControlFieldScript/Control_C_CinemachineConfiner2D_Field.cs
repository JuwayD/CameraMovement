using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineConfiner2D_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineConfiner2D);

       [UnityEngine.TooltipAttribute("Damping applied around corners to avoid jumps.  Higher numbers are more gradual.")]
            public DataMixer <System.Single> m_Damping;
       [UnityEngine.TooltipAttribute("To optimize computation and memory costs, set this to the largest view size that the camera is expected to have.  The confiner will not compute a polygon cache for frustum sizes larger than this.  This refers to the size in world units of the frustum at the confiner plane (for orthographic cameras, this is just the orthographic size).  If set to 0, then this parameter is ignored and a polygon cache will be calculated for all potential window sizes.")]
            public DataMixer <System.Single> m_MaxWindowSize;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineConfiner2D_Config source = (CameraMovement.Control_C_CinemachineConfiner2D_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value));
            if(source.m_MaxWindowSize.IsUse) m_MaxWindowSize.Add(new MixItem<System.Single>(id, priority, source.m_MaxWindowSize.CalculatorExpression, source.m_MaxWindowSize.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineConfiner2D_Config source = (CameraMovement.Control_C_CinemachineConfiner2D_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value));
            if(source.m_MaxWindowSize.IsUse) m_MaxWindowSize.Remove(new MixItem<System.Single>(id, priority, source.m_MaxWindowSize.CalculatorExpression, source.m_MaxWindowSize.Value));
        }
        public void RemoveAll()
        {
            m_Damping.RemoveAll();
            m_MaxWindowSize.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineConfiner2D)targetObj;
            if (templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * m_Damping.Value;
            target.m_Damping = (System.Single)m_Damping.Value;
            if (templateDict.ContainsKey(m_MaxWindowSize.Id))
                target.m_MaxWindowSize = templateDict[m_MaxWindowSize.Id].Config.alertCurve.Evaluate(templateDict[m_MaxWindowSize.Id].CostTime / templateDict[m_MaxWindowSize.Id].Config.duration) * m_MaxWindowSize.Value;
            target.m_MaxWindowSize = (System.Single)m_MaxWindowSize.Value;
        }
    }
}
