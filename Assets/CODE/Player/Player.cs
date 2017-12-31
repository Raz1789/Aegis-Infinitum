using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static float health, maxHealth, speed;
    public static float damageMultiplier = 1f, healMultiplier = 1f, speedMultiplier = 1f;

    public static void Damage(float damage) {
        health -= (damage * damageMultiplier);   // Need to add damage calculations
        if (health <= 0f) {
            Kill();
        }
    }

    public static void Heal(float heal) {
        health += (heal * healMultiplier);  // Need to add healing calculations
        if (health > maxHealth) {
            heal = maxHealth;
        }
    }

    public static void Kill() {
        // Do something once dead
    }
}
