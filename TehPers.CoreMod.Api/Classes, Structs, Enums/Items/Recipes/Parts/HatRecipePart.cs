﻿using System;
using StardewValley;
using StardewValley.Objects;
using TehPers.CoreMod.Api.Drawing.Sprites;

namespace TehPers.CoreMod.Api.Items.Recipes.Parts {
    public class HatRecipePart : IRecipePart {
        private readonly int _index;

        public int Quantity { get; }
        public ISprite Sprite { get; }

        public HatRecipePart(ICoreApi coreApi, int index, int quantity = 1) {
            this._index = index;
            this.Quantity = quantity;
            this.Sprite = coreApi.Drawing.HatSpriteSheet.TryGetSprite(index, FacingDirection.DOWN, out ISprite sprite) ? sprite : throw new ArgumentOutOfRangeException(nameof(index));
        }

        public bool Matches(Item item) {
            return item is Hat hat && hat.ParentSheetIndex == this._index;
        }

        public string GetDisplayName() {
            return new Hat(this._index).DisplayName;
        }

        public bool TryCreateOne(out Item result) {
            result = new Hat(this._index);
            return true;
        }
    }
}