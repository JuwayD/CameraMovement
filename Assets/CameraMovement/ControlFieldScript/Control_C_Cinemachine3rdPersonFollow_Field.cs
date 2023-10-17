using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_Cinemachine3rdPersonFollow_Field :ICameraMovementControlField<Cinemachine.Cinemachine3rdPersonFollow>
    {
       public  Type AttachControlField => typeof(Cinemachine.Cinemachine3rdPersonFollow);

       [UnityEngine.TooltipAttribute("How responsively the camera tracks the target.  Each axis (camera-local) can have its own setting.  Value is the approximate time it takes the camera to catch up to the target's new position.  Smaller values give a more rigid effect, larger values give a squishier one")]
            public DataMixer <UnityEngine.Vector3> Damping;
       [UnityEngine.HeaderAttribute("Rig")]
           [UnityEngine.TooltipAttribute("Position of the shoulder pivot relative to the Follow target origin.  This offset is in target-local space")]
            public DataMixer <UnityEngine.Vector3> ShoulderOffset;
       [UnityEngine.TooltipAttribute("Vertical offset of the hand in relation to the shoulder.  Arm length will affect the follow target's screen position when the camera rotates vertically")]
            public DataMixer <System.Single> VerticalArmLength;
        public float VerticalArmLengthAlertInit;
        public float VerticalArmLengthDiff;
       [UnityEngine.TooltipAttribute("Specifies which shoulder (left, right, or in-between) the camera is on")]
            public DataMixer <System.Single> CameraSide;
        public float CameraSideAlertInit;
        public float CameraSideDiff;
       [UnityEngine.TooltipAttribute("How far behind the hand the camera will be placed")]
            public DataMixer <System.Single> CameraDistance;
        public float CameraDistanceAlertInit;
        public float CameraDistanceDiff;
       [UnityEngine.TooltipAttribute("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public DataMixer <System.String> IgnoreTag;
       [UnityEngine.TooltipAttribute("Specifies how close the camera can get to obstacles")]
            public DataMixer <System.Single> CameraRadius;
        public float CameraRadiusAlertInit;
        public float CameraRadiusDiff;
       [UnityEngine.TooltipAttribute("How gradually the camera moves to correct for occlusions.  Higher numbers will move the camera more gradually.")]
            public DataMixer <System.Single> DampingIntoCollision;
        public float DampingIntoCollisionAlertInit;
        public float DampingIntoCollisionDiff;
       [UnityEngine.TooltipAttribute("How gradually the camera returns to its normal position after having been corrected by the built-in collision resolution system.  Higher numbers will move the camera more gradually back to normal.")]
            public DataMixer <System.Single> DampingFromCollision;
        public float DampingFromCollisionAlertInit;
        public float DampingFromCollisionDiff;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.Cinemachine3rdPersonFollow target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config)sourceConfig;
            if(source.Damping.IsUse)
            {
                Damping.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.Damping.CalculatorExpression, source.Damping.Value, source.Damping.IsUse));
            }
            if(source.ShoulderOffset.IsUse)
            {
                ShoulderOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.ShoulderOffset.CalculatorExpression, source.ShoulderOffset.Value, source.ShoulderOffset.IsUse));
            }
            if(source.VerticalArmLength.IsUse)
            {
                VerticalArmLength.Add(new MixItem<System.Single>(id, priority, source.VerticalArmLength.CalculatorExpression, source.VerticalArmLength.Value, source.VerticalArmLength.IsUse));
               var targetValue = (VerticalArmLength.IsExpression ? VerticalArmLength.Value : VerticalArmLength.PrimitiveValue);
               VerticalArmLengthDiff = targetValue - target.VerticalArmLength;
               VerticalArmLengthAlertInit = target.VerticalArmLength - templateDict[VerticalArmLength.Id].Config.alertCurve.Evaluate(templateDict[VerticalArmLength.Id].CostTime / templateDict[VerticalArmLength.Id].Config.duration) * (VerticalArmLengthDiff);
            }
            if(source.CameraSide.IsUse)
            {
                CameraSide.Add(new MixItem<System.Single>(id, priority, source.CameraSide.CalculatorExpression, source.CameraSide.Value, source.CameraSide.IsUse));
               var targetValue = (CameraSide.IsExpression ? CameraSide.Value : CameraSide.PrimitiveValue);
               CameraSideDiff = targetValue - target.CameraSide;
               CameraSideAlertInit = target.CameraSide - templateDict[CameraSide.Id].Config.alertCurve.Evaluate(templateDict[CameraSide.Id].CostTime / templateDict[CameraSide.Id].Config.duration) * (CameraSideDiff);
            }
            if(source.CameraDistance.IsUse)
            {
                CameraDistance.Add(new MixItem<System.Single>(id, priority, source.CameraDistance.CalculatorExpression, source.CameraDistance.Value, source.CameraDistance.IsUse));
               var targetValue = (CameraDistance.IsExpression ? CameraDistance.Value : CameraDistance.PrimitiveValue);
               CameraDistanceDiff = targetValue - target.CameraDistance;
               CameraDistanceAlertInit = target.CameraDistance - templateDict[CameraDistance.Id].Config.alertCurve.Evaluate(templateDict[CameraDistance.Id].CostTime / templateDict[CameraDistance.Id].Config.duration) * (CameraDistanceDiff);
            }
            if(source.IgnoreTag.IsUse)
            {
                IgnoreTag.Add(new MixItem<System.String>(id, priority, source.IgnoreTag.CalculatorExpression, source.IgnoreTag.Value, source.IgnoreTag.IsUse));
            }
            if(source.CameraRadius.IsUse)
            {
                CameraRadius.Add(new MixItem<System.Single>(id, priority, source.CameraRadius.CalculatorExpression, source.CameraRadius.Value, source.CameraRadius.IsUse));
               var targetValue = (CameraRadius.IsExpression ? CameraRadius.Value : CameraRadius.PrimitiveValue);
               CameraRadiusDiff = targetValue - target.CameraRadius;
               CameraRadiusAlertInit = target.CameraRadius - templateDict[CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[CameraRadius.Id].CostTime / templateDict[CameraRadius.Id].Config.duration) * (CameraRadiusDiff);
            }
            if(source.DampingIntoCollision.IsUse)
            {
                DampingIntoCollision.Add(new MixItem<System.Single>(id, priority, source.DampingIntoCollision.CalculatorExpression, source.DampingIntoCollision.Value, source.DampingIntoCollision.IsUse));
               var targetValue = (DampingIntoCollision.IsExpression ? DampingIntoCollision.Value : DampingIntoCollision.PrimitiveValue);
               DampingIntoCollisionDiff = targetValue - target.DampingIntoCollision;
               DampingIntoCollisionAlertInit = target.DampingIntoCollision - templateDict[DampingIntoCollision.Id].Config.alertCurve.Evaluate(templateDict[DampingIntoCollision.Id].CostTime / templateDict[DampingIntoCollision.Id].Config.duration) * (DampingIntoCollisionDiff);
            }
            if(source.DampingFromCollision.IsUse)
            {
                DampingFromCollision.Add(new MixItem<System.Single>(id, priority, source.DampingFromCollision.CalculatorExpression, source.DampingFromCollision.Value, source.DampingFromCollision.IsUse));
               var targetValue = (DampingFromCollision.IsExpression ? DampingFromCollision.Value : DampingFromCollision.PrimitiveValue);
               DampingFromCollisionDiff = targetValue - target.DampingFromCollision;
               DampingFromCollisionAlertInit = target.DampingFromCollision - templateDict[DampingFromCollision.Id].Config.alertCurve.Evaluate(templateDict[DampingFromCollision.Id].CostTime / templateDict[DampingFromCollision.Id].Config.duration) * (DampingFromCollisionDiff);
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.Cinemachine3rdPersonFollow target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config)sourceConfig;
            if(source.Damping.IsUse)
            {
                Damping.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.Damping.CalculatorExpression, source.Damping.Value, source.Damping.IsUse));
            }
            if(source.ShoulderOffset.IsUse)
            {
                ShoulderOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.ShoulderOffset.CalculatorExpression, source.ShoulderOffset.Value, source.ShoulderOffset.IsUse));
            }
            if(source.VerticalArmLength.IsUse)
            {
                VerticalArmLength.Remove(new MixItem<System.Single>(id, priority, source.VerticalArmLength.CalculatorExpression, source.VerticalArmLength.Value, source.VerticalArmLength.IsUse));
               var targetValue = (VerticalArmLength.IsExpression ? VerticalArmLength.Value : VerticalArmLength.PrimitiveValue);
               VerticalArmLengthDiff = targetValue - target.VerticalArmLength;
               VerticalArmLengthAlertInit = target.VerticalArmLength - templateDict[VerticalArmLength.Id].Config.alertCurve.Evaluate(templateDict[VerticalArmLength.Id].CostTime / templateDict[VerticalArmLength.Id].Config.duration) * (VerticalArmLengthDiff);
            }
            if(source.CameraSide.IsUse)
            {
                CameraSide.Remove(new MixItem<System.Single>(id, priority, source.CameraSide.CalculatorExpression, source.CameraSide.Value, source.CameraSide.IsUse));
               var targetValue = (CameraSide.IsExpression ? CameraSide.Value : CameraSide.PrimitiveValue);
               CameraSideDiff = targetValue - target.CameraSide;
               CameraSideAlertInit = target.CameraSide - templateDict[CameraSide.Id].Config.alertCurve.Evaluate(templateDict[CameraSide.Id].CostTime / templateDict[CameraSide.Id].Config.duration) * (CameraSideDiff);
            }
            if(source.CameraDistance.IsUse)
            {
                CameraDistance.Remove(new MixItem<System.Single>(id, priority, source.CameraDistance.CalculatorExpression, source.CameraDistance.Value, source.CameraDistance.IsUse));
               var targetValue = (CameraDistance.IsExpression ? CameraDistance.Value : CameraDistance.PrimitiveValue);
               CameraDistanceDiff = targetValue - target.CameraDistance;
               CameraDistanceAlertInit = target.CameraDistance - templateDict[CameraDistance.Id].Config.alertCurve.Evaluate(templateDict[CameraDistance.Id].CostTime / templateDict[CameraDistance.Id].Config.duration) * (CameraDistanceDiff);
            }
            if(source.IgnoreTag.IsUse)
            {
                IgnoreTag.Remove(new MixItem<System.String>(id, priority, source.IgnoreTag.CalculatorExpression, source.IgnoreTag.Value, source.IgnoreTag.IsUse));
            }
            if(source.CameraRadius.IsUse)
            {
                CameraRadius.Remove(new MixItem<System.Single>(id, priority, source.CameraRadius.CalculatorExpression, source.CameraRadius.Value, source.CameraRadius.IsUse));
               var targetValue = (CameraRadius.IsExpression ? CameraRadius.Value : CameraRadius.PrimitiveValue);
               CameraRadiusDiff = targetValue - target.CameraRadius;
               CameraRadiusAlertInit = target.CameraRadius - templateDict[CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[CameraRadius.Id].CostTime / templateDict[CameraRadius.Id].Config.duration) * (CameraRadiusDiff);
            }
            if(source.DampingIntoCollision.IsUse)
            {
                DampingIntoCollision.Remove(new MixItem<System.Single>(id, priority, source.DampingIntoCollision.CalculatorExpression, source.DampingIntoCollision.Value, source.DampingIntoCollision.IsUse));
               var targetValue = (DampingIntoCollision.IsExpression ? DampingIntoCollision.Value : DampingIntoCollision.PrimitiveValue);
               DampingIntoCollisionDiff = targetValue - target.DampingIntoCollision;
               DampingIntoCollisionAlertInit = target.DampingIntoCollision - templateDict[DampingIntoCollision.Id].Config.alertCurve.Evaluate(templateDict[DampingIntoCollision.Id].CostTime / templateDict[DampingIntoCollision.Id].Config.duration) * (DampingIntoCollisionDiff);
            }
            if(source.DampingFromCollision.IsUse)
            {
                DampingFromCollision.Remove(new MixItem<System.Single>(id, priority, source.DampingFromCollision.CalculatorExpression, source.DampingFromCollision.Value, source.DampingFromCollision.IsUse));
               var targetValue = (DampingFromCollision.IsExpression ? DampingFromCollision.Value : DampingFromCollision.PrimitiveValue);
               DampingFromCollisionDiff = targetValue - target.DampingFromCollision;
               DampingFromCollisionAlertInit = target.DampingFromCollision - templateDict[DampingFromCollision.Id].Config.alertCurve.Evaluate(templateDict[DampingFromCollision.Id].CostTime / templateDict[DampingFromCollision.Id].Config.duration) * (DampingFromCollisionDiff);
            }
        }
        public void RemoveAll()
        {
            Damping.RemoveAll();
            ShoulderOffset.RemoveAll();
            VerticalArmLength.RemoveAll();
            CameraSide.RemoveAll();
            CameraDistance.RemoveAll();
            IgnoreTag.RemoveAll();
            CameraRadius.RemoveAll();
            DampingIntoCollision.RemoveAll();
            DampingFromCollision.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.Cinemachine3rdPersonFollow target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (VerticalArmLength.IsUse && templateDict.ContainsKey(VerticalArmLength.Id))
            {
                var targetValue = (VerticalArmLength.IsExpression ? VerticalArmLength.Value : VerticalArmLength.PrimitiveValue);
                target.VerticalArmLength = Mathf.Approximately(0, templateDict[VerticalArmLength.Id].Config.duration) ? targetValue : VerticalArmLengthAlertInit + templateDict[VerticalArmLength.Id].Config.alertCurve.Evaluate(templateDict[VerticalArmLength.Id].CostTime / templateDict[VerticalArmLength.Id].Config.duration) * VerticalArmLengthDiff;
            }
            if (CameraSide.IsUse && templateDict.ContainsKey(CameraSide.Id))
            {
                var targetValue = (CameraSide.IsExpression ? CameraSide.Value : CameraSide.PrimitiveValue);
                target.CameraSide = Mathf.Approximately(0, templateDict[CameraSide.Id].Config.duration) ? targetValue : CameraSideAlertInit + templateDict[CameraSide.Id].Config.alertCurve.Evaluate(templateDict[CameraSide.Id].CostTime / templateDict[CameraSide.Id].Config.duration) * CameraSideDiff;
            }
            if (CameraDistance.IsUse && templateDict.ContainsKey(CameraDistance.Id))
            {
                var targetValue = (CameraDistance.IsExpression ? CameraDistance.Value : CameraDistance.PrimitiveValue);
                target.CameraDistance = Mathf.Approximately(0, templateDict[CameraDistance.Id].Config.duration) ? targetValue : CameraDistanceAlertInit + templateDict[CameraDistance.Id].Config.alertCurve.Evaluate(templateDict[CameraDistance.Id].CostTime / templateDict[CameraDistance.Id].Config.duration) * CameraDistanceDiff;
            }
            if (IgnoreTag.IsUse) target.IgnoreTag = IgnoreTag.PrimitiveValue;
            if (CameraRadius.IsUse && templateDict.ContainsKey(CameraRadius.Id))
            {
                var targetValue = (CameraRadius.IsExpression ? CameraRadius.Value : CameraRadius.PrimitiveValue);
                target.CameraRadius = Mathf.Approximately(0, templateDict[CameraRadius.Id].Config.duration) ? targetValue : CameraRadiusAlertInit + templateDict[CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[CameraRadius.Id].CostTime / templateDict[CameraRadius.Id].Config.duration) * CameraRadiusDiff;
            }
            if (DampingIntoCollision.IsUse && templateDict.ContainsKey(DampingIntoCollision.Id))
            {
                var targetValue = (DampingIntoCollision.IsExpression ? DampingIntoCollision.Value : DampingIntoCollision.PrimitiveValue);
                target.DampingIntoCollision = Mathf.Approximately(0, templateDict[DampingIntoCollision.Id].Config.duration) ? targetValue : DampingIntoCollisionAlertInit + templateDict[DampingIntoCollision.Id].Config.alertCurve.Evaluate(templateDict[DampingIntoCollision.Id].CostTime / templateDict[DampingIntoCollision.Id].Config.duration) * DampingIntoCollisionDiff;
            }
            if (DampingFromCollision.IsUse && templateDict.ContainsKey(DampingFromCollision.Id))
            {
                var targetValue = (DampingFromCollision.IsExpression ? DampingFromCollision.Value : DampingFromCollision.PrimitiveValue);
                target.DampingFromCollision = Mathf.Approximately(0, templateDict[DampingFromCollision.Id].Config.duration) ? targetValue : DampingFromCollisionAlertInit + templateDict[DampingFromCollision.Id].Config.alertCurve.Evaluate(templateDict[DampingFromCollision.Id].CostTime / templateDict[DampingFromCollision.Id].Config.duration) * DampingFromCollisionDiff;
            }
        }
    }
}
