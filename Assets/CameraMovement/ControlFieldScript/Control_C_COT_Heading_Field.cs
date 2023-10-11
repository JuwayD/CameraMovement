using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_COT_Heading_Field :ICameraMovementControlField<Cinemachine.CinemachineOrbitalTransposer.Heading>
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
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_COT_Heading_Config source = (CameraMovement.Control_C_COT_Heading_Config)sourceConfig;
            if(source.m_Definition.IsUse) m_Definition.Add(new MixItem<Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition>(id, priority, source.m_Definition.CalculatorExpression, source.m_Definition.Value, source.m_Definition.IsUse));
            if(source.m_VelocityFilterStrength.IsUse) m_VelocityFilterStrength.Add(new MixItem<System.Int32>(id, priority, source.m_VelocityFilterStrength.CalculatorExpression, source.m_VelocityFilterStrength.Value, source.m_VelocityFilterStrength.IsUse));
            if(source.m_Bias.IsUse) m_Bias.Add(new MixItem<System.Single>(id, priority, source.m_Bias.CalculatorExpression, source.m_Bias.Value, source.m_Bias.IsUse));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_COT_Heading_Config source = (CameraMovement.Control_C_COT_Heading_Config)sourceConfig;
            if(source.m_Definition.IsUse) m_Definition.Remove(new MixItem<Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition>(id, priority, source.m_Definition.CalculatorExpression, source.m_Definition.Value, source.m_Definition.IsUse));
            if(source.m_VelocityFilterStrength.IsUse) m_VelocityFilterStrength.Remove(new MixItem<System.Int32>(id, priority, source.m_VelocityFilterStrength.CalculatorExpression, source.m_VelocityFilterStrength.Value, source.m_VelocityFilterStrength.IsUse));
            if(source.m_Bias.IsUse) m_Bias.Remove(new MixItem<System.Single>(id, priority, source.m_Bias.CalculatorExpression, source.m_Bias.Value, source.m_Bias.IsUse));
        }
        public void RemoveAll()
        {
            m_Definition.RemoveAll();
            m_VelocityFilterStrength.RemoveAll();
            m_Bias.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineOrbitalTransposer.Heading target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Definition.IsUse) target.m_Definition = m_Definition.IsExpression ? (Cinemachine.CinemachineOrbitalTransposer.Heading.HeadingDefinition)m_Definition.Value :m_Definition.PrimitiveValue;
            if (m_VelocityFilterStrength.IsUse) target.m_VelocityFilterStrength = m_VelocityFilterStrength.IsExpression ? (System.Int32)m_VelocityFilterStrength.Value :m_VelocityFilterStrength.PrimitiveValue;
            if (m_Bias.IsUse && templateDict.ContainsKey(m_Bias.Id))
                target.m_Bias = Mathf.Approximately(0, templateDict[m_Bias.Id].Config.duration) ? (m_Bias.IsExpression ? m_Bias.Value : m_Bias.PrimitiveValue) : templateDict[m_Bias.Id].Config.alertCurve.Evaluate(templateDict[m_Bias.Id].CostTime / templateDict[m_Bias.Id].Config.duration) * (m_Bias.IsExpression ? m_Bias.Value : m_Bias.PrimitiveValue);
        }
    }
}
