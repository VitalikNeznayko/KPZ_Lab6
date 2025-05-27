using System;

namespace RecipeBookApp.Services
{
    public static class RecipeValidator
    {
        public static bool Validate(
            string name,
            string description,
            string cookingTimeText,
            string category,
            string totalCaloriesText,
            string instructions,
            out int cookingTime,
            out int totalCalories,
            out string errorMessage)
        {
            cookingTime = 0;
            totalCalories = 0;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Будь ласка, введіть назву рецепту.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                errorMessage = "Будь ласка, введіть опис рецепту.";
                return false;
            }

            if (!int.TryParse(cookingTimeText, out cookingTime) || cookingTime <= 0)
            {
                errorMessage = "Час приготування повинен бути додатнім цілим числом.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                errorMessage = "Будь ласка, введіть категорію рецепту.";
                return false;
            }

            if (!int.TryParse(totalCaloriesText, out totalCalories) || totalCalories <= 0)
            {
                errorMessage = "Загальна калорійність повинна бути додатнім цілим числом.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(instructions))
            {
                errorMessage = "Будь ласка, введіть інструкції з приготування.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
