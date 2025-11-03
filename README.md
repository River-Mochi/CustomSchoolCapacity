# [CSC] Custom School Capacity

**Version:** 1.3.0  

---

## 📖 Overview
**[CSC] Custom School Capacity** lets you easily change the student capacity of all school buildings in *Cities: Skylines II*.

- Adjust elementary, high school, college, and university capacities individually.  
- Optionally scale building upkeep with capacity.  
- Instantly reset to vanilla values or the mod’s recommended balanced defaults.

---

## ⚙️ Features

| Feature | Description |
|----------|--------------|
| 🎚️ **Custom sliders** | Each school level can be set between **10 % and 500 %** of its vanilla capacity. |
| 💰 **Scale upkeep** | When enabled, building upkeep automatically scales by the same multiplier. |
| 🔁 **Reset to Vanilla** | Brings every slider back to **100 %**, exactly matching vanilla behavior. |
| 🎯 **Reset to CSC Defaults** | Applies balanced presets: **Elementary 200 %**, **High 130 %**, **College 120 %**, **University 120 %**. |

---

## 🧠 How it works
When the mod is loaded into a city:

1. The mod scans all existing school buildings.
2. It records each building’s **baseline** (original vanilla capacity and upkeep).
3. When you move a slider, the mod reapplies that multiplier to all schools of that type.
4. New schools built later automatically adopt the same multiplier.

At **100 %**, CSC leaves the building at its baseline — effectively identical to vanilla.

---

## 🌍 Localization
Languages currently included:
- English (en-US)
- Simplified Chinese (zh-HANS)
- French (fr-FR)
- Spanish (es-ES)

---

## 🧩 Compatibility
- Works with **game version 1.3.6 and later**.
- Pure C# implementation; **no Harmony** patches, **no reflection hooks** (safe and update-resistant).
- Fully compatible with other mods that do **not** modify `SchoolData` directly.

---

## 🧰 Technical Notes
- Uses official Colossal `ModSetting` and `IDictionarySource` APIs.
- Settings persist between sessions via the game’s `ModsSettings` system.
- Safe to enable or disable between sessions (settings file is isolated).

---

## 💬 Feedback
Report issues or suggestions on GitHub:  
👉 [Github Repo](https://github.com/River-Mochi/CustomSchoolCapacity)

---

*Enjoy smoother city education management with [CSC] Custom School Capacity!*
