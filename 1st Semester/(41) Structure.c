#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct Car
{
    _Bool extra;
    char model[10];
    int price;
};

void initialization(struct Car* storage, int size)
{
    for (int i = 0; i < size; i++)
    {
        storage[i].extra = 0;
    }
}

void storageFilling(struct Car* storage, int size)
{
    for (int i = 0; i < size; i++)
    {
        if (storage[i].extra == 0)
        {
            printf("Car %d model name: ", i);
            scanf("%s", storage[i].model);

            printf("Car %d price: ", i);
            scanf("%d", &storage[i].price);

            printf("\n");
            storage[i].extra = 1;
        }
    }
}

void printInformation(struct Car* storage, int size)
{
    for (int i = 0; i < size; i++)
    {
        if (storage[i].extra != 0)
        {
             printf("Car %d model: %s\n", i, storage[i].model);
             printf("Car %d price: %d", i, storage[i].price);
        }
        printf("\n");
    }
}

void sellAuto(struct Car* storage, int size, int n)
{
    if (storage[n].extra == 0 || n >= size)
    {
        printf("There is no such car!");
    }
    else
    {
        storage[n].extra = 0;
        printf("Car number %d is sold!", n);
    }
}

int main()
{
    struct Car storage[10];
    int size = 10;

    int choice = 0;
    int carNumber;
    while (choice != -1)
    {
        printf("Choose function:\n-1.Exit\n1.Initialization\n2.Fill the storage\n3.Print the information\n4.Sell a car\n");
        scanf("%d", &choice);
        switch (choice)
        {
        case 1:
            initialization(&storage, size);
            break;
        case 2:
            storageFilling(&storage, size);
            break;
        case 3:
            printInformation(&storage, size);
            break;
        case 4:
            printf("Choose a car to sell: ");
            scanf("%d", &carNumber);
            sellAuto(&storage, size, carNumber);
            break;
        case -1:
            printf("Exiting the program...");
            break;
        }
    }
}
