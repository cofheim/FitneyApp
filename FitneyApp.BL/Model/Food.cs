using System;

namespace FitneyApp.BL.Model
{
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }

        #region Ценность за 100 грамм

        /// <summary>
        /// Белки за 100 грамм продукта
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры за 100 грамм продукта
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы за 100 грамм продукта
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; }
        #endregion
        #region Ценность за 1 грамм

        /// <summary>
        /// Калории за 1 грамм продукта
        /// </summary>
        private double CaloriesOneGramm { get { return Calories / 100.0; } }
        /// <summary>
        /// Белки за 1 грамм продукта
        /// </summary>
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        /// <summary>
        /// Жиры за 1 грамм продукта
        /// </summary>
        private double FatsOneGramm { get { return Fats / 100.0; } }
        /// <summary>
        /// Углеводы за 1 грамм продукта
        /// </summary>
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        #endregion
        #endregion

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO: проверка

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
