void swap(int* array, int i, int k)
{
    int temp;
    temp = array[i];
    array[i] = array[k];
    array[k] = temp;
}

int partition(int* array, int low, int high)
{
    int x = array[high];
    int j = low;

    for (int i = low; i < high; i++)
    {
        if (array[i] <= x)
        {
            swap(array, i, j);
            j++;
        }
    }

    swap(array, j, high);
    return j;
}

void quickSort(int* array, int low, int high) //разбиение Ломуто
{
    if (low < high)
    {
        int j = partition(array, low, high);
        quickSort(array, low, j - 1);
        quickSort(array, j + 1, high);
    }
}