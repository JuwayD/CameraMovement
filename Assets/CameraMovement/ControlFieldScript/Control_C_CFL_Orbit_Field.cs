using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CFL_Orbit_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFreeLook.Orbit);

        public DataMixer <System.Single> m_Height;
        public DataMixer <System.Single> m_Radius;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CFL_Orbit_Config source = (CameraMovement.Control_C_CFL_Orbit_Config)sourceConfig;
            if(source.m_Height.IsUse) m_Height.Add(new MixItem<System.Single>(id, priority, source.m_Height.CalculatorExpression, source.m_Height.Value));
            if(source.m_Radius.IsUse) m_Radius.Add(new MixItem<System.Single>(id, priority, source.m_Radius.CalculatorExpression, source.m_Radius.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CFL_Orbit_Config source = (CameraMovement.Control_C_CFL_Orbit_Config)sourceConfig;
            if(source.m_Height.IsUse) m_Height.Remove(new MixItem<System.Single>(id, priority, source.m_Height.CalculatorExpression, source.m_Height.Value));
            if(source.m_Radius.IsUse) m_Radius.Remove(new MixItem<System.Single>(id, priority, source.m_Radius.CalculatorExpression, source.m_Radius.Value));
        }
        public void RemoveAll()
        {
            m_Height.RemoveAll();
            m_Radius.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineFreeLook.Orbit)targetObj;
            if (templateDict.ContainsKey(m_Height.Id))
                target.m_Height = templateDict[m_Height.Id].Config.alertCurve.Evaluate(templateDict[m_Height.Id].CostTime / templateDict[m_Height.Id].Config.duration) * m_Height.Value;
            target.m_Height = (System.Single)m_Height.Value;
            if (templateDict.ContainsKey(m_Radius.Id))
                target.m_Radius = templateDict[m_Radius.Id].Config.alertCurve.Evaluate(templateDict[m_Radius.Id].CostTime / templateDict[m_Radius.Id].Config.duration) * m_Radius.Value;
            target.m_Radius = (System.Single)m_Radius.Value;
        }
    }
}
