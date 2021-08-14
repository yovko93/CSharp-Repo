using System;
using System.Collections.Generic;
using System.Text;

namespace HAD.Entities.Items
{
    public class RecipeItem : BaseItem
    {
        private List<CommonItem> requiredItems;

        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, params string[] items) 
             : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {

        }
    }
}
