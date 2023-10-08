using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_COT_Heading_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineOrbitalTransposer.Heading);

       [UnityEngine.TooltipAttribute("How 'forward' is defined.  The camera will be placed by default behind the target.  PositionDelta will consider 'forward' to be the direction in which the target is moving.")]
            public DataMixer <Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition> m_Definition;
       [UnityEngine.TooltipAttribute("Size of the velocity sampling window for target heading filter.  This filters out irregularities in the target's movement.  Used only if deriving heading from target's movement (PositionDelta or Velocity)")]
            public DataMixer <System.Int32> m_VelocityFilterStrength;
       [UnityEngine.TooltipAttribute("Where the camera is placed when the X-axis value is zero.  This is a rotation in degrees around the Y axis.  When this value is 0, the camera will be placed behind the target.  Nonzero offsets will rotate the zero position around the target.")]
            public DataMixer <System.Single> m_Bias;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_COT_Heading_Config source = (CameraMovement.Control_C_COT_Heading_Config)sourceConfig;
            if(source.m_Definition.IsUse) m_Definition.Add(new MixItem<Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition>(id, priority, source.m_Definition.Value));
            if(source.m_VelocityFilterStrength.IsUse) m_VelocityFilterStrength.Add(new MixItem<System.Int32>(id, priority, source.m_VelocityFilterStrength.Value));
            if(source.m_Bias.IsUse) m_Bias.Add(new MixItem<System.Single>(id, priority, source.m_Bias.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_COT_Heading_Config source = (CameraMovement.Control_C_COT_Heading_Config)sourceConfig;
            if(source.m_Definition.IsUse) m_Definition.Remove(new MixItem<Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition>(id, priority, source.m_Definition.Value));
            if(source.m_VelocityFilterStrength.IsUse) m_VelocityFilterStrength.Remove(new MixItem<System.Int32>(id, priority, source.m_VelocityFilterStrength.Value));
            if(source.m_Bias.IsUse) m_Bias.Remove(new MixItem<System.Single>(id, priority, source.m_Bias.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineOrbitalTransposer.Heading)targetObj;
            target.m_Definition = m_Definition.Value;
            target.m_VelocityFilterStrength = m_VelocityFilterStrength.Value;
            if (templateDict.ContainsKey(m_Bias.Id))
                target.m_Bias = templateDict[m_Bias.Id].Config.alertCurve.Evaluate(templateDict[m_Bias.Id].CostTime / templateDict[m_Bias.Id].Config.duration);
            target.m_Bias = m_Bias.Value;
        }
    }
}
