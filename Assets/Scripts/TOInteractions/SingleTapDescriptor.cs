using System;

[Serializable]
public record SingleTapDescriptor
{
    public double Appearance;
    public double Disappearance;
    public double TapTime;
    public double UntapTime;

    public void Invalidate()
    {
        Appearance = -1;
        Disappearance = -1;
        TapTime = -1;
        UntapTime = -1;
    }

    public bool IsValidAppearance()
    {
        return Appearance > 0;
    }

    public bool IsValidDisappearance()
    {
        return Disappearance > 0;
    }

    public bool IsValidTapTime()
    {
        return TapTime > 0;
    }

    public bool IsValidUntapTime()
    {
        return UntapTime > 0;
    }

    public bool IsValidTimedObject()
    {
        return Appearance > 0 && Disappearance > 0 && Appearance < Disappearance;
    }

    public bool IsValidTap()
    {
        return TapTime > 0 && UntapTime > 0 && TapTime < UntapTime;
    }
}