using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CameraMovement
{
    /// <summary>
    /// 用于标记上下文中每个成员的标识符
    /// </summary>
    public enum EContextMember
    {
        /// <summary>
        /// 空标记
        /// </summary>
        None,
        ZoomMax,
        ZoomMin,
    }
    
    /// <summary>
    /// 上下文会触发的事件
    /// </summary>
    public enum EContextEvent
    {
        /// <summary>
        /// 空标记
        /// </summary>
        None,
        /// <summary>
        /// 每帧触发的上下文事件
        /// </summary>
        Tick,
        /// <summary>
        /// 手动触发
        /// </summary>
        Invoke,
        /// &lt;summary&gt;
        /// 最大个数
        /// &lt;/summary&gt;
        Max,
    }

    /// <summary>
    /// 参数索引 用于事件参数和行为的解耦
    /// </summary>
    public enum EEventParamType
    {
        DirX,//水平方向
        DirY,//竖直方向
        Extent,//程度
        StartOrEnd,//是开始还是结束 1开始 0结束
        LastState,//上一个状态
        NewState,//新状态
    }

    
    
    /// <summary>
    /// 用于描述属性或者字段的标记 标记的属性会被视为需要暴露到上下文 传入的文本会替代原本存在的tooltip的属性内容（如果不存在将创建tooltip）
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ContextDescriptionAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">这个上下文的唯一标记</param>
        /// <param name="isReadOnly">是否只在读取上下文中暴露</param>
        /// <param name="description">鼠标悬浮时显示的描述文本</param>
        public ContextDescriptionAttribute(EContextMember token, bool isReadOnly, string description)
        {
            this.token = token;
            this.isReadOnly = isReadOnly;
            this.description = description;
        }

        public readonly EContextMember token;
        public readonly bool isReadOnly;
        public readonly string description;
    }
    
    /// <summary>
    /// 相机运镜数据区接口
    /// </summary>
    public interface ICameraMovementDataField
    {
        /// <summary>
        /// 添加配置数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="id"></param>
        /// <param name="priority"></param>
        public void AddByConfig(CameraMovementDataConfigBase source,int id,int priority);

        /// <summary>
        /// 移除配置数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="id"></param>
        /// <param name="priority"></param>
        public void RemoveByConfig(CameraMovementDataConfigBase source,int id,int priority);

        /// <summary>
        /// 移除所有控制数据
        /// </summary>
        public void RemoveAll();
    }
    
    /// <summary>
    /// 相机运镜数据区配置接口
    /// </summary>
    [Serializable]
    [SuffixLabel("@$value?.Description")]
    public abstract class CameraMovementDataConfigBase
    {
        public string Description;
        /// <summary>
        /// 作用于哪种上下文
        /// </summary>
        public abstract Type AttachDataField { get;}
    }

    /// <summary>
    /// 相机运镜数据区
    /// </summary>
    public class CameraMovementDataField : ICameraMovementDataField
    {
        [ContextDescription(EContextMember.ZoomMax, false, "牛逼")]
        public DataMixer<float> ZoomMax;
        [ContextDescription(EContextMember.ZoomMin, true, "牛逼")]
        public DataMixer<float> ZoomMin;
        [ContextDescription(EContextMember.ZoomMin, false, "牛逼")]
        public DataMixer<float> curZoom;

        public void AddByConfig(CameraMovementDataConfigBase source, int id, int priority)
        {
            if(source == null) return;
            var dataConfig = (Data_CM_CameraMovementDataField_Config)source;
            // if(dataConfig.ZoomMax.IsUse) ZoomMax.Add(new MixItem<float>(id, priority, dataConfig.ZoomMax.CalculatorExpression, dataConfig.ZoomMax.Value, dataConfig.ZoomMax.IsUse));
        }

        public void RemoveByConfig(CameraMovementDataConfigBase source, int id, int priority)
        {
            if(source == null) return;
            var dataConfig = (Data_CM_CameraMovementDataField_Config)source;
            // ZoomMax.Remove(new MixItem<float>(id, priority, dataConfig.ZoomMax.CalculatorExpression, dataConfig.ZoomMax.Value, dataConfig.ZoomMax.IsUse));
        }

        public void RemoveAll()
        {
            ZoomMax.RemoveAll();
        }
    }
}