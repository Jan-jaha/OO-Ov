using System;
using ov.Enums;
using ov.Interfaces;

namespace ov
{
    public abstract class OvKaartBase : IOvKaart
    {
        public OvKaartType Type { get; private set; }
        public decimal Balans { get; private set; }
        public OvKaartStatus Status { get; private set; }

        public decimal KortingFactor { get; private set; }
        public decimal KortingPercentage { get; private set; }

        public StortOpBalans(decimal bedracht)
        {
            if (bedracht > 0)
            {
                Balans += bedracht;
            }
            else
            {
                throw new ArgumentException("Bedrag moet groter zijn dan 0");
            }
        }

        public abstract bool Inchecken();

        public abstract bool Uitchecken(decimal? standaardTarief);

     
           
    }

    public class KortingOvKaart : OvKaartBase
    {
        public KortingsOVKaart()
        {
            Type = OvKaartType.Kortings;
            KortingsFactor = 0.6m; // bijvoorbeeld 40% korting → klant betaalt 60%
            KortingsPercentage = 0.4m;
            Status = OvKaartStatus.NietIngecheckt;
        }

        public override bool Inchecken()
        {
            if (Status == OvKaartStatus.In)
            {
                throw new InvalidOperationException("Kaart is al ingecheckt");
            }
            else
            {
                throw new InvalidOperationException("U bent ingecheckt");
            }
            Status = OvKaartStatus.In;
            return true;
        }

        public override bool Uitchecken(decimal? standaardTarief)
        {
            if (Status == OvKaartStatus.in)
            {
                if (Balans >= standaardTarief * KortingFactor)
                {
                    Balans -= standaardTarief * KortingFactor;
                    Status = OvKaartStatus.Uit;
                    throw new InvalidOperationException("U bent uitgecheckt");
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Saldo is te laag om uit te checken");
                    return false;
                }

            }

        }
    }
}