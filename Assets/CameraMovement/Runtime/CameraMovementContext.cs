using System.Collections;
using System.Collections.Generic;

namespace CameraMovement
{
    public class CameraMovementContext
    {
        #region 字段

        /// <summary>
        /// 数据区
        /// </summary>
        /// <returns></returns>
        protected CameraMovementDataField dataField_;

        /// <summary>
        /// 标志哪个相机事件被触发
        /// </summary>
        public BitArray ContextEventBit;

        /// <summary>
        /// 标志哪个相机事件被触发
        /// </summary>
        public Dictionary<EContextEvent, Dictionary<EEventParamType, float>> CameraEventParamDict;

        #endregion

        #region 周期函数

        public void Init()
        {
            dataField_ = new CameraMovementDataField();
            ContextEventBit = new BitArray((int)EContextEvent.Max);
            CameraEventParamDict = new Dictionary<EContextEvent, Dictionary<EEventParamType, float>>()
            {
                { EContextEvent.Tick, new Dictionary<EEventParamType, float>() },
                { EContextEvent.Invoke, new Dictionary<EEventParamType, float>() }
            };
        }
        
        public void Tick()
        {
            ContextEventBit.Set((int)EContextEvent.Tick, true);
        }

        #endregion

        #region 外部函数

        public void Invoke()
        {
            ContextEventBit.Set((int)EContextEvent.Invoke, true);
        }

        public void ResetEvent()
        {
            ContextEventBit.SetAll(false);
        }
        
        /// <summary>
        /// 更新数据区通过数据区配置
        /// </summary>
        /// <param name="dataConfigBase"></param>
        public void AddConfigData(CameraMovementConfig dataConfigBase)
        {
            dataField_.AddByConfig(dataConfigBase.DataConfigBaseTemplate, dataConfigBase.id, dataConfigBase.priority);
        }

        /// <summary>
        /// 更新数据区通过数据区配置
        /// </summary>
        /// <param name="dataConfigBase"></param>
        public void RemoveConfigData(CameraMovementConfig dataConfigBase)
        {
            dataField_.RemoveByConfig(dataConfigBase.DataConfigBaseTemplate, dataConfigBase.id, dataConfigBase.priority);
        }

        /// <summary>
        /// 更新数据区通过数据区配置
        /// </summary>
        public void RemoveAllConfig()
        {
            dataField_.RemoveAll();
        }

        /// <summary>
        /// 获取上下文成员
        /// </summary>
        /// <param name="member"></param>
        public float GetContextMember(EContextMember member)
        {
            if (dataField_ is CameraMovementDataField dataField)
            {
                switch (member)
                {
                    case EContextMember.ZoomMax:
                        return dataField.ZoomMax.IsExpression ? dataField.ZoomMax.Value : dataField.ZoomMax.PrimitiveValue;
                    case EContextMember.ZoomMin:
                        return dataField.ZoomMin.IsExpression ? dataField.ZoomMin.Value : dataField.ZoomMin.PrimitiveValue;
                }
            }

            return 0;
        }
        
        #endregion
        
    }
}