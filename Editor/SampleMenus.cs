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

using UnityEditor;

namespace Game.Framework.Sample.Editor
{
    /// <summary>
    /// 演示案例的菜单项
    /// </summary>
    static class SampleMenus
    {
        const string MenuName_EnableTutorialMode = @"Nova/Tutorial/Enable Tutorial Mode";
        const string MenuName_DisplayTutorialCases = @"Nova/Tutorial/Display Tutorial Cases";

        [InitializeOnLoadMethod]
        static void InitializeOnLoad()
        {
            // 在编辑器启动时调用
            EditorApplication.delayCall += InitMenuState;
        }

        static void InitMenuState()
        {
            bool isTutorialEnabled = TutorialConfigure.IsTutorialEnabled;
            Menu.SetChecked(MenuName_EnableTutorialMode, isTutorialEnabled);
        }

        [MenuItem(MenuName_EnableTutorialMode)]
        static void OnTutorialEnabled()
        {
            bool isEnabled = TutorialConfigure.IsTutorialEnabled;
            isEnabled = !isEnabled;
            TutorialConfigure.IsTutorialEnabled = isEnabled;
            Menu.SetChecked(MenuName_EnableTutorialMode, isEnabled);
        }

        [MenuItem(MenuName_DisplayTutorialCases)]
        static void OnDisplayTutorialCases()
        {
            string[] sampleNames = System.Enum.GetNames(typeof(TutorialSampleType));
            for (int n = 0; n < sampleNames.Length; ++n)
            {
                string path = $"{MenuName_DisplayTutorialCases}/{sampleNames[n]}";
                MenuItem menu = new MenuItem(path);
            }
        }
    }
}
