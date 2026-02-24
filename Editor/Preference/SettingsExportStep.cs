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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using GameFramework.Sample;

namespace GameFramework.Editor.Sample
{
    /// <summary>
    /// 配置导出的安装步骤对象类
    /// </summary>
    public class SettingsExportStep : NovaFramework.Editor.Preference.InstallationStep
    {
        const string TutorialSettingsAssetUrl = @"Assets/Resources/TutorialSettings.asset";

        public void Install(Action onComplete = null)
        {
            Debug.Log("PostInstallConfigurationExporter: 开始执行安装后配置资产创建");

            CreateAndSaveSettingAsset();
            Debug.Log("已创建 TutorialSettings.asset");

            Debug.Log("CreateConfigurationStep: 配置资产创建完成");

            // 调用完成回调
            onComplete?.Invoke();
        }

        /// <summary>
        /// 创建并保存‘AppSettings’资产文件
        /// </summary>
        private TutorialSettings CreateAndSaveSettingAsset()
        {
            return NovaFramework.Editor.AssetDatabaseUtils.CreateScriptableObjectAsset<TutorialSettings>(TutorialSettingsAssetUrl, (asset) =>
            {
                asset.TutorialSampleType = TutorialSampleType.Unknown;
            });
        }

        public void Uninstall(Action onComplete = null)
        {
            Debug.Log("PostInstallConfigurationExporter: 执行卸载操作");

            // 卸载逻辑（如果需要）
            AssetDatabase.DeleteAsset(TutorialSettingsAssetUrl);

            // 调用完成回调
            onComplete?.Invoke();
        }
    }
}
