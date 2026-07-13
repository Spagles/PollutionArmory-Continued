# PollutionArmory[Continued] (RimWorld 1.6) / PollutionArmory[Continued]（RimWorld 1.6）

Independently maintained RimWorld 1.6 continuation of POP's original
`Pollution weapon[Abandoned]`, released with permission from the original
author. This is not the original project.

Original mod / 原 Mod:
https://steamcommunity.com/sharedfiles/filedetails/?id=3276521515

Original author / 原作者: 顶针的马 / POP
https://steamcommunity.com/id/yzywd

Workshop continuation / 续作创意工坊:
https://steamcommunity.com/sharedfiles/filedetails/?id=3763065626

Source repository / 源码仓库:
https://github.com/Juggernautsst/PollutionArmory-Continued

It requires the Biotech DLC. The original `packageId` and all Def names are
preserved so existing mod lists and saves can resolve the same content. Do not
enable this together with the original mod.

这是 POP 原作 `Pollution weapon[Abandoned]` 的独立维护 RimWorld 1.6 续作，
已获原作者许可发布，并非原项目。

需要 Biotech DLC。原有 `packageId` 和全部 Def 名称均被保留，以兼容已有 Mod
列表和存档。请勿与原 Mod 同时启用。

## Build / 构建

With a .NET SDK installed:

安装 .NET SDK 后运行：

```powershell
dotnet build .\Source\PollutionWeapons.csproj -c Release `
  -p:RimWorldDir="D:\steam\steamapps\common\RimWorld"
```

The compiled assembly is written to `1.6/Assemblies/Pollution_weapons.dll`.

编译后的程序集位于 `1.6/Assemblies/Pollution_weapons.dll`。

## Combat Extended / Combat Extended

This continuation includes optional Combat Extended (CE) 1.6 compatibility. It
loads only when the `CETeam.CombatExtended` package is active; load CE before
this mod. It adds dedicated ammunition, CE projectiles, and CE ability
ballistics. The base assembly does not reference or bundle CE.

本续作已包含可选的 Combat Extended（CE）1.6 兼容。仅当
`CETeam.CombatExtended` 已启用时才会加载；请将 CE 排在本 Mod 前。它会增加专属
弹药、CE 投射物和 CE 能力弹道。基础程序集不会引用或附带 CE。

Build the CE-only companion assembly with the local CE installation available:

在本机存在 CE 安装时，使用以下命令构建仅 CE 使用的附属程序集：

```powershell
dotnet build .\Source\PollutionWeapons.CE.csproj -c Release `
  -p:RimWorldDir="D:\steam\steamapps\common\RimWorld" `
  -p:CombatExtendedAssemblyPath="D:\steam\steamapps\workshop\content\294100\2890901044\Assemblies\CombatExtended.dll"
```

This writes `1.6/CE/Assemblies/PollutionWeapons.CE.dll`. Do not copy
`CombatExtended.dll`, Harmony, or game assemblies into this mod.

该命令会生成 `1.6/CE/Assemblies/PollutionWeapons.CE.dll`。不要将
`CombatExtended.dll`、Harmony 或游戏程序集复制到本 Mod 中。

## Test / 测试

Without CE, enable the local mod after Core and Biotech. With CE, load CE before
this mod. Start with a new save and check Def loading, crafting, reloading,
weapon abilities, explosions, pollution, hive spawning, and save/load during a
delayed residue explosion before using an existing save.

不使用 CE 时，在 Core 和 Biotech 之后启用本地 Mod；使用 CE 时，将 CE 放在本
Mod 之前。先用新存档检查 Def 加载、制造、装填、武器技能、爆炸、污染、虫巢
生成，以及延迟污染残留期间的存读档，再测试已有存档。
