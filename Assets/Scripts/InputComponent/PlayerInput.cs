using UnityEngine;

namespace InputComponent
{
   public class PlayerInput : IPlayerInput
   {

      public Vector2 GetMoveDirection()
      {
         return new Vector2(Input.GetAxis("Horizontal"),0);
      }
      
   }

   public interface IPlayerInput
   {
      public Vector2 GetMoveDirection();
   }
}
