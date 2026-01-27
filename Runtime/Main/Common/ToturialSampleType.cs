/// -------------------------------------------------------------------------------
/// Copyright (C) 2024 - 2025, Hurley, Independent Studio.
/// Copyright (C) 2025, Hainan Yuanyou Information Technology Co., Ltd. Guangzhou Branch
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

using UnityEngine;

namespace GameFramework.Sample
{
    /// <summary>
    /// 教程示例的类型定义
    /// </summary>
    internal enum TutorialSampleType : int
    {
        [Header("未知")]
        Unknown = 0,

        [Header("文本格式化")]
        TextFormat,

        [Header("符号解析")]
        SymbolParser,

        [Header("构建动态调用")]
        DynamicInvokeGenerator,

        [Header("控制反转")]
        InversionOfControl,

        [Header("对象生命周期")]
        ObjectLifecycle,

        [Header("转发通知")]
        DispatchCall,

        [Header("状态转换")]
        StateTransition,

        [Header("依赖注入")]
        DependencyInject,

        [Header("配置表达式")]
        ConfigureExpression,

        [Header("性能分析")]
        PerformanceAnalysis,
    }
}
