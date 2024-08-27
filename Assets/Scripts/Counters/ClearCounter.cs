using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // Pick and drop object
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject here
            if (player.HasKitchenObject())
            { 
                // "Drop" the kitchen object to this clear counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else
            {
                // Player not carrying anything
            }
        }
        else
        {
            // There is a KitchenObject
            if (player.HasKitchenObject())
            {
                // player is carrying something

                if(player.GetKitchenObject() is PlateKitchenObject)
                {
                    // Player is holding a Plate
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
            } else
            {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
