using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CTD_AutoDolly_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineTrackedDolly.AutoDolly);

       [UnityEngine.TooltipAttribute("If checked, will enable automatic dolly, which chooses a path position that is as close as possible to the Follow target.  Note: this can have significant performance impact")]
            public DataMixer <System.Boolean> m_Enabled;
       [UnityEngine.TooltipAttribute("Offset, in current position units, from the closest point on the path to the follow target")]
            public DataMixer <System.Single> m_PositionOffset;
       [UnityEngine.TooltipAttribute("Search up to this many waypoints on either side of the current position.  Use 0 for Entire path.")]
            public DataMixer <System.Int32> m_SearchRadius;
       [UnityEngine.TooltipAttribute("We search between waypoints by dividing the segment into this many straight pieces.  he higher the number, the more accurate the result, but performance is proportionally slower for higher numbers")]
            public DataMixer <System.Int32> m_SearchResolution;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CTD_AutoDolly_Config source = (CameraMovement.Control_C_CTD_AutoDolly_Config)sourceConfig;
            if(source.m_Enabled.IsUse) m_Enabled.Add(new MixItem<System.Boolean>(id, priority, source.m_Enabled.Value));
            if(source.m_PositionOffset.IsUse) m_PositionOffset.Add(new MixItem<System.Single>(id, priority, source.m_PositionOffset.Value));
            if(source.m_SearchRadius.IsUse) m_SearchRadius.Add(new MixItem<System.Int32>(id, priority, source.m_SearchRadius.Value));
            if(source.m_SearchResolution.IsUse) m_SearchResolution.Add(new MixItem<System.Int32>(id, priority, source.m_SearchResolution.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CTD_AutoDolly_Config source = (CameraMovement.Control_C_CTD_AutoDolly_Config)sourceConfig;
            if(source.m_Enabled.IsUse) m_Enabled.Remove(new MixItem<System.Boolean>(id, priority, source.m_Enabled.Value));
            if(source.m_PositionOffset.IsUse) m_PositionOffset.Remove(new MixItem<System.Single>(id, priority, source.m_PositionOffset.Value));
            if(source.m_SearchRadius.IsUse) m_SearchRadius.Remove(new MixItem<System.Int32>(id, priority, source.m_SearchRadius.Value));
            if(source.m_SearchResolution.IsUse) m_SearchResolution.Remove(new MixItem<System.Int32>(id, priority, source.m_SearchResolution.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineTrackedDolly.AutoDolly)targetObj;
            target.m_Enabled = m_Enabled.Value;
            if (templateDict.ContainsKey(m_PositionOffset.Id))
                target.m_PositionOffset = templateDict[m_PositionOffset.Id].Config.alertCurve.Evaluate(templateDict[m_PositionOffset.Id].CostTime / templateDict[m_PositionOffset.Id].Config.duration);
            target.m_PositionOffset = m_PositionOffset.Value;
            target.m_SearchRadius = m_SearchRadius.Value;
            target.m_SearchResolution = m_SearchResolution.Value;
        }
    }
}
