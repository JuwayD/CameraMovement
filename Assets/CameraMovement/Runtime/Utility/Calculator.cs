using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace CameraMovement
{
    public enum ECalculatorOperator
    {
        None = 0, // 非法操作符
        LeftParenthesis,
        RightParenthesis,
        Big = 40,
        Small,
        BigOrEqual,
        SmallOrEqual,
        Equal,
        Unequal,
        And = 60,
        Not,
        Or,
        Add = 100,
        Subtract,
        Multiply = 200,
        Divide,
    }

    public class Calculator
    {
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="contextEnum"></param>
        /// <returns></returns>
        public static float Calculate(CalculatorItem[] expression,int contextEnum = 0)
        {
            //将中缀表达式转换成后缀表达式
            List<CalculatorItem> suffixExpression = ParseSuffixExpression(expression);

            return CalculatePoland(suffixExpression, contextEnum);
        }

        /// <summary>
        /// 计算波兰表达式
        /// </summary>
        /// <param name="suffixExpression"></param>
        /// <param name="contextEnum"></param>
        /// <returns></returns>
        public static float CalculatePoland(CalculatorItem[] suffixExpression,int contextEnum = 0)
        {
            //创建栈
            Stack<CalculatorItem> stack = new Stack<CalculatorItem>();

            //循环遍历
            for (int i = 0; i < suffixExpression.Length; i++)
            {
                var item = suffixExpression[i];
                //如果是上下文则获取上下文
                if (item.Operator == ECalculatorOperator.None && item.ContextMember != EContextMember.None) //"\\d+"
                {
                    item.Value = CameraMovementStateMachine.Instance.Context.GetContextMember(item.ContextMember, item.ContextMember == (EContextMember)contextEnum);
                    stack.Push(item);
                }
                else if (item.Operator == ECalculatorOperator.None && item.ContextMember == EContextMember.None)
                {
                    //如果是立即数直接入栈
                    stack.Push(item);
                }
                //如果是操作符
                else
                {
                    CalculatorItem result = default(CalculatorItem);

                    //出栈两个数字，并运算，再入栈
                    CalculatorItem num1 = stack.Pop();

                    if (item.Operator == ECalculatorOperator.Not)
                    {
                        result.Value = Mathf.Approximately(num1.Value, 0.0f) ? 1.0f : 0.0f;
                        stack.Push(result);
                        continue;
                    }

                    CalculatorItem num2 = stack.Pop();


                    if (item.Operator == ECalculatorOperator.Add)
                    {
                        result.Value = num2.Value + num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.Multiply)
                    {
                        result.Value = num2.Value * num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.Divide)
                    {
                        result.Value = num2.Value / num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.Subtract)
                    {
                        result.Value = num2.Value - num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.And)
                    {
                        result.Value = !Mathf.Approximately(num1.Value, 0.0f) && !Mathf.Approximately(num2.Value, 0.0f)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Or)
                    {
                        result.Value = !Mathf.Approximately(num1.Value, 0.0f) || !Mathf.Approximately(num2.Value, 0.0f)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Equal)
                    {
                        result.Value = Mathf.Approximately(num1.Value, num2.Value)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Unequal)
                    {
                        result.Value = !Mathf.Approximately(num1.Value, num2.Value)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Big)
                    {
                        result.Value = num1.Value > num2.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.BigOrEqual)
                    {
                        result.Value = num1.Value >= num2.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Small)
                    {
                        result.Value = num1.Value < num2.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.SmallOrEqual)
                    {
                        result.Value = num1.Value <= num2.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else
                    {
                        throw new Exception("无法识别符号");
                    }

                    stack.Push(result);
                }
            }

            //最后把stack中数据返回
            return stack.Pop().Value;
        }

        private static Stack<CalculatorItem> polandStack = new Stack<CalculatorItem>();
        /// <summary>
        /// 计算波兰表达式
        /// </summary>
        /// <param name="suffixExpression"></param>
        /// <param name="contextEnum"></param>
        /// <returns></returns>
        public static float CalculatePoland(List<CalculatorItem> suffixExpression,int contextEnum = 0)
        {
            //创建栈
            polandStack.Clear();
            
            //循环遍历
            for (int i = 0; i < suffixExpression.Count; i++)
            {
                var item = suffixExpression[i];
                //如果是上下文则获取上下文
                if (item.Operator == ECalculatorOperator.None && item.ContextMember != EContextMember.None) //"\\d+"
                {
                    item.Value = CameraMovementStateMachine.Instance.Context.GetContextMember(item.ContextMember, item.ContextMember == (EContextMember)contextEnum);
                    polandStack.Push(item);
                }
                else if (item.Operator == ECalculatorOperator.None && item.ContextMember == EContextMember.None)
                {
                    //如果是立即数直接入栈
                    polandStack.Push(item);
                }
                //如果是操作符
                else
                {
                    CalculatorItem result = default(CalculatorItem);

                    //出栈两个数字，并运算，再入栈
                    CalculatorItem num1 = polandStack.Pop();

                    if (item.Operator == ECalculatorOperator.Not)
                    {
                        result.Value = Mathf.Approximately(num1.Value, 0.0f) ? 1.0f : 0.0f;
                        polandStack.Push(result);
                        continue;
                    }

                    CalculatorItem num2 = polandStack.Pop();


                    if (item.Operator == ECalculatorOperator.Add)
                    {
                        result.Value = num2.Value + num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.Multiply)
                    {
                        result.Value = num2.Value * num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.Divide)
                    {
                        result.Value = num2.Value / num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.Subtract)
                    {
                        result.Value = num2.Value - num1.Value;
                    }
                    else if (item.Operator == ECalculatorOperator.And)
                    {
                        result.Value = !Mathf.Approximately(num1.Value, 0.0f) && !Mathf.Approximately(num2.Value, 0.0f)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Or)
                    {
                        result.Value = !Mathf.Approximately(num1.Value, 0.0f) || !Mathf.Approximately(num2.Value, 0.0f)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Equal)
                    {
                        result.Value = Mathf.Approximately(num1.Value, num2.Value)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Unequal)
                    {
                        result.Value = !Mathf.Approximately(num1.Value, num2.Value)
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Big)
                    {
                        result.Value = num2.Value > num1.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.BigOrEqual)
                    {
                        result.Value = num2.Value >= num1.Value 
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.Small)
                    {
                        result.Value = num2.Value < num1.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else if (item.Operator == ECalculatorOperator.SmallOrEqual)
                    {
                        result.Value = num2.Value <= num1.Value
                            ? 1.0f
                            : 0.0f;
                    }
                    else
                    {
                        throw new Exception("无法识别符号");
                    }

                    polandStack.Push(result);
                }
            }

            //最后把stack中数据返回
            return polandStack.Pop().Value;
        }
        
        /// <summary>
        /// 中缀转后缀
        /// </summary>
        /// <param name="expressionList"></param>
        /// <returns></returns>
        public static List<CalculatorItem> ParseSuffixExpression(CalculatorItem[] expressionList)
        {
            //存储中间结果
            List<CalculatorItem> list = new List<CalculatorItem>();
            //符号栈
            Stack<CalculatorItem> stack = new Stack<CalculatorItem>();

            foreach (var item in expressionList)
            {
                //如果是数字直接加入list
                if (item is { Operator: ECalculatorOperator.None})
                {
                    list.Add(item);
                }
                //如果是左括号，直接入符号栈
                else if (item.Operator == ECalculatorOperator.LeftParenthesis)
                {
                    stack.Push(item);
                }
                //如果是右括号
                else if (item.Operator == ECalculatorOperator.RightParenthesis)
                {
                    //依次弹出stack栈顶的运算符，并存入list,直到遇到左括号为止
                    while (stack.Peek().Operator != ECalculatorOperator.LeftParenthesis)
                    {
                        list.Add(stack.Pop());
                    }

                    //将(也出栈
                    stack.Pop();
                }
                //如果是*/+-
                else
                {
                    //循环判断item的优先级小于或者等于stack栈顶运算符,这里每20算一个优先级梯度即 0 - 19优先级一样 20 - 39 优先级一样，将stack栈顶的运算符出栈并加入到list中
                    while (stack.Count != 0 && ((int)stack.Peek().Operator / 20) >= ((int)item.Operator / 20))
                    {
                        list.Add(stack.Pop());
                    }

                    //将item入栈
                    stack.Push(item);
                }
            }

            //将stack剩余的运算符依次入list
            while (stack.Count != 0)
            {
                list.Add(stack.Pop());
            }

            return list;
        }

    }

}