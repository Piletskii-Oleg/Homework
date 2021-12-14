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

struct node* merge(struct node* headOne, struct node* headTwo)
{
    struct node* head;
    struct node* Head;

    if (headOne == NULL && headTwo == NULL)
        return NULL;
    else if (headOne == NULL)
        return headTwo;
    else if (headTwo == NULL)
        return headOne;

    if (headOne->value <= headTwo->value)
    {
        head = headOne;
        headOne = headOne->next;
        Head = head;
    }
    else
    {
        head = headTwo;
        headTwo = headTwo->next;
        Head = head;
    }

    while (headOne != NULL && headTwo != NULL)
    {
        if (headOne->value <= headTwo->value)
        {
            head->next = headOne;
            head = headOne;
            headOne = headOne->next;
        }
        else
        {
            head->next = headTwo;
            head = headTwo;
            headTwo = headTwo->next;
        }
    }

    while (headOne != NULL)
    {
        head->next = headOne;
        head = headOne;
        headOne = headOne->next;
    }

    while (headTwo != NULL)
    {
        head->next = headTwo;
        head = headTwo;
        headTwo = headTwo->next;
    }
    return Head;
}

void print_elements(struct node* head)
{
    while (head != NULL)
    {
        printf("%d\n", head->value);
        head = head->next;
    }
}

void add_last(struct node** headRef, int d)
{
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));

    struct node* last = *headRef;
    newNode->next = NULL;
    newNode->value = d;

    if (*headRef == NULL)
    {
        *headRef = newNode;
        return;
    }
    while (last->next != NULL)
        last = last->next;

    last->next = newNode;
}

struct node* create_node()
{
    int value = 1;
    struct node* head = NULL;

    printf("10 is the last element of the List\n");
    while (value != 10)
    {
        scanf("%d", &value);
        add_last(&head, value);
    }

    return head;
}

int main()
{
    struct node* head1 = NULL;
    struct node* head2 = NULL;

    struct node* head = merge(head1, head2);
    print_elements(head);
}
