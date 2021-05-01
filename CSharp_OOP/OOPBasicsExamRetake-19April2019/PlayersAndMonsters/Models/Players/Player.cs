﻿using System;

using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System.Collections.Generic;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private readonly ICardRepository cardRepository;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.cardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository
            => this.cardRepository;

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //TODO whitespace at the end
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                this.health = value;
            }
        }

        public bool IsDead
            => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.Health - damagePoints < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }

        }
    }
}
