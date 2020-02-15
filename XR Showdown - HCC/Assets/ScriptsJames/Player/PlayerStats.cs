using UnityEngine;

namespace Stats
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Main Player Stats")]
        public string player_name;
        
        private int player_health;
        
        public int Player_health { get => player_health; set => player_health = value; }

        public void SetPlayerHealth(int mod)
        {
            Player_health = mod;
        }

        public void ModifyPlayerHealth(int mod)
        {
            Player_health += mod;
            if (Player_health < 0) Player_health = 0;
            if (Player_health > 10) Player_health = 10;
        }
    }
}