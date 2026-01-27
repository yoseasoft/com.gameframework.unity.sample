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

using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameFramework.Sample.StateTransition
{
    /// <summary>
    /// 延迟激活
    /// </summary>
    internal class DelayActivationActivity : GameEngine.HFSM.StateActivity
    {
        public float seconds = 0.2f;

        public override async Task ActivateAsync(CancellationToken cancellationToken)
        {
            Debugger.Info("延时活动激活！");
            await Task.Delay(TimeSpan.FromSeconds(seconds), cancellationToken);

            await base.ActivateAsync(cancellationToken);
        }

        public override async Task DeactivateAsync(CancellationToken cancellationToken)
        {
            Debugger.Info("延时活动停止");
            await Task.Delay(TimeSpan.FromSeconds(seconds), cancellationToken);

            await base.DeactivateAsync(cancellationToken);
        }
    }

    /// <summary>
    /// 简单聊天
    /// </summary>
    internal class TalkAboutActivity : GameEngine.HFSM.StateActivity
    {
        public string enterMessage = null;
        public string exitMessage = null;

        public override async Task ActivateAsync(CancellationToken cancellationToken)
        {
            if (GameEngine.HFSM.StateActivityMode.Inactive != this.ActivityMode) return;

            this.ActivityMode = GameEngine.HFSM.StateActivityMode.Activating;
            Debugger.Info($"大喊：{enterMessage}");
            await Task.Yield();
            this.ActivityMode = GameEngine.HFSM.StateActivityMode.Active;
        }

        public override async Task DeactivateAsync(CancellationToken cancellationToken)
        {
            if (GameEngine.HFSM.StateActivityMode.Active != this.ActivityMode) return;

            this.ActivityMode = GameEngine.HFSM.StateActivityMode.Deactivating;
            Debugger.Info($"大喊：{exitMessage}");
            await Task.Yield();
            this.ActivityMode = GameEngine.HFSM.StateActivityMode.Inactive;
        }
    }
}
