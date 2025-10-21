# CustomKeycardAPI

该插件*不是*开箱即用的，它仅作为概念验证。

This plugin is *not* ready to use out of the box; it is only a proof of concept.

---

该插件的基本原理是：

1. 从某个后端(例如数据库)获取玩家自定义钥匙卡的数据
2. 当玩家捡起物品和收到物品(重生装备或指令给予)时，扫描玩家背包，替换普通钥匙卡为自定义钥匙卡。
3. 添加914对自定义钥匙卡的处理能力

**其中第1步不是开箱即用的，你可能需要重写 `RefreshDataBase()` 即其相关的逻辑，使插件能够从你的后端中读取数据（这也意味着你需要自行编写一个后端，用于存储玩家自定义数据，以及向插件提供数据；你可能也需要自行编写一个前端，例如一个网页，使玩家可以自定义钥匙卡）。**

对平衡性的潜在影响：[自定义钥匙卡无法通过扔向读卡器开门](https://git.scpslgame.com/northwood-qa/scpsl-bug-reporting/-/issues/1625)，对 SCP-3114 不利.

---

The basic principle of this plugin is as follows:

1. Retrieve player-customized keycard data from a backend (e.g., a database).
2. When a player picks up or receives an item (through loadout or admin command), scan the player’s inventory and replace normal keycards with customized ones.
3. Add support for SCP-914 processing of customized keycards.

**Step 1 is not ready to use out of the box. You may need to rewrite `RefreshDataBase()` and its related logic to make the plugin read data from your backend. This also means you’ll need to implement your own backend to store user-customized data and provide it to the plugin. You may also want to create a frontend (for example, a web page) that allows players to customize their keycards.**

Potential impact on game balance: [Custom keycards cannot open doors by being thrown at card readers](https://git.scpslgame.com/northwood-qa/scpsl-bug-reporting/-/issues/1625), which is disadvantageous to SCP-3114.
