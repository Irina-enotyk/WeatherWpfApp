namespace WeatherWpfApp.Models
{
    public enum WeatherCodes
    {
        ClearSky = 0,
        MainlyClear = 1,
        PartlyCloudy = 2,
        Overcast = 3,

        Fog = 45,
        DepositingRimeFog = 48,

        LightDrizzle = 51,
        ModerateDrizzle = 53,
        IntensityDrizzle = 55,
        LightFreezingDrizzle = 56,
        IntensityFreezingDrizzle = 57,

        SlightRain = 61,
        ModerateRain = 63,
        HeavyIntensityRain = 65,

        SlightSnowFall = 71,
        ModerateSnowFall = 73,
        HeavySnowFall = 75,
        SnowGrains = 77,

        SlightRainShowers = 80,
        ModerateRainShowers = 81,
        ViolentRainShowers = 82,

        SlightSnowShowers = 85,
        HeavySnowShowers = 86,

        Thunderstorm = 95,
        SlightThunderstormHail = 96,
        HeavyThunderstormHail = 99
    }
}
