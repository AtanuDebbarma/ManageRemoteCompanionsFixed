# Manage Remote Companions Fix

A Mount & Blade II: Bannerlord mod that lets you manage remote clan companions and adult family from Inventory and Character Developer, and manage troops of companion parties, caravans, and settlement garrisons from Clan > Parties.

**Nexus Mods URL:** <https://www.nexusmods.com/mountandblade2bannerlord/mods/14470>.

## Credit to the original

This is a **1.4.8 fix / continuation** of **[Manage Remote Companions](https://www.nexusmods.com/mountandblade2bannerlord/mods/698)** by **[RadthorDax](https://www.nexusmods.com/profile/RadthorDax?gameId=3174)**. Full credit to RadthorDax for the original mod.

The game module id remains `ManageRemoteCompanionsFix`. The GitHub repository is named **ManageRemoteCompanionsFixed**.

### What this fix changes

- Ports the idea to Bannerlord **1.4.8** with current APIs (`PartyScreenHelper`, MCM v5, UIExtenderEx 3).
- Replaces the old **experimental** behaviour (clicking a party opened troop management and blocked the right-panel UI) with a dedicated **Manage Troops** button beside the party name.
- Keeps remote **Manage Equipment** and **Character Upgrades** for companions and adult clan family.

## Features

| Feature | What it does |
|---|---|
| **Manage Equipment** | Adds remote living adult clan heroes and companions to Inventory so you can change their gear |
| **Character Upgrades** | Lets you spend focus, attributes, and perks for those remote heroes |
| **Manage Troops** | Clan > Parties button opens vanilla troop management for companion parties, caravans, and (optional) garrisons |

Regular non-hero soldiers do not get personal equipment screens. Manage Troops edits party **rosters** (add/remove troops), not per-soldier kits. Heroes cannot be transferred in that screen (vanilla rule).

## Mod options ([MCM][mcm])

**Options > Mod Options > Manage Remote Companions Fix**

| Setting | Default |
|---|---|
| Enabled | On |
| Character Upgrades | On |
| Manage Equipment | On |
| Enable Manage Troops | On |
| Manage Troops of Companion Parties | On |
| Manage Troops of Companion Caravans | On |
| Manage Settlement Garrisons | Off |

Turn **Manage Settlement Garrisons** on when you own a castle or town and want Clan > Parties > Garrisons > Manage Troops.

## Requirements and versions

| Dependency | Tested version | Expected to work with |
|---|---|---|
| Mount & Blade II: Bannerlord | 1.4.8 | 1.4.x and 1.5.x (not officially supported) |
| War Sails (NavalDLC), optional | 1.2.8 | 1.2.x |
| [Harmony][harmony] | 2.4.2 | 2.x |
| [UIExtenderEx][uiextenderex] | 3.0.3 | 3.x |
| [Mod Configuration Menu v5 (MCM)][mcm] | 5.13.1 | 5.x |

**Tested and works with Bannerlord 1.4.8.** Expected to work with **1.4.x** and **1.5.x**, but those are **not officially supported**.

This mod needs [Harmony][harmony], [UIExtenderEx][uiextenderex], and [MCM][mcm] directly. [MCM][mcm] also needs [ButterLib][butterlib] in a normal install.

War Sails is not required. With War Sails, the Clan Parties button still targets the shared `HeroNameParent` row. Fleet management stays in the Port UI and is out of scope.

## Compatibility

- **Vanilla and War Sails.** No XML troop or settlement overwrites.
- **Other companion / inventory / party-screen mods** may conflict if they patch the same inventory or character-developer methods, or insert into the same Clan Parties prefab node.
- Safe to add to an existing campaign. The mod does not add custom save data.

## Installation

1. Install [Harmony][harmony], [ButterLib][butterlib], [UIExtenderEx][uiextenderex], and [MCM][mcm].
2. Extract the `ManageRemoteCompanionsFix` folder into `Mount & Blade II Bannerlord\Modules`.
3. In the launcher, enable **Manage Remote Companions Fix** after Harmony, UIExtenderEx, and MCM.

## Building from source

The repository contains source code. TaleWorlds, Harmony, UIExtenderEx, and MCM DLLs are referenced from your game install and are not committed.

Requirements:

- Windows with .NET Framework 4.7.2 or later.
- Visual Studio 2019+, Build Tools, or the .NET Framework MSBuild.
- Bannerlord with Harmony, UIExtenderEx, and MCM installed.

The code is limited to C# 5 so it builds with the .NET Framework compiler.

### Point the build at your game

- Copy `ManageRemoteCompanionsFix.user.props.example` to `ManageRemoteCompanionsFix.user.props` and set `BannerlordDir` (git ignores that file).
- Or set `BANNERLORD_DIR`.
- Or pass `/p:BannerlordDir="..."` to MSBuild.

Default Steam path if none is set: `C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord`.

### Build

```bat
build.cmd
```

DLL output: `bin\Win64_Shipping_Client\ManageRemoteCompanionsFix.dll`.

To copy into the game `Modules\ManageRemoteCompanionsFix` folder after build:

```bat
build.cmd /p:DeployToGame=true
```

Close the game first if the DLL is locked.

## Repository layout

```
ManageRemoteCompanionsFix.csproj
ManageRemoteCompanionsFix.user.props.example
build.cmd
SubModule.xml
src/
NOTICE
LICENSE
CHANGELOG.md
README.md
```

## Credit

Copyright (C) 2026 AtanuDebbarma.

Based on **[Manage Remote Companions](https://www.nexusmods.com/mountandblade2bannerlord/mods/698)** by **[RadthorDax](https://www.nexusmods.com/profile/RadthorDax?gameId=3174)**

Manage Remote Companions Fix is free software under the [GNU General Public License v3.0](LICENSE), with attribution terms in [NOTICE](NOTICE).

Mount & Blade II: Bannerlord is a trademark of TaleWorlds Entertainment. This project is not affiliated with or endorsed by TaleWorlds.

[mcm]: https://www.nexusmods.com/mountandblade2bannerlord/mods/612
[butterlib]: https://www.nexusmods.com/mountandblade2bannerlord/mods/2018?tab=description
[harmony]: https://www.nexusmods.com/mountandblade2bannerlord/mods/2006?tab=description
[uiextenderex]: https://www.nexusmods.com/mountandblade2bannerlord/mods/2102?tab=description
[repo]: https://github.com/AtanuDebbarma/ManageRemoteCompanionsFixed
