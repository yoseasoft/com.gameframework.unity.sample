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

using UnityEngine;

namespace GameFramework.Sample
{
    /// <summary>
    /// 教程案例的基础配置，通过运行官方提供的案例来学习如何应用框架中的API及调度流程
    /// </summary>
    // [CreateAssetMenu(fileName = nameof(TutorialSettings), menuName = "Game Framework/Tutorial Settings")] // 创建后可以不再显示在右键菜单
    class TutorialSettings : ScriptableObject
    {
        // ----------------------------------------------------------------------------------------------------
        [Header("教程案例设置")]

        [NovaFramework.EnumLabelName("案例选项")]
        [Tooltip("通过选择教程示例，程序运行后将在对应的案例环境下进行启动")]
        public TutorialSampleType TutorialSampleType = TutorialSampleType.Unknown;

        /// <summary>
        /// TutorialSettings
        /// </summary>
        public static TutorialSettings Instance
        {
            get
            {
                TutorialSettings settings = Resources.Load<TutorialSettings>(nameof(TutorialSettings));
                if (settings == null)
                {
                    settings = CreateInstance<TutorialSettings>();
                    Debugger.Error("Could not found any TutorialSettings assets, please create one instance in resources directory.");
                }

                return settings;
            }
        }
    }
}
