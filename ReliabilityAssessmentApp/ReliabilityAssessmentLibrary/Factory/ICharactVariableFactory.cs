using ReliabilityAssessmentLibrary.Model;

namespace ReliabilityAssessmentLibrary.Factory
{
    /// <summary>
    /// Интерфейс фабрики создания модели характеристик
    /// </summary>
    public interface ICharactVariableFactory
    {
        /// <summary>
        /// Создать модель характеристик случ. величины
        /// </summary>
        /// <param name="mathExpectation">Оценка математического ожиданя</param>
        /// <param name="dispersion">Оценка дисперсии</param>
        CharactVariable Create(double mathExpectation, double dispersion);
    }
}
