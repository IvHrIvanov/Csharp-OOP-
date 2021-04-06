﻿using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {

        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        protected Car(string model, int horsePower, double cubicCentimeters,int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length<4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }
        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            private set
            {
                if (minHorsePower <= value && value <= maxHorsePower)
                {
                    horsePower = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                
            }
        }
        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = (CubicCentimeters / horsePower) * laps;
            return racePoints;
        }
    }
}
