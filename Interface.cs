using System;

namespace ov
{
    public interface IEenmaligeOvKaart
    {
        OvKaartType Type { get; }
        OvKaartStatus Status { get; }

        bool Inchecken();
        bool Uitchecken(decimal? standaardTerief);

    }

    public interface IOvKaart
    {
        OvKaartType Type { get; }
        decimal Balans { get; }
        OvKaartStatus Status { get; }

        void StortOpBalans(decimal bedrag);
        bool Inchecken();
        bool Uitchecken(decimal? standaardTerief);
    }

}