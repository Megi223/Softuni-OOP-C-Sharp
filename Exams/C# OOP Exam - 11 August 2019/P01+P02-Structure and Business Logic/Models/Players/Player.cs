﻿using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepository;
        protected Player(string name,int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
        }
        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }

        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }
        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository => this.gunRepository;


        public void TakeLifePoints(int points)
        {
            this.LifePoints -= points;
        }
    }
}
