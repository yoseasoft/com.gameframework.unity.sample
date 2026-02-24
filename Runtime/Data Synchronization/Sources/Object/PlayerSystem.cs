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

using System.Text;

namespace GameFramework.Sample.DataSynchronization
{
    /// <summary>
    /// 玩家对象逻辑类
    /// </summary>
    static class PlayerSystem
    {
        [GameEngine.OnAspectBeforeCall(GameEngine.AspectBehaviourType.Awake)]
        static void Awake(this Player self)
        {
        }

        [GameEngine.OnAspectBeforeCall(GameEngine.AspectBehaviourType.Start)]
        static void Start(this Player self)
        {
        }

        [GameEngine.OnAspectAfterCall(GameEngine.AspectBehaviourType.Destroy)]
        static void Destroy(this Player self)
        {
        }

        public static string ToPlayerString(this Player self)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[玩家对象]:{0},", self.ToSoldierString());

            InventoryComponent inventoryComponent = self.GetComponent<InventoryComponent>();
            sb.Append(@"背包={");
            for (int n = 0; null != inventoryComponent.items && n < inventoryComponent.items.Count; ++n)
            {
                InventoryComponent.ItemInfo item = inventoryComponent.items[n];

                if (n > 0) sb.Append(",");
                sb.AppendFormat("[{0},{1},{2},{3},{4}]", item.id, item.pos, item.quantity, item.using_time, item.last_used_time);
            }
            sb.Append(@"}");

            return sb.ToString();
        }
    }
}
