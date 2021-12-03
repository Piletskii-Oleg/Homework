void merge(int array[], int low, int mid, int high)
{
    int iFirst, iSecond, i;
    int leftSize = mid - low + 1;
    int rightSize = high - mid;
    int* LeftArray = (int*)malloc(leftSize * sizeof(int));
    int* RightArray = (int*)malloc(rightSize * sizeof(int));

    for (iFirst = 0; iFirst < leftSize; iFirst++)
        LeftArray[iFirst] = array[low + iFirst];

    for (iSecond = 0; iSecond < rightSize; iSecond++)
        RightArray[iSecond] = array[mid + 1 + iSecond];

    iFirst = 0, iSecond = 0;
    i = low;
    while (iFirst < leftSize && iSecond < rightSize)
    {
        if (LeftArray[iFirst] <= RightArray[iSecond])
        {
            array[i] = LeftArray[iFirst];
            iFirst++;
        }
        else
        {
            array[i] = RightArray[iSecond];
            iSecond++;
        }
        i++;
    }

    while (iFirst < leftSize)
    {
        array[i] = LeftArray[iFirst];
        iFirst++;
        i++;
    }
    while (iSecond < rightSize)
    {
        array[i] = RightArray[iSecond];
        iSecond++;
        i++;
    }

    free(LeftArray);
    free(RightArray);
}

void mergeSort(int array[], int low, int high)
{
    int mid;
    if (low < high)
    {
        mid = (low + high) / 2;
        mergeSort(array, low, mid);
        mergeSort(array, mid + 1, high);
        merge(array, low, mid, high);
    }
    else
        return;
}