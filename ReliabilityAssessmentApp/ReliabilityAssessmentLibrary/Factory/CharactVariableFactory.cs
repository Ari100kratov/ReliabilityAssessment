using ReliabilityAssessmentLibrary.Model;
using System;

namespace ReliabilityAssessmentLibrary.Factory
{
    /// <summary>
    /// Фабрика создания модели характеристик
    /// </summary>
    public class CharactVariableFactory : ICharactVariableFactory
    {
        /// <summary>
        /// Создать модель характеристик случ. величины
        /// </summary>
        /// <param name="mathExpectation">Оценка математического ожиданя</param>
        /// <param name="dispersion">Оценка дисперсии</param>
        public CharactVariable Create(double mathExpectation, double dispersion)
        {
            if (mathExpectation == 0)
                throw new ArgumentOutOfRangeException(nameof(mathExpectation), "Can't be 0");

            var squareDeviation = Math.Sqrt(dispersion);
            var coeffVariation = squareDeviation / mathExpectation;

            var charactVariable = new CharactVariable
            {
                MathExpectation = mathExpectation,
                Dispersion = dispersion,
                SquareDeviation = squareDeviation,
                CoeffVariation = coeffVariation
            };

            return charactVariable;
        }
    }
}
