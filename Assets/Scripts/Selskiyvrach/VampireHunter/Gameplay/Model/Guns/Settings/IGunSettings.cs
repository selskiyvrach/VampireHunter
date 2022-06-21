﻿namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    public interface IGunSettings 
    {
        float Damage { get; }
        IRecoilSettings RecoilSettings { get; }
        IAimingSettings AimingSettings { get; }
        IMagazineSettings MagazineSettings { get; }
    }
}