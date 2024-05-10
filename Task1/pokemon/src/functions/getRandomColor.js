const getRandomColor = () => {
    // Массив доступных цветов
    const colors = ['rgba(255, 192, 203, 0.7)', 'rgba(255, 165, 0, 0.7)', 'rgba(0, 128, 0, 0.7)',
        'rgba(255, 0, 0, 0.7)', 'rgba(255, 132, 80, 0.7)', 'rgba(97, 75, 0, 0.7)', 'rgba(154, 0, 102, 0.7)'];

    // Случайным образом выбираем цвет из массива
    const randomIndex = Math.floor(Math.random() * colors.length);

    // Возвращаем выбранный цвет
    return colors[randomIndex];
}
export default getRandomColor