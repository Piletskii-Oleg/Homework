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

struct node* create_reverse(struct node* head)
{
    if (head == NULL)
        return NULL;

    struct node* newHead = (struct node*)malloc(sizeof(struct node));
    struct node* Head = newHead;

    struct node* headCopy = head;
    int storage = 0;

    while (head->next != NULL)
    {
        head = head->next;
        storage++;
    }
    newHead->next = head;
    newHead->value = head->value;
    head = headCopy;

    while (storage != 0)
    {
        head = headCopy;
        for (int i = storage; i > 1; i--)
        {
            head = head->next;
        }
        struct node* newNode = (struct node*)malloc(sizeof(struct node));
        newNode->value = head->value;
        newNode->next = NULL;

        newHead->next = newNode;
        newHead = newHead->next;
        storage--;
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
    struct node* head = create_node();
    printf("\n");

    struct node* reverse = create_reverse(head);
    print_elements(reverse);
}
