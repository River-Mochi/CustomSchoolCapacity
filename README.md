# [ASC] Adjust School Capacity is a mod for *Cities Skylines II*


## Overview

**Adjust School Capacity [ASC]** lets you change how many students each school building can handle

- Tweak capacity for **elementary**, **high school**, **college**, and **university**.
- Use simple sliders from **10% to 500%** of the vanilla capacity.
- One click to reset to **vanilla 100%**, or to **ASC starter defaults**.

---

## Features

| Feature | Description |
|--------|-------------|
| Custom capacity sliders | Set each school level between **10% and 500%** of the vanilla capacity. |
| Reset to Vanilla | Brings every slider back to **100%**, exactly matching the base game. |
| Reset to ASC Defaults | Applies the ASC starter preset: **Elementary 200%**, **High School 150%**, **College 120%**, **University 120%**. |
| Works with extensions | Capacity scaling applies to main school buildings and their extension upgrades. |

---

## How it works

When you load a city:

1. The mod scans all school-related prefabs (main buildings and their extensions).
2. It records the **vanilla baseline** capacity for each education level.
3. It applies your chosen percentage to that baseline:
   - 100% = vanilla capacity  
   - 200% = double the vanilla capacity, and so on
4. New schools you place later automatically use the same multiplier for their level.

If you press **Reset to Vanilla**, all sliders return to 100% and capacity goes back to the normal game values.  
If you press **Reset to ASC Defaults**, sliders jump to **200 / 150 / 120 / 120** for a “fewer buildings, more students” playstyle.

---

## Localization

Current languages:

- English (en-US)
- Spanish (es-ES)
- French (fr-FR)
- German (de-DE)
- Italian (it-IT)
- Japanese (ja-JP)
- Korean (ko-KR)
- Simplified Chinese (zh-HANS)
- Traditional Chinese (zh-HANT)

---

## Compatibility

- Updated for game version 1.3.6* and Bridges DLC. 
- Safe to remove at any time 
- This mod does not use Reflection or Harmony; safe/compatible, less likely to break with game updates.
- Remove any other school capacity mods to avoid conflicts. 
- Plays nicely with other mods as long as they do not also rewrite `SchoolData` capacity for the same entities. 

---

## Technical Notes

- Settings are stored under `ModsSettings/AdjustSchoolCapacity/AdjustSchoolCapacity`.
- Safe to make changes between sessions (it only manipulates capacity values when the city loads or when settings change).
- This mod only changes **capacity**. Upkeep and fees still follow the vanilla game logic.

---

## Feedback

Bugs, ideas, or feedback:

- GitHub: [AdjustSchoolCapacity repo](https://github.com/River-Mochi/AdjustSchoolCapacity)
- Discord Cities Skylines Modding: `https://discord.gg/HTav7ARPs2`
- Paradox Mods: [Download Here](https://mods.paradoxplaza.com/uploaded?orderBy=desc&sortBy=best&time=alltime)

---

Enjoy having fewer school buildings and more educated cims with **[ASC] Adjust School Capacity**.
