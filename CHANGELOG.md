# Changelog

## 1.0.0

First release of **Manage Remote Companions Fix** for Bannerlord 1.4.8.

Based on [Manage Remote Companions](https://www.nexusmods.com/mountandblade2bannerlord/mods/698) by [RadthorDax](https://www.nexusmods.com/profile/RadthorDax?gameId=3174).

- Remote companion and adult clan family equipment in the Inventory screen (MCM: Manage Equipment).
- Remote character upgrades for companions and adult clan family (MCM: Character Upgrades).
- **Manage Troops** button on Clan > Parties for companion parties, caravans, and (when enabled) settlement garrisons. Uses vanilla `PartyScreenHelper.OpenScreenAsManageTroops`. Selecting a party no longer opens the troop screen, so wages, Change Leader, and party stats stay usable.
- MCM page under **Manage Remote Companions Fix**, with separate toggles for parties, caravans, and garrisons. Manage Settlement Garrisons starts off.
- UIExtenderEx prefab insert targets `HeroNameParent` so SandBox and War Sails (NavalDLC) Clan Parties right panels both match.
- Tested and works with Bannerlord **1.4.8**. Expected to work with **1.4.x** and **1.5.x** (not officially supported).
