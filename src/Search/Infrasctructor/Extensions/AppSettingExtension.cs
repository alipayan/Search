﻿namespace Search.Infrasctructor.Extensions;

public static class AppSettingExtentions
{
    public static void BindAppSettings(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(builder.Configuration);
    }
}
