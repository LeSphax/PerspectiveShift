﻿internal class NormalTileEffectStrategy : ATileEffectStrategy
{

    public override void Init()
    {
        tileModel.SetState(TileController.State.FILLED);
    }
}

