using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_Cinemachine3rdPersonFollow_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.Cinemachine3rdPersonFollow);

       [UnityEngine.TooltipAttribute("How responsively the camera tracks the target.  Each axis (camera-local) can have its own setting.  Value is the approximate time it takes the camera to catch up to the target's new position.  Smaller values give a more rigid effect, larger values give a squishier one")]
            public DataMixer <UnityEngine.Vector3> Damping;
       [UnityEngine.HeaderAttribute("Rig")]
           [UnityEngine.TooltipAttribute("Position of the shoulder pivot relative to the Follow target origin.  This offset is in target-local space")]
            public DataMixer <UnityEngine.Vector3> ShoulderOffset;
       [UnityEngine.TooltipAttribute("Vertical offset of the hand in relation to the shoulder.  Arm length will affect the follow target's screen position when the camera rotates vertically")]
            public DataMixer <System.Single> VerticalArmLength;
       [UnityEngine.TooltipAttribute("Specifies which shoulder (left, right, or in-between) the camera is on")]
            public DataMixer <System.Single> CameraSide;
       [UnityEngine.TooltipAttribute("How far behind the hand the camera will be placed")]
            public DataMixer <System.Single> CameraDistance;
       [UnityEngine.TooltipAttribute("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public DataMixer <System.String> IgnoreTag;
       [UnityEngine.TooltipAttribute("Specifies how close the camera can get to obstacles")]
            public DataMixer <System.Single> CameraRadius;
       [UnityEngine.TooltipAttribute("How gradually the camera moves to correct for occlusions.  Higher numbers will move the camera more gradually.")]
            public DataMixer <System.Single> DampingIntoCollision;
       [UnityEngine.TooltipAttribute("How gradually the camera returns to its normal position after having been corrected by the built-in collision resolution system.  Higher numbers will move the camera more gradually back to normal.")]
            public DataMixer <System.Single> DampingFromCollision;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config)sourceConfig;
            if(source.Damping.IsUse) Damping.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.Damping.CalculatorExpression, source.Damping.Value));
            if(source.ShoulderOffset.IsUse) ShoulderOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.ShoulderOffset.CalculatorExpression, source.ShoulderOffset.Value));
            if(source.VerticalArmLength.IsUse) VerticalArmLength.Add(new MixItem<System.Single>(id, priority, source.VerticalArmLength.CalculatorExpression, source.VerticalArmLength.Value));
            if(source.CameraSide.IsUse) CameraSide.Add(new MixItem<System.Single>(id, priority, source.CameraSide.CalculatorExpression, source.CameraSide.Value));
            if(source.CameraDistance.IsUse) CameraDistance.Add(new MixItem<System.Single>(id, priority, source.CameraDistance.CalculatorExpression, source.CameraDistance.Value));
            if(source.IgnoreTag.IsUse) IgnoreTag.Add(new MixItem<System.String>(id, priority, source.IgnoreTag.CalculatorExpression, source.IgnoreTag.Value));
            if(source.CameraRadius.IsUse) CameraRadius.Add(new MixItem<System.Single>(id, priority, source.CameraRadius.CalculatorExpression, source.CameraRadius.Value));
            if(source.DampingIntoCollision.IsUse) DampingIntoCollision.Add(new MixItem<System.Single>(id, priority, source.DampingIntoCollision.CalculatorExpression, source.DampingIntoCollision.Value));
            if(source.DampingFromCollision.IsUse) DampingFromCollision.Add(new MixItem<System.Single>(id, priority, source.DampingFromCollision.CalculatorExpression, source.DampingFromCollision.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonFollow_Config)sourceConfig;
            if(source.Damping.IsUse) Damping.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.Damping.CalculatorExpression, source.Damping.Value));
            if(source.ShoulderOffset.IsUse) ShoulderOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.ShoulderOffset.CalculatorExpression, source.ShoulderOffset.Value));
            if(source.VerticalArmLength.IsUse) VerticalArmLength.Remove(new MixItem<System.Single>(id, priority, source.VerticalArmLength.CalculatorExpression, source.VerticalArmLength.Value));
            if(source.CameraSide.IsUse) CameraSide.Remove(new MixItem<System.Single>(id, priority, source.CameraSide.CalculatorExpression, source.CameraSide.Value));
            if(source.CameraDistance.IsUse) CameraDistance.Remove(new MixItem<System.Single>(id, priority, source.CameraDistance.CalculatorExpression, source.CameraDistance.Value));
            if(source.IgnoreTag.IsUse) IgnoreTag.Remove(new MixItem<System.String>(id, priority, source.IgnoreTag.CalculatorExpression, source.IgnoreTag.Value));
            if(source.CameraRadius.IsUse) CameraRadius.Remove(new MixItem<System.Single>(id, priority, source.CameraRadius.CalculatorExpression, source.CameraRadius.Value));
            if(source.DampingIntoCollision.IsUse) DampingIntoCollision.Remove(new MixItem<System.Single>(id, priority, source.DampingIntoCollision.CalculatorExpression, source.DampingIntoCollision.Value));
            if(source.DampingFromCollision.IsUse) DampingFromCollision.Remove(new MixItem<System.Single>(id, priority, source.DampingFromCollision.CalculatorExpression, source.DampingFromCollision.Value));
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
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.Cinemachine3rdPersonFollow)targetObj;
        }
    }
}
