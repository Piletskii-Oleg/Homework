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

void print_elements(struct node* head)
{
    struct node* p = head;
    while (p != NULL)
    {
        printf("%d ", p->value);
        p = p->next;
    }
}

struct node* create_list()
{
    struct node* head = (struct node*)malloc(sizeof(struct node));
    head->value = 2;
    struct node* Head = head;
    for (int i = 3; i <= 1000; i++)
    {
        struct node* newNode = (struct node*)malloc(sizeof(struct node));
        head->next = newNode;
        newNode->value = i;
        head = head->next;
    }
    head->next = NULL;
    return Head;
}

void delete_element(struct node** headRef)
{
    struct node* toDelete;
    toDelete = (*headRef)->next;
    (*headRef)->next = (*headRef)->next->next;
    free(toDelete);
}

void eratosphenes_sieve()
{
    struct node* head = create_list();
    struct node* Head = head;

    for (int i = 2; i < ; i++)
    {
        head = Head;
        while (head != NULL && head->next != NULL)
        {
            if (head->next->value != i && head->next->value % i == 0)
            {
                delete_element(&head);
            }
            head = head->next;
        }
    }
    print_elements(Head);
}

int main()
{
    eratosphenes_sieve();
}
