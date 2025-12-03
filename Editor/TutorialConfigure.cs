/// -------------------------------------------------------------------------------
/// Sample Editor Module for GameEngine Framework
///
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

namespace Game.Framework.Sample.Editor
{
    /// <summary>
    /// 演示案例的配置管理类，用于管理案例的配置信息
    /// </summary>
    static class TutorialConfigure
    {
        const string DataLabelForTutorialEnabledStatus = @"Game.Framework.Sample-TutorialEnabled";
        const string DataLabelForTutorialSampleType = @"Game.Framework.Sample-TutorialSampleType";

        public static bool IsTutorialEnabled
        {
            get => NovaEngine.Editor.UserSettings.GetBool(DataLabelForTutorialEnabledStatus);
            set => NovaEngine.Editor.UserSettings.SetBool(DataLabelForTutorialEnabledStatus, value);
        }

        public static int TutorialSampleType
        {
            get => NovaEngine.Editor.UserSettings.GetInt(DataLabelForTutorialSampleType);
            set => NovaEngine.Editor.UserSettings.SetInt(DataLabelForTutorialSampleType, value);
        }
    }
}
