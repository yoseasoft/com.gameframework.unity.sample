/// -------------------------------------------------------------------------------
/// Copyright (C) 2024 - 2025, Hurley, Independent Studio.
/// Copyright (C) 2025 - 2026, Hainan Yuanyou Information Technology Co., Ltd. Guangzhou Branch
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// -------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;

namespace GameFramework.Sample
{
    /// 游戏层提供的调试对象类
    static partial class Debugger
    {
        /// <summary>
        /// 基于常规模式下的日志输出接口
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="message">日志内容</param>
        public static void LoopInfo(object obj, object message)
        {
            if (IsLoopCallPassedWithOnceTime(obj)) Info(message);
        }

        /// <summary>
        /// 基于常规模式下的日志输出接口
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="message">日志内容</param>
        public static void LoopInfo(object obj, string message)
        {
            if (IsLoopCallPassedWithOnceTime(obj)) Info(message);
        }

        /// <summary>
        /// 基于常规模式下的日志输出接口
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="format">日志格式内容</param>
        /// <param name="args">日志格式化参数</param>
        public static void LoopInfo(object obj, string format, params object[] args)
        {
            if (IsLoopCallPassedWithOnceTime(obj)) Info(format, args);
        }

        #region 检测循环调用是否已触发的接口函数

        private static IDictionary<int, int> GameEntityUpdateCallStat;

        /// <summary>
        /// 一次性更新调度逻辑控制可行状态检测
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <returns>若满足一次性刷新调度条件则返回true，否则返回false</returns>
        private static bool IsLoopCallPassedWithOnceTime(object obj)
        {
            if (!GlobalMacros.LoopOutputEnabled)
            {
                return false;
            }

            if (null == GameEntityUpdateCallStat)
            {
                GameEntityUpdateCallStat = new Dictionary<int, int>();
            }

            int hash = obj.GetHashCode();
            int frame = NovaEngine.Timestamp.FrameCount;

            if (false == GameEntityUpdateCallStat.TryGetValue(hash, out int v))
            {
                GameEntityUpdateCallStat.Add(hash, frame);
                return true;
            }

            if (v == frame)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
