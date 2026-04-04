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

namespace GameFramework.Sample.DataSynchronization
{
    /// <summary>
    /// 玩家对象逻辑类
    /// </summary>
    static class PlayerSystem
    {
        [OnAwake]
        static void Awake(this Player self)
        {
        }

        [OnStart]
        static void Start(this Player self)
        {
        }

        [OnDestroy]
        static void Destroy(this Player self)
        {
        }

        [OnInput(GameEngine.VirtualKeyCode.Keypad1, GameEngine.InputOperationType.Released)]
        static void OnAlpha1Click(this Player self, GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            self.GetComponent<IdentityComponent>().objectName = "yukie";
        }

        [OnInput(GameEngine.VirtualKeyCode.Keypad2, GameEngine.InputOperationType.Released)]
        static void OnAlpha2Click(this Player self, GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            self.GetComponent<AttributeComponent>().health = 10;
        }

        [OnReplicate("player.inventory.item", GameEngine.ReplicateAnnounceType.Changed)]
        static void OnPlayerChangedNotify(string tags, GameEngine.ReplicateAnnounceType announceType)
        {
            Debugger.Info("??????????????????");
        }

        [OnReplicate("player.skill", GameEngine.ReplicateAnnounceType.Changed)]
        static void OnPlayerSkillChangedNotify(string tags, GameEngine.ReplicateAnnounceType announceType)
        {
            Debugger.Info("!!!!!!!!!!!!!!!!!!!!");
        }

        [OnReplicate(typeof(Player), "player.inventory.item", GameEngine.ReplicateAnnounceType.Changed)]
        static void OnPlayerChangedEachEveryoneNotify(Player player, string tags, GameEngine.ReplicateAnnounceType announceType)
        {
            Debugger.Info("?????????????????? player = {%s}", player.ToString());
        }

        [OnReplicate("player.inventory.item", GameEngine.ReplicateAnnounceType.Changed)]
        static void OnPlayerItemChangedBySelfNotify(this Player self, string tags, GameEngine.ReplicateAnnounceType announceType)
        {
            Debugger.Info("~~~~~~~~~~~~~~~~~~ player = {%s}", self.ToString());
        }

        [OnReplicate("player.object_name", GameEngine.ReplicateAnnounceType.Changed)]
        static void OnPlayerIdentityNameChanged(this Player self, string tags, GameEngine.ReplicateAnnounceType announceType)
        {
            Debugger.Info("玩家对象【{%d}】名称被改变！", self.uid);
        }

        [OnReplicate("player.attribute.health", GameEngine.ReplicateAnnounceType.Changed)]
        static void OnPlayerAttributeHealthChanged(this Player self, string tags, GameEngine.ReplicateAnnounceType announceType)
        {
            Debugger.Info("玩家对象【{%d}】生命值被改变！", self.uid);
        }
    }
}
