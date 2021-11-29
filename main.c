#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct node
{
    int value;
    struct node* next;
};  

void first_element_condition(struct node* head, struct node* result)
{
    struct node* p = head;
    while (p != NULL)
    {
        if (p->value == 1)
        {
            result->value = p->value;
            result->next = p->next;
            break;
        }
    }
}

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
    struct Car* car = (struct Car*)malloc(sizeof(struct Car));

    for (int i = 0; i < size; i++)
    {
        if (storage[i].extra == 0)
        {
            printf("Car %d podel name: ", i);
            scanf("%s", &car->model);
            strcpy(storage[i].model, car->model);

            printf("Car %d price: ", i);
            scanf("%d", &car->price);
            storage[i].price = car->price;

            printf("\n");
            storage[i].extra = 1;
        }
    }
    free(car);
}

void printInformation(struct Car* storage, int size)
{
    struct Car* car = storage;
    for (int i = 0; i < size; i++)
    {
        if (storage[i].extra != 0)
        {
            if (storage[i].model != 0)
                printf("Car %d model: %s\n", i, storage[i].model);
            if (storage[i].price != 0)
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
    initialization(&storage, size);
    storageFilling(&storage, size);
    printInformation(&storage, size);
    sellAuto(&storage, 2, 1);
}

//int main()
//{
//    struct node *head;
//    struct node* one = malloc(sizeof(struct node));
//    struct node* two = malloc(sizeof(struct node));
//    struct node* three = malloc(sizeof(struct node));
//    struct node* four = malloc(sizeof(struct node));
//
//    one->value = 1;
//    two->value = 2;
//    three->value = 3;
//    four->value = 50;
//
//    one->next = two;
//    two->next = three;
//    three->next = four;
//    four->next = NULL;
//    head = one;
//
//    struct node result;
//
//    printf("%d", count_elements(head));
//}


