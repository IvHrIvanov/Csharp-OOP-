﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int healtPotionWeight = 5;
        private const int healPotion = 20;
        private const string healtPotion = "HealtPotion";
        public HealthPotion()
            : base(healtPotionWeight, healtPotion)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += healPotion;
            if (character.Health >= character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
