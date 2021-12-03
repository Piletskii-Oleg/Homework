int maxElement(int array[], int n)
{
    int max = array[0];
    for (int i = 1; i < n; i++)
    {
        if (max < array[i])
            max = array[i];
    }
    return max;
}

void radixSort(int* array, int n)
{
    int helper[10][50];
    int helperCount[10];
    int maximum = maxElement(array, n); //максимальное число в массиве
    int divisor = 1; //определяет разряд
    int currentNumber, arrayElement;

    while (maximum > 0)
    {
        maximum = maximum / 10;

        //заполняем массив, определяющий, сколько элементов уже соответствуют цифре
        for (int i = 0; i < 10; i++)
            helperCount[i] = 0;

        //распределительный проход
        for (int i = 0; i < 50; i++)
        {
            currentNumber = (array[i] / divisor) % 10; //определяем нужную нам цифру
            helper[currentNumber][helperCount[currentNumber]] = array[i]; //вставляем ее на нужное место в массиве
            helperCount[currentNumber]++; //увеличиваем значение массива-помощника в соответствующей цифре
        }

        arrayElement = 0; //нужен нам, чтобы определять номер элемента в изначальном массиве
        //собирательный проход
        for (int j = 0; j < 10; j++)
        {
            for (int k = 0; k < helperCount[j]; k++)
            {
                array[arrayElement] = helper[j][k];
                arrayElement++;
            }
        }
        divisor *= 10; //увеличиваем разряд на 1
    }
}
