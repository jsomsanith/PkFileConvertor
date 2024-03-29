﻿using System;

namespace PKHeX.Core;

[Flags]
public enum BinaryExportSetting
{
    None,
    IncludeFooter = 1 << 0,
    IncludeHeader = 1 << 1,
}

public static class BinaryExportSettingExtensions
{
    public static bool HasFlagFast(this BinaryExportSetting value, BinaryExportSetting setting) => (value & setting) != 0;
}
