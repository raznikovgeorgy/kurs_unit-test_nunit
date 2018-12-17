namespace ClassLib
{
    /// <summary>
    /// Интерфейс вектора
    /// </summary>
    public interface IVector
    {
        /// <summary>
        /// Добавляет значение в "вектор"
        /// </summary>
        /// <param name="value">Значение которое нужно добавить в "вектор"</param>
        void PushBack(int value);

        /// <summary>
        /// Удаляет последний элемент
        /// </summary>
        void PopBack();
    }
}