void insertion_sort(int* array, int n)
{
    int temp;
    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (array[i] < array[j])
            {
                temp = array[i];
                for (int k = i; k > j; k--)
                    array[k] = array[k - 1];
                array[j] = temp;
                break;
            }
        }
    }
}