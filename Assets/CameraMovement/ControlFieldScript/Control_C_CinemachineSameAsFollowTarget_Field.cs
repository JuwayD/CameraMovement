using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineSameAsFollowTarget_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineSameAsFollowTarget);

       [UnityEngine.TooltipAttribute("How much time it takes for the aim to catch up to the target's rotation")]
            public DataMixer <System.Single> m_Damping;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config source = (CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config source = (CameraMovement.Control_C_CinemachineSameAsFollowTarget_Config)sourceConfig;
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineSameAsFollowTarget)targetObj;
            if (templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration);
            target.m_Damping = m_Damping.Value;
        }
    }
}
